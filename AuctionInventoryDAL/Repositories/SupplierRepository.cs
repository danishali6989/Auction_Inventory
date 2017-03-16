using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;
using System.Net.Mail;
using System.Net;

namespace AuctionInventoryDAL.Repositories
{
    public class SupplierRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public List<MSupplier> GetAll()
        {
            List<MSupplier> listsupplier = new List<MSupplier>();
            listsupplier = (from r in auctionContext.MSuppliers select r).OrderBy(a => a.strFirstName).ToList();
            return listsupplier;
        }

        public MSupplier Get(int id)
        {
            MSupplier supplier = new MSupplier();
            supplier = auctionContext.MSuppliers.Where(a => a.iSupplierID == id).FirstOrDefault();
            return supplier;
        }

        public bool SaveEdit(MSupplier supplier, string password)
        {
            bool status = false;
            if (supplier.iSupplierID > 0)
            {
                //Edit Existing Record
                var supp = auctionContext.MSuppliers.Where(a => a.iSupplierID == supplier.iSupplierID).FirstOrDefault();
                if (supp != null)
                {
                    supp.strFirstName = supplier.strFirstName;
                    supp.strMiddleName = supplier.strMiddleName;
                    supp.strLastName = supplier.strLastName;
                    supp.iSupplierCategory = supplier.iSupplierCategory;
                    supp.iSupplierServiceType = supplier.iSupplierServiceType;
                    supp.strEmailID = supplier.strEmailID;
                    supp.iPhoneNumber = supplier.iPhoneNumber;
                    supp.strAddress = supplier.strAddress;
                    supp.iPincode = supplier.iPincode;
                    supp.iCurrency = supplier.iCurrency;
                    supp.SupplierPhoto = supplier.SupplierPhoto;
                    supp.SupplierDate = supplier.SupplierDate;
                    auctionContext.SaveChanges();
                }
            }
            else
            {
                //Save
                auctionContext.MSuppliers.Add(supplier);
                auctionContext.SaveChanges();
                SendEmail(supplier, password);
            }
            //  auctionContext.SaveChanges();

            status = true;
            return status;
        }

        public bool SendEmail(MSupplier supplier, string password)
        {
            bool status = false;


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("shahzadq0077@gmail.com");
            mail.To.Add("shahzadq58@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "Your Login ID Is   " + supplier.strEmailID + " And Your Password Is  " + password;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("auctioninventorydubai@gmail.com", "smart123");
            SmtpServer.EnableSsl = true;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Send(mail);
            SmtpServer.Dispose();



            //using (MailMessage mm = new MailMessage("shahzadq0077@gmail.com", supplier.strEmailID))
            //{
            //    // Now access this
            //    // string password = supplier.Password;
            //    mm.Subject = "static...........";
            //    mm.Body = "Your Login ID Is   " + supplier.strEmailID + " And Your Password Is  " + password;

            //    //if (model.Attachment.ContentLength > 0)
            //    //{
            //    //    string fileName = Path.GetFileName(model.Attachment.FileName);
            //    //    mm.Attachments.Add(new Attachment(model.Attachment.InputStream, fileName));
            //    //}
            //    mm.IsBodyHtml = false;
            //    using (SmtpClient smtp = new SmtpClient())
            //    {
            //        smtp.Host = "smtp.gmail.com";
            //        smtp.EnableSsl = true;
            //        NetworkCredential NetworkCred = new NetworkCredential("auctioninventorydubai@gmail.com", "smart123");
            //        smtp.UseDefaultCredentials = true;
            //        smtp.Credentials = NetworkCred;
            //        smtp.Port = 587;
            //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //        smtp.Send(mm);
            //        smtp.Dispose();

            //    }
            //}
            status = true;
            return status;

        }

        public bool Delete(int id)
        {
            bool status = false;
            var supp = auctionContext.MSuppliers.Where(a => a.iSupplierID == id).FirstOrDefault();
            if (supp != null)
            {
                auctionContext.MSuppliers.Remove(supp);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }



        #endregion

    }
}
