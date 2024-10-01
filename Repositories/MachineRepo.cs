using Microsoft.Extensions.Configuration;
using Vaskebjørnen.Models;

namespace Vaskebjørnen.Repositories
{
    public class MachineRepo : IRepo<Machine>
    {
        private readonly string _connectionString;

        public MachineRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }
        public void Add(Machine t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Machine t)
        {
            throw new NotImplementedException();
        }

        public List<Machine> GetAll()
        {
            throw new NotImplementedException();
        }

        public Machine GetBy(Machine t)
        {
            throw new NotImplementedException();
        }

        public void Update(Machine t)
        {
            throw new NotImplementedException();
        }
    }
}
