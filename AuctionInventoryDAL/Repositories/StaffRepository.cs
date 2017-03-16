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

        public List<MStaff> GetAll()
        {
            List<MStaff> listStaff = new List<MStaff>();
            listStaff = (from r in auctionContext.MStaffs select r).OrderBy(a => a.strFirstName).ToList();
            return listStaff;
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
                    staffs.strNationalityAddress = staff.strNationalityAddress;
                    staffs.iNationality = staff.iNationality;
                    staffs.iNationalityContact = staff.iNationalityContact;
                    staffs.strEmailID = staff.strEmailID;
                    staffs.iIDNO = staff.iIDNO;
                    staffs.strMISC = staff.strMISC;
                    staffs.strPassport = staff.strPassport;
                    staffs.strPassportExpiry = staff.strPassportExpiry;
                    staffs.strVisa = staff.strVisa;
                    staffs.strVisaExpiry = staff.strVisaExpiry;
                    staffs.strCurrentAddress = staff.strCurrentAddress;
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
