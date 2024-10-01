using Microsoft.Extensions.Configuration;
using Vaskebjørnen.Models;

namespace Vaskebjørnen.Repositories
{
    public class BookingRepo : IRepo<Booking>
    {
        private readonly string _connectionString;

        public BookingRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }
        public void Add(Booking t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Booking t)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public Booking GetBy(Booking t)
        {
            throw new NotImplementedException();
        }

        public void Update(Booking t)
        {
            throw new NotImplementedException();
        }
    }
}
