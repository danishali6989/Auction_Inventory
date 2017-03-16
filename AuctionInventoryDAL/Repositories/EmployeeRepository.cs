using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;

namespace AuctionInventoryDAL.Repositories
{
    public class EmployeeRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public List<Employee> GetAll()
        {
            List<Employee> listEmployee = new List<Employee>();
            listEmployee = (from r in auctionContext.Employees select r).OrderBy(a => a.FirstName).ToList();
            return listEmployee;
        }
        public Employee Get(int id)
        {
            Employee employee = new Employee();
            employee = auctionContext.Employees.Where(a => a.EmployeeID == id).FirstOrDefault();
            return employee;
        }
        public bool SaveEdit(AuctionInventoryDAL.Entity.Employee employee)
        {
            bool status = false;
            if (employee.EmployeeID > 0)
            {
                //Edit Existing Record
                var v = auctionContext.Employees.Where(a => a.EmployeeID == employee.EmployeeID).FirstOrDefault();
                if (v != null)
                {
                    v.FirstName = employee.FirstName;
                    v.LastName = employee.LastName;
                    v.EmailID = employee.EmailID;
                    v.City = employee.City;
                    v.Country = employee.Country;
                }
            }
            else
            {
                //Save
                auctionContext.Employees.Add(employee);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }
        public bool DeleteEmployee(int id)
        {
            bool status = false;
            var v = auctionContext.Employees.Where(a => a.EmployeeID == id).FirstOrDefault();
            if (v != null)
            {
                auctionContext.Employees.Remove(v);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }
        #endregion
    }
}
