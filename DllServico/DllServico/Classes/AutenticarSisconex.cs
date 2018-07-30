using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using DllServico.Classes;
using DllServico.Models;

namespace DllServico.Classes
{
    public class AutenticarSisconex
    {
        private IEnumerable<String> token;
        private IEnumerable<String> xCSRFtoken;
        private HttpResponseMessage response;
        private HttpClient client;
        private String url = null;

        public Boolean GetTokenAutenticado(ServicoParametros servicoParametros)
        {

            //Para autenticação só usar o Principal.
            if (!servicoParametros.GetServicoEmTeste()) { 
                url = "https://portalunico.siscomex.gov.br";
            } else {
                url = "https://val.portalunico.siscomex.gov.br";
            }

            client = ChaveX509.ClienteHttp(servicoParametros);

            //Se setado para Teste usa a Url de teste (val.)
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();

            //Adicionar o cabecario do tipo de documento
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // adioncionar o Header Role-Type - Setar nas configurações 
            client.DefaultRequestHeaders.Add("Role-Type", servicoParametros.GetTipoRoleType());

            var metodo = "/portal/api/autenticar";  // Metodo padrão para autenticacao

            response = client.GetAsync(metodo).Result;
            
            //se retornar com sucesso busca os dados
            if (!response.IsSuccessStatusCode) return false;
                        
            //recolhe as informações para setar.
            var setToken = response.Headers.FirstOrDefault(h => h.Key.Trim().Equals("Set-Token"));
            var setCSRFToken = response.Headers.FirstOrDefault(h => h.Key.Trim().Equals("X-CSRF-Token"));

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