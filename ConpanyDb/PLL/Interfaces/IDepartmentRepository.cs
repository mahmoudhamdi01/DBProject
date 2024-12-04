﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDepartmentRepository : IGenericRepositories<Department>
    {

        IQueryable<Department> GetEmployeeByName(string SearchValue);

    }
}