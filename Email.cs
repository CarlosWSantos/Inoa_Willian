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
        private string _password = "";
        private string _servidor = "";
        private string _port = "";

        public Email() { }

        public void GetMail(string archivePath)
        {

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
                    string valor = partes[1].Trim();
                    configuracoes[chave] = valor;
                }
            }

            if (configuracoes.TryGetValue("email", out _email) &&
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
        public void SendMail()
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
                    string recipientEmail = "c.willian2004@gmail.com";
                    string subject = "oiiii";
                    string body = "CAIU! HAHAHAHA";

                    // configurando classe SMTP
                    SmtpClient smtpClient = new SmtpClient(_servidor, Int32.Parse(_port))
                    {
                        Credentials = new NetworkCredential(_email, _password),
                        EnableSsl = true
                    };

                    MailMessage mailMessage = new MailMessage(_email, recipientEmail, subject, body);
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
