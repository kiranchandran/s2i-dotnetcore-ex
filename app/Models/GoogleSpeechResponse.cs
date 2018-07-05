using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models.Response
{
  public class Button
  {

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("postback")]
    public string Postback { get; set; }
  }

  public class Card
  {

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("subtitle")]
    public string Subtitle { get; set; }

    [JsonProperty("imageUri")]
    public string ImageUri { get; set; }

    [JsonProperty("buttons")]
    public IList<Button> Buttons { get; set; }
  }

  public class FulfillmentMessage
  {

    [JsonProperty("card")]
    public Card Card { get; set; }
  }

  public class SimpleResponse
  {

    [JsonProperty("textToSpeech")]
    public string TextToSpeech { get; set; }
  }

  public class Item
  {

    [JsonProperty("simpleResponse")]
    public SimpleResponse SimpleResponse { get; set; }
  }

  public class RichResponse
  {

    [JsonProperty("items")]
    public IList<Item> Items { get; set; }
  }

  public class Google
  {

    [JsonProperty("expectUserResponse")]
    public bool ExpectUserResponse { get; set; }

    [JsonProperty("richResponse")]
    public RichResponse RichResponse { get; set; }
  }

  public class Facebook
  {

    [JsonProperty("text")]
    public string Text { get; set; }
  }

  public class Slack
  {

    [JsonProperty("text")]
    public string Text { get; set; }
  }

  public class Payload
  {

    [JsonProperty("google")]
    public Google Google { get; set; }

    [JsonProperty("facebook")]
    public Facebook Facebook { get; set; }

    [JsonProperty("slack")]
    public Slack Slack { get; set; }
  }

  public class Parameters
  {

    [JsonProperty("param")]
    public string Param { get; set; }
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

  public class FollowupEventInput
  {

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("languageCode")]
    public string LanguageCode { get; set; }

    [JsonProperty("parameters")]
    public Parameters Parameters { get; set; }
  }

  public class GoogleSpeechResponse
  {

    [JsonProperty("fulfillmentText")]
    public string FulfillmentText { get; set; }

    [JsonProperty("fulfillmentMessages")]
    public IList<FulfillmentMessage> FulfillmentMessages { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("payload")]
    public Payload Payload { get; set; }

    [JsonProperty("outputContexts")]
    public IList<OutputContext> OutputContexts { get; set; }

    [JsonProperty("followupEventInput")]
    public FollowupEventInput FollowupEventInput { get; set; }
  }
}
