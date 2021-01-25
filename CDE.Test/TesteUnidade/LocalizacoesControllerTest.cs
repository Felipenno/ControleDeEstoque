using CDE.Application.Controllers;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Models;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CDE.Test.TesteUnidade
{
    public class LocalizacoesControllerTest
    {
        private readonly Mock<ILocalizacaoRepository> _mockContext;
        private readonly List<ListarLocalizacoesViewModel> _listarLocalizacoesViewModel;
        private readonly CriarLocalizacaoViewModel _criarLocalizacaoViewModel;
        private readonly AtualizarLocalizacaoViewModel _atualizarLocalizacaoViewModel;

        public LocalizacoesControllerTest()
        {
            _mockContext = new Mock<ILocalizacaoRepository>();

            _listarLocalizacoesViewModel = new List<ListarLocalizacoesViewModel>();
            _listarLocalizacoesViewModel.Add(new ListarLocalizacoesViewModel(1, "2", "5", "2", "1", "produto nome", 100, true, 0, 0));

            _criarLocalizacaoViewModel = new CriarLocalizacaoViewModel();
            _atualizarLocalizacaoViewModel = new AtualizarLocalizacaoViewModel();

            _mockContext.Setup(m => m.ListarTodosAsync()).ReturnsAsync(_listarLocalizacoesViewModel);
        }

        [Fact]
        public async Task Listar_Localizacoes()
        {
            var service = new LocalizacoesController(_mockContext.Object);

            await service.Listar();

            _mockContext.Verify(mocks => mocks.ListarTodosAsync(), Times.Once());
        }

        [Fact]
        public void Criar_Localizacao()
        {
            var service = new LocalizacoesController(_mockContext.Object);
            service.CriarLocalizacao(_criarLocalizacaoViewModel);

            _mockContext.Verify(l => l.Adicionar(_criarLocalizacaoViewModel), Times.Once());
        }

        [Fact]
        public void Atualizar_Localizacao()
        {
            var service = new LocalizacoesController(_mockContext.Object);
            service.AtualizarLocalizacao(_atualizarLocalizacaoViewModel);

            _mockContext.Verify(l => l.Atualizar(_atualizarLocalizacaoViewModel), Times.Once());
        }

        [Fact]
        public async Task Remover_Localizacao()
        {
            var service = new LocalizacoesController(_mockContext.Object);
            await service.RemoverLocalizacao(1);

            _mockContext.Verify(l => l.Deletar(1), Times.Once());
        }
    }
}
