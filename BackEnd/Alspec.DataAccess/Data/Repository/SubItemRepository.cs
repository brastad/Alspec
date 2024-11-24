using Alspec.DataAccess;
using Alspec.DataAccess.Data.Repository;
using Alspec.DataAccess.Data.Repository.IRepository;
using Alspec.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Alspec.DataAccess.Data.Repository
{
    public class SubItemRepository : Repository<SubItem>, ISubItemRepository
    {
        private readonly ApplicationDbContext _db;
        public SubItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       
    }
}

