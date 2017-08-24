using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }

        void SaveEmployee(Employee employee);
        void SaveSimpleEmployee(Employee employee);
        Employee DeleteEmployee(int employeeid);
    }
}
