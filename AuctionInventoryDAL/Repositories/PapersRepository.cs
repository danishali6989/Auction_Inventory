using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;

namespace AuctionInventoryDAL.Repositories
{
    public class PapersRepository
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public bool SavePaperImport(List<PaperDetailsForImport> pprImport)
        {
            bool status = false;

            foreach (var item in pprImport)
            {
                //Save
                auctionContext.PaperDetailsForImports.Add(item);
            }

            auctionContext.SaveChanges();
            status = true;
            return status;
        }


        public dynamic GetImportData()
        {

            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = dc.PaperDetailsForImports.ToList().Count,
                    rows = (
                      from import in
                          (from t1 in dc.PaperDetailsForImports
                           join t2 in dc.Vehicles on t1.iVehicleID equals t2.iVehicleID

                           select new
                           {
                               iPaperDetailsForImportID = t1.iPaperDetailsForImportID,
                               iVehicleID = t1.iVehicleID,
                               strChassisNum = t2.strChassisNum,
                               iModel = t2.iModel,
                               iDecNo = t1.iDecNo,
                               strDecDate = t1.strDecDate,
                               dcmlImpDeposit = t1.dcmlImpDeposit,
                               dcmlDuty = t1.dcmlDuty,
                               dcmlPaper = t1.dcmlPaper,
                               dcmlTotal = t1.dcmlTotal,
                               dcmlImpBalance = t1.dcmlImpBalance

                           }).ToList()
                      select new
                      {
                          id = import.iPaperDetailsForImportID,
                          cell = new string[] {
               Convert.ToString(import.iPaperDetailsForImportID),Convert.ToString(import.iVehicleID),
               Convert.ToString(import.strChassisNum),Convert.ToString(import.iModel),               
               Convert.ToString( import.iDecNo),Convert.ToString(import.strDecDate),Convert.ToString( import.dcmlImpDeposit),Convert.ToString(import.dcmlDuty),Convert.ToString( import.dcmlPaper),Convert.ToString( import.dcmlTotal),Convert.ToString(import.dcmlImpBalance)
                        }
                      }).ToArray()
                };
                return jsonData;
            }

        }

        public dynamic GetExportData()
        {

            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = dc.PaperDetailsForExports.ToList().Count,
                    rows = (
                      from export in
                          (from t1 in dc.PaperDetailsForExports
                           join t2 in dc.Vehicles on t1.iVehicleID equals t2.iVehicleID

                           select new
                           {
                               iPaperDetailsForExportID = t1.iPaperDetailsForExportID,
                               iVehicleID=t1.iVehicleID,
                               iCustApproval = t1.iCustApproval,
                               strChassisNum = t2.strChassisNum,
                               iModel = t2.iModel,
                               strReceivingDate = t1.strReceivingDate,
                               strSubmitDate = t1.strSubmitDate,
                               //iImpDeposit = t1.iImpDeposit,
                               dcmlDeduction = t1.dcmlDeduction,
                               dcmlFine = t1.dcmlFine,
                               dcmlMisc = t1.dcmlMisc,
                               dcmlExportDeposit = t1.dcmlExportDeposit,
                               dcmlExportBalance = t1.dcmlExportBalance

                           }).ToList()
                      select new
                      {
                          id = export.iPaperDetailsForExportID,
                          cell = new string[] {
                              Convert.ToString(export.iPaperDetailsForExportID),Convert.ToString(export.iVehicleID), Convert.ToString(export.iCustApproval),
              Convert.ToString(export.strChassisNum),Convert.ToString(export.iModel),Convert.ToString( export.strReceivingDate),Convert.ToString(export.strSubmitDate),Convert.ToString(export.dcmlDeduction),Convert.ToString( export.dcmlFine),Convert.ToString( export.dcmlMisc),Convert.ToString(export.dcmlExportDeposit),Convert.ToString(export.dcmlExportBalance)
                        }
                      }).ToArray()
                };
                return jsonData;
            }

        }


        public dynamic GetSalesVehicleByPapertype(int paperTypeID)
        {
            var vehiclePaperByType = (from sale in auctionContext.Sales
                                      join saleVehicle in auctionContext.SalesVehicles on sale.iSaleFrontEndID equals saleVehicle.iSaleFrontEndID
                                      join vehicle in auctionContext.Vehicles on saleVehicle.iVehicleID equals vehicle.iVehicleID
                                      where sale.iImpExpTransfer == paperTypeID
                                      select new
                                      {
                                          iVehicleID = vehicle.iVehicleID,
                                          iLotNum = vehicle.iLotNum,
                                          strChassisNum = vehicle.strChassisNum,
                                          iModel = vehicle.iModel,
                                          iYear = vehicle.iYear,
                                          color = vehicle.strColor,
                                          iCustomValInJPY = vehicle.iCustomValInJPY


                                      }).ToList();

            //return Json(vehiclePaperByType, JsonRequestBehavior.AllowGet);
            return vehiclePaperByType;
        }
        public bool UpdatePaperImport(PaperDetailsForImport pprImport)
        {
            bool status = false;

            if (pprImport.iPaperDetailsForImportID > 0)
            {
                var import = auctionContext.PaperDetailsForImports.Where(a => a.iPaperDetailsForImportID == pprImport.iPaperDetailsForImportID).FirstOrDefault();
                if (import != null)
                {
                    import.iVehicleID = pprImport.iVehicleID;
                    import.iDecNo = pprImport.iDecNo;
                    import.strDecDate = pprImport.strDecDate;
                    import.dcmlImpDeposit = pprImport.dcmlImpDeposit;
                    import.dcmlDuty = pprImport.dcmlDuty;
                    import.dcmlPaper = pprImport.dcmlPaper;
                    import.dcmlTotal = pprImport.dcmlTotal;
                    import.dcmlImpBalance = pprImport.dcmlImpBalance;

                }
            }

            else
            {
                //Save
                auctionContext.PaperDetailsForImports.Add(pprImport);
            }

            auctionContext.SaveChanges();
            status = true;
            return status;
        }


        public bool UpdatePaperExport(PaperDetailsForExport pprExport)
        {
            bool status = false;

            if (pprExport.iPaperDetailsForExportID > 0)
            {
                var export = auctionContext.PaperDetailsForExports.Where(a => a.iPaperDetailsForExportID == pprExport.iPaperDetailsForExportID).FirstOrDefault();
                if (export != null)
                {
                    
                    export.iVehicleID = pprExport.iVehicleID;
                    export.strReceivingDate = pprExport.strReceivingDate;
                    export.strSubmitDate = pprExport.strSubmitDate;
                    export.iCustApproval = pprExport.iCustApproval;
                    export.dcmlDeduction = pprExport.dcmlDeduction;
                    export.dcmlFine = pprExport.dcmlFine;
                    export.dcmlMisc = pprExport.dcmlMisc;
                    export.dcmlExportDeposit = pprExport.dcmlExportDeposit;
                    export.dcmlExportBalance = pprExport.dcmlExportBalance;

                }
            }

            else
            {
                //Save
                auctionContext.PaperDetailsForExports.Add(pprExport);
            }

            auctionContext.SaveChanges();
            status = true;
            return status;
        }
        public bool SavePaperExport(List<PaperDetailsForExport> pprExport)
        {
            bool status = false;
            foreach (var item in pprExport)
            {
                //Save
                auctionContext.PaperDetailsForExports.Add(item);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }

    }
}
