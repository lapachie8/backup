using Admin.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Service.Impls
{
    public class LoginService : ILoginService
    {
        private List<LoginCommand> _login = new List<LoginCommand>
        {
            new LoginCommand
            {
                id = 1,
                firstName = "Test",
                lastName = "User",
                userName = "test",
                password = "test"
            }
        };

        public async Task<LoginCommand> Authenticate(string username, string password)
        {
            var login = await Task.Run(() => _login.SingleOrDefault(x => x.userName == username && x.password == password));
            if(login == null)
                return null;
            
            
            login.password = null;
            return login;
        }

        public async Task<IEnumerable<LoginCommand>> GetAll()
        {
            return await Task.Run(() => _login.Select(x =>
            {
                x.password = null;
                return x;
            }));
        }
    }
}
