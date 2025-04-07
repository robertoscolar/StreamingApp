using StreamingAPI.Data;
using StreamingAPI.DTO;
using StreamingAPI.Model;
using StreamingAPI.Repositories.Impl;

namespace StreamingAPI.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public string Autenticar(AuthDTO authDTO)
        {
            Usuario usuario = _usuarioRepository.GetByEmailAndPassword(authDTO.Email, authDTO.Senha);

            if (usuario == null)
            {
                return null;
            }

            var token = TokenService.GenerateToken(usuario);
            usuario.Senha = "";

            return token;
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
        }

        public bool AcharPlaylistsPorUsuarioId(int id)
        {
            return true;
        }

        public Usuario EncontrarUsuarioPorId(int id)
        {
            return _usuarioRepository.GetByID(id);
        }
    }
}
