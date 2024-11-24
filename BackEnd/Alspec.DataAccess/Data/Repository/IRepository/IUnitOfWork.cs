using System;
using System.Collections.Generic;
using System.Text;
using Alspec.DataAccess.Data.Repository.IRepository;

namespace Alspec.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository Job { get; }
        ISubItemRepository SubItem { get; }
        void Save();
    }
}
