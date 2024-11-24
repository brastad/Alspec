using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Alspec.DataAccess.Data.Repository.IRepository;
using Alspec.Models.Entities;

namespace Alspec.DataAccess.Data.Repository.IRepository
{
    public interface ISubItemRepository : IRepository<SubItem>
    {
    }
}

