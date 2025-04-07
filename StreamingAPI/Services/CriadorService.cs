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

        
    }
}
