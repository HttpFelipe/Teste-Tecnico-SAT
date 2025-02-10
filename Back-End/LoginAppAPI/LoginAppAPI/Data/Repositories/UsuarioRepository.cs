using LoginAppAPI.Data.DBConfig;
using LoginAppAPI.Data.Interfaces;
using LoginAppAPI.DTOs;
using LoginAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAppAPI.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UsuarioResponseModel> CadastrarUsuario(UsuarioRequestModel usuarioRequestModel)
        {
            try
            {
                var usuario = new Usuario(usuarioRequestModel.Login, usuarioRequestModel.Senha);

                var usuarioExiste = await _context.Usuarios.SingleOrDefaultAsync(u => u.Login == usuario.Login);

                if (usuarioExiste is not null)
                {
                    return new UsuarioResponseModel
                    {
                        Error = true,
                        Body = "Usuário já existe."
                    };
                }

                await _context.Usuarios.AddAsync(usuario);

                await _context.SaveChangesAsync();

                return new UsuarioResponseModel
                {
                    Error = false
                };
            }
            catch (Exception)
            {
                return new UsuarioResponseModel
                {
                    Error = true
                };
            }
        }

        public async Task<UsuarioResponseModel> BuscarUsuario(UsuarioRequestModel usuarioRequestModel)
        {
            try
            {
                var usuarioEncontrado = await _context.Usuarios.SingleAsync(u => u.Login == usuarioRequestModel.Login && u.Senha == usuarioRequestModel.Senha);

                return new UsuarioResponseModel
                {
                    Error = false
                };
            }
            catch (Exception)
            {
                return new UsuarioResponseModel
                {
                    Error = true
                };
            }
        }

        public async Task<UsuarioResponseModel> BuscarUsuarios()
        {
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                return new UsuarioResponseModel
                {
                    Error = false,
                    Usuarios = usuarios
                };
            }
            catch (Exception)
            {
                return new UsuarioResponseModel
                {
                    Error = true
                };
            }
        }
    }
}