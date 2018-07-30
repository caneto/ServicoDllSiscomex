using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using WebApp.Classes;

namespace WebApp.Classes
{
    public class AutenticarSisconex
    {
        private IEnumerable<String> token;
        private IEnumerable<String> xCSRFtoken;
        private HttpResponseMessage response;
        private HttpClient client;

        public Boolean GetTokenAutenticado()
        {

            //Para autenticação só usar o Principal.
            var url = "https://portalunico.siscomex.gov.br";

            client = ChaveX509.ClienteHttp(null);

            //Selecionar a url (teste = urlValidacao)
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();

            //Adicionar o cabecario do tipo de documento
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // adioncionar o Header Role-Type
            client.DefaultRequestHeaders.Add("Role-Type", "DEPOSIT");
            var metodo = "/portal/api/autenticar";

            response = client.GetAsync(metodo).Result;
            
            //se retornar com sucesso busca os dados
            if (!response.IsSuccessStatusCode) return false;

            //recolhe as informações para setar.
            var setToken = response.Headers.ElementAtOrDefault(0);
            var setCSRFToken = response.Headers.ElementAtOrDefault(1);
            token = setToken.Value;
            xCSRFtoken = setCSRFToken.Value;

            return true;
        }

        public IEnumerable<String> getToken()
        {
            return token;
        }

        public IEnumerable<String> getxCSRFtoken()
        {
            return xCSRFtoken;
        }

        public HttpClient getClient()
        {
            return client;
        }
    }
}