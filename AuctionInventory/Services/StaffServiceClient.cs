using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class StaffServiceClient
    {
        public dynamic GetAllStaff()
        {
           
            StaffRepository repo = new StaffRepository();           
            var listStaff = repo.GetAll();
            return listStaff;
        }
        public bool SaveData(Staff staff)
        {
            bool status = true;
            Staff staffs = new Staff();
            StaffRepository repo = new StaffRepository();
            status = repo.SaveEdit(ParserAddStaff(staff));
            return status;
        }

        public Staff GetStaff(int id)
        {

            Staff staffs = new Staff();
            StaffRepository repo = new StaffRepository();
            if (staffs != null)
            {
                staffs = ParserStaff(repo.Get(id));
            }
            return staffs;

        }

        public bool Delete(int id)
        {
            bool status = false;
            StaffRepository repo = new StaffRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser

        private MStaff ParserAddStaff(Staff staff)
        {
            MStaff mStaff = new MStaff();

            if (staff != null)
            {
                mStaff.iStaffID = staff.iStaffID;
                mStaff.strFirstName = staff.strFirstName ?? " ";
                mStaff.strMiddleName = staff.strMiddleName ?? " ";
                mStaff.strLastName = staff.strLastName ?? " ";
                mStaff.iCountryID = staff.iCountryID;
                mStaff.iCityID = staff.iCityID;
                mStaff.strArea = staff.strArea ?? " ";
                mStaff.iPhoneNumber = staff.iPhoneNumber;
                mStaff.strEmailID = staff.strEmailID ?? " ";
               
                mStaff.iIDNO = staff.iIDNO;
                mStaff.strMISC = staff.strMISC ?? " ";
                mStaff.strPassport = staff.strPassport ?? " ";
                mStaff.strPassportExpiry = staff.strPassportExpiry ?? " ";
                mStaff.strVisa = staff.strVisa ?? " ";
                mStaff.strVisaExpiry = staff.strVisaExpiry ?? " ";
                mStaff.strAddress = staff.strAddress ?? " ";
                mStaff.iDesignation = staff.iDesignation;
                mStaff.dmlSalary = staff.dmlSalary;
                mStaff.DOB = staff.DOB ?? " ";
                mStaff.DOJ = staff.DOJ ?? " ";
                mStaff.strRemark = staff.strRemark ?? " ";
            }
            return mStaff;
        }

        private Staff ParserStaff(dynamic data)
        {
            Staff staff = new Staff();

            if (data != null)
            {
               
                staff.iStaffID = data.iStaffID;
                staff.strFirstName = data.strFirstName ?? " ";
                staff.strMiddleName = data.strMiddleName ?? " ";
                staff.strLastName = data.strLastName ?? " ";
                staff.iCountryID = data.iCountryID;
                staff.iCityID = data.iCityID;
                staff.strArea = data.strArea ?? " ";
                staff.iPhoneNumber = data.iPhoneNumber;
                staff.strEmailID = data.strEmailID ?? " ";

                staff.iIDNO = data.iIDNO;
                staff.strMISC = data.strMISC ?? " ";
                staff.strPassport = data.strPassport ?? " ";
                staff.strPassportExpiry = data.strPassportExpiry ?? " ";
                staff.strVisa = data.strVisa ?? " ";
                staff.strVisaExpiry = data.strVisaExpiry ?? " ";
                staff.strAddress = data.strAddress ?? " ";
                staff.iDesignation = data.iDesignation;
                staff.dmlSalary = data.dmlSalary;
                staff.DOB = data.DOB ?? " ";
                staff.DOJ = data.DOJ ?? " ";
                staff.strRemark = data.strRemark ?? " ";
            }
            return staff;
        }
        private List<Staff> ParserGetAllStaff(dynamic responseData)
        {
            List<Staff> listStaff = new List<Staff>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Staff staff = new Staff();
                   
                    staff.iStaffID = data.iStaffID;
                    staff.strFirstName = data.strFirstName ?? " ";
                    staff.strMiddleName = data.strMiddleName ?? " ";
                    staff.strLastName = data.strLastName ?? " ";
                    staff.iCountryID = data.iCountryID;
                    staff.iCityID = data.iCityID;
                    staff.strArea = data.strArea ?? " ";
                    staff.iPhoneNumber = data.iPhoneNumber;
                    staff.strEmailID = data.strEmailID ?? " ";

                    staff.iIDNO = data.iIDNO;
                    staff.strMISC = data.strMISC ?? " ";
                    staff.strPassport = data.strPassport ?? " ";
                    staff.strPassportExpiry = data.strPassportExpiry ?? " ";
                    staff.strVisa = data.strVisa ?? " ";
                    staff.strVisaExpiry = data.strVisaExpiry ?? " ";
                    staff.strAddress = data.strAddress ?? " ";
                    staff.iDesignation = data.iDesignation;
                    staff.dmlSalary = data.dmlSalary;
                    staff.DOB = data.DOB ?? " ";
                    staff.DOJ = data.DOJ ?? " ";
                    staff.strRemark = data.strRemark ?? " ";

                    listStaff.Add(staff);
                }
            }
            return listStaff;
        }

        #endregion
    }
}