using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ima.Api.V1.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class EmpenhoResponse {
    
    
    [DataMember(Name="links", EmitDefaultValue=false)]
    public List<LinksModel> Links { get; set; }

    
    /* Identificador do registro. */
    [DataMember(Name="ID", EmitDefaultValue=false)]
    public string ID { get; set; }

    
    /* CÃ³digo da funcao */
    [DataMember(Name="codigoFuncao", EmitDefaultValue=false)]
    public int? CodigoFuncao { get; set; }

    
    /* Procesos de compra */
    [DataMember(Name="processo", EmitDefaultValue=false)]
    public string Processo { get; set; }

    

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class EmpenhoResponse {\n");
      
      sb.Append("  Links: ").Append(Links).Append("\n");
      
      sb.Append("  ID: ").Append(ID).Append("\n");
      
      sb.Append("  CodigoFuncao: ").Append(CodigoFuncao).Append("\n");
      
      sb.Append("  Processo: ").Append(Processo).Append("\n");
      
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
  
  
}
