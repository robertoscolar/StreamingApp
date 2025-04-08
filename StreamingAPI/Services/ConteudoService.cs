using StreamingAPI.DTO;
using StreamingAPI.Model;
using StreamingAPI.Repositories.Impl;

namespace StreamingAPI.Services
{
    public class ConteudoService
    {
        private readonly ConteudoRepository _conteudoRepository;
        private readonly CriadorRepository _criadorRepository;

        public ConteudoService(ConteudoRepository conteudoRepository , CriadorRepository criadorRepository)
        {
            _conteudoRepository = conteudoRepository;
            _criadorRepository = criadorRepository;
        }

        public bool RegistrarConteudo(ConteudoCadastroDTO conteudoDTO)
        {
            if (_criadorRepository.GetByID(conteudoDTO.CriadorId) == null) {
                return false;
            }

            Conteudo conteudo = new Conteudo();
            conteudo.Titulo = conteudoDTO.Titulo;
            conteudo.Tipo = conteudoDTO.Tipo;
            conteudo.CriadorId = conteudoDTO.CriadorId;

            _conteudoRepository.Add(conteudo);
            return true;
        }

        public Conteudo EncontrarConteudoPorId(int id)
        {
            return _conteudoRepository.GetByID(id);
        }
    }
}
