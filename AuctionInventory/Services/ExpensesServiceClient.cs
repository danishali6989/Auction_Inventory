using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class ExpensesServiceClient
    {
        public List<Expenses> GetAllExpenses()
        {
            List<Expenses> listExpenses = new List<Expenses>();
            ExpensesRepository repo = new ExpensesRepository();
            dynamic expenses = repo.GetAll();
            listExpenses = ParserGetAllExpenses(expenses);
            return listExpenses;
        }
        public bool SaveData(Expenses expenses)
        {
            bool status = true;
            Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.SaveEdit(ParserAddExpenses(expenses));
            return status;
        }

        public Expenses GetExpenses(int id)
        {

            Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();
            if (expense != null)
            {
                expense = ParserExpenses(repo.Get(id));
            }
            return expense;

        }

        public bool Delete(int id)
        {
            bool status = false;
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.Delete(id);
            return status;
        }



        public bool SaveDataAllVehicleExpense(List<AllVehicleExpenseModel> expenses)
        {
            bool status = true;
            //Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.SaveRepoAllVehicleExpense(ParserAddAllVehicleExpenses(expenses));
            return status;
        }


        public bool SaveDataSingleVehicleExpense(SingleVehicleExpenseModel expenses)
        {
            bool status = true;
            //Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.SaveRepoSingleVehicleExpense(ParserAddSingleVehicleExpenses(expenses));
            return status;
        }

        #region Parser

        private MExpense ParserAddExpenses(Expenses expenses)
        {
            MExpense expense = new MExpense();

            if (expenses != null)
            {
                expense.iExpenseID = expenses.iExpenseID;
                expense.strExpenseName = expenses.strExpenseName ?? " ";
                expense.iPurchaseInvoiceID = expenses.iPurchaseInvoiceID;
                expense.iCategoryID = expenses.iCategoryID;
                expense.iSubCategoryID = expenses.iSubCategoryID;
                expense.iExpenseAmount = expenses.iExpenseAmount;
            }
            return expense;
        }

        private Expenses ParserExpenses(dynamic data)
        {
            Expenses expenses = new Expenses();

            if (data != null)
            {
                expenses.iExpenseID = data.iExpenseID ?? -1;
                expenses.strExpenseName = data.strExpenseName ?? " ";
                expenses.iPurchaseInvoiceID = data.iPurchaseInvoiceID ?? -1;

                expenses.iCategoryID = data.iCategoryID ?? -1;
                expenses.iSubCategoryID = data.iSubCategoryID ?? -1;
                expenses.iExpenseAmount = data.iExpenseAmount ?? -1;
            }
            return expenses;
        }
        private List<Expenses> ParserGetAllExpenses(dynamic responseData)
        {
            List<Expenses> listExpenses = new List<Expenses>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Expenses expenses = new Expenses();
                    // supplier.FullName = data.FullName;
                    expenses.iExpenseID = data.iExpenseID ?? -1;
                    expenses.strExpenseName = data.strExpenseName ?? " ";
                    expenses.iPurchaseInvoiceID = data.iPurchaseInvoiceID ?? -1;
                    expenses.iCategoryID = data.iCategoryID ?? -1;
                    expenses.iSubCategoryID = data.iSubCategoryID ?? -1;
                    expenses.iExpenseAmount = data.iExpenseAmount ?? -1;
                    listExpenses.Add(expenses);
                }
            }
            return listExpenses;
        }

        private List<AllVehicleExpense> ParserAddAllVehicleExpenses(List<AllVehicleExpenseModel> expenses)
        {
            List<AllVehicleExpense> listAllVehicleExpense = new List<AllVehicleExpense>();
            foreach (var item in expenses)
            {


                if (expenses != null)
                {
                    AllVehicleExpense mVehicleExpense = new AllVehicleExpense();
                    mVehicleExpense.iAllVehicleExpenseID = item.iAllVehicleExpenseID;
                    mVehicleExpense.iPurchaseInvoiceID = item.iPurchaseInvoiceID;
                    mVehicleExpense.iExpenseID = item.iExpenseID;
                    mVehicleExpense.iExpenseAmount = item.iExpenseAmount;
                    mVehicleExpense.iTotalExpenseAmounrt = item.iTotalExpenseAmounrt;
                    listAllVehicleExpense.Add(mVehicleExpense);
                }
            }
            return listAllVehicleExpense;
        }

        private SingleVehicleExpense ParserAddSingleVehicleExpenses(SingleVehicleExpenseModel expenses)
        {
            SingleVehicleExpense expense = new SingleVehicleExpense();

            if (expenses != null)
            {
                expense.iSingleVehicleID = expenses.iSingleVehicleID;
                expense.iVehicleID = expenses.iVehicleID;
                expense.iExpenseID = expenses.iExpenseID;
                expense.iExpenseAmount = expenses.iExpenseAmount;
                expense.iTotalExpenseAmounrt = expenses.iTotalExpenseAmounrt;
                expense.strRemarks = expenses.strRemarks ?? " ";
                
            }
            return expense;
        }

        #endregion
    }
}