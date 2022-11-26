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
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        private AppDbContext _db;

        public ToDoRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ToDo obj)
        {
            _db.ToDo.Update(obj);
        }
    }
}
