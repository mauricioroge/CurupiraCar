﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ModelDTO
{
    public class ApoliceSeguroDTO
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
    }
}
