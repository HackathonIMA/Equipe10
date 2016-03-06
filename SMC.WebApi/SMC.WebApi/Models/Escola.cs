using ima.Api.V1;
using ima.Api.V1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SMC.WebApi.Models
{
    public class Escola
    {
        public string Id { get; set; }

        [DisplayName("Nome")]
        public string NomeUnidadeEscolar { get; set; }

        public string Bairro { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

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

        /// <summary>
        /// Esse metodo ira fazer o sincronismo entre a base de dados com os dados do web service
        /// </summary>
        public void SyncData()
        {
            var db = new ApplicationDbContext();
            var dbset = db.Set<Escola>();
            var educaoApi = new EducaoApi();

            var offSet = 0;
            var count = 0;
            List<EducacaoResponse> data = null;
            List<Escola> escolas = new List<Escola>();
            do
            {
                data = educaoApi.EducacaoGet(Constants.Constants.Token, offSet.ToString(), "100", new List<string>(),
                   new List<string>() { "ano: " + DateTime.Now.Year });

                foreach (var item in data)
                {
                    var escola = dbset.FirstOrDefault(p => p.NomeUnidadeEscolar == item.NomeUnidadeEscolar);
                    if (escola == null)
                    {
                        escolas.Add(map(item));
                    }
                    count++;
                }
                offSet = count;
            } while (data.Count > 0);

            var distinctEscolas = escolas.GroupBy(s => s.NomeUnidadeEscolar).Select(s => s.First());

            dbset.AddRange(distinctEscolas);
            db.SaveChangesAsync();
        }

        private Escola map(EducacaoResponse educacaoResponse)
        {
            var escola = new Escola
            {
                Id = educacaoResponse.ID,
                NomeUnidadeEscolar = educacaoResponse.NomeUnidadeEscolar,
                Bairro = educacaoResponse.Bairro,
                Descricao = educacaoResponse.Descricao,
                Endereco = educacaoResponse.EnderecoEscola,
                LogradouroDemanda = educacaoResponse.Logradouro,
                MunicipioDemanda = educacaoResponse.Municipio,
                UfDemanda = educacaoResponse.Uf,
                CepDemanda = educacaoResponse.cep
            };

            return escola;
        }
    }
}