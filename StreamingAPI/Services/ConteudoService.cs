using StreamingAPI.DTO;
using StreamingAPI.Model;
using StreamingAPI.Repositories.Impl;

namespace StreamingAPI.Services
{
    public class ConteudoService
    {
        private readonly ConteudoRepository _conteudoRepository;

        public ConteudoService(ConteudoRepository conteudoRepository)
        {
            _conteudoRepository = conteudoRepository;
        }

        
    }
}
