using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class VehicleServiceClient
    {
        public dynamic GetAllVehicle()
        {
           
            VehicleRepository repo = new VehicleRepository();
            var listVehicle = repo.GetAll();            
            return listVehicle;
        }
        public bool SaveData(Vehicles vehicle)
        {
            bool status = true;
            VehicleRepository repo = new VehicleRepository();
            status = repo.SaveEdit(ParserAddVehicle(vehicle));
            return status;
        }
        
        public bool GriddataService(List<Vehicles> vehicle)
        {
            bool status = true;           
            VehicleRepository repo = new VehicleRepository();
            status = repo.GriddataRepo(ParserAddListVehicle(vehicle));
            return status;
        }


       

        public Vehicles GetVehicles(int id)
        {

            Vehicles vehicles = new Vehicles();
            VehicleRepository repo = new VehicleRepository();
            if (vehicles != null)
            {
                vehicles = ParserVehicles(repo.Get(id));
            }
            return vehicles;

        }

        public bool Delete(int id)
        {
            bool status = false;
            VehicleRepository repo = new VehicleRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser

        private Vehicle ParserAddVehicle(Vehicles vehicles)
        {
            Vehicle mVehicle = new Vehicle();

            if (vehicles != null)
            {
                mVehicle.iVehicleID = vehicles.iVehicleID;
                mVehicle.iLotNum = vehicles.iLotNum;
                mVehicle.strGrade = vehicles.strGrade ?? " ";
                mVehicle.strChassisNum = vehicles.strChassisNum ?? " ";
                mVehicle.strCategory = vehicles.strCategory ?? " ";
                mVehicle.strMake = vehicles.strMake ?? " ";
                mVehicle.iModel = vehicles.iModel;
                mVehicle.iYear = vehicles.iYear ?? " ";
                mVehicle.strColor = vehicles.strColor;
                mVehicle.dmlKM = vehicles.dmlKM;
                mVehicle.strOrigin = vehicles.strOrigin ?? " ";
                mVehicle.iDoor = vehicles.iDoor;
                mVehicle.strLocation = vehicles.strLocation ?? " ";
                mVehicle.weight = vehicles.weight ?? " ";
                mVehicle.strHSCode = vehicles.strHSCode ?? " ";
                mVehicle.ATMT = vehicles.ATMT ?? " ";
                mVehicle.iCustomAssesVal = vehicles.iCustomAssesVal;
                mVehicle.dmlDuty = vehicles.dmlDuty;
                mVehicle.iCustomValInJPY = vehicles.iCustomValInJPY;


                mVehicle.strGradeA = vehicles.strGradeA ?? " ";
                mVehicle.strGradeB = vehicles.strGradeB ?? " ";
                mVehicle.dmlLitter = vehicles.dmlLitter;
                mVehicle.strTrans = vehicles.strTrans;
                mVehicle.iMileage = vehicles.iMileage;
            }
            return mVehicle;
        }

        private List<Vehicles> ParserGetAllVehicles(dynamic responseData)
        {
            List<Vehicles> listVehicles = new List<Vehicles>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Vehicles mVehicle = new Vehicles();
                    mVehicle.iVehicleID = data.iVehicleID;
                    mVehicle.iLotNum = data.iLotNum;
                    mVehicle.strGrade = data.strGrade ?? " ";
                    mVehicle.strChassisNum = data.strChassisNum ?? " ";
                    mVehicle.strCategory = data.strCategory ?? " ";
                    mVehicle.strMake = data.strMake ?? " ";
                    mVehicle.iModel = data.iModel ?? " ";
                    mVehicle.iYear = data.iYear ?? " ";
                    mVehicle.strColor = data.strColor;
                    mVehicle.dmlKM = data.dmlKM;
                    mVehicle.strOrigin = data.strOrigin ?? " ";
                    mVehicle.iDoor = data.iDoor;
                    mVehicle.strLocation = data.strLocation ?? " ";
                    mVehicle.weight = data.weight ?? " ";
                    mVehicle.strHSCode = data.strHSCode ?? " ";
                    mVehicle.ATMT = data.ATMT ?? " ";
                    mVehicle.iCustomAssesVal = data.iCustomAssesVal;
                    mVehicle.dmlDuty = data.dmlDuty;
                    mVehicle.iCustomValInJPY = data.iCustomValInJPY;


                    mVehicle.strGradeA = data.strGradeA ?? " ";
                    mVehicle.strGradeB = data.strGradeB ?? " ";
                    mVehicle.dmlLitter = data.dmlLitter;
                    mVehicle.strTrans = data.strTrans;
                    mVehicle.iMileage = data.iMileage;
                    listVehicles.Add(mVehicle);
                }
            }
            return listVehicles;
        }


        private Vehicles ParserVehicles(dynamic data)
        {
            Vehicles mVehicle = new Vehicles();

            if (data != null)
            {
                mVehicle.iVehicleID = data.iVehicleID;
                mVehicle.iLotNum = data.iLotNum;
                mVehicle.strGrade = data.strGrade ?? " ";
                mVehicle.strChassisNum = data.strChassisNum ?? " ";
                mVehicle.strCategory = data.strCategory ?? " ";
                mVehicle.strMake = data.strMake ?? " ";
                mVehicle.iModel = data.iModel ?? " ";
                mVehicle.iYear = data.iYear ?? " ";
                mVehicle.strColor = data.strColor;
                mVehicle.dmlKM = data.dmlKM;
                mVehicle.strOrigin = data.strOrigin ?? " ";
                mVehicle.iDoor = data.iDoor;
                mVehicle.strLocation = data.strLocation ?? " ";
                mVehicle.weight = data.weight ?? " ";
                mVehicle.strHSCode = data.strHSCode ?? " ";
                mVehicle.ATMT = data.ATMT ?? " ";
                mVehicle.iCustomAssesVal = data.iCustomAssesVal;
                mVehicle.dmlDuty = data.dmlDuty;
                mVehicle.iCustomValInJPY = data.iCustomValInJPY;


                mVehicle.strGradeA = data.strGradeA ?? " ";
                mVehicle.strGradeB = data.strGradeB ?? " ";
                mVehicle.dmlLitter = data.dmlLitter;
                mVehicle.strTrans = data.strTrans;
                mVehicle.iMileage = data.iMileage;
            }
            return mVehicle;
        }


        private List<Vehicle> ParserAddListVehicle(List<Vehicles> vehicles)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            foreach (var item in vehicles)
            {
                if (item != null)
                {
                    Vehicle mVehicle = new Vehicle();
                    mVehicle.iVehicleID = item.iVehicleID;
                    mVehicle.iLotNum = item.iLotNum;
                    mVehicle.strGrade = item.strGrade ?? " ";
                    mVehicle.strChassisNum = item.strChassisNum ?? " ";
                    mVehicle.strCategory = item.strCategory ?? " ";
                    mVehicle.strMake = item.strMake ?? " ";
                    mVehicle.iModel = item.iModel;
                    mVehicle.iYear = item.iYear ?? " ";
                    mVehicle.strColor = item.strColor;
                    mVehicle.dmlKM = item.dmlKM;
                    mVehicle.strOrigin = item.strOrigin ?? " ";
                    mVehicle.iDoor = item.iDoor;
                    mVehicle.strLocation = item.strLocation ?? " ";
                    mVehicle.weight = item.weight ?? " ";
                    mVehicle.strHSCode = item.strHSCode ?? " ";
                    mVehicle.ATMT = item.ATMT ?? " ";
                    mVehicle.iCustomAssesVal = item.iCustomAssesVal;
                    mVehicle.dmlDuty = item.dmlDuty;
                    mVehicle.iCustomValInJPY = item.iCustomValInJPY;


                    mVehicle.strGradeA = item.strGradeA ?? " ";
                    mVehicle.strGradeB = item.strGradeB ?? " ";
                    mVehicle.dmlLitter = item.dmlLitter;
                    mVehicle.strTrans = item.strTrans;
                    mVehicle.iMileage = item.iMileage;
                    listVehicle.Add(mVehicle);
                }
            }
            return listVehicle;
        }


        #endregion


    }
}

