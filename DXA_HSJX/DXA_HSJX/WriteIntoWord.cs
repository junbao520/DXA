
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXA_HSJX
{
    public class WriteIntoWord
    {
        ApplicationClass app = null;   //定义应用程序对象 
        Document doc = null;   //定义 word 文档对象
        Object missing = System.Reflection.Missing.Value; //定义空变量
        Object isReadOnly = false;

        //通过模板创建新文档
        public void CreateNewDocument(string filePath)
        {
            KillWinWordProcess();
            app = new ApplicationClass();
            app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            app.Visible = false;
            object missing = System.Reflection.Missing.Value;
            object templateName = filePath;
            doc = app.Documents.Open(ref templateName, ref missing,
              ref missing, ref missing, ref missing, ref missing, ref missing,
              ref missing, ref missing, ref missing, ref missing, ref missing,
              ref missing, ref missing, ref missing, ref missing);
        }

        // 向 word 文档写入数据 
        public void OpenDocument(string FilePath)
        {
            object filePath = FilePath;//文档路径
            app = new ApplicationClass(); //打开文档 
            doc = app.Documents.Open(ref filePath, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing);
            doc.Activate();//激活文档
        }

        /// <summary> 
        /// </summary> 
        ///<param name="parLableName">域标签</param> 
        /// <param name="parFillName">写入域中的内容</param> 
        /// 
        //打开word，将对应数据写入word里对应书签域
        public Bitmap[] WordtoImage(string filePath)
        {
            string tmpPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + Path.GetFileName(filePath) + ".tmp";
            File.Copy(filePath, tmpPath);

            List<Bitmap> imageLst = new List<Bitmap>();
            Microsoft.Office.Interop.Word.Application wordApplicationClass = new Microsoft.Office.Interop.Word.Application();
            wordApplicationClass.Visible = false;
            object missing = System.Reflection.Missing.Value;

            try
            {
                object filePathObject = tmpPath;

                Document document = wordApplicationClass.Documents.Open(ref filePathObject, ref missing,
                    false, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);

                bool finished = false;
                while (!finished)
                {
                    document.Content.CopyAsPicture();
                    System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
                    if (data.GetDataPresent(DataFormats.MetafilePict))
                    {
                        object obj = data.GetData(DataFormats.MetafilePict);
                        Metafile metafile = MetafileHelper.GetEnhMetafileOnClipboard(IntPtr.Zero);
                        Bitmap bm = new Bitmap(metafile.Width, metafile.Height);
                        using (Graphics g = Graphics.FromImage(bm))
                        {
                            g.Clear(Color.White);
                            g.DrawImage(metafile, 0, 0, bm.Width, bm.Height);
                        }
                        imageLst.Add(bm);
                        Clipboard.Clear();
                    }

                    object Next = WdGoToItem.wdGoToPage;
                    object First = WdGoToDirection.wdGoToFirst;
                    object startIndex = "1";
                    document.ActiveWindow.Selection.GoTo(ref Next, ref First, ref missing, ref startIndex);
                    Range start = document.ActiveWindow.Selection.Paragraphs[1].Range;
                    Range end = start.GoToNext(WdGoToItem.wdGoToPage);
                    finished = (start.Start == end.Start);
                    if (finished)
                    {
                        end.Start = document.Content.End;
                    }

                    object oStart = start.Start;
                    object oEnd = end.Start;
                    document.Range(ref oStart, ref oEnd).Delete(ref missing, ref missing);
                }

                ((_Document)document).Close(ref missing, ref missing, ref missing);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(document);

                return imageLst.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                wordApplicationClass.Quit(ref missing, ref missing, ref missing);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApplicationClass);
                File.Delete(tmpPath);
            }
        }
        public void WriteIntoDocument(string BookmarkName, string FillName)
        {
            object bookmarkName = BookmarkName;
            Bookmark bm = doc.Bookmarks.get_Item(ref bookmarkName);//返回书签 
            bm.Range.Text = FillName;//设置书签域的内容
        }

        public void WritePicIntoDocument(string BookmarkName, string picName)
        {
            if (string.IsNullOrWhiteSpace(picName))
            {
                return;
            }
            object bookmarkName = BookmarkName;
            Bookmark bm = doc.Bookmarks.get_Item(ref bookmarkName);//返回书签 
            //bm.Range.Text = FillName;//设置书签域的内容
            bm.Select();
            Selection sel = app.Selection;
            sel.InlineShapes.AddPicture(picName);
        }
        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="n"></param>
        public void AddRow(int n)
        {
            object miss = System.Reflection.Missing.Value;
            doc.Content.Tables[n].Rows.Add(ref miss);
        }


        /// <summary>
        /// 插入表格
        /// </summary>
        /// <param name="n"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public void InsertCellImage(int n, int row, int column, string imgPath, string title, string description)
        {
            object missing = System.Reflection.Missing.Value;

            if (!System.IO.File.Exists(imgPath))
            {
                return;
            }
            object linkToFile = false;
            object saveWithDocument = true;

            doc.Content.Tables[n].Cell(row, column).Select();

            app.Selection.TypeParagraph();//插入段落
            app.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            app.Selection.Range.Font.Size = 13;
            app.Selection.TypeText(title);
            app.Selection.Range.Font.Size = 13;
            app.Selection.InsertParagraphAfter();

            object range = app.Selection.Range;
            InlineShape shape = app.ActiveDocument.InlineShapes.AddPicture(imgPath, ref linkToFile, ref saveWithDocument, ref range);
            shape.ConvertToShape().WrapFormat.Type = WdWrapType.wdWrapTopBottom;
            app.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            object count = 0;
            object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
            app.Selection.MoveDown(ref WdLine, ref count, ref missing);//移动焦点
            app.Selection.TypeParagraph();//插入段落
            app.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            app.Selection.Range.Font.Size = 11;
            app.Selection.TypeText(description);
            app.Selection.Range.Font.Size = 11;
            app.Selection.InsertParagraphAfter();
        }

        /// <summary> 
        /// 保存并关闭 
        /// </summary> 
        /// <param name="parSaveDocPath">文档另存为的路径</param>
        /// 
        public void Save_CloseDocument(string SaveDocPath)
        {
            object savePath = SaveDocPath;  //文档另存为的路径 
            Object saveChanges = app.Options.BackgroundSave;//文档另存为 
            doc.SaveAs(ref savePath, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);
            doc.Close(ref saveChanges, ref missing, ref missing);//关闭文档
            app.Quit(ref missing, ref missing, ref missing);//关闭应用程序
        }

        public void Dispose()
        {
            KillWinWordProcess();
        }

        //杀掉winword.exe进程
        public void KillWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }
    }
    #region MetafileHelper
    /// <summary>
    /// MetafileHelper 用于从剪切板获取Metafile数据。
    /// </summary>
    internal class MetafileHelper
    {
        [DllImport("user32.dll")]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll")]
        static extern bool EmptyClipboard();
        [DllImport("user32.dll")]
        static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        [DllImport("user32.dll")]
        static extern IntPtr GetClipboardData(uint uFormat);
        [DllImport("user32.dll")]
        static extern bool IsClipboardFormatAvailable(uint uFormat);
        [DllImport("user32.dll")]
        static extern bool CloseClipboard();
        [DllImport("gdi32.dll")]
        static extern IntPtr CopyEnhMetaFile(IntPtr hemfSrc, IntPtr hNULL);
        [DllImport("gdi32.dll")]
        static extern IntPtr CopyEnhMetaFileA(IntPtr hemfSrc, string filename);
        [DllImport("gdi32.dll")]
        static extern bool DeleteEnhMetaFile(IntPtr hemf);

        // Metafile mf is set to a state that is not valid inside this function.
        public static bool PutEnhMetafileOnClipboard(IntPtr hWnd, Metafile mf)
        {
            bool bResult = false;
            IntPtr hEMF, hEMF2;
            hEMF = mf.GetHenhmetafile(); // invalidates mf
            if (!hEMF.Equals(new IntPtr(0)))
            {
                hEMF2 = CopyEnhMetaFile(hEMF, new IntPtr(0));
                if (!hEMF2.Equals(new IntPtr(0)))
                {
                    if (OpenClipboard(hWnd))
                    {
                        if (EmptyClipboard())
                        {
                            IntPtr hRes = SetClipboardData(14 /*CF_ENHMETAFILE*/, hEMF2);
                            bResult = hRes.Equals(hEMF2);
                            CloseClipboard();
                        }
                    }
                }
                DeleteEnhMetaFile(hEMF);
            }
            return bResult;
        }

        public static Metafile GetEnhMetafileOnClipboard(IntPtr hWnd)
        {
            if (OpenClipboard(hWnd))
            {
                uint format = 14/*CF_ENHMETAFILE*/;
                if (IsClipboardFormatAvailable(format))
                {
                    IntPtr hRes = GetClipboardData(format);

                    CloseClipboard();

                    if (!hRes.Equals(new IntPtr(0)))
                    {
                        IntPtr hEMF = CopyEnhMetaFile(hRes, new IntPtr(0));
                        Metafile mf = new Metafile(hEMF, true);
                        return mf;
                    }
                }
            }
            return null;
        }

        public static bool IsClipboardFormatAvailableENHMETAFILE(IntPtr hWnd)
        {
            if (OpenClipboard(hWnd))
            {
                uint format = 14/*CF_ENHMETAFILE*/;
                if (IsClipboardFormatAvailable(format))
                {
                    CloseClipboard();
                    return true;
                }
            }
            return false;
        }

        public static bool SaveMetafile(Metafile mf, string filename)
        {
            bool bResult = false;
            IntPtr hEMF, hEMF2;
            hEMF = mf.GetHenhmetafile(); // invalidates mf
            if (!hEMF.Equals(new IntPtr(0)))
            {
                //hEMF = CopyEnhMetaFile(hEMF, new IntPtr(0));
                hEMF2 = CopyEnhMetaFileA(hEMF, filename);
                DeleteEnhMetaFile(hEMF2);
                if (hEMF2 != IntPtr.Zero)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
    #endregion
}
