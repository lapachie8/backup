using Admin.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Service
{
    public interface ILoginService
    {
        Task<LoginCommand> Authenticate(string username, string password);
        Task<IEnumerable<LoginCommand>> GetAll();
    }
}
