using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooperativeApplication.Models;
using CooprtaiveApps.Models;


namespace CooprtaiveApps.Models
{
    public class CooperativeRepository : ICooperativeRepository
    {
        private CooperativeDbContext context;

        public CooperativeRepository(CooperativeDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Employee> Employees => context.Employees;
        public IQueryable<Thrift> Thrifts => context.Thrifts;
      
        public IQueryable<Department> Departments => context.Departments;
       
        public IQueryable<Role> Roles => context.Roles;

       
        public IQueryable<User> Users => context.Users;

        //    public IQueryable<Porter> Porters => throw new NotImplementedException();

        // public IQueryable<Porter> Porters => throw new NotImplementedException();



      
        public void AddThrift(Thrift a)
        {
            context.Thrifts.Add(a);
        }

       

        public void AddUser(User b)
        {
            context.Users.Add(b);
        }
       
        public void AddRole(Role s)
        {
            context.Roles.Add(s);
        }
        public void AddDepartment(Department s)
        {
            context.Departments.Add(s);
        }


        public void Save()
        {
            context.SaveChanges();

        }

        public void Employee(Employee d)
        {
            throw new NotImplementedException();
        }

        public void Department(Department d)
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(Employee q)
        {
            throw new NotImplementedException();
        }
    }
}

