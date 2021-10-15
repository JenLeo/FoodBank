using ID.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public interface IPackageRepository : IDisposable
    {
        IEnumerable<Package> GetPackage();

        IEnumerable<Package> Package { get; }
        void InsertPackage(Package package);

        void Save();

        Task<Package> Create(Package _package);
        Task<bool> Update(Package _package);
        void UpdatePackage(Package packages);
        Task<bool> Delete(string id);
        IQueryable<Package> GetAll();
    }
}
