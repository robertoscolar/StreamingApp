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
            authDTO.Senha = HashService.GerarHashSHA256(authDTO.Senha);
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
            usuario.Senha = HashService.GerarHashSHA256(usuario.Senha);
            _usuarioRepository.Add(usuario);
        }

        public Usuario EncontrarUsuarioPorId(int id)
        {
            return _usuarioRepository.GetByID(id);
        }
    }
}
