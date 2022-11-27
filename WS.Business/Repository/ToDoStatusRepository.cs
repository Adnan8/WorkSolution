using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.Base;
using WS.Business.IRepository;
using WS.Data;
using WS.Domain.Model;

namespace WS.Business.Repository
{
    public class ToDoStatusRepository : Repository<ToDoStatus>, IToDoStatusRepository
    {
        private AppDbContext _db;

        public ToDoStatusRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ToDoStatus obj)
        {
            _db.ToDoStatus.Update(obj);
        }
    }
}
