using app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{

  public class Parameters
  {

    [JsonProperty("param")]
    public string Param { get; set; }
  }

  public class Text
  {

    [JsonProperty("text")]
    public IList<string> Texts { get; set; }
  }

  public class FulfillmentMessage
  {

    [JsonProperty("text")]
    public Text Text { get; set; }
  }

  public class OutputContext
  {

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("lifespanCount")]
    public int LifespanCount { get; set; }

    [JsonProperty("parameters")]
    public Parameters Parameters { get; set; }
  }

  public class Intent
  {

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; }
  }

  public class DiagnosticInfo
  {
  }

  public class QueryResult
  {

    [JsonProperty("queryText")]
    public string QueryText { get; set; }

    [JsonProperty("parameters")]
    public Parameters Parameters { get; set; }

    [JsonProperty("allRequiredParamsPresent")]
    public bool AllRequiredParamsPresent { get; set; }

    [JsonProperty("fulfillmentText")]
    public string FulfillmentText { get; set; }

    [JsonProperty("fulfillmentMessages")]
    public IList<FulfillmentMessage> FulfillmentMessages { get; set; }

    [JsonProperty("outputContexts")]
    public IList<OutputContext> OutputContexts { get; set; }

    [JsonProperty("intent")]
    public Intent Intent { get; set; }

    [JsonProperty("intentDetectionConfidence")]
    public int IntentDetectionConfidence { get; set; }

    [JsonProperty("diagnosticInfo")]
    public DiagnosticInfo DiagnosticInfo { get; set; }

    [JsonProperty("languageCode")]
    public string LanguageCode { get; set; }
  }

  public class OriginalDetectIntentRequest
  {
  }

  public class GoogleSpeechRequest
  {

    [JsonProperty("responseId")]
    public string ResponseId { get; set; }

    [JsonProperty("session")]
    public string Session { get; set; }

    [JsonProperty("queryResult")]
    public QueryResult QueryResult { get; set; }

    [JsonProperty("originalDetectIntentRequest")]
    public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; }
  }
}

