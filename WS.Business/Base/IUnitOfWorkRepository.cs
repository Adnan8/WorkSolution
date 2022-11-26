using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.IRepository;

namespace WS.Business.Base
{
    public interface IUnitOfWorkRepository
    {
        IToDoRepository ToDo
        {
            get;
        }
        IToDoHistoryRepository ToDoHistory { get; }

        void Save();
    }
}
