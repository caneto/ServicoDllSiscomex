using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace DllServico.Classes
{

    public class ChaveX509
    {
        public static HttpClient client;
        public static WebRequestHandler requestHandler;

        // Metodo padrão X509 para ler o certificado.
        // os sertificados deverão está na pasta ~/certificado/
        // Parametros certificado = "nome sem a extensão" / senha do certificado
        private static X509Certificate2 GetClientCertificate(ServicoParametros servicoParametros)
        {
            // Carrega o arquivo de certificado A1 (verificar sempre a validade dele.
            //string priKeyFile = HttpContext.Current.Server.MapPath("~/certificado/" + certificado+".pfx");
            //var extensao = ".pfx";
            string priKeyFile =
                System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath)
                    , "certificado"
                    , servicoParametros.GetCertificado()
                    );

            X509Certificate2 certEncrypt = new X509Certificate2(priKeyFile, servicoParametros.GetSenhaCertificado()); // passa a senha

            return certEncrypt;
        }

        public static HttpClient ClienteHttp(ServicoParametros servicoParametros)
        {
        
            X509Certificate2 clientCert = GetClientCertificate(servicoParametros);
            requestHandler = new WebRequestHandler();
            requestHandler.ClientCertificates.Add(clientCert);

            //Seta a parte de segurança.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            client = new HttpClient(requestHandler);

            return client;
        }

        public static X509Certificate2 GetCertificate(ServicoParametros servicoParametros)
        {
            X509Certificate2 clientCert = GetClientCertificate(servicoParametros);

            return clientCert;
        }

    }
}