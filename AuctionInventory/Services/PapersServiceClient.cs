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

            foreach(var data in import)
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