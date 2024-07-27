using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApiPostgreSqlCrudAPIs.Model
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int Department { get; set; }
        public string DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }


    }
}
