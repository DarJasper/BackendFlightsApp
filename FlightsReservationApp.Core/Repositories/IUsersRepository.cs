using System.Threading.Tasks;

namespace FlightsReservationApp.Core.Repositories
{
    public interface IUsersRepository
    {
        Task<string> GetUserHash(string email);
    }
}