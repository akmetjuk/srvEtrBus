using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using srvEtrBus.aClasses;

namespace srvEtrBus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISrvClients
    {
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        cl_Client getClientByPhone(cl_SearchOption s, cl_authority a);

        [OperationContract]
        string getClientByPhoneXML(cl_SearchOption s, cl_authority a);

    }

    [DataContract]
    public class cl_authority
    {
        string sPassword = "";
        string sLogin = "";
        string sPublicCode = "";

        [DataMember]
        public string login
        {
            get { return sLogin; }
            set { sLogin = login; }
        }

        [DataMember]
        public string password
        {
            get { return sPassword; }
            set { sPassword = password; }
        }

        [DataMember]
        public string q_code
        {
            get { return sPublicCode; }
            set { sPublicCode = q_code; }
        }
    }

    [DataContract]
    public class cl_SearchOption
    {
        public string sInsCode = "";
        [DataMember]
        public string sPhone = ""; //"380503849909";
    }

    [DataContract]
    public class cl_Client 
    {
        bool isValid = false;
        string sinn = "";
        string s_err = "";

        [DataMember]
        public bool IsValid
        {
            get { return isValid; }
            set { }
        }

        [DataMember]
        public string sFullName = "";
        [DataMember]
        public string sLastName = "";
        [DataMember]
        public string sFirstName = "";
        [DataMember]
        public string sMiddleName = "";
        [DataMember]
        public string sPersonType = "";
        [DataMember]
        public string sDMC_Programm = "";
        [DataMember]
        public string sDMC_CardNum = "";
        [DataMember]
        public string sComm_ForCC = "";
        [DataMember]
        public string sInn
        {
            get { return sinn; }
            set { this.isValid = true; sinn = value; }
        }
        [DataMember]
        public string sError
        {
            get { return s_err; }
            set { this.isValid = false; s_err = value; }
        }     
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "srvEtrBus.ContractType".
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
