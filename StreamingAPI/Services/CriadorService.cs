using StreamingAPI.DTO;
using StreamingAPI.Model;
using StreamingAPI.Repositories.Impl;

namespace StreamingAPI.Services
{
    public class CriadorService
    {
        private readonly CriadorRepository _criadorRepository;

        public CriadorService(CriadorRepository criadorRepository)
        {
            _criadorRepository = criadorRepository;
        }

        public void RegistrarCriador(CriadorCadastroDTO criadorDTO)
        {
            Criador criador = new Criador();
            criador.Nome = criadorDTO.Nome;

            _criadorRepository.Add(criador);
        }

        public Criador EncontrarCriadorPorId(int id)
        {
            return _criadorRepository.GetByID(id);
        }
    }
}
