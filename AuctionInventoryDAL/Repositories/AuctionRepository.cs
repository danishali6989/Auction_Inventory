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



        public List<Vehicle> GetRepoAuctionList()
        {
            List<Vehicle> vehicleList = new List<Vehicle>();

            //Give an Exception




            /// Select from Bellow two lines

            vehicleList = (from r in auctionContext.Vehicles select r).ToList();


            var vehicleListTest = (from AM in auctionContext.Vehicles
                                select new
                                {
                                    AM.iVehicleID,
                                    AM.iLotNum,
                                    AM.strChassisNum,
                                    AM.iModel,
                                    AM.iYear,
                                    AM.strColor,
                                    AM.iCustomValInJPY,
                                    AM.iCustomAssesVal

                                }).ToList();


            return vehicleList;


            //////////Give not selected data .whole data of vehicle//////////////



            //vehicleList = auctionContext.Vehicles.AsEnumerable()

            //            .Select(AM => new Vehicle()
            //            {

            //                iVehicleID = AM.iVehicleID,
            //                iLotNum = AM.iLotNum,
            //                strChassisNum = AM.strChassisNum,
            //                iModel = AM.iModel,
            //                iYear = AM.iYear,
            //                strColor = AM.strColor,
            //                iCustomValInJPY = AM.iCustomValInJPY,
            //                iCustomAssesVal = AM.iCustomAssesVal
            //            }).ToList();


            //return vehicleList;



        }


        public List<Vehicle> GetVehicleForAuctionListPDF(int id)
        {
            List<Vehicle> vehicle = new List<Vehicle>();
            //vehicle = auctionContext.Vehicles.Where(a => a.iVehicleID == id).FirstOrDefault();


            vehicle = (from t1 in auctionContext.AuctionLists
                       join t2 in auctionContext.Vehicles on t1.iVehicleID equals t2.iVehicleID
                       where t1.iAuctionFrontEndID == id

                       select new Vehicle
                           {
                               //iVehicleID = t2.iVehicleID,
                               iLotNum = t2.iLotNum,
                               strChassisNum = t2.strChassisNum,
                               iModel = t2.iModel,
                               iYear = t2.iYear,
                               strColor = t2.strColor,
                               //iCustomValInJPY = t2.iCustomValInJPY,
                               iCustomAssesVal = t2.iCustomAssesVal

                           }).OrderBy(a => a.iVehicleID).ToList();

            return vehicle;


            //var auction = (from t1 in auctionContext.AuctionLists
            //               join t2 in auctionContext.Vehicles on t1.iVehicleID equals t2.iVehicleID
            //               where t1.iAuctionFrontEndID == id

            //               select t2).OrderBy(a => a.iVehicleID).ToList();
            //vehicle = auction.Select(i =>
            //new { LotNum = i.iLotNum, ChassisNum = i.strChassisNum, iModel = i.iModel, Year = i.iYear, color = i.strColor, JPY = i.iCustomAssesVal }).ToList();

            //return vehicle;
        }


    }
}
