using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ApoliceSeguroRepository : BaseRepository<ApoliceSeguro>, IApoliceSeguroRepository
    {
        public ApoliceSeguroRepository(MySqlContext db): base(db)
        {

        }
    }
}
