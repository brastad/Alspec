using Alspec.DataAccess.Data.Repository.IRepository;
using Alspec.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Alspec.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Job = new JobRepository(_db);
            SubItem = new SubItemRepository(_db);
            
        }

        public IJobRepository Job { get; private set; }
        public ISubItemRepository SubItem { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }
       
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
