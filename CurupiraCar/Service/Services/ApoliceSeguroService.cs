using AutoMapper;
using Domain.Model;
using Repository.Context;
using Repository.Contracts;
using Repository.Repositories;
using Service.Contracts;

namespace Service.Services
{
    public class ApoliceSeguroService : BaseService<ApoliceSeguro>, IApoliceSeguroService
    {
        private readonly IApoliceSeguroRepository _context;

        public ApoliceSeguroService(MySqlContext context): base(context)
        {
            _context = new ApoliceSeguroRepository(context);
        }
        public ApoliceSeguro GetByNumeroApolice(double numeroApolice) => _context.Get(x => x.NumeroApolice == numeroApolice);

        public ApoliceSeguro RemoveByNumeroApolice(double numeroApolice) => _context.Remove(c => c.NumeroApolice == numeroApolice);
    
    }
}
