using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Employee> Employees
        {
            get { return context.Employees; }
        }

        public void SaveEmployee(Employee employee)
        {
            if (employee.EmployeeID == 0)
            {
                employee.EmployeeStatus = true;
                employee.EmployeeDate = DateTime.Now;
                context.Employees.Add(employee);
            }
            else
            {
                Employee dbEntry = context.Employees.Find(employee.EmployeeID);
                if (dbEntry != null)
                {
                    dbEntry.EmployeeName = employee.EmployeeName;
                    dbEntry.EmployeeDescription = employee.EmployeeDescription;
                    dbEntry.EmployeeSpecial = employee.EmployeeSpecial;
                    dbEntry.EmployeeImageData = employee.EmployeeImageData;
                    dbEntry.EmployeeMimeType = employee.EmployeeMimeType;
                    dbEntry.EmployeeStatus = true;
                }
            }
            context.SaveChanges();
        }

        public void SaveSimpleEmployee(Employee employee)
        {
            if (employee.EmployeeID == 0)
            {
                employee.EmployeeStatus = true;
                employee.EmployeeDate = DateTime.Now;
                context.Employees.Add(employee);
            }
            else
            {
                Employee dbEntry = context.Employees.Find(employee.EmployeeID);
                if (dbEntry != null)
                {
                    dbEntry.EmployeeName = employee.EmployeeName;
                    dbEntry.EmployeeDescription = employee.EmployeeDescription;
                    dbEntry.EmployeeSpecial = employee.EmployeeSpecial;
                    dbEntry.EmployeeStatus = true;
                }
            }
            context.SaveChanges();
        }

        public Employee DeleteEmployee(int employeeid)
        {
            Employee dbEntry = context.Employees.Find(employeeid);
            if (dbEntry != null)
            {
                dbEntry.EmployeeStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
