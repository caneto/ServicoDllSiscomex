using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography.X509Certificates;

namespace WebTeste.Classes
{

    public class ChaveX509
    {
        public static HttpClient client;
        public static WebRequestHandler requestHandler;

        // Metodo padrão X509 para ler o certificado.
        // os sertificados deverão está na pasta ~/certificado/
        // Parametros certificado = "nome sem a extensão" / senha do certificado
        private static X509Certificate2 GetClientCertificate(String certificado, String senha)
        {
            // Carrega o arquivo de certificado A1 (verificar sempre a validade dele.
            string priKeyFile = HttpContext.Current.Server.MapPath("~/certificado/"+certificado+".pfx");
            X509Certificate2 certEncrypt = new X509Certificate2(priKeyFile, senha); // passa a senha

            return certEncrypt;
        }

        public static HttpClient ClienteHttp(X509Certificate2 certificado)
        {
            //Recolhe o certificado e prepara o header.
            //Key e Senha deverão ser obtidos de Configuração.
            X509Certificate2 clientCert = GetClientCertificate("1000247237", "cmsp270790");
            requestHandler = new WebRequestHandler();
            requestHandler.ClientCertificates.Add(clientCert);

            //Seta a parte de segurança.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            client = new HttpClient(requestHandler);

            return client;
        }

    }
}