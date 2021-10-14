﻿using ID.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    internal interface IPackageRepository : IDisposable
    {
        IEnumerable<Packages> GetPackage();

        void InsertPackage(Packages package);

        void Save();

        Task<Packages> Create(Packages _package);
        Task<bool> Update(Packages _package);
        Task<bool> Delete(string id);
        IQueryable<Packages> GetAll();
    }
}
