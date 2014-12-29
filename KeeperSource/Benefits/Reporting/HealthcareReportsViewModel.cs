
using KeeperRichClient.Modules.Benefits.Models;
//using System.Data;
using KeeperRichClient.Modules.Benefits.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace KeeperRichClient.Modules.Benefits.Reporting
{
    public class HealthcareReportsViewModel : IHealthcareReportsViewModel
    {

        public HealthcareReportsViewModel()
        {
            dataContext = new DbContext(ServerChanger.ConnStr);
            CreElasReportCommand = new RelayCommand(action => this.creElasReportCommand(ReportPath));
            ReportStart = new DateTime(2014,1,1);
            ReportEnd = new DateTime(2014, 1, 31);
        }

        public ICommand CreElasReportCommand
        {
            get;
            private set;
        }

        public DateTime     ReportStart { get; set; }
        public DateTime?    ReportEnd { get; set; }
        public String       ReportPath { get; set; }

        private DbContext dataContext;
        private void creElasReportCommand(string fileName)
        {
            
            try
            {     
                /*
                 * calculate med fin data through view
                 * 
                 */
                 
                //System.Data.DataTable dt = (dataContext.vMedTotRepos).ToDataTable<vMedTotRepo>();

                System.Data.DataTable dt = (dataContext.spCalcHealthcareCostV3(this.ReportStart, this.ReportEnd).OrderBy(x=>x.nazwisko_imię_pracownik)).ToDataTable();


            System.IO.FileInfo newXlFile = new System.IO.FileInfo(ReportPath);
            if (newXlFile.Exists)
            {
                if (newXlFile.IsFileLocked())
                {
                    System.Windows.MessageBox.Show(string.Format("File {0} is opened! \n\n Please close it and regenerate givent report.\n\n Thank you!",ReportPath),
                                                    msgCaption,
                                                    System.Windows.MessageBoxButton.OK);
                }

                var decision = System.Windows.MessageBox.Show(string.Format("File {0} already exists! \n\n Please click Yes to delete file or No to quit the procedure.\n\n Thank you!", ReportPath),
                                                                msgCaption,
                                                                System.Windows.MessageBoxButton.YesNo);
                switch (decision)
                {
                    case System.Windows.MessageBoxResult.Yes:
                        newXlFile.Delete();
                        break;
                    case System.Windows.MessageBoxResult.No:
                        return;
                }
            }

            using (ExcelPackage xlPack = new ExcelPackage(newXlFile))
            {
                ExcelWorksheet ws = xlPack.Workbook.Worksheets.Add("DATA");
                ws.Cells["A2"].LoadFromDataTable(dt, true);
                
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

                ws.Hidden = OfficeOpenXml.eWorkSheetHidden.Visible;   

                xlPack.Save();
            }

            //newXlFile.Open(mode: System.IO.FileMode.Open);

            System.Diagnostics.Process.Start(newXlFile.FullName);
            }

            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error occurred! \n\n{0}",e.ToString()),msgCaption,MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }
        private const string msgCaption = "Healthcare reports :: KeeperRichClient 2014";

    }
}




