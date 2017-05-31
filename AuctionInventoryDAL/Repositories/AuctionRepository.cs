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

                foreach (var item in auction)
                {
                    var auctionList = auctionContext.AuctionLists.Where(a => a.iAuctionFrontEndID == item.iAuctionFrontEndID).ToList();

                    if (auctionList.Count > 0)
                    {
                        foreach (var deleteauctionList in auctionList)
                        {
                            auctionContext.AuctionLists.Remove(deleteauctionList);
                        }
                        //auctionContext.SaveChanges();
                    }
                }


                foreach (var items in auction)
                {
                    //Save
                    //items.iAuctionFrontEndID = AuctionFrontEndID;
                    auctionContext.AuctionLists.Add(items);
                }
                auctionContext.SaveChanges();
            }

            status = true;
            return status;
        }

        public dynamic GetAuctionListData()
        {
            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {

                var preResult = (from AM in dc.AuctionLists

                                 select new
                                 {
                                     //iAuctionListID = AM.iAuctionListID,
                                     iAuctionFrontEndID = AM.iAuctionFrontEndID,
                                     strAuctionDate = AM.strAuctionDate,
                                     dtAuctionDate = AM.dtAuctionDate,
                                     iVehicleID = AM.iVehicleID,


                                 }).ToList();

                if (preResult.Count > 0)
                {
                    var result = preResult.GroupBy(a => a.strAuctionDate).Select(y =>
                        new
                        {
                            strAuctionDate = y.Key,
                            iAuctionFrontEndID = y.First().iAuctionFrontEndID,
                            dtAuctionDate = y.First().dtAuctionDate,
                            iVehicleID = y.Count(),

                        }).ToList();

                    var rows = (from AM in result
                                select new
                 {
                     id = AM.iAuctionFrontEndID,
                     cell = new string[] {
               Convert.ToString(AM.iAuctionFrontEndID),Convert.ToString(AM.dtAuctionDate),Convert.ToString(AM.strAuctionDate),Convert.ToString( AM.iVehicleID)
                        }
                 }).ToArray();




                    var jsonData = new
                    {
                        total = 1,
                        page = 1,
                        // records = dc.Vehicles.ToList().Count,
                        rows = rows
                    };

                    return jsonData;
                }
                else
                {
                    return null;
                }
            }
        }

        public dynamic GetRepoAuctionListVehicles()
        {
            //List<Vehicle> vehicleList = new List<Vehicle>();

            //Give an Exception


            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {


                var test = (
                     from vehi in
                         (from AM in dc.Vehicles


                          select new
                          {
                              iVehicleID = AM.iVehicleID,
                              iLotNum = AM.iLotNum,
                              strChassisNum = AM.strChassisNum,
                              iModel = AM.iModel,
                              iYear = AM.iYear,
                              color = AM.strColor,
                              iCustomValInJPY = AM.iCustomValInJPY,
                              iCustomAssesVal = AM.iCustomAssesVal

                          }).ToList()
                     select new
                     {
                         id = vehi.iVehicleID,
                         cell = new string[] {
               Convert.ToString(vehi.iVehicleID),Convert.ToString(vehi.iLotNum),Convert.ToString( vehi.strChassisNum)
               ,Convert.ToString(vehi.iModel),Convert.ToString( vehi.iYear),Convert.ToString(vehi.color)
               ,Convert.ToString( vehi.iCustomValInJPY),Convert.ToString(vehi.iCustomAssesVal)
                        }
                     }).ToArray();


                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    // records = dc.Vehicles.ToList().Count,
                    rows = test
                };

                return jsonData;
            }





            ///// Select from Bellow two lines

            //vehicleList = (from r in auctionContext.Vehicles select r).ToList();

            //return vehicleList;

            //var vehicleListTest = (from AM in auctionContext.Vehicles
            //                       select new
            //                       {
            //                           AM.iVehicleID,
            //                           AM.iLotNum,
            //                           AM.strChassisNum,
            //                           AM.iModel,
            //                           AM.iYear,
            //                           AM.strColor,
            //                           AM.iCustomValInJPY,
            //                           AM.iCustomAssesVal

            //                       }).ToList();


            //return vehicleListTest;


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
        public dynamic AuctionFrontEnd()
        {
            var AuctionID = auctionContext.AuctionLists.Max(i => i.iAuctionFrontEndID) + 1;
            return AuctionID;
        }

        public dynamic GetVehicleForAuctionListPDF(int id)
        {
            //List<Vehicle> vehicle = new List<Vehicle>();
            //vehicle = auctionContext.Vehicles.Where(a => a.iVehicleID == id).FirstOrDefault();


            //var vehicle = (from t1 in auctionContext.AuctionLists
            //            join t2 in auctionContext.Vehicles on t1.iVehicleID equals t2.iVehicleID
            //            where t1.iAuctionFrontEndID == id

            //            select new Vehicle
            //                {
            //                    //iVehicleID = t2.iVehicleID,
            //                    iLotNum = t2.iLotNum,
            //                    strChassisNum = t2.strChassisNum,
            //                    iModel = t2.iModel,
            //                    iYear = t2.iYear,
            //                    strColor = t2.strColor,
            //                    //iCustomValInJPY = t2.iCustomValInJPY,
            //                    iCustomAssesVal = t2.iCustomAssesVal

            //                }).OrderBy(a => a.iVehicleID).ToList();

            // return vehicle;


            var auction = (from t1 in auctionContext.AuctionLists
                           join t2 in auctionContext.Vehicles on t1.iVehicleID equals t2.iVehicleID
                           where t1.iAuctionFrontEndID == id

                           select t2).OrderBy(a => a.iVehicleID).ToList();
            var vehicle = auction.Select(i =>
             new { LotNum = i.iLotNum, ChassisNum = i.strChassisNum, iModel = i.iModel, Year = i.iYear, color = i.strColor, JPY = i.iCustomValInJPY }).ToList();

            return vehicle;
        }


    }
}
