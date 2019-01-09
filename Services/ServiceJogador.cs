using System;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {

        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {
        }

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
         
            
            Jogador jogador = new Jogador(
                request.Nome,
                request.Email,
                Enums.EnumSituacaoJogador.EmAndamento
                );
            
            Guid id = _repositoryJogador.AdicionarJogador(jogador);
            
            return new AdicionarJogadorResponse()
            {
                Id = id,
                Message = "Operação realizada com sucesso!"
            };
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {

            var email = new Email("thiago@cunha.com");
            Jogador jogador = new Jogador(email, "123");
            
            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
            {
                AddNotification("AutenticarJogador", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));
            }
            
            var response = _repositoryJogador.AutenticarJogador(request);
            return response;
        }

        private bool IsEmail(string requestEmail)
        {
            return false;
        }
    }
}