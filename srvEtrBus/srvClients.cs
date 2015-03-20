using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using srvEtrBus.aClasses;

// http://192.168.0.77:8080/IMPR/TasWebDB.nsf/ClientsInfoSrv?WSDL
// http://sebus.tas-insurance.com.ua/srvEtrBus.srvClients.svc

namespace srvEtrBus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class srvClients : ISrvClients
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

        public cl_Client getClientByPhone(cl_SearchOption s, cl_authority a)
        {
            cl_Client c = null;
            if (s == null || a == null ) return c;
            string rk = "";

            // authorize by variabe "a"
            if (s.sPhone.Trim().Length == 0) return c;
            try
            {
                srvLotusClients.agentSrvClient lc = new srvLotusClients.agentSrvClient();
                string r = lc.GETCLIENTBYPHONE(s.sPhone);
                if (r.Trim().Length == 0) return c;

                lotus_Client lcR = new lotus_Client();
                lcR = (lotus_Client)obj2XML.DeserializeMe( obj2XML.GenerateStreamFromString(r) , lcR.GetType() );


                if (lcR != null) 
                {
                    c = new cl_Client()
                    {
                        sFirstName = lcR.F_NAME,
                        sFullName = lcR.F_NAME,  // ((  lcR.F_NAME + " " + lcR.L_NAME ).Trim() + " " + lcR.M_NAME ).Trim() ,
                        sInn = lcR.S_INN,
                        sPersonType = lcR.PT,
                        sLastName = lcR.L_NAME,
                        sMiddleName = lcR.M_NAME,
                        sDMC_CardNum = lcR.DMC_CardNum,
                        sComm_ForCC = lcR.Comm_for_CC,
                        sDMC_Programm = lcR.DMC_Program
                    };
                }
                else {
                    rk = "Some unexpected error";
                    if (r.Length == 0) rk = "No Client Info";
                    if (r.Length > 0) rk = r;  // "Can't deserialized";
                    if (c == null) c = new cl_Client() { sError = rk};
                }
                
            }
            catch (Exception ex) { 
                rk = ex.Message;
                if (c == null) c = new cl_Client();
                c.sError = rk;
            }

            return c;
        }


        string ISrvClients.getClientByPhoneXML(cl_SearchOption s, cl_authority a)
        {
            cl_Client c = this.getClientByPhone(s, a);

            if (c == null) return "null";
         //   if (!c.IsValid) return "";

           return obj2XML.Serialize(c);
        }
    

}
}
