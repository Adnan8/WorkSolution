using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.IRepository;
using WS.Business.Repository;
using WS.Data;
using WS.Domain.Model.IdentityModel;

namespace WS.Business.Base
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private AppDbContext _db;

        public UnitOfWorkRepository(AppDbContext db)
        {
            _db = db;
            ToDo = new ToDoRepository(_db);
            ToDoHistory = new ToDoHistoryRepository(_db);
            ToDoStatus = new ToDoStatusRepository(_db);
        }
        public IToDoHistoryRepository ToDoHistory
        {
            get; private set;
        }
        public IToDoRepository ToDo
        {
            get; private set;
        }
        public IToDoStatusRepository ToDoStatus
        {
            get; private set;
        }
        public void Save()
        {
            _db.SaveChanges();

        }
    }
}
