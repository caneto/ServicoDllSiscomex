using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using DllServico.Models;
using DllServico.Controllers;
using DllServico.Classes;

namespace WebApp.Controllers
{
    public class WebTesteController : ApiController
    {
        public IEnumerable<String> token = null;
        public IEnumerable<String> xCSRFtoken = null;
        public HttpResponseMessage responseConsumo;
        public HttpClient client;
        public RetornoSiscomex retornoSiscomex;

        // GET api/values
        public RetornoSiscomex GetDUEx(String numeroDue)
        {

            SiscomexController siscomexController = new SiscomexController();

            ServicoParametros servicoParametros = new ServicoParametros();

            string priKeyFile = "1000247237.pfx";

            servicoParametros.SetCertificado(priKeyFile);
            servicoParametros.SetSenhaCertificado("cmsp270790");
            servicoParametros.SetTipoRoleType("DEPOSIT");
            servicoParametros.SetComCertificado(false);

            retornoSiscomex = siscomexController.GetDUE(numeroDue, servicoParametros);

            return retornoSiscomex;
        }

    }

}
