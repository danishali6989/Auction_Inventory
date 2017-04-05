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
                               iImpDeposit = t1.iImpDeposit,
                               iDuty = t1.iDuty,
                               iPaper = t1.iPaper,
                               iTotal = t1.iTotal,
                               iImpBalance = t1.iImpBalance

                           }).ToList()
                      select new
                      {
                          id = import.iPaperDetailsForImportID,
                          cell = new string[] {
               Convert.ToString(import.iPaperDetailsForImportID),Convert.ToString(import.iVehicleID),
               Convert.ToString(import.strChassisNum),Convert.ToString(import.iModel),               
               Convert.ToString( import.iDecNo),Convert.ToString(import.strDecDate),Convert.ToString( import.iImpDeposit),Convert.ToString(import.iDuty),Convert.ToString( import.iPaper),Convert.ToString( import.iTotal),Convert.ToString(import.iImpBalance)
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
                               strChassisNum = t2.strChassisNum,
                               iModel = t2.iModel,
                               strReceivingDate = t1.strReceivingDate,
                               strSubmitDate = t1.strSubmitDate,
                               //iImpDeposit = t1.iImpDeposit,
                               iDeduction = t1.iDeduction,
                               iFine = t1.iFine,
                               iMisc = t1.iMisc,
                               iExportDeposit = t1.iExportDeposit,
                               iExportBalance = t1.iExportBalance

                           }).ToList()
                      select new
                      {
                          id = export.iPaperDetailsForExportID,
                          cell = new string[] {
              Convert.ToString(export.iVehicleID),Convert.ToString(export.iPaperDetailsForExportID),Convert.ToString(export.strChassisNum),Convert.ToString(export.iModel),Convert.ToString( export.strReceivingDate),Convert.ToString(export.strSubmitDate),Convert.ToString(export.iDeduction),Convert.ToString( export.iFine),Convert.ToString( export.iMisc),Convert.ToString(export.iExportDeposit)
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
                    import.iImpDeposit = pprImport.iImpDeposit;
                    import.iDuty = pprImport.iDuty;
                    import.iPaper = pprImport.iPaper;
                    import.iTotal = pprImport.iTotal;
                    import.iImpBalance = pprImport.iImpBalance;

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
                    export.iDeduction = pprExport.iDeduction;
                    export.iFine = pprExport.iFine;
                    export.iMisc = pprExport.iMisc;
                    export.iExportDeposit = pprExport.iExportDeposit;
                    export.iExportBalance = pprExport.iExportBalance;

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
