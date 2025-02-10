using LoginAppAPI.DTOs;

namespace LoginAppAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponseModel> CadastrarUsuario(UsuarioRequestModel usuarioRequestModel);

        Task<UsuarioResponseModel> LoginUsuario(UsuarioRequestModel usuarioRequestModel);

        Task<UsuarioResponseModel> BuscarUsuarios();
    }
}