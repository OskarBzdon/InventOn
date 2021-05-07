using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InverntOn.Data;

namespace InverntOn.Repositories
{
    class ClientRepo : IClientRepo
    {
        private readonly DbContext _ctx;

        public ClientRepo(DbContext ctx)
        {
            _ctx = ctx;
        }
    }
}
