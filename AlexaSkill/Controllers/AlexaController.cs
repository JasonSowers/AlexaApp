using System.Web.Http;
using AlexaPOCDataModel;

namespace AlexaSkill.Controllers
{
    
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/alexa/demo")]
        public dynamic nachos(AlexaRequest alexaRequest)
        {
            //var request = 
                new Requests().Create(new Request
                {
                MemberId = (alexaRequest.Session.Attributes == null) ? 0 : alexaRequest.Session.Attributes.MemberId,
                Timestamp = alexaRequest.Request.Timestamp,
                Intent = (alexaRequest.Request.Intent == null) ? "" : alexaRequest.Request.Intent.Name,
                AppId = alexaRequest.Session.Application.ApplicationId,
                RequestId = alexaRequest.Request.RequestId,
                SessionId = alexaRequest.Session.SessionId,
                UserId = alexaRequest.Session.User.UserId,
                IsNew = alexaRequest.Session.New,
                Version = alexaRequest.Version,
                Type = alexaRequest.Request.Type,
                Reason = alexaRequest.Request.Reason,                
                DateCreated = System.DateTime.UtcNow
            });
            return new
            {

                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Hello World"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "Pliralsight",
                        content = "Hello\ncruel world!"
                    },
                    shouldEndSession = true
                }

               
            };
        }
    }
}
