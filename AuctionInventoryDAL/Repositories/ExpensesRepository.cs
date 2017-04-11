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

        public dynamic VehiclesByInvoiceID(int id)
        {
            var listPurchase = (from t1 in auctionContext.TPurchases
                                //join t2 in dc.MColors on t1.iColor equals t2.iColorID
                                where t1.iPurchaseInvoiceNo == id
                                select new
                                {
                                    iPurchaseInvoiceNo = t1.iPurchaseInvoiceNo,
                                    strPurchaseInvoiceDate = t1.strPurchaseInvoiceDate,
                                    NoOfUnits = t1.Vehicles.Count,
                                    strMasterDecNo = t1.strMasterDecNo,
                                    strBLNo = t1.strBLNo
                                    //,strCategory = t1.strCategory

                                }).ToList();
            return listPurchase;
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
                    exp.iExpenseAmount = expense.iExpenseAmount;

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



        public bool SaveRepoVehicleExpense(List<VehicleExpens> expense, string refenceNumber)
        {
            bool status = false;
            {

                foreach (var item in expense)
                {

                    if (item.iVehicleExpenseID > 0)
                    {
                        var mVehicleExpense = auctionContext.VehicleExpenses.Where(a => a.iVehicleExpenseID == item.iVehicleExpenseID).FirstOrDefault();


                        if (mVehicleExpense != null)
                        {


                            mVehicleExpense.iPurchaseInvoiceID = item.iPurchaseInvoiceID;

                            mVehicleExpense.iVehicleID = item.iVehicleID;

                            mVehicleExpense.iExpenseID = item.iExpenseID;
                            mVehicleExpense.iExpenseAmount = item.iExpenseAmount;
                            mVehicleExpense.iTotalExpenseAmounrt = item.iTotalExpenseAmounrt;

                            mVehicleExpense.strRemarks = item.strRemarks ?? " ";
                           // mVehicleExpense.strExpenseKey = refenceNumber;
                            
                            //item.strExpenseKey = refenceNumber;
                            //auctionContext.VehicleExpenses.Add(item);

                        }
                    }
                    
                    else
                    {
                        //Save
                        item.strExpenseKey = refenceNumber;
                        auctionContext.VehicleExpenses.Add(item);
                    }
                }

               
                auctionContext.SaveChanges();
            }

            status = true;
            return status;
        }


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
    }
}
