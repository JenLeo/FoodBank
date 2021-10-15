using ID.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ID.Models
{
    public class PackageRepository : IPackageRepository
    {
        private readonly AppDbContext _context;

        public PackageRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Package> GetPackage()
        {
            return _context.Packages.ToList();
        }
        public IEnumerable<Package> Package
        {
            get
            {
                return _context.Packages.ToList();
            }
        }
        public void UpdatePackage(Package packages)
        {
            _context.Packages.Update(packages);
            _context.SaveChanges();
        }


        public void InsertPackage(Package package)
        {
            _context.Packages.Add(package);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!(_disposed || !disposing))
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task<Package> Create(Package _package)
        {
            var data = new Package
            {
                PackageId = _package.PackageId,
                PackageNameId = _package.PackageNameId,
                PackageDetail = _package.PackageDetail,
                PackageType = _package.PackageType,
                PackagePrice = _package.PackagePrice,
                Pic = _package.Pic
                

            };
            await _context.Packages.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public IQueryable<Package> GetAll()
        {
            return _context.Packages.AsQueryable();
        }

        public async Task<bool> Delete(string id)
        {
            Task<Package> pkTask = _context.Packages.FirstOrDefaultAsync(p => p.PackageId == id);
            Package pk = pkTask.Result;
            if (pk == null)
            {
                return false;
            }

            _context.Remove(pk);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(Package _package)
        {
            Task<Package> pkTask = _context.Packages.FirstOrDefaultAsync(p => p.PackageId == _package.PackageId);
            Package pk = pkTask.Result;
            if (pk == null)
            {
                return false;
            }

            pk.PackageId = _package.PackageId;
            pk.PackageNameId = _package.PackageNameId;
            pk.PackageDetail = _package.PackageDetail;
            pk.PackageType = _package.PackageType;
            pk.PackagePrice = _package.PackagePrice;
            pk.Pic = _package.Pic;
            


            await _context.SaveChangesAsync();
            return true;
        }
    }
}
