using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMuaiClinet.Models;

namespace ToDoMuaiClinet.DataServices
{
    public interface IRestDataService
    {
        Task<List<ToDo>> GetAllToDoAsync();
        Task AddTaskAsync(ToDo toDo);
        Task UpdateTaskAsync(ToDo toDo);
        Task DeleteTaskAsync(int id);

    }
}
