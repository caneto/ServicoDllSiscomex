using System;

namespace DllServico.Classes
{
    public class ServicoParametros
    {
        private string Certificado;
        private string SenhaCertificado;
        private string TipoRoleType = "DEPOSIT"; // (IMPEXP-Declarante importador/exportador, DEPOSIT-Depositário,OPERPORT-Operador Portuário,TRANSPORT-Transportador,AGEREMESS-Remessa Expressa/Correio,AJUDESPAC-Ajudante de Despachante,HABILITAD-Habilitador,PUBLICO Público)
        private bool ServicoComCertificado;
        private bool ServicoEmTeste;

        public void SetCertificado(String certificado)
        {
            Certificado = certificado;
        }

        public string GetCertificado()
        {
            return Certificado;
        }

        public void SetSenhaCertificado(String senhacertificado)
        {
            SenhaCertificado = senhacertificado;
        }

        public string GetSenhaCertificado()
        {
            return SenhaCertificado;
        }
        
        public void SetComCertificado(bool servicocomcertificado)
        {
            ServicoComCertificado = servicocomcertificado;
        }

        public bool GetComCertificado()
        {
            return ServicoComCertificado;
        }

        public void SetServicoEmTeste(bool servicoemTeste)
        {
            ServicoEmTeste = servicoemTeste;
        }

        public bool GetServicoEmTeste()
        {
            return ServicoEmTeste;
        }

        public void SetTipoRoleType(String tipoRoleType)
        {
            TipoRoleType = tipoRoleType;
        }

        public String GetTipoRoleType()
        {
            return TipoRoleType;
        }

    }
}
