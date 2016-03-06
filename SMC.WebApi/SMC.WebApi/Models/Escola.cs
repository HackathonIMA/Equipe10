using ima.Api.V1;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMC.WebApi.Models
{
    public class Escola
    {
        public string Id { get; set; }
        public string Regime { get; set; }
        [DisplayName("Nome")]
        public string NomeUnidadeEscolar { get; set; }
        public string Bairro { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DisplayName("Endereço")]
        public string EnderecoEscolaDemanda { get; set; }
        [DisplayName("Logradouro")]
        public string LogradouroDemanda { get; set; }
        [DisplayName("Municipio")]
        public string MunicipioDemanda { get; set; }
        [DisplayName("UF")]
        public string UfDemanda { get; set; }
        [DisplayName("CEP")]
        public string CepDemanda { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<ComentarioModel> Comentarios { get; set; }
        public virtual ICollection<MuralModel> Murais { get; set; }
        public void SyncData()
        {
            var educaoApi = new EducaoApi();

            var eof = false;

            while (!eof)
            {
                var data = educaoApi.EducacaoGet(Constants.Constants.Token, "0", "100", new List<string>(), new List<string>());
                if (data.Count <= 0)
                {
                    eof = true;
                }
            }
        }
    }
}