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
        public List<Vehicles> GetAllVehicle()
        {
            List<Vehicles> listVehicle = new List<Vehicles>();
            VehicleRepository repo = new VehicleRepository();
            dynamic vehicle = repo.GetAll();
            listVehicle = ParserGetAllVehicles(vehicle);
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
            Vehicle mvehicle = new Vehicle();

            if (vehicles != null)
            {
                mvehicle.iVehicleID = vehicles.iVehicleID;
                mvehicle.iLotNum = vehicles.iLotNum;
                mvehicle.strGrade = vehicles.strGrade ?? " ";
                mvehicle.strChassisNum = vehicles.strChassisNum ?? " ";
                mvehicle.strCategory = vehicles.strCategory ?? " ";
                mvehicle.strMake = vehicles.strMake ?? " ";
                mvehicle.iModel = vehicles.iModel ?? " ";
                mvehicle.iYear = vehicles.iYear ?? " ";
                mvehicle.strColor = vehicles.strColor;
                mvehicle.dmlKM = vehicles.dmlKM;
                mvehicle.strOrigin = vehicles.strOrigin ?? " ";
                mvehicle.iDoor = vehicles.iDoor;
                mvehicle.strLocation = vehicles.strLocation ?? " ";
                mvehicle.weight = vehicles.weight ?? " ";
                mvehicle.strHSCode = vehicles.strHSCode ?? " ";
                mvehicle.ATMT = vehicles.ATMT ?? " ";
                mvehicle.iCustomAssesVal = vehicles.iCustomAssesVal;
                mvehicle.iDuty = vehicles.iDuty;
                mvehicle.iCustomValInJPY = vehicles.iCustomValInJPY;
            }
            return mvehicle;
        }

        private List<Vehicles> ParserGetAllVehicles(dynamic responseData)
        {
            List<Vehicles> listVehicles = new List<Vehicles>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Vehicles vehicle = new Vehicles();
                    vehicle.iVehicleID = data.iVehicleID;
                    vehicle.iLotNum = data.iLotNum;
                    vehicle.strGrade = data.strGrade ?? " ";
                    vehicle.strChassisNum = data.strChassisNum ?? " ";
                    vehicle.strCategory = data.strCategory ?? " ";
                    vehicle.strMake = data.strMake ?? " ";
                    vehicle.iModel = data.iModel ?? " ";
                    vehicle.iYear = data.iYear ?? " ";
                    vehicle.strColor = data.strColor;
                    vehicle.dmlKM = data.dmlKM;
                    vehicle.strOrigin = data.strOrigin ?? " ";
                    vehicle.iDoor = data.iDoor;
                    vehicle.strLocation = data.strLocation ?? " ";
                    vehicle.weight = data.weight ?? " ";
                    vehicle.strHSCode = data.strHSCode ?? " ";
                    vehicle.ATMT = data.ATMT ?? " ";
                    vehicle.iCustomAssesVal = data.iCustomAssesVal;
                    vehicle.iDuty = data.iDuty;
                    vehicle.iCustomValInJPY = data.iCustomValInJPY;
                    listVehicles.Add(vehicle);
                }
            }
            return listVehicles;
        }


        private Vehicles ParserVehicles(dynamic data)
        {
            Vehicles vehicle = new Vehicles();

            if (data != null)
            {
                vehicle.iVehicleID = data.iVehicleID;
                vehicle.iLotNum = data.iLotNum;
                vehicle.strGrade = data.strGrade ?? " ";
                vehicle.strChassisNum = data.strChassisNum ?? " ";
                vehicle.strCategory = data.strCategory ?? " ";
                vehicle.strMake = data.strMake ?? " ";
                vehicle.iModel = data.iModel ?? " ";
                vehicle.iYear = data.iYear ?? " ";
                vehicle.strColor = data.strColor;
                vehicle.dmlKM = data.dmlKM;
                vehicle.strOrigin = data.strOrigin ?? " ";
                vehicle.iDoor = data.iDoor;
                vehicle.strLocation = data.strLocation ?? " ";
                vehicle.weight = data.weight ?? " ";
                vehicle.strHSCode = data.strHSCode ?? " ";
                vehicle.ATMT = data.ATMT ?? " ";
                vehicle.iCustomAssesVal = data.iCustomAssesVal;
                vehicle.iDuty = data.iDuty;
                vehicle.iCustomValInJPY = data.iCustomValInJPY;
            }
            return vehicle;
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
                    mVehicle.iModel = item.iModel ?? " ";
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
                    mVehicle.iDuty = item.iDuty;
                    mVehicle.iCustomValInJPY = item.iCustomValInJPY;
                    listVehicle.Add(mVehicle);
                }
            }
            return listVehicle;
        }


        #endregion


    }
}

