using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.IO;
using System.Threading;

namespace AuctionInventoryDAL.Repositories
{
    public class SupplierRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

      
        public dynamic GetAll()
        {
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = auctionContext.MSuppliers.ToList().Count,
                rows = (
                  from supplier in
                      (from AM in auctionContext.MSuppliers
                       join t1 in auctionContext.MCurrencies on AM.iCurrency equals t1.CurrencyID
                      // join t2 in auctionContext.MCategories on AM.iSupplierCategory equals t2.iCategoryID


                       select new
                       {
                           SupplierPhoto = AM.SupplierPhoto,
                           iSupplierID = AM.iSupplierID,
                           strFirstName = AM.strFirstName,
                           strLastName = AM.strLastName,

                           //iSupplierServiceType = AM.iSupplierServiceType,
                           //iSupplierCategory = AM.iSupplierCategory,

                           iPhoneNumber = AM.iPhoneNumber,
                           strEmailID = AM.strEmailID,

                           strAddress = AM.strAddress,
                           SupplierDate = AM.SupplierDate,
                           strCurrencyName = t1.strCurrencyName,
                           //strCategoryName = t2.strCategoryName,

                           iPersonPhoneNumber = AM.iPersonPhoneNumber,
                           strPersonEmailID = AM.strPersonEmailID,
                           strCompanyName = AM.strCompanyName,
                           strWebsites = AM.strWebsites,
                           //iOfcPhoneNumber = AM.iOfcPhoneNumber,

                       }).OrderBy(a => a.strFirstName).ToList()
                  select new
                  {
                      id = supplier.iSupplierID,
                      cell = new string[] {
               Convert.ToString(supplier.iSupplierID),
               Convert.ToString(supplier.SupplierPhoto),
                Convert.ToString(supplier.strCompanyName),
               
                  //Convert.ToString(supplier.iOfcPhoneNumber),
               //Convert.ToString(supplier.strFirstName+" "+supplier.strLastName),             
              Convert.ToString(supplier.iPhoneNumber),Convert.ToString(supplier.strEmailID),
              Convert.ToString(supplier.strAddress),  Convert.ToString(supplier.strWebsites),
              Convert.ToString(supplier.SupplierDate), Convert.ToString(supplier.strCurrencyName)
              //, Convert.ToString(supplier.strCategoryName)
                      }
                  }).ToArray()
            };
            return jsonData;
        }


        public MSupplier Get(int id)
        {
            MSupplier supplier = new MSupplier();
            supplier = auctionContext.MSuppliers.Where(a => a.iSupplierID == id).FirstOrDefault();
            return supplier;
        }

        public bool SaveEdit(MSupplier supplier, HttpPostedFileBase file, string password)
        {
            bool status = false;
            if (supplier.iSupplierID > 0)
            {
                if (supplier.strPicName != null && supplier.strPicName.Length>0)
                {
                    //string pic = System.IO.Path.GetFileName(file.FileName);


                    string pic = supplier.strPicName;

                    string path = @"..\Images\Profiles\" + pic;



                    file.SaveAs(System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/Profiles"), pic));

                    supplier.SupplierPhoto = path;
                    // auctionContext.SaveChanges();
                }

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


                    supp.iPersonPhoneNumber = supplier.iPersonPhoneNumber;
                    supp.strPersonEmailID = supplier.strPersonEmailID;
                    supp.strCompanyName = supplier.strCompanyName;
                    supp.strWebsites = supplier.strWebsites;
                  
                    auctionContext.SaveChanges();
                }
            }
            else
            {
                //Save

                //save image into database


                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    //string path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/Profiles"), pic);


                    string path = @"..\Images\Profiles\" + pic;



                    file.SaveAs(System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/Profiles"), pic));

                    supplier.SupplierPhoto = path;
                    // auctionContext.SaveChanges();
                }

                auctionContext.MSuppliers.Add(supplier);
                auctionContext.SaveChanges();
                SendEmail(supplier, password);
            }
            //  auctionContext.SaveChanges();

            status = true;
            return status;
        }

        //public  bool SendEmail(MSupplier supplier, string password)
        //{
        //    bool status = false;


        //    MailMessage mail = new MailMessage();
        //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

        //    mail.From = new MailAddress("shahzadq0077@gmail.com");
        //    mail.To.Add("shahzadq58@gmail.com");
        //    mail.Subject = "Test Mail";
        //    mail.Body = "Your Login ID Is   " + supplier.strEmailID + " And Your Password Is  " + password;

        //    SmtpServer.Port = 587;
        //    SmtpServer.Credentials = new System.Net.NetworkCredential("auctioninventorydubai@gmail.com", "smart123");
        //    SmtpServer.EnableSsl = true;
        //    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    SmtpServer.Send(mail);
        //    SmtpServer.Dispose();

        //    status = true;
        //    return status;

        //}



        //public  async Task SendEmail(MSupplier supplier, string password)
        //{

        //    using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.From = new MailAddress("shahzadq0077@gmail.com");
        //        mail.To.Add("shahzadq58@gmail.com");
        //        mail.Subject = "Test Mail";
        //        mail.Body = "Your Login ID Is   " + supplier.strEmailID + " And Your Password Is  " + password;

        //        smtpClient.Port = 587;
        //        smtpClient.Credentials = new System.Net.NetworkCredential("auctioninventorydubai@gmail.com", "smart123");
        //        smtpClient.EnableSsl = true;
        //        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        await smtpClient.SendMailAsync(mail);
        //        //smtpClient.Dispose();

        //    }


        //} 


        private void SendEmail(MSupplier supplier, string password)
        {
            Thread email = new Thread(delegate()
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("shahzadq0077@gmail.com");
                    mail.To.Add("shahzadq58@gmail.com");
                    mail.Subject = "Test Mail";
                    mail.Body = "Your Login ID Is   " + supplier.strEmailID + " And Your Password Is  " + password;

                    smtpClient.Port = 587;
                    smtpClient.Credentials = new System.Net.NetworkCredential("auctioninventorydubai@gmail.com", "smart123");
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Send(mail);
                    //smtpClient.Dispose();

                }
            });

            email.IsBackground = true;
            email.Start();

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




        public dynamic RetrieveImage(int id)
        {

            var cover = (from supplier in auctionContext.MSuppliers
                         where supplier.iSupplierID == id
                         select new
                         {
                             supplier.SupplierPhoto,
                             supplier.strPicName
                         }).FirstOrDefault();

            return cover;
           

        }
        //public byte[] ConvertToBytes(HttpPostedFileBase image)
        //{
        //    byte[] imageBytes = null;
        //    BinaryReader reader = new BinaryReader(image.InputStream);
        //    imageBytes = reader.ReadBytes((int)image.ContentLength);
        //    return imageBytes;
        //}

        //public byte[] GetImageFromDataBase(int Id)
        //{
        //    var q = from supplier in auctionContext.MSuppliers where supplier.iSupplierID == Id select supplier.SupplierPhoto;
        //    byte[] cover = q.First();
        //    return cover;
        //}
        #endregion

    }
}
