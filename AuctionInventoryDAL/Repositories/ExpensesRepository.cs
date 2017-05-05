using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;

namespace AuctionInventoryDAL.Repositories
{
    public class ExpensesRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public List<MExpense> GetAll()
        {
            List<MExpense> listexpense = new List<MExpense>();
            listexpense = (from r in auctionContext.MExpenses select r).OrderBy(a => a.strExpenseName).ToList();
            return listexpense;
        }
        public MExpense Get(int id)
        {
            MExpense expense = new MExpense();
            expense = auctionContext.MExpenses.Where(a => a.iExpenseID == id).FirstOrDefault();
            return expense;
        }



        public dynamic GetExpenseByVehicleID(int id)
        {
            var listExpense = (from AM in auctionContext.VehicleExpenses
                               join t2 in auctionContext.MExpenses on AM.iExpenseID equals t2.iExpenseID
                               where AM.iVehicleID == id

                               select new
                               {
                                   iVehicleExpenseID = AM.iVehicleExpenseID,
                                   iVehicleID = AM.iVehicleID,
                                   iExpenseID = AM.iExpenseID,
                                   strExpenseName = t2.strExpenseName,
                                   strRemarks = AM.strRemarks,

                                   dcmlExpenseAmount = AM.dcmlExpenseAmount,
                                   dcmlTotalExpenseAmount = AM.dcmlTotalExpenseAmount,

                               }).ToList();
            return listExpense;
        }


        public dynamic GetExpenseByInvoiceID(int id)
        {
            var listExpense = (from AM in auctionContext.VehicleExpenses
                               join t2 in auctionContext.MExpenses on AM.iExpenseID equals t2.iExpenseID
                               where AM.iPurchaseInvoiceID == id

                               select new
                               {
                                   iVehicleExpenseID = AM.iVehicleExpenseID,
                                   iPurchaseInvoiceID = AM.iPurchaseInvoiceID,
                                   strPurchaseInvoiceNo = AM.strPurchaseInvoiceNo,
                                   iExpenseID = AM.iExpenseID,

                                   strExpenseName = t2.strExpenseName,

                                   dcmlExpenseAmount = AM.dcmlExpenseAmount,
                                   dcmlTotalExpenseAmount = AM.dcmlTotalExpenseAmount,

                               }).ToList();

            return listExpense;
        }


        public dynamic VehiclesByInvoiceID(int id)
        {
            var listPurchase = (from t1 in auctionContext.TPurchases
                                //join t2 in dc.MColors on t1.iColor equals t2.iColorID
                                where t1.iPurchaseInvoiceNo == id
                                select new
                                {
                                    iPurchaseInvoiceNo = t1.iPurchaseInvoiceNo,
                                    strPurchaseInvoiceNo = t1.strPurchaseInvoiceNo,
                                    strPurchaseInvoiceDate = t1.strPurchaseInvoiceDate,
                                    NoOfUnits = t1.Vehicles.Count,
                                    strMasterDecNo = t1.strMasterDecNo,
                                    strBLNo = t1.strBLNo
                                    //,strCategory = t1.strCategory

                                }).ToList();
            return listPurchase;
        }

