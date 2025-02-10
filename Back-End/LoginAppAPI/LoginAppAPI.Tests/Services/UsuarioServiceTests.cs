using LoginAppAPI.Data.Interfaces;
using LoginAppAPI.DTOs;
using LoginAppAPI.Services;
using Moq;

namespace LoginAppAPI.Tests.Data
{
    public class UsuarioServiceTests
    {
        private readonly UsuarioService _usuarioService;
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock = new();

        public UsuarioServiceTests()
        {
            _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object);
        }

        [Fact]
        public async Task CadastrarUsuario_DeveRetornarUsuarioResponseModel_Success_QuandoRepositoryFuncionar()
        {
            // Arrange

            var usuarioRequestModel = new UsuarioRequestModel
            {
                Login = "teste",
                Senha = "123456"
            };

            var usuarioResponseModel = new UsuarioResponseModel
            {
                Error = false
            };

            _usuarioRepositoryMock.Setup(p => p.CadastrarUsuario(usuarioRequestModel)).ReturnsAsync(usuarioResponseModel);

            // Act

            var result = await _usuarioService.CadastrarUsuario(usuarioRequestModel);

            // Assert

            Assert.False(result.Error);
        }

        [Fact]
        public async Task CadastrarUsuario_DeveRetornarPersistenceResponseModel_Error_QuandoRepositoryFalhar()
        {
            // Arrange

            var usuarioRequestModel = new UsuarioRequestModel
            {
                Login = "teste",
                Senha = "123456"
            };

            var usuarioResponseModel = new UsuarioResponseModel
            {
                Error = true
            };

            _usuarioRepositoryMock.Setup(p => p.CadastrarUsuario(usuarioRequestModel)).ReturnsAsync(usuarioResponseModel);

            //Act

            var result = await _usuarioService.CadastrarUsuario(usuarioRequestModel);

            // Assert

            Assert.True(result.Error);
        }

        [Fact]
        public async Task LoginUsuario_DeveRetornarUsuarioResponseModel_Success_QuandoUsuarioForEncontrado()
        {
            // Arrange

            var usuarioRequestModel = new UsuarioRequestModel
            {
                Login = "teste",
                Senha = "123456"
            };

            var usuarioResponseModel = new UsuarioResponseModel
            {
                Error = false
            };

            _usuarioRepositoryMock.Setup(p => p.BuscarUsuario(usuarioRequestModel)).ReturnsAsync(usuarioResponseModel);

            //Act

            var result = await _usuarioService.LoginUsuario(usuarioRequestModel);

            // Assert

            Assert.False(result.Error);
        }
    }
}