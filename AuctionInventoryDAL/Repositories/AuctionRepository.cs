using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;

namespace AuctionInventoryDAL.Repositories
{
    public class AuctionRepository
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public bool SaveRepoAuctionList(List<AuctionList> auction)
        {
            int? AuctionFrontEndID = auctionContext.AuctionLists.Max(i => i.iAuctionFrontEndID) ?? 0;
            AuctionFrontEndID = AuctionFrontEndID + 1;

            bool status = false;
            {
                foreach (var items in auction)
                {
                    //Save
                    items.iAuctionFrontEndID = AuctionFrontEndID;
                    auctionContext.AuctionLists.Add(items);
                }
                auctionContext.SaveChanges();
            }

            status = true;
            return status;
        }

    }
}
