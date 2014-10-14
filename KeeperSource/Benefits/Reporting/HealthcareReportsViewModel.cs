
using KeeperRichClient.Modules.Benefits.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
//using System.Data;

namespace KeeperRichClient.Modules.Benefits.Reporting
{
    public class HealthcareReportsViewModel : IHealthcareReportsViewModel
    {
        public HealthcareReportsViewModel()
        {
            dataContext = new DbContext();
            CreElasReportCommand = new RelayCommand(action => this.creElasReportCommand());
            ReportStart = new DateTime(2014,1,1);
            ReportEnd = new DateTime(2014, 1, 31);

        }

        public ICommand CreElasReportCommand
        {
            get;
            private set;
        }

        public DateTime ReportStart { get; set; }
        public DateTime? ReportEnd { get; set; }


        private DbContext dataContext;
        private void creElasReportCommand()
        {
            var queryResult = dataContext.spCalcHealthcareCost(this.ReportStart, this.ReportEnd).OrderBy(x => x.NazwiskoImię);

            //System.Data.DataTable dt = (dataContext.spCalcHealthcareCost(this.ReportStart, this.ReportEnd)).CopyToDataTable();

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("NazwiskoImię",typeof(string));
            dt.Columns.Add("LimitDoWykorzystania", typeof(string));
            dt.Columns.Add("CałkowityKosztPakietu", typeof(decimal));
            dt.Columns.Add("KosztMedycynyPracy", typeof(decimal));
            dt.Columns.Add("KosztPakietuPomniejszonyOMedycynęPracy", typeof(decimal));
            dt.Columns.Add("DopłataPracownika", typeof(decimal));
            dt.Columns.Add("DoZusIOpodatkowania", typeof(decimal));
            dt.Columns.Add("PotrącenieRodzina", typeof(decimal));


            foreach (spCalcHealthcareCostResult iter in queryResult)
            {
                System.Data.DataRow dr = dt.NewRow();
                dr["NazwiskoImię"] = iter.NazwiskoImię;
                dr["LimitDoWykorzystania"] = iter.LimitDoWykorzystania;
                dr["CałkowityKosztPakietu"] = iter.CałkowityKosztPakietu;
                dr["KosztMedycynyPracy"] = iter.KosztMedycynyPracy;
                dr["KosztPakietuPomniejszonyOMedycynęPracy"] = iter.KosztPakietuPomniejszonyOMedycynęPracy;
                dr["DopłataPracownika"] = iter.DopłataPracownika;
                dr["DoZusIOpodatkowania"] = iter.DoZusIOpodatkowania;
                dr["PotrącenieRodzina"] = iter.PotrącenieRodzina;
                dt.Rows.Add(dr);
            }



            using (ExcelPackage xlPack = new ExcelPackage())
            {
                System.IO.FileInfo newXlFile =  new System.IO.FileInfo("C:\\Export.xlsx");
                if (newXlFile.Exists) newXlFile.Delete();

                ExcelWorksheet ws = xlPack.Workbook.Worksheets.Add("Export");
                
                ws.Cells[2,1].LoadFromDataTable(dt, true);
                
                //header row
                var headCell = ws.Cells[1, 1];
                headCell.Value = "MEDIACOM WARSAW";
                headCell.Style.Font.Color.SetColor(Color.White);
                headCell.Style.Font.Size = 20;
                headCell.Style.Font.Bold = true;
                headCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                headCell.Style.Fill.BackgroundColor.SetColor(Color.Magenta);

                ws.View.FreezePanes(3, 1);
                ws.Cells.AutoFitColumns();
                xlPack.Save();
            }

            MessageBox.Show("Done.");
            System.Diagnostics.Process.Start("C:\\Export.xlsx");
            
            
        }
    }
}




