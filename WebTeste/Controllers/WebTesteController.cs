using System;
using System.Collections.Generic;
using System.Net.Http;
using DllServico.Models;
using DllServico.Controllers;
using DllServico.Classes;
using System.Web.Http;

namespace WebTeste.Controllers
{
    public class WebTesteController : ApiController
    {
        public IEnumerable<String> token = null;
        public IEnumerable<String> xCSRFtoken = null;
        public HttpResponseMessage responseConsumo;
        public HttpClient client;
        public RetornoSiscomex retornoSiscomex;
        
        // Tipos de RoleType
        //IMPEXP     Declarante importador/exportador
        //DEPOSIT    Depositário
        //OPERPORT   Operador Portuário
        //TRANSPORT  Transportador
        //AGEREMESS  Remessa Expressa/Correio
        //AJUDESPAC  Ajudante de Despachante
        //HABILITAD  Habilitador
        //PUBLICO    Público

        // GET api/values
        public RetornoSiscomex GetDUETeste(String numeroDue)
        {

            SiscomexController siscomexController = new SiscomexController();

            ServicoParametros servicoParametros = new ServicoParametros();

            string priKey = "1234567890.pfx"; /// Numero do Certificado padrão A1 em Arquivo pfx

            servicoParametros.SetCertificado(priKey);
            servicoParametros.SetSenhaCertificado("senha"); /// Senha usada no Certificado.
            servicoParametros.SetTipoRoleType("DEPOSIT");  /// Tipo de RoleType (De acordo com o manual do Siscomex)
            servicoParametros.SetComCertificado(false);

            retornoSiscomex = siscomexController.GetDUE(numeroDue, servicoParametros);

            return retornoSiscomex;
        }

    }

}
