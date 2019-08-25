using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ApoliceSeguro : BaseEntity
    {
        /// <summary>
        /// Numero da apolice do seguro
        /// </summary>
        public double NumeroApolice { get; set; }
        /// <summary>
        /// Identificacao do Segurado, podendo ser CPF ou CNPJ
        /// </summary>
        public string IdentificacaoSegurado { get; set; }
        /// <summary>
        /// Placa do veiculo da apolice do seguro
        /// </summary>
        public string PlacaVeiculo { get; set; }
        /// <summary>
        /// Valor do premio da apolice
        /// </summary>
        public decimal ValorPremio { get; set; }

        public override string ToString()
        {
            var list = new List<string> {
                Id.ToString().ToLowerInvariant(),
                NumeroApolice.ToString().ToLowerInvariant(),
                IdentificacaoSegurado.ToLowerInvariant(),
                PlacaVeiculo.ToLowerInvariant(),
                ValorPremio.ToString().ToLowerInvariant()
            };
            return string.Join(";",list);
        }
    }
}
