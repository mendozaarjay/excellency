﻿using Excellency.Interfaces;
using Excellency.Models;
using System;
using System.Collections.Generic;

namespace Excellency.Services
{
    public class BranchService : IBranch
    {
        public void Add(Branch branch)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Branch> Branches()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> Companies()
        {
            throw new NotImplementedException();
        }

        public Branch GetBranchById(int id)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyPerBranch(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Branch branch)
        {
            throw new NotImplementedException();
        }
    }
}