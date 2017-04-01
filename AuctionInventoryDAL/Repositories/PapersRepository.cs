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
