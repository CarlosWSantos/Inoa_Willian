using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Security;

namespace Inoa_Willian
{
    internal class Email
    {
        private string _email = "";
        private string _destinatario = "";
        private string _password = "";
        private string _servidor = "";
        private string _port = "";

        public Email() { }

        public void GetMail(string archivePath)
        {
            //tratamento de erro de ausencia de dados no arquivo cfg
            if (!File.Exists(archivePath))
            {
                Console.WriteLine("Arquivo de configuração não encontrado");
                return;
            }

            var configuracoes = new Dictionary<string, string>();

            foreach (var linha in File.ReadAllLines(archivePath))
            {
                var partes = linha.Split('=');
                if (partes.Length == 2)
                {
                    string chave = partes[0].Trim(); //remove espaços
                    string valor = partes[1].Trim(); //remove espaços
                    configuracoes[chave] = valor;
                }
            }

            //salva os dados do arquivo
            if (configuracoes.TryGetValue("email", out _email) &&
                configuracoes.TryGetValue("destinatario", out _destinatario) &&
                configuracoes.TryGetValue("senha", out _password) &&
                configuracoes.TryGetValue("smtp_servidor", out _servidor) &&
                configuracoes.TryGetValue("smtp_porta", out _port))
            {
                Console.WriteLine("sucesso!");

            }
            else
            {
                Console.WriteLine("Erro: Configurações incompletas no arquivo.");
            }
        }
        public void SendMail(string informacoesAtivo,string orientacaoAtivo)
        {
            if (String.IsNullOrEmpty(_email))
            {
                Console.WriteLine("Nenhum arquivo de configuração foi lido.");
            }
            else
            {
                try
                {
                    // destinatário
                    string recipientEmail = _destinatario;
                    string subject = informacoesAtivo;
                    string body = orientacaoAtivo;

                    // configurando classe SMTP
                    SmtpClient smtpClient = new SmtpClient(_servidor, Int32.Parse(_port))
                    {
                        Credentials = new NetworkCredential(_email, _password),
                        EnableSsl = true
                    };

                    //classe de dados do email
                    MailMessage mailMessage = new MailMessage(_email, recipientEmail, subject, body)
                    {
                        IsBodyHtml = true
                    };
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("enviado");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

    }
}
