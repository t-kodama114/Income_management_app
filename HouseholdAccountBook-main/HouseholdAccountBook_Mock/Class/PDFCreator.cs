using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using HouseholdAccountBook_Mock.MBox;

namespace HouseholdAccountBook_Mock.Class
{
    /// <summary>
    /// PDFの管理オブジェクト（作成、複製、ページ追加など）
    /// 基本的にInit⇒Createの順番で処理を呼ぶ流れで（設定したいことはinitで出来るようにする）
    /// </summary>
    public class PDFCreator : Singleton<PDFCreator>
    {
        #region 定数

        /// <summary>
        /// PDF保存パス（一時的）
        /// </summary>
        private const string PDF_DIR = @"C:\Users\makia\OneDrive\ドキュメント\HouseholdAccountBook_Mock\HouseholdAccountBook_Mock\PDF";

        /// <summary>
        /// AcrobatReaderのパス
        /// </summary>
        private const string PDF_ACROBAT_READER = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe";

        #endregion

        #region プロパティ

        /// <summary>
        /// PDFファイル名
        /// </summary>
        private string FileName { get; set; }

        /// <summary>
        /// PDFのサイズ
        /// </summary>
        private Rectangle SizeRect { get; set; }

        /// <summary>
        /// PDFのフォント形式
        /// </summary>
        private BaseFont PdfFont { get; set; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// 一応作ったけどインスタンスから取得するので不要の可能性あり
        /// </summary>
        public PDFCreator() { }

        #endregion

        #region メソッド

        /// <summary>
        /// PDFのデフォルト設定（文字やフォント設定や線の描画方式など）
        /// </summary>
        public void Init(string fileName)
        {
            FileName = Path.Combine(PDF_DIR, DateTime.Now.ToString("yyyyMMdd_HHmmss_") + fileName);
            //サイズは固定
            SizeRect = PageSize.A4.Rotate();
            //フォントも設定
            PdfFont = BaseFont.CreateFont(@"c:\windows\fonts\msgothic.ttc,0", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        }

        /// <summary>
        /// PDF作成
        /// </summary>
        /// <param name="dayStr">作成指定日時</param>
        /// <param name="classificationStr">分類文字列</param>
        /// <param name="periodTypeStr">期間指定文字列</param>
        /// <param name="originTable">表のオリジナルデータ</param>
        public void Create(string dayStr, string classificationStr, string periodTypeStr, DataTable originTable, string imgDataStr)
        {
            try
            {
                var doc = new Document(SizeRect);
                var stream = new MemoryStream();
                //ファイルの出力先を設定
                var pw = PdfWriter.GetInstance(doc, stream);

                //ドキュメントを開く
                doc.Open();

                // A4 595x842 pt = 210x297 
                Paragraph prgTitle = new Paragraph();
                Font titleFont = new Font(PdfFont, 24, 1, BaseColor.BLACK);
                prgTitle.Alignment = Element.ALIGN_LEFT;
                prgTitle.Add(new Chunk(dayStr + "の統計確認データ", titleFont));
                doc.Add(prgTitle);

                Paragraph p = new Paragraph(new Chunk(new LineSeparator(0.0f, 100.0f, BaseColor.BLACK, Element.ALIGN_LEFT, 0.0f)));
                doc.Add(p);

                Paragraph prgCreateDate = new Paragraph();
                Font createDateFont = new Font(PdfFont, 11, 1, BaseColor.BLACK);
                prgCreateDate.Alignment = Element.ALIGN_LEFT;
                prgCreateDate.Add(new Chunk("作成日時： " + DateTime.Now.ToString(AppConst.DTP_DAY_TIMESTR) + " "
                    + DateTime.Now.ToShortTimeString(), createDateFont));
                doc.Add(prgCreateDate);
                doc.Add(new Chunk("\n", titleFont));

                Paragraph prgClassification = new Paragraph();
                Paragraph prgPeriodType = new Paragraph();
                Font classificationFont = new Font(PdfFont, 18, 1, BaseColor.BLACK);
                prgClassification.Alignment = Element.ALIGN_LEFT;
                prgClassification.Add(new Chunk("分類: " + classificationStr, createDateFont));
                doc.Add(prgClassification);
                prgPeriodType.Alignment = Element.ALIGN_LEFT;
                prgPeriodType.Add(new Chunk("期間種類: " + periodTypeStr, createDateFont));
                doc.Add(prgPeriodType);

                //グラフ画像を表示
                string fileName = GetImageFile(imgDataStr);
                if(fileName != null && !string.IsNullOrEmpty(fileName))
                {
                    Image image = Image.GetInstance(fileName);
                    image.ScalePercent(75.0f); // WindowsとPDFのサイズ共通化のため
                    image.Alignment = Element.ALIGN_CENTER;
                    doc.Add(image);
                    doc.Add(new Chunk("\n", titleFont));
                }

                //表を作成
                PdfPTable table = new PdfPTable(originTable.Columns.Count)
                {
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                Font fntColumnHeader = new Font(PdfFont, 18, 1, BaseColor.WHITE);
                for(int i = 0; i < originTable.Columns.Count; i++)
                {
                    PdfPCell cell = new PdfPCell
                    {
                        BackgroundColor = BaseColor.GRAY
                    };
                    cell.AddElement(new Chunk(originTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table.AddCell(cell);
                }

                Font fntRowHeader = new Font(PdfFont, 18, 1, BaseColor.BLACK);
                for (int i = 0; i < originTable.Rows.Count; i++)
                {
                    for(int j = 0; j < originTable.Columns.Count; j++)
                    {
                        PdfPCell cell = new PdfPCell
                        {
                            BackgroundColor = BaseColor.WHITE
                        };
                        cell.AddElement(new Chunk(originTable.Rows[i][j].ToString(), fntRowHeader));
                        table.AddCell(cell);
                    }
                }
                doc.Add(table);

                //ドキュメントを閉じる
                doc.Close();

                //PDF作成
                using (BinaryWriter w = new BinaryWriter(File.OpenWrite(FileName)))
                {
                    w.Write(stream.ToArray());
                }

                Console.WriteLine("See the " + FileName);
            }
            catch(Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.PDF_FAILURE_MESSAGE);
            }
            
        }

        /// <summary>
        /// AcrobatReader起動(ブラウザ起動)
        /// </summary>
        /// <param name="isAcrobatReader">AcrobatReaderがインストールされているかどうか</param>
        /// <param name="pdfName">PDFファイル名</param>
        public void Preview(bool isAcrobatReader, string pdfName)
        {
            try
            {
                string exeFile = "";
                ProcessStartInfo psi = new ProcessStartInfo();

                //AcrobatReaderがあるかどうか
                if (isAcrobatReader && File.Exists(PDF_ACROBAT_READER))
                {
                    OriginMBox.MBoxInfoOK(AppConst.PDF_DC_MESSAGE);
                    exeFile = PDF_ACROBAT_READER;
                    //コマンドライン引数を指定する
                    psi.Arguments = pdfName;
                }
                //ブラウザで開く
                else
                {
                    OriginMBox.MBoxInfoOK(AppConst.PDF_BROWSER_MESSAGE);
                    exeFile = pdfName;
                    psi.Arguments = "";
                }

                //起動するファイルのパスを指定する
                psi.FileName = exeFile;

                Process p = Process.Start(psi);
                p.WaitForExit();              // プロセスの終了を待つ
                int iExitCode = p.ExitCode;   // 終了コード
            }
            catch(Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.PDF_ERROR_MESSAGE);
            }
        }

        /// <summary>
        /// PDFファイル名取得
        /// </summary>
        /// <param name="dateStr">今日日付</param>
        /// <returns>PDFファイル名取得</returns>
        public static string GetPDFFile(string dateStr)
        {
            string fileName = "";
            try
            {
                var pdfFileList = Directory.GetFiles(PDF_DIR, dateStr + "*.pdf", SearchOption.TopDirectoryOnly).ToList();

                if (pdfFileList.Count == 0) return null;
                List<int> timeList = new List<int>();
                foreach(var file in pdfFileList)
                {
                    var strs = Path.GetFileNameWithoutExtension(file).Split('_');
                    if (!int.TryParse(strs[1], out int time)) continue;
                    timeList.Add(time);
                }
                var nowTime = timeList.Max();
                fileName = pdfFileList.Where(x => Path.GetFileName(x).Substring(0, 15) == dateStr + "_" + nowTime).FirstOrDefault();
            }
            catch(Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.PDF_FAILURE_MESSAGE2);
            }
            return fileName;
        }

        /// <summary>
        /// PNGファイル名取得
        /// </summary>
        /// <param name="dateStr">今日日付</param>
        /// <returns>PNGファイル名取得</returns>
        public static string GetImageFile(string dateStr)
        {
            string fileName = "";
            try
            {
                var pngFileList = Directory.GetFiles(AppConst.GRAPH_IMAGE_FILE_DIR, dateStr + "*pie.png", SearchOption.TopDirectoryOnly).ToList();

                if (pngFileList.Count == 0) return null;
                List<long> timeList = new List<long>();
                foreach (var file in pngFileList)
                {
                    var strs = Path.GetFileNameWithoutExtension(file).Split('_');
                    if (!long.TryParse(strs[0], out long time)) continue;
                    timeList.Add(time);
                }
                var nowTime = timeList.Max();
                fileName = pngFileList.Where(x => Path.GetFileName(x).Substring(0, 14) == nowTime.ToString()).FirstOrDefault();
            }
            catch (Exception e)
            {
                string s = e.Message;
                OriginMBox.MBoxErrorOK(AppConst.PNG_FAILURE_MESSAGE);
            }
            return fileName;
        }

        #endregion
    }
}
