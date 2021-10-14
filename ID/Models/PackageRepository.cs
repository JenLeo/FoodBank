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

        public IEnumerable<Packages> GetPackage()
        {
            return _context.Package1.ToList();
        }

        public void InsertPackage(Packages package)
        {
            _context.Package1.Add(package);
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
        public async Task<Packages> Create(Packages _package)
        {
            var data = new Packages
            {
                PackageID = _package.PackageID,
                PackageNameId = _package.PackageNameId,
                PackageDetail = _package.PackageDetail,
                PackageType = _package.PackageType,
                PackagePrice = _package.PackagePrice
                

            };
            await _context.Package1.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public IQueryable<Packages> GetAll()
        {
            return _context.Package1.AsQueryable();
        }

        public async Task<bool> Delete(string id)
        {
            Task<Packages> pkTask = _context.Package1.FirstOrDefaultAsync(p => p.PackageID == id);
            Packages pk = pkTask.Result;
            if (pk == null)
            {
                return false;
            }

            _context.Remove(pk);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(Packages _package)
        {
            Task<Packages> pkTask = _context.Package1.FirstOrDefaultAsync(p => p.PackageID == _package.PackageID);
            Packages pk = pkTask.Result;
            if (pk == null)
            {
                return false;
            }

            pk.PackageID = _package.PackageID;
            pk.PackageNameId = _package.PackageNameId;
            pk.PackageDetail = _package.PackageDetail;
            pk.PackageType = _package.PackageType;
            pk.PackagePrice = _package.PackagePrice;
            


            await _context.SaveChangesAsync();
            return true;
        }
    }
}
