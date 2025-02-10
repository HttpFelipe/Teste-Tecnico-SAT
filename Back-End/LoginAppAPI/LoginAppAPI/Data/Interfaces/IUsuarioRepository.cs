using LoginAppAPI.DTOs;

namespace LoginAppAPI.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioResponseModel> CadastrarUsuario(UsuarioRequestModel usuarioRequestModel);

        Task<UsuarioResponseModel> BuscarUsuario(UsuarioRequestModel usuarioRequestModel);

        Task<UsuarioResponseModel> BuscarUsuarios();
    }
}