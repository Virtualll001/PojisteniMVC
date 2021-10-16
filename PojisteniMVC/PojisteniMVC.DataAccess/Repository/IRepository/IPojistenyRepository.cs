using PojisteniMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojisteniMVC.DataAccess.Repository.IRepository
{
    public interface IPojistenyRepository : IRepository<Pojisteny>
    {
        void Update(Pojisteny pojisteny);
    }
}
