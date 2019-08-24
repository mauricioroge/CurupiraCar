using Domain.Model;

namespace Service.Contracts
{
    public interface IApoliceSeguroService: IBaseService<ApoliceSeguro>
    {
        ApoliceSeguro GetByNumeroApolice(double numeroApolice);
        ApoliceSeguro RemoveByNumeroApolice(double numeroApolice);
    }
}
