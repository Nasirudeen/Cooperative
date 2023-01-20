using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooprtaiveApps.Models;


namespace CooprtaiveApps.Models
{
    public interface ICooperativeRepository
    {
        
        IQueryable<Thrift> Thrifts { get; }

        IQueryable<Employee> Employees { get; }
        IQueryable<Department> Departments { get; }

        IQueryable<User> Users { get; }

        IQueryable<Role> Roles { get; }


       
        public void AddThrift(Thrift d);
       
        public void AddRole(Role f);
       

        public void AddUser(User q);


        public void AddDepartment(Department f);


        public void AddEmployee(Employee q);









        public void Save();

      
    }
}

