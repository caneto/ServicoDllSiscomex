using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using DllServico.Classes;
using DllServico.Models;

namespace DllServico.Controllers
{
    public class SiscomexController
    {
        public IEnumerable<String> token = null;
        public IEnumerable<String> xCSRFtoken = null;

        private AutenticarSisconex autenticar;
        private HttpResponseMessage responseConsumo;
        private HttpClient client;
        private RetornoSiscomex retornoSisconex;
        private String metododeconsumo;
        
        // GET api/SiscomexController/GetDUE
        // Parametros numero due, servicoParametros
        public RetornoSiscomex GetDUE(String numeroDue, ServicoParametros servicoParametros)
        {
            autenticar = new AutenticarSisconex(); // Autentica 
            retornoSisconex = new RetornoSiscomex();

            //Caso o token seja nulo solita autenticação.
            if (token == null)
            {
                if (autenticar.GetTokenAutenticado(servicoParametros))
                {
                    token = autenticar.getToken();
                    xCSRFtoken = autenticar.getxCSRFtoken();
                }

                client = autenticar.getClient(); // Usa client já configurado
            }

            // seta os novos dados do Header para a consulta
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", token); // obtido na autenticação
            client.DefaultRequestHeaders.Add("X-CSRF-Token", xCSRFtoken); // obtido na autenticação

            metododeconsumo = "/due/api/ext/due/consultarDadosResumidosDUE?numero=" + numeroDue;

            //efetura a consulta
            responseConsumo = client.GetAsync(metododeconsumo).Result;

            var result = responseConsumo.Content.ReadAsStringAsync().Result;
            retornoSisconex = JsonConvert.DeserializeObject<RetornoSiscomex>(result); // desmonta o resultado.

            return retornoSisconex;
        }


        // Post api/SiscomexController/PostRecepNFE
        // Parametros blocoRecepcaoNFE, servicoParametros
        // Disponivel na versão comercial.

        // Post api/SiscomexController/PostRecepNFF
        // Parametros blocoRecepcaoNFF, servicoParametros
        // Disponivel na versão comercial

        // Post api/SiscomexController/PostEntCarga
        // Parametros blocoEntregaDocumentoCarga, caminhoCertificado, senhaCertificado
        // Disponivel na versão Comercial
        
        // Post api/SiscomexController/ValidarXml
        // Parametros xmlFilename, schemaFilename
        // Disponivel na versão comercial
    }
}
