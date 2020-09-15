using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamrinEfCoreApi.Models;

namespace XamrinEfCoreApi.Interfaces
{
    interface IUserHttpService
    {
        Task<List<User>> GetUsersAsync();
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(User user);
        Task<bool> AddUserAsync(User user);        
    }
}
