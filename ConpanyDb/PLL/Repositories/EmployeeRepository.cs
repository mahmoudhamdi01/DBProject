using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _dbContext;

        public EmployeeRepository(CompanyDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeeByAddress(string address)
         => _dbContext.employees.Where(e => e.Address == address);

        public IQueryable<Employee> GetEmployeeByName(string SearchValue)
         => _dbContext.employees.Where(e => e.Name.ToLower().Contains(SearchValue.ToLower()));
    }
}
