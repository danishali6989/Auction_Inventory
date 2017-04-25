using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;

namespace AuctionInventoryDAL.Repositories
{
    public class StaffRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public dynamic GetAll()
        {
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = auctionContext.MStaffs.ToList().Count,
                rows = (
                  from staff in
                      (from AM in auctionContext.MStaffs

                       join t1 in auctionContext.MCountries on AM.iCountryID equals t1.iCountry
                       join t2 in auctionContext.MCities on AM.iCityID equals t2.iCity

                       select new
                       {
                           iStaffID = AM.iStaffID,
                           strFirstName = AM.strFirstName,
                           strLastName = AM.strLastName,
                           strCountryName = t1.strCountryName,
                           strCityName = t2.strCityName,
                           strArea = AM.strArea,
                           iPhoneNumber = AM.iPhoneNumber,
                           strEmailID = AM.strEmailID,
                           //iIDNO = AM.iIDNO,
                           //strMISC = AM.strMISC,
                           strPassport = AM.strPassport,
                           strPassportExpiry = AM.strPassportExpiry,
                           strVisa = AM.strVisa,
                           strVisaExpiry = AM.strVisaExpiry,
                           DOB = AM.DOB,
                           DOJ = AM.DOJ,
                           strAddress = AM.strAddress,
                           iDesignation = AM.iDesignation,
                           //dmlSalary = AM.dmlSalary,                          
                           //strRemark = AM.strRemark

                       }).OrderBy(a => a.strFirstName).ToList()
                  select new
                  {
                      id = staff.iStaffID,
                      cell = new string[] {
               Convert.ToString(staff.iStaffID),Convert.ToString(staff.strFirstName+" "+staff.strLastName),
               Convert.ToString(staff.strCountryName),Convert.ToString(staff.strCityName),
               Convert.ToString(staff.strArea),Convert.ToString(staff.iPhoneNumber),Convert.ToString(staff.strEmailID),
               //Convert.ToString(staff.iIDNO),Convert.ToString(staff.strMISC),
               Convert.ToString(staff.strPassport),Convert.ToString(staff.strPassportExpiry),
                  Convert.ToString(staff.strVisa), Convert.ToString(staff.strVisaExpiry),
                    Convert.ToString(staff.DOB),Convert.ToString(staff.DOJ),
              Convert.ToString(staff.strAddress),
               Convert.ToString(staff.iDesignation)
               //,Convert.ToString(staff.dmlSalary),Convert.ToString(staff.strRemark)
               
                      }
                  }).ToArray()
            };
            return jsonData;
        }
        public MStaff Get(int id)
        {
            MStaff staff = new MStaff();
            staff = auctionContext.MStaffs.Where(a => a.iStaffID == id).FirstOrDefault();
            return staff;
        }
        public bool SaveEdit(MStaff staff)
        {
            bool status = false;
            if (staff.iStaffID > 0)
            {
                //Edit Existing Record
                var staffs = auctionContext.MStaffs.Where(a => a.iStaffID == staff.iStaffID).FirstOrDefault();
                if (staffs != null)
                {
                   
                    staffs.strFirstName = staff.strFirstName;
                    staffs.strMiddleName = staff.strMiddleName;
                    staffs.strLastName = staff.strLastName;
                    staffs.iCountryID = staff.iCountryID;
                    staffs.iCityID = staff.iCityID;
                    staffs.strArea = staff.strArea ;
                    staffs.iPhoneNumber = staff.iPhoneNumber;
                    staffs.strEmailID = staff.strEmailID;

                    staffs.iIDNO = staff.iIDNO;
                    staffs.strMISC = staff.strMISC ;
                    staffs.strPassport = staff.strPassport;
                    staffs.strPassportExpiry = staff.strPassportExpiry;
                    staffs.strVisa = staff.strVisa;
                    staffs.strVisaExpiry = staff.strVisaExpiry;
                    staffs.strAddress = staff.strAddress;
                    staffs.iDesignation = staff.iDesignation;
                    staffs.dmlSalary = staff.dmlSalary;
                    staffs.DOB = staff.DOB;
                    staffs.DOJ = staff.DOJ;
                    staffs.strRemark = staff.strRemark;


                }
            }
            else
            {
                //Save
                auctionContext.MStaffs.Add(staff);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }
        public bool Delete(int id)
        {
            bool status = false;
            var staff = auctionContext.MStaffs.Where(a => a.iStaffID == id).FirstOrDefault();
            if (staff != null)
            {
                auctionContext.MStaffs.Remove(staff);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }
        #endregion

    }
}