        public dynamic GetSingleVehicleExpensesListData()
        {

            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {

                var preResult = (from AM in dc.VehicleExpenses
                                 join t2 in dc.MExpenses on AM.iExpenseID equals t2.iExpenseID
                                 join t3 in dc.Vehicles on AM.iVehicleID equals t3.iVehicleID
                                 where (AM.iVehicleID != null && AM.iVehicleID != 0)

                                 select new
                            {
                                iVehicleExpenseID = AM.iVehicleExpenseID,

                                strRemarks = AM.strRemarks,

                                iVehicleID = AM.iVehicleID,

                                iExpenseID = AM.iExpenseID,
                                strChassisNum = t3.strChassisNum,
                                strExpenseName = t2.strExpenseName,
                                strExpenseDate = AM.strExpenseDate,

                                dcmlExpenseAmount = AM.dcmlExpenseAmount,
                                dcmlTotalExpenseAmount = AM.dcmlTotalExpenseAmount
                            }).ToList();

                if (preResult.Count > 0)
                {
                    var results = preResult.GroupBy(x => x.iVehicleID).Select(y =>
                                    new
                                    {
                                        iVehicleID = y.Key,
                                        dcmlExpenseAmount = y.Sum(x => x.dcmlExpenseAmount),
                                        strChassisNum = y.First().strChassisNum,
                                        iVehicleExpenseID = y.First().iVehicleExpenseID,
                                        iExpenseID = y.Count(),
                                        strRemarks = y.First().strRemarks,
                                        strExpenseName = y.First().strExpenseName,
                                        strExpenseDate = y.First().strExpenseDate,
                                        dcmlTotalExpenseAmount = y.First().dcmlTotalExpenseAmount,
                                        iSpreadAmountPerVehicle = y.First().dcmlTotalExpenseAmount
                                    }).ToList();


                    var rows = (from singleExp in results
                                select new
                      {
                          id = singleExp.iVehicleExpenseID,
                          cell = new string[] {
               Convert.ToString(singleExp.iVehicleExpenseID),
               Convert.ToString(singleExp.strRemarks),
                Convert.ToString( singleExp.strExpenseName),
                Convert.ToString(singleExp.iVehicleID),
              
               
               Convert.ToString(singleExp.strChassisNum),
               Convert.ToString( singleExp.strExpenseDate),
                Convert.ToString(singleExp.iExpenseID),
               Convert.ToString( singleExp.dcmlExpenseAmount),
               Convert.ToString(singleExp.dcmlTotalExpenseAmount)
               
                        }
                      }).ToArray();


                    var jsonData = new
                    {
                        total = 1,
                        page = 1,
                        records = dc.VehicleExpenses.ToList().Count,
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

        public dynamic GetAllVehicleExpensesByInvoiceID(int id)
        {
            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = dc.VehicleExpenses.ToList().Count,
                    rows = (
                      from vehi in
                          (from AM in dc.VehicleExpenses
                           where AM.iPurchaseInvoiceID == id

                           select new
                           {
                               iVehicleExpenseID = AM.iVehicleExpenseID,
                               iPurchaseInvoiceID = AM.iPurchaseInvoiceID,
                               strPurchaseInvoiceNo = AM.strPurchaseInvoiceNo,
                               iExpenseID = AM.iExpenseID,
                               dcmlExpenseAmount = AM.dcmlExpenseAmount,
                               dcmlTotalExpenseAmount = AM.dcmlTotalExpenseAmount,
                               //iSpreadAmountPerVehicle = AM.dcmlTotalExpenseAmount

                           }).ToList()
                      select new
                      {
                          id = vehi.iVehicleExpenseID,
                          cell = new string[] {
               Convert.ToString(vehi.iVehicleExpenseID),Convert.ToString(vehi.iPurchaseInvoiceID),Convert.ToString(vehi.strPurchaseInvoiceNo),Convert.ToString( vehi.iExpenseID),Convert.ToString( vehi.dcmlExpenseAmount),Convert.ToString(vehi.dcmlTotalExpenseAmount)
                        }
                      }).ToArray()
                };
                return jsonData;
            }
            //return View();
        }




        public dynamic GetAllVehicleExpensesListData()
        {
            using (AuctionInventoryEntities dc = new AuctionInventoryEntities())
            {

                var preResult = (from a in dc.VehicleExpenses
                                 join b in dc.MExpenses on a.iExpenseID equals b.iExpenseID
                                 where (a.iPurchaseInvoiceID != null && a.iPurchaseInvoiceID != 0)
                                 select new
                                 {
                                     iExpenseKey = a.strExpenseKey,
                                     iVehicleExpenseID = a.iVehicleExpenseID,
                                     iExpenseID = a.iExpenseID,

                                     //NoOfExpenses = a.Expenses.Count,

                                     strPurchaseInvoiceNo = a.strPurchaseInvoiceNo,

                                     iPurchaseInvoiceID = a.iPurchaseInvoiceID,
                                     strExpenseDate = a.strExpenseDate,
                                     strExpenseName = b.strExpenseName,
                                     dcmlExpenseAmount = a.dcmlExpenseAmount,
                                     dcmlTotalExpenseAmount = a.dcmlTotalExpenseAmount,
                                     iSpreadAmountPerVehicle = a.dcmlTotalExpenseAmount
                                 }).ToList();
                if (preResult.Count > 0)
                {
                    var results = preResult.GroupBy(x => x.strPurchaseInvoiceNo).Select(y =>
                                    new
                                    {
                                        strPurchaseInvoiceNo = y.Key,
                                        dcmlExpenseAmount = y.Sum(x => x.dcmlExpenseAmount),
                                        iPurchaseInvoiceID = y.First().iPurchaseInvoiceID,
                                        iExpenseKey = y.First().iExpenseKey,
                                        iVehicleExpenseID = y.First().iVehicleExpenseID,
                                        iExpenseID = y.Count(),

                                        //NoOfExpenses = y.NoOfExpenses,

                                        strExpenseDate = y.First().strExpenseDate,
                                        strExpenseName = y.First().strExpenseName,
                                        dcmlTotalExpenseAmount = y.First().dcmlTotalExpenseAmount,
                                        iSpreadAmountPerVehicle = y.First().dcmlTotalExpenseAmount
                                    }).ToList();


                    var rows = (from allExpense in results
                                select new
                                {
                                    id = allExpense.iVehicleExpenseID,
                                    cell = new string[] {
                                     Convert.ToString(allExpense.iVehicleExpenseID),
                                      Convert.ToString( allExpense.strExpenseName),
                                       Convert.ToString(allExpense.iPurchaseInvoiceID),
                                       Convert.ToString(allExpense.strPurchaseInvoiceNo),
                                        Convert.ToString(allExpense.strExpenseDate),
                                     Convert.ToString(allExpense.iExpenseID),
                                    
                                     Convert.ToString( allExpense.dcmlExpenseAmount),
                                     Convert.ToString(allExpense.dcmlTotalExpenseAmount)
                               }
                                }).ToArray();


                    var jsonData = new
                    {
                        total = 1,
                        page = 1,
                        records = dc.VehicleExpenses.ToList().Count,
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



        public dynamic AutoCompleteExpense(string prefix)
        {
            var expenses = (from expense in auctionContext.MExpenses
                            where expense.strExpenseName.StartsWith(prefix)
                            //||
                            //supplier.strEmailID.StartsWith(prefix)||
                            //supplier.strLastName.StartsWith(prefix)
                            select new
                            {
                                strExpenseName = expense.strExpenseName,
                                iExpenseID = expense.iExpenseID
                            }).ToList();


            return expenses;
        }


        public dynamic VehiclesByVehicleID(int id)
        {
            var VehiclesList = (from t1 in auctionContext.Vehicles
                                //join t2 in dc.MColors on t1.iColor equals t2.iColorID
                                where t1.iVehicleID == id
                                select new
                                {
                                    iLotNum = t1.iLotNum,
                                    strChassisNum = t1.strChassisNum,
                                    iModel = t1.iModel,
                                    iYear = t1.iYear,
                                    strColor = t1.strColor,
                                    iCustomValInJPY = t1.iCustomValInJPY


                                });

            return VehiclesList;
        }


        public dynamic AutoCompleteVehicles(string prefix)
        {
            var vehicles = (from vehicle in auctionContext.Vehicles
                            where vehicle.strChassisNum.StartsWith(prefix)
                            //||
                            //supplier.strEmailID.StartsWith(prefix)||
                            //supplier.strLastName.StartsWith(prefix)
                            select new
                            {
                                strChassisNum = vehicle.strChassisNum,
                                iVehicleID = vehicle.iVehicleID
                            }).ToList();

            return vehicles;
        }


        public bool SaveEdit(MExpense expense)
        {
            bool status = false;
            if (expense.iExpenseID > 0)
            {
                //Edit Existing Record
                var exp = auctionContext.MExpenses.Where(a => a.iExpenseID == expense.iExpenseID).FirstOrDefault();
                if (exp != null)
                {
                    exp.strExpenseName = expense.strExpenseName;
                    exp.iPurchaseInvoiceID = expense.iPurchaseInvoiceID;
                    exp.iCategoryID = expense.iCategoryID;
                    exp.iSubCategoryID = expense.iSubCategoryID;
                    exp.dcmlExpenseAmount = expense.dcmlExpenseAmount;

                }
            }
            else
            {
                //Save
                auctionContext.MExpenses.Add(expense);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            var exp = auctionContext.MExpenses.Where(a => a.iExpenseID == id).FirstOrDefault();
            if (exp != null)
            {
                auctionContext.MExpenses.Remove(exp);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }



        //public bool SaveRepoVehicleExpense(List<VehicleExpens> expense, string refenceNumber)
        //{
        //    bool status = false;
        //    {

        //        foreach (var item in expense)
        //        {

        //            if (item.iVehicleExpenseID > 0)
        //            {
        //                var mVehicleExpense = auctionContext.VehicleExpenses.Where(a => a.iVehicleExpenseID == item.iVehicleExpenseID).FirstOrDefault();


        //                if (mVehicleExpense != null)
        //                {


        //                    mVehicleExpense.iPurchaseInvoiceID = item.iPurchaseInvoiceID;

        //                    mVehicleExpense.iVehicleID = item.iVehicleID;

        //                    mVehicleExpense.iExpenseID = item.iExpenseID;
        //                    mVehicleExpense.dcmlExpenseAmount = item.dcmlExpenseAmount;
        //                    mVehicleExpense.dcmlTotalExpenseAmount = item.dcmlTotalExpenseAmount;

        //                    mVehicleExpense.strRemarks = item.strRemarks ?? " ";
        //                   // mVehicleExpense.strExpenseKey = refenceNumber;

        //                    //item.strExpenseKey = refenceNumber;
        //                    //auctionContext.VehicleExpenses.Add(item);

        //                }
        //            }

        //            else
        //            {
        //                //Save
        //                item.strExpenseKey = refenceNumber;
        //                auctionContext.VehicleExpenses.Add(item);
        //            }
        //        }


        //        auctionContext.SaveChanges();
        //    }

        //    status = true;
        //    return status;
        //}


        //public bool SaveRepoSingleVehicleExpense(VehicleExpens expense)
        //{
        //    bool status = false;
        //    {
        //        //Save
        //        auctionContext.VehicleExpenses.Add(expense);

        //    }
        //    auctionContext.SaveChanges();
        //    status = true;
        //    return status;
        //}


        #endregion



        public bool SaveRepoVehicleExpense(List<VehicleExpense> expense, string refenceNumber, int id)
        {
           
            var spreadAmount=(decimal?)0;
            bool status = false;
            {

                
                //for all vehicle expense
                if (id != 0)
                {

                    var vehicleExpID = auctionContext.VehicleExpenses.Where(a => a.iPurchaseInvoiceID == id).ToList();

                    foreach (var item in vehicleExpID)
                    {
                        auctionContext.VehicleExpenses.Remove(item);
                    }

                    auctionContext.SaveChanges();

                }


                //for single vehicle expense
                if (id != 0)
                {

                    var vehicleID = auctionContext.VehicleExpenses.Where(a => a.iVehicleID == id).ToList();

                    foreach (var item in vehicleID)
                    {
                        auctionContext.VehicleExpenses.Remove(item);
                    }
                    auctionContext.SaveChanges();

                }



                //for Spread total expense amount on a particular vehicle 

                var iPurchaseInvoiceID = expense.First().iPurchaseInvoiceID;

                if (iPurchaseInvoiceID != null)
                {
                    var dcmlTotalExpenseAmount = expense.First().dcmlTotalExpenseAmount;

                    var vehicleDataByInvoiceID = (from t1 in auctionContext.TPurchases
                                                  join t2 in auctionContext.Vehicles on t1.PurchaseID equals t2.PurchaseID
                                                  //join t3 in auctionContext.MColors on AM.iColor equals CM.iColorID
                                                  where t1.iPurchaseInvoiceNo == iPurchaseInvoiceID
                                                  // select t2);
                                                  select new
                                                  {
                                                      iVehicleID = t2.iVehicleID,
                                                      NoOfUnits = t1.Vehicles.Count

                                                  }).ToList();

                    spreadAmount = dcmlTotalExpenseAmount / vehicleDataByInvoiceID.FirstOrDefault().NoOfUnits;

                    foreach (var data in vehicleDataByInvoiceID)
                    {
                        if (data.iVehicleID > 0)
                        {
                            //Edit Existing Record
                            var vehi = auctionContext.Vehicles.Where(a => a.iVehicleID == data.iVehicleID).FirstOrDefault();
                            if (vehi != null)
                            {
                                vehi.dcmlExpenseAmount = spreadAmount;
                            }
                        }
                    }
                    //auctionContext.SaveChanges();

                }


                //Save for both
                    foreach (var item in expense)
                    {
                        
                        //Save
                        item.dcmlSpreadAmount = spreadAmount;
                        item.strExpenseKey = refenceNumber;
                        auctionContext.VehicleExpenses.Add(item);
                    }
                   
                }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }
    }
}