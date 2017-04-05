using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class PapersServiceClient
    {
        public bool SaveImportData(List<PaperDetailsImportModel> mImport)
        {
            bool status = true;
            PapersRepository repo = new PapersRepository();
            status = repo.SavePaperImport(ParserAddImports(mImport));
            return status;
        }


        public bool UpdateImportData(PaperDetailsImportModel mImport)
        {
            bool status = true;
            PapersRepository repo = new PapersRepository();
            status = repo.UpdatePaperImport(ParserUpdateImports(mImport));
            return status;
        }

        public bool UpdateExportData(PaperDetailsExportModel mExport)
        {
            bool status = true;
            PapersRepository repo = new PapersRepository();
            status = repo.UpdatePaperExport(ParserUpdateExports(mExport));
            return status;
        }
        public dynamic GetImportData()
        {

            PapersRepository repo = new PapersRepository();
            var importDataList = repo.GetImportData();
            return importDataList;
        }

        public dynamic GetExportData()
        {
            PapersRepository repo = new PapersRepository();
            var exportDataList = repo.GetExportData();
            return exportDataList;
        }

        public dynamic GetSalesVehicleByPapertype(int paperTypeID)
        {
            PapersRepository repo = new PapersRepository();
            var vehiclePaperByType = repo.GetSalesVehicleByPapertype(paperTypeID);
            return vehiclePaperByType;
        }

        public bool SaveExportData(List<PaperDetailsExportModel> mExport)
        {
            bool status = true;
            PapersRepository repo = new PapersRepository();
            status = repo.SavePaperExport(ParserAddExports(mExport));
            return status;
        }

        private List<PaperDetailsForImport> ParserAddImports(List<PaperDetailsImportModel> import)
        {
            List<PaperDetailsForImport> eImportList = new List<PaperDetailsForImport>();

            foreach (var data in import)
            {
                if (data != null)
                {
                    PaperDetailsForImport eImport = new PaperDetailsForImport();
                    eImport.iPaperDetailsForImportID = data.iPaperDetailsForImportID;
                    eImport.iVehicleID = data.iVehicleID;
                    eImport.iDecNo = data.iDecNo;
                    eImport.strDecDate = data.strDecDate;
                    eImport.iImpDeposit = data.iImpDeposit;
                    eImport.iDuty = data.iDuty;
                    eImport.iPaper = data.iPaper;
                    eImport.iTotal = data.iTotal;
                    eImport.iImpBalance = data.iImpBalance;
                    eImportList.Add(eImport);
                }
            }

            return eImportList;
        }


        private PaperDetailsForImport ParserUpdateImports(PaperDetailsImportModel import)
        {
            PaperDetailsForImport eImport = new PaperDetailsForImport();

            if (import != null)
            {

                eImport.iPaperDetailsForImportID = import.iPaperDetailsForImportID;
                eImport.iVehicleID = import.iVehicleID;
                eImport.iDecNo = import.iDecNo;
                eImport.strDecDate = import.strDecDate;
                eImport.iImpDeposit = import.iImpDeposit;
                eImport.iDuty = import.iDuty;
                eImport.iPaper = import.iTotal;
                eImport.iImpBalance = import.iImpBalance;

            }

            return eImport;
        }

        private PaperDetailsForExport ParserUpdateExports(PaperDetailsExportModel export)
        {
            PaperDetailsForExport eExport = new PaperDetailsForExport();

            if (export != null)
            {
                eExport.iPaperDetailsForExportID = export.iPaperDetailsForExportID;
                eExport.iVehicleID = export.iVehicleID;
                eExport.strReceivingDate = export.strReceivingDate;
                eExport.strSubmitDate = export.strSubmitDate;
                eExport.iCustApproval = export.iCustApproval;
                eExport.iDeduction = export.iDeduction;
                eExport.iFine = export.iFine;
                eExport.iMisc = export.iMisc;
                eExport.iExportDeposit = export.iExportDeposit;
                eExport.iExportBalance = export.iExportBalance;

            }

            return eExport;
        }


        private List<PaperDetailsForExport> ParserAddExports(List<PaperDetailsExportModel> export)
        {
            List<PaperDetailsForExport> eExportList = new List<PaperDetailsForExport>();

            foreach (var data in export)
            {
                if (data != null)
                {
                    PaperDetailsForExport eExport = new PaperDetailsForExport();
                    eExport.iPaperDetailsForExportID = data.iPaperDetailsForExportID;
                    eExport.iVehicleID = data.iVehicleID;
                    eExport.strReceivingDate = data.strReceivingDate;
                    eExport.strSubmitDate = data.strSubmitDate;
                    eExport.iCustApproval = data.iCustApproval;
                    eExport.iDeduction = data.iDeduction;
                    eExport.iFine = data.iFine;
                    eExport.iMisc = data.iMisc;
                    eExport.iExportDeposit = data.iExportDeposit;
                    eExport.iExportBalance = data.iExportBalance;
                    eExportList.Add(eExport);
                }
            }

            return eExportList;
        }

    }
}