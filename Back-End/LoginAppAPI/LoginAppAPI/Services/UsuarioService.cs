using LoginAppAPI.Data.Interfaces;
using LoginAppAPI.DTOs;
using LoginAppAPI.Services.Interfaces;

namespace LoginAppAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioResponseModel> CadastrarUsuario(UsuarioRequestModel usuarioRequestModel)
        {
            return await _usuarioRepository.CadastrarUsuario(usuarioRequestModel);
        }

        public async Task<UsuarioResponseModel> LoginUsuario(UsuarioRequestModel usuarioRequestModel)
        {
            return await _usuarioRepository.BuscarUsuario(usuarioRequestModel);
        }

        public async Task<UsuarioResponseModel> BuscarUsuarios()
        {
            return await _usuarioRepository.BuscarUsuarios();
        }
    }
}