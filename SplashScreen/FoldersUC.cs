using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace SplashScreen
{
    public partial class FoldersUC : XtraUserControl
    {
        private TreeList Tree;
        public List<FileSystemInfo> CheckedFiles { get; set; }
        private string RootFolder { get; set; } = defaultFolder;
        private static string defaultFolder  = @"D:\Git";
        public List<string> CheckedProceduresFullPath
        {
            get
            {
                var paths = new List<string>();
                foreach (FileSystemInfo file in CheckedFiles)
                {
                    var dirPaths = file.FullName.Split('\\');
                    if (dirPaths.Length >= 4)
                    {
                        var partial = Path.Combine(dirPaths.Take(4).ToArray());
                        if (paths.Contains(partial))
                        {
                            continue;
                        }

                        paths.Add(partial);

                    }
                }

                return paths;
            }
        }

        public FoldersUC()
        {
            InitializeComponent();
        }

        private void KamaDBFoldersUC_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            CheckedFiles = new List<FileSystemInfo>();
            Tree = tlRecordingFolder;
            InitColumns();
            InitData();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            void OpenFolder(string folderOrFile)
            {
                
                ProcessStartInfo pinfo = new ProcessStartInfo(folderOrFile)
                {
                    UseShellExecute = true
                };
                Process.Start(pinfo);
            }

            hylRootFolder.HyperlinkClick += (s, e) => OpenFolder(RootFolder);
           KamaItemSelection.HyperlinkClick += (s, e) => OpenFolder(KamaItemSelection.Text);
      
            Tree.NodeChanged += (s, e) =>
            {
                if (e.ChangeType == NodeChangeTypeEnum.CheckedState && e.Node[treeListColumn3].ToString() == "File")
                {
                    if (e.Node[treeListColumn5] is FileSystemInfo fi)
                    {
                        if (e.Node.CheckState == CheckState.Checked)
                        {
                            CheckedFiles.Add(fi);
                        }
                        else
                        {
                            CheckedFiles.Remove(fi);
                        }
                    }
                }
            };

            Tree.BeforeExpand += treeList1_BeforeExpand;
            Tree.AfterExpand += treeList1_AfterExpand;
            Tree.AfterCollapse += treeList1_AfterCollapse;
            Tree.CalcNodeDragImageIndex += treeList1_CalcNodeDragImageIndex;
            Tree.DragDrop += treeList1_DragDrop;
            Tree.Click += (s, e) => KamaItemSelection.Text = (Tree.FocusedNode[treeListColumn5] as FileSystemInfo).FullName;

        }
        
        #region Procedures files Tree list

        void InitColumns()
        {
            treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();

            treeListColumn1.Caption = "FullName";
            treeListColumn1.FieldName = "FullName";

            treeListColumn2.Caption = "Name";
            treeListColumn2.FieldName = "Name";
            treeListColumn2.VisibleIndex = 0;
            treeListColumn2.Visible = true;

            treeListColumn3.Caption = "Type";
            treeListColumn3.FieldName = "Type";
            treeListColumn3.VisibleIndex = 1;
            treeListColumn3.Visible = true;
            treeListColumn4.AppearanceCell.Options.UseTextOptions = true;
            treeListColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            treeListColumn4.Caption = "Size(Bytes)";
            treeListColumn4.FieldName = "Size";
            treeListColumn4.VisibleIndex = 2;
            treeListColumn4.Visible = true;

            treeListColumn5.Caption = "treeListColumn5";
            treeListColumn5.FieldName = "Info";
            treeListColumn5.Name = "treeListColumn5";


            Tree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            treeListColumn1,
            treeListColumn2,
            treeListColumn3,
            treeListColumn4,
            treeListColumn5});
            Tree.BestFitColumns();
        }

        private void InitData()
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Loading Folder's Data");
            hylRootFolder.Text = $"Root Folder: {RootFolder}";
            Tree.BeginUnboundLoad();
            Tree.Nodes.Clear();
            InitFolders(RootFolder, null);
            Tree.EndUnboundLoad();
            splashScreenManager1.CloseWaitForm();
        }

        private void InitFolders(string path, TreeListNode pNode)
        {
            TreeListNode node;
            DirectoryInfo di;
            try
            {
                string[] root = Directory.GetDirectories(path);
                foreach (string s in root)
                {
                    try
                    {

                        di = new DirectoryInfo(s);

                        node = Tree.AppendNode(new object[] { s, di.Name, "Folder", GetDirectorySizeInMB(di), di }, pNode);
                        node.StateImageIndex = 0;
                        node.HasChildren = HasFiles(s);
                        if (node.HasChildren)
                            node.Tag = true;
                        InitFolders(s, node);
                    }
                    catch { }
                }
                InitFiles(path, pNode);
            }
            catch { }

        }
        private void InitFiles(string path, TreeListNode pNode)
        {
            TreeListNode node;
            FileInfo fi;
            try
            {
                string[] root = Directory.GetFiles(path);
                foreach (string s in root)
                {
                    fi = new FileInfo(s);
                    node = Tree.AppendNode(new object[] { s, fi.Name, "File", fi.Length, fi }, pNode);
                    node.StateImageIndex = 1;
                    node.HasChildren = false;
                }
            }
            catch { }
        }
        private bool HasFiles(string path)
        {
            string[] root = Directory.GetFiles(path);
            if (root.Length > 0) return true;
            root = Directory.GetDirectories(path);
            if (root.Length > 0) return true;
            return false;
        }

        private void treeList1_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            //if (e.Node.Tag != null)
            //{
            //    Cursor currentCursor = Cursor.Current;
            //    Cursor.Current = Cursors.WaitCursor;
            //    InitFolders(e.Node.GetDisplayText("FullName"), e.Node);
            //    e.Node.Tag = null;
            //    Cursor.Current = currentCursor;
            //}
        }

        private void treeList1_AfterExpand(object sender, NodeEventArgs e)
        {
            if (e.Node.StateImageIndex != 1) e.Node.StateImageIndex = 2;
        }

        private void treeList1_AfterCollapse(object sender, NodeEventArgs e)
        {
            if (e.Node.StateImageIndex != 1) e.Node.StateImageIndex = 0;
        }

        private void treeList1_CalcNodeDragImageIndex(object sender, CalcNodeDragImageIndexEventArgs e)
        {
            if (e.Node[treeListColumn3].ToString() == "Folder")
            {
                e.ImageIndex = 0;
            }
            if (e.Node[treeListColumn3].ToString() == "File")
            {
                if (e.Node.ParentNode == Tree.FocusedNode.ParentNode)
                {
                    e.ImageIndex = -1;
                    return;
                }
                if (e.ImageIndex == 0)
                    if (e.Node.Id > Tree.FocusedNode.Id)
                        e.ImageIndex = 2;
                    else
                        e.ImageIndex = 1;
            }
        }

        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            //TreeListNode draggedNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
            //TreeListNode tagretNode = Tree.ViewInfo.GetHitTest(Tree.PointToClient(new Point(e.X, e.Y))).Node;
            //if (tagretNode == null || draggedNode == null) return;
            //if (tagretNode[treeListColumn3].ToString() == "File")
            //{
            //    if (tagretNode.ParentNode != draggedNode.ParentNode)
            //        MoveInFolder(draggedNode, tagretNode.ParentNode);
            //}
            //else
            //{
            //    MoveInFolder(draggedNode, tagretNode);
            //}
            //e.Effect = DragDropEffects.None;
        }

        void MoveInFolder(TreeListNode sourceNode, TreeListNode destNode)
        {
            Tree.MoveNode(sourceNode, destNode);
            if (sourceNode == null) return;
            FileSystemInfo sourceInfo = sourceNode[treeListColumn5] as FileSystemInfo;
            string sourcePath = sourceInfo.FullName;

            string destPath;
            if (destNode == null)
                destPath = RootFolder + sourceInfo.Name;
            else
            {
                DirectoryInfo destInfo = destNode[treeListColumn5] as DirectoryInfo;
                destPath = destInfo.FullName + "\\" + sourceInfo.Name;
            }
            if (sourceInfo is DirectoryInfo)
                Directory.Move(sourcePath, destPath);
            else
                File.Move(sourcePath, destPath);
            sourceNode[treeListColumn5] = new DirectoryInfo(destPath);
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (sender is TreeList tl)

            {
                if (tl.FocusedNode[treeListColumn3].ToString() == "File")
                {
                    string fileName = (tl.FocusedNode[treeListColumn5] as FileSystemInfo).FullName;
                    ProcessStartInfo pinfo = new ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    Process.Start(pinfo);


                }
            }
        }
        #endregion

        public void SetRootFolder(string folder)
        {
       
            if (Directory.Exists(folder))
            {
                RootFolder = folder;
                InitData();
            }

        }

        public void SetDefaultFolder()
        {
            if (Directory.Exists(defaultFolder))
            {
                SetRootFolder(defaultFolder);
            }
        }

        public void ClearSelection() => CheckedFiles.Clear();

        public static double GetDirectorySizeInMB(DirectoryInfo directoryInfo, bool recursive = true)
        {
            var startDirectorySize = default(double);
            if (directoryInfo == null || !directoryInfo.Exists)
                return startDirectorySize; //Return 0 while Directory does not exist.
            try
            {
                //Add size of files in the Current Directory to main size.
                foreach (var fileInfo in directoryInfo.GetFiles())
                    startDirectorySize += fileInfo.Length;

                if (recursive) //Loop on Sub Directories in the Current Directory and Calculate it's files size.
                {
                    foreach (var dir in directoryInfo.GetDirectories())
                    {
                        startDirectorySize += GetDirectorySizeInMB(dir, true);
                    }
                }

                return Math.Round(startDirectorySize / 1024.0 / 1024.0, 2);  //Return full Size of this Directory.
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
