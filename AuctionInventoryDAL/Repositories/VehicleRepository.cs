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

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicle = new List<Vehicle>();
            vehicle = (from a in auctionContext.Vehicles select a).OrderBy(a => a.iLotNum).ToList();
            return vehicle;
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
                    a.iDuty = vehicle.iDuty;
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
