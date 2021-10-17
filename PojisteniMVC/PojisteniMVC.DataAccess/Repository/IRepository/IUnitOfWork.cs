using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojisteniMVC.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPojistenyRepository Pojisteny { get; }
        ISP_Call SP_Call { get; }
        void Save();
    }
}
