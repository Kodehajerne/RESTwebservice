﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace RESTwebserviceVejrstation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    [ServiceContract]
   
    public interface IService1
    {

        [OperationContract]
        //Routing til metoden "GetAll".Bruges i browseren til at vise alt data fra databasen. 
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "getall/")]
        List<Dataset> GetAll();

        [OperationContract]
        //Routing til metoden "GetAll".Bruges i browseren til at vise alt data fra databasen. 
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "getnewest/")]
        Dataset getnewest();

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Delete/{id}")]
        void DeleteID(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "getavg/")]
        Dataset getavg();


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
