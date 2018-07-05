using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using Newtonsoft.Json;

namespace app.Controllers
{
  public class PermissionsRequest
  {

    [JsonProperty("opt_context")]
    public string OptContext { get; set; }

    [JsonProperty("permissions")]
    public IList<string> Permissions { get; set; }
  }

  public class Google
  {

    [JsonProperty("expect_user_response")]
    public bool ExpectUserResponse { get; set; }

    [JsonProperty("is_ssml")]
    public bool IsSsml { get; set; }

    [JsonProperty("permissions_request")]
    public PermissionsRequest PermissionsRequest { get; set; }
  }

  public class Data
  {

    [JsonProperty("google")]
    public Google Google { get; set; }
  }

  public class GoogleSpeechModel
  {

    [JsonProperty("speech")]
    public string Speech { get; set; }

    [JsonProperty("displayText")]
    public string DisplayText { get; set; }

    [JsonProperty("data")]
    public Data Data { get; set; }

    [JsonProperty("contextOut")]
    public IList<object> ContextOut { get; set; }
  }

  public class HomeController : Controller
  {

    string respones = @"{
  'fulfillmentText': 'Dipu, This is a text response for Dipus testing',
  'fulfillmentMessages': [
    {
      'card': {
        'title': 'card title',
        'subtitle': 'card text',
        'imageUri': 'https://assistant.google.com/static/images/molecule/Molecule-Formation-stop.png',
        'buttons': [
          {
            'text': 'button text',
            'postback': 'https://assistant.google.com/'
          }
        ]
      }
    }
  ],
  'source': 'example.com',
  'payload': {
    'google': {
      'expectUserResponse': true,
      'richResponse': {
        'items': [
          {
            'simpleResponse': {
              'textToSpeech': 'Dipu, this is a simple response for Dipu'
            }
          }
        ]
      }
    },
    'facebook': {
      'text': 'Hello, Facebook!'
    },
    'slack': {
      'text': 'This is a text response for Slack.'
    }
  },
  'outputContexts': [
    {
      'name': 'projects/${PROJECT_ID}/agent/sessions/${SESSION_ID}/contexts/context name',
      'lifespanCount': 5,
      'parameters': {
        'param': 'param value'
      }
    }
  ],
  'followupEventInput': {
    'name': 'event name',
    'languageCode': 'en-US',
    'parameters': {
      'param': 'param value'
    }
  }
}";
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult GetSpeechJson()
    {
      //GoogleSpeechModel model = new GoogleSpeechModel();
      //model.Speech = "Hello Deepu, this is from hosted web service.";
      //model.DisplayText = "Hello Deepu, this is the display from hosted web service.";
      //return Ok(model);

      var data = @"{
              'speech': 'Hello Team!The API speech is working',
              'displayText': 'Hello Team! The API text is working',
              'data': {
                    'google': {
                      'expect_user_response': true,
                  'is_ssml': true,
                  'permissions_request': {
                        'opt_context': '...',
                    'permissions': [
                      'NAME',
                      'DEVICE_COARSE_LOCATION',
                      'DEVICE_PRECISE_LOCATION'
                    ]
              }
            }
              },
              'contextOut': [],
            }";

      GoogleSpeechModel model = JsonConvert.DeserializeObject<GoogleSpeechModel>(data);
      return Ok(model);
    }

    [HttpPost]
    public IActionResult GoogleSpeechWebhookPost(GoogleSpeechRequest request)
    {
      Models.Response.GoogleSpeechResponse model = JsonConvert.DeserializeObject<Models.Response.GoogleSpeechResponse>(respones);
      return Ok(model);
    }
    public IActionResult GoogleSpeechWebhookGet()
    {
      Models.Response.GoogleSpeechResponse model = JsonConvert.DeserializeObject<Models.Response.GoogleSpeechResponse>(respones);
      return Ok(model);
    }
  }
}
