using PojisteniMVC.Data;
using PojisteniMVC.DataAccess.Repository.IRepository;
using PojisteniMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojisteniMVC.DataAccess.Repository
{
    public class PojistenyRepository : Repository<Pojisteny>, IPojistenyRepository
    {
        private readonly ApplicationDbContext _db;
        public PojistenyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Pojisteny pojisteny)
        {
            var objFromDb = _db.PojisteneOsoby.FirstOrDefault(s => s.PojistenyId == pojisteny.PojistenyId);
            if (objFromDb != null)
            {
                objFromDb.Jmeno = pojisteny.Jmeno;
                objFromDb.Prijmeni = pojisteny.Prijmeni;
                objFromDb.Adresa = pojisteny.Adresa;
                _db.SaveChanges();
            }
        }
    }
}
