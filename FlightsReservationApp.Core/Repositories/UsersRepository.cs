using FlightsReservationApp.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Core.Repositories
{
    public class UsersRepository : IUsersRepository
    {

        //fields
        private readonly ApplicationDbContext _context;

        //constructor injection (dependency injection)
        public UsersRepository(ApplicationDbContext context)
        {
            this._context = context;

        }

        public async Task<string> GetUserHash(string email)
        {
            var x = _context.Users
                .Where(u => u.Email == email)
                .FirstOrDefault();
            if(x.PasswordHash == null)
            {
                return null;
            }
            else
            {
                return x.PasswordHash.ToString();
            }
        }

        
    }

    
}
