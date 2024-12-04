using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly CompanyDbContext _dbContext;

        public DepartmentRepository(CompanyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
       

        public IQueryable<Department> GetEmployeeByName(string SearchValue)
           => _dbContext.departments.Where(e => e.Name.ToLower().Contains(SearchValue.ToLower()));

    }
}
