using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class AuctionServiceClient
    {
        public bool SaveDataAuctionList(List<AuctionListModel> auction)
        {
            bool status = true;           
            AuctionRepository repo = new AuctionRepository();
            status = repo.SaveRepoAuctionList(ParserAddAuctionList(auction));
            return status;
        }


        private List<AuctionList> ParserAddAuctionList(List<AuctionListModel> auction)
        {
            
            List<AuctionList> AllAuctionList = new List<AuctionList>();
            
            foreach (var item in auction)
            {


                if (auction != null)
                {
                    AuctionList auctionList = new AuctionList();

                    auctionList.iAuctionListID = item.iAuctionListID;
                    auctionList.iVehicleID = item.iVehicleID;
                    auctionList.strAuctionDate = item.strAuctionDate;
                    auctionList.iAuctionFrontEndID = item.iAuctionFrontEndID;
                    AllAuctionList.Add(auctionList);
                }
            }
            return AllAuctionList;
        }

    }
}