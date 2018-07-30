using System.Collections.Generic;
using DllServico.Models;

namespace DllServico.Models
{
    public class RetornoSiscomex
    {
        public string numeroDUE { get; set; }
        public string numeroRUC { get; set; }
        public string situacaoDUE { get; set; }
        public string dataSituacaoDUE { get; set; }
        public string indicadorBloqueio { get; set; }
        public string controleAdministrativo { get; set; }
        public string uaEmbarque { get; set; }
        public string uaDespacho { get; set; }
        public string responsavelUADespacho { get; set; }
        public string codigoRecintoAduaneiroDespacho { get; set; }
        public string codigoRecintoAduaneiroEmbarque { get; set; }
        public string latitudeDespacho { get; set; }
        public string longitudeDespacho { get; set; }
        public RetornoSiscomexDeclarante  declarante { get; set; }
        public IList<RetornoSiscomexExportadores> exportadores { get; set; }
        public IList<string> situacaoCarga { get; set; }
    }
}