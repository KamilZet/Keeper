
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
            dataContext =           new DbContext(ServerChanger.ConnStr);
            GroupMedRepCommand =    new RelayCommand(action => this.groupMedRepCommand(GroupReportPath));
            InternMedRepCommand =   new RelayCommand(action => this.internMedRepCommand(InternReportPath));
            GroupReportStart =      new DateTime(DateTime.Today.Year,DateTime.Today.Month,1).AddMonths(-1);
            GroupReportEnd =        new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
            InternReportStart =     new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
            InternReportEnd =       new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
        }

        public ICommand GroupMedRepCommand
        {
            get;
            private set;
        }

        public ICommand InternMedRepCommand
        {
            get;
            private set;
        }


        //these variables are so ugly...but im runnin' o-o-T ;)
        public DateTime GroupReportStart { get; set; }
        public DateTime GroupReportEnd { get; set; }
        public String GroupReportPath { get; set; }

        public DateTime InternReportStart { get; set; }
        public DateTime InternReportEnd { get; set; }
        public String   InternReportPath { get; set; } 

        

        private DbContext dataContext;

        private void internMedRepCommand(string fileName)
        {

            try
            {
                System.Data.DataTable permEmpData = (dataContext.PermEmpMedUseInLimit(this.InternReportStart, this.InternReportEnd).OrderBy(x => x.Nazwisko_i_imię)).ToDataTable();
                System.Data.DataTable shitEmpData = (dataContext.ShitEmpMedUseInLimit(this.InternReportStart, this.InternReportEnd).OrderBy(x => x.Nazwisko_i_imię)).ToDataTable();
                System.Data.DataTable busEmpData = (dataContext.BusEmpMedUseInLimit(this.InternReportStart, this.InternReportEnd).OrderBy(x => x.Nazwisko_i_imię)).ToDataTable();

                System.IO.FileInfo newXlFile = new System.IO.FileInfo(InternReportPath);
                if (newXlFile.Exists)
                {
                    if (newXlFile.IsFileLocked())
                    {
                        System.Windows.MessageBox.Show(string.Format("File {0} is opened! \n\n Please close it and regenerate givent report.\n\n Thank you!", InternReportPath),
                                                        msgCaption,
                                                        System.Windows.MessageBoxButton.OK);
                    }

                    var decision = System.Windows.MessageBox.Show(string.Format("File {0} already exists! \n\n Please click Yes to delete file or No to quit the procedure.\n\n Thank you!", InternReportPath),
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
                    ExcelWorksheet wsPermEmp = xlPack.Workbook.Worksheets.Add("Pracownicy");
                    ExcelWorksheet wsShitEmp = xlPack.Workbook.Worksheets.Add("Zleceniobiorcy");
                    ExcelWorksheet wsBusEmp = xlPack.Workbook.Worksheets.Add("Działalność gospodarcza");

                    
                    wsPermEmp.Cells["A2"].LoadFromDataTable(permEmpData, true);
                    this.addHeaderToTab(wsPermEmp);

                    
                    wsShitEmp.Cells["A2"].LoadFromDataTable(shitEmpData, true);
                    this.addHeaderToTab(wsShitEmp);

                    
                    wsBusEmp.Cells["A2"].LoadFromDataTable(shitEmpData, true);
                    this.addHeaderToTab(wsBusEmp);

                    xlPack.Save();
                }

                //newXlFile.Open(mode: System.IO.FileMode.Open);

                System.Diagnostics.Process.Start(newXlFile.FullName);
            }

            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error occurred! \n\n{0}", e.ToString()), msgCaption, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void groupMedRepCommand(string fileName)
        {
            
            try
            {     
                System.Data.DataTable dt = (dataContext.spCalcHealthcareCostV3(this.GroupReportStart, this.GroupReportEnd).OrderBy(x=>x.nazwisko_imię_pracownik)).ToDataTable();


            System.IO.FileInfo newXlFile = new System.IO.FileInfo(GroupReportPath);
            if (newXlFile.Exists)
            {
                if (newXlFile.IsFileLocked())
                {
                    System.Windows.MessageBox.Show(string.Format("File {0} is opened! \n\n Please close it and regenerate givent report.\n\n Thank you!", GroupReportPath),
                                                    msgCaption,
                                                    System.Windows.MessageBoxButton.OK);
                }

                var decision = System.Windows.MessageBox.Show(string.Format("File {0} already exists! \n\n Please click Yes to delete file or No to quit the procedure.\n\n Thank you!", GroupReportPath),
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

        private void addHeaderToTab(ExcelWorksheet worksheet)
        {
            var headCell = worksheet.Cells[1, 1];
            headCell.Value = "MEDIACOM WARSAW";
            headCell.Style.Font.Color.SetColor(Color.White);
            headCell.Style.Font.Size = 20;
            headCell.Style.Font.Bold = true;
            headCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            headCell.Style.Fill.BackgroundColor.SetColor(Color.Magenta);
            {
                worksheet.View.FreezePanes(3, 1);
                worksheet.Cells.AutoFitColumns();
                worksheet.Hidden = OfficeOpenXml.eWorkSheetHidden.Visible;
            }
        }

    }
}




