using ima.Api.V1;
using System.Collections.Generic;

namespace SMC.WebApi.Models
{
    public class Escola
    {
        public string Regime { get; set; }
        public string NomeUnidadeEscolar { get; set; }
        public string Bairro { get; set; }
        public string Descricao { get; set; }
        public string EnderecoEscolaDemanda { get; set; }
        public string LogradouroDemanda { get; set; }
        public string MunicipioDemanda { get; set; }
        public string UfDemanda { get; set; }
        public string CepDemanda { get; set; }

        public IEnumerable<Escola> Get(int offSet, int limit)
        {
            var educacaoApi = new EducaoApi();
            return
        }
    }
}