using Domain.Model;
using System;
using Tests.Repositories;
using Xunit;

namespace Tests
{
    public class InsertApolicesTest: IDisposable
    {
        private readonly ApoliceSeguroRepositoryTest _repositoryTest;

        public InsertApolicesTest()
        {
            _repositoryTest = new ApoliceSeguroRepositoryTest();
        }

        [Fact]
        public void InsertSuccess()
        {
            ApoliceSeguro apoliceTest = new ApoliceSeguro
            {
                IdentificacaoSegurado = "3123124122",
                NumeroApolice = 152525,
                PlacaVeiculo = "ABASD1231",
                ValorPremio = 12.24m
            };
            var result = _repositoryTest.Create(apoliceTest);
            Assert.True(result);
        }
        [Fact]
        public void Delete()
        {
            var result = _repositoryTest.Delete(1);
            Assert.True(result);
        }
        public void Dispose()
        {
            _repositoryTest.Dispose();
        }

    }
}
