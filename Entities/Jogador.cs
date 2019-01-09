using System;
using prmToolkit.NotificationPattern;
using XGame.Domain.Enums;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNotEmail(x => x.Email.Endereco, "Informe um e-mail válido")
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter entre 6 e 32 caracteres");

        }

        public Jogador(Nome nome, Email email, EnumSituacaoJogador status)
        {
            Nome = nome;
            Email = email;
            Status = status;
        }

        public Guid Id { get; set; }
        
        public Nome Nome{ get; set; }
        
        public Email Email { get; set; }

        public string Senha { get; set; }
        
        public EnumSituacaoJogador Status { get; set; }
    }
}