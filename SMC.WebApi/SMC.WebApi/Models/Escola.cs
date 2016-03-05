using ima.Api.V1;
using System.Collections.Generic;

namespace SMC.WebApi.Models
{
    public class Escola
    {
        public string Id { get; set; }
        public string Regime { get; set; }
        public string NomeUnidadeEscolar { get; set; }
        public string Bairro { get; set; }
        public string Descricao { get; set; }
        public string EnderecoEscolaDemanda { get; set; }
        public string LogradouroDemanda { get; set; }
        public string MunicipioDemanda { get; set; }
        public string UfDemanda { get; set; }
        public string CepDemanda { get; set; }
        public string Telefone { get; set; }

        public void SyncData()
        {
            var educaoApi = new EducaoApi();

            educaoApi.EducacaoGet(Constants.Constants.Token, "0", "100", new List<string>(), new List<string>());
        }
    }
}