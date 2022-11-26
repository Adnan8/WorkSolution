using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Business.Base;
using WS.Domain.Model;

namespace WS.Business.IRepository
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        void Update(ToDo obj);
    }
}
