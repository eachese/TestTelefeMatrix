using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfTelefeMatrix
{
    [ServiceContract]
    public interface ITelefeService
    {

        [OperationContract]
        [WebInvoke(
          Method = "GET"
          , UriTemplate = "GetPosiciones?word={word}"
          , BodyStyle = WebMessageBodyStyle.WrappedRequest
          , RequestFormat = WebMessageFormat.Json
          , ResponseFormat = WebMessageFormat.Json)]
        List<List<int>> GetPosiciones(string word);

        [OperationContract]
        [WebInvoke(
          Method = "GET"
          , UriTemplate = "ChangeSecuencias?secuencia={secuencia}"
          , BodyStyle = WebMessageBodyStyle.WrappedRequest
          , RequestFormat = WebMessageFormat.Json
          , ResponseFormat = WebMessageFormat.Json)]
        void ChangeSecuencias(string[] secuencia);

        [OperationContract]
        [WebInvoke(
         Method = "GET"
         , UriTemplate = "GetSearchs"
         , BodyStyle = WebMessageBodyStyle.WrappedRequest
         , RequestFormat = WebMessageFormat.Json
         , ResponseFormat = WebMessageFormat.Json)]
        List<string> GetSearchs();
    }

}
