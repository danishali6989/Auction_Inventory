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
        #endregion
    }
}
