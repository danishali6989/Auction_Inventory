using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;

namespace AuctionInventoryDAL.Repositories
{
    public class VehicleRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public dynamic GetAll()
        {
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = auctionContext.Vehicles.ToList().Count,
                rows = (
                  from vehicle in
                      (from AM in auctionContext.Vehicles

                       select new
                       {
                          iVehicleID = AM.iVehicleID,
                              iLotNum = AM.iLotNum,
                              strChassisNum = AM.strChassisNum,
                              iModel = AM.iModel,
                              iYear = AM.iYear,
                              color = AM.strColor,
                          iDuty = AM.dmlDuty,
                              iCustomValInJPY = AM.iCustomValInJPY,
                              iCustomAssesVal = AM.iCustomAssesVal

                          }).ToList()
                     select new
                     {
                         id = vehicle.iVehicleID,
                         cell = new string[] {
               Convert.ToString(vehicle.iVehicleID),Convert.ToString(vehicle.iLotNum),Convert.ToString( vehicle.strChassisNum)
               ,Convert.ToString(vehicle.iModel),Convert.ToString( vehicle.iYear),Convert.ToString(vehicle.color),Convert.ToString(vehicle.iDuty)
               ,Convert.ToString( vehicle.iCustomValInJPY)
               //,Convert.ToString(vehicle.iCustomAssesVal)
                        }
                     }).ToArray()
            };
            return jsonData;
        }
        
        public Vehicle Get(int id)
        {
            Vehicle vehicle = new Vehicle();
            vehicle = auctionContext.Vehicles.Where(a => a.iVehicleID == id).FirstOrDefault();
            return vehicle;
        }


       

        public bool GriddataRepo(List<Vehicle> vehicle)
        {
            bool status = false;

            foreach (var v in vehicle)
            {
                auctionContext.Vehicles.Add(v);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;

        }
        public bool SaveEdit(Vehicle vehicle)
        {
            bool status = false;
            if (vehicle.iVehicleID > 0)
            {
                var a = auctionContext.Vehicles.Where(v => v.iVehicleID == vehicle.iVehicleID).FirstOrDefault();
                if (a != null)
                {
                    a.iLotNum = vehicle.iLotNum;
                    a.strGrade = vehicle.strGrade;
                    a.strChassisNum = vehicle.strChassisNum;
                    a.strCategory = vehicle.strCategory;
                    a.strMake = vehicle.strMake;
                    a.iModel = vehicle.iModel;
                    a.iYear = vehicle.iYear;
                    a.strColor = vehicle.strColor;
                    a.dmlKM = vehicle.dmlKM;
                    a.strOrigin = vehicle.strOrigin;
                    a.iDoor = vehicle.iDoor;
                    a.strLocation = vehicle.strLocation;
                    a.weight = vehicle.weight;
                    a.strHSCode = vehicle.strHSCode;
                    a.ATMT = vehicle.ATMT;
                    a.iCustomAssesVal = vehicle.iCustomAssesVal;
                    a.dmlDuty = vehicle.dmlDuty;
                    a.iCustomValInJPY = vehicle.iCustomValInJPY;
                }

            }
            else
            {
                auctionContext.Vehicles.Add(vehicle);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            var vehicle = auctionContext.Vehicles.Where(a => a.iVehicleID == id).FirstOrDefault();
            if(vehicle!=null)
            {
                auctionContext.Vehicles.Remove(vehicle);
                auctionContext.SaveChanges();
                 status = true;
            }
            return status;
        }

        #endregion
    }
}
