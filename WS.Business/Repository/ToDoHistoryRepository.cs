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
    public class ToDoHistoryRepository : Repository<ToDoHistory>, IToDoHistoryRepository
    {
        private AppDbContext _db;

        public ToDoHistoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ToDoHistory obj)
        {
            _db.ToDoHistory.Update(obj);
        }
    }
}
