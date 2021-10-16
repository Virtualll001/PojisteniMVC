using PojisteniMVC.Data;
using PojisteniMVC.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojisteniMVC.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IPojistenyRepository Pojisteny { get; private set; }
        public ISP_Call SP_Call { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Pojisteny = new PojistenyRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        //o ukládání do databáze se stará UnitOfWork - v Repository tato metoda není!
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
