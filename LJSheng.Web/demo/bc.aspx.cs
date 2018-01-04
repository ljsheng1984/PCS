using LJSheng.Common;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LJSheng.Web.demo
{
    public partial class bc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void daoru_Click(object sender, EventArgs e)
        {
            if (file.PostedFile.InputStream.Length < 1 || file.PostedFile.FileName.ToLower().IndexOf("xls") == -1)
            {
                JS.Alert("表格在哪里?",this);
                return;
            }
            Stream UpLoadStream = file.PostedFile.InputStream;
            int r = 1;//表格的行数
            int newsp = 0;//新的数据
            int oldsp = 0;//更新的数据
            int oldspall = 0;//重复的数据
            StringBuilder sb = new StringBuilder();//失败的数据行记录
            int FileLen = file.PostedFile.ContentLength;//获取上传文件的大小
            byte[] input = new byte[FileLen];
            UpLoadStream.Read(input, 0, FileLen);
            UpLoadStream.Position = 0;
            IWorkbook book = WorkbookFactory.Create(UpLoadStream);
            //遍历工作区
            for (int s = 0; s < 1; s++)
            {
                r = 1;//初始化第一行
                ISheet sheet = book.GetSheetAt(s);
                if (sheet.LastRowNum == 0)
                {
                    JS.Alert("数据去哪儿了?", this);
                    return;
                }
                var headerRow = sheet.GetRow(0);
                var rowCount = sheet.LastRowNum;
                var cellCount = headerRow.LastCellNum;
                try
                {
                    StringBuilder tb = new StringBuilder("[table="+kuan.Value+"][tr=#808080][td]海燕ID[/td][td]楼层[/td][td=30,0][align=center]抽奖编号[/align][/td][/tr]");
                    //表数据列表跳过第一行
                    for (r = 1; r <= rowCount; r++)
                    {
                        IRow row = sheet.GetRow(r);
                        if (row == null)
                        {
                            sb.Append("空行-" + r.ToString() + ",");
                            continue;//当前行为空跳出该循环
                        }
                        else
                        {
                            //必填字段判断
                            if (String.IsNullOrEmpty(GetCellValue(row.GetCell(0)).ToString()))
                            {
                                sb.Append("必填字段为空-" + r.ToString() + ",");
                                continue;//当前行没有名称跳出该循环
                            }
                            newsp++;
                            tb.Append("[tr][td]" + GetCellValue(row.GetCell(0)).ToString() + "[/td][td]" + GetCellValue(row.GetCell(1)).ToString() + "[/td]");
                            for (int i = r; i <= 1000; i = i + rowCount)
                            {
                                //自动计算抽奖编号
                                if (i == 1000)
                                {
                                    tb.Append("[td]000[/td]");
                                }
                                else
                                {
                                    tb.Append("[td]" + i.ToString().PadLeft(3, '0') + "[/td]");
                                }
                            }
                            tb.Append("[/tr]");
                        }
                    }
                    tb.Append("[/table]");
                    haoma.Value = tb.ToString();
                }
                catch (Exception err)
                {
                    sb.Append(r.ToString() + ":" + err + ",");
                }
                finally
                {
                    UpLoadStream.Close();
                    UpLoadStream = null;
                    msg.InnerHtml = String.Format("当前共检测到:{0} 条数据,转换成功的数据:{1} 条,执行失败的行号:{2}", rowCount.ToString(), (newsp + oldsp).ToString(), sb.ToString().TrimEnd(','));
                }
            }
        }

        public static Object GetCellValue(ICell cell)
        {
            if (cell == null)
            {
                return "";
            }
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return String.Empty;
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Formula:
                    try
                    {
                        var e = WorkbookFactory.CreateFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch (Exception)
                    {
                        return cell.NumericCellValue;
                    }
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(cell))
                    {
                        return cell.DateCellValue;
                    }
                    return cell.NumericCellValue;
                default:
                    return cell.ToString();
            }
        }
    }
}