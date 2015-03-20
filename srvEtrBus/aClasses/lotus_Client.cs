using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvEtrBus.aClasses
{
    public class lotus_Client : obj2XML
    {
        public string PT = "";

        public string F_NAME = "";
        public string L_NAME = "";
        public string M_NAME = "";

        public string S_INN = "";

        public List<M_CONTACT> M_CONTACTS = new List<M_CONTACT>();


        public string DMC_Program = "";
        public string DMC_CardNum = "";
        public string Comm_for_CC = "";

        /*"<lotus_Client><PT></PT>
		<F_NAME>Андрій</F_NAME>
		<L_NAME>Кметюк</L_NAME>
		<M_NAME>Володимирович</M_NAME>
		<M_CONTACTS>
			<M_CONTACT>
				<M_PHONE>+380503849909</M_PHONE>
			</M_CONTACT>
		</M_CONTACTS>
</lotus_Client>"

         	sResult = sResult + "<M_CONTACTS>"
                    Forall x In v 
                        sResult = sResult + "<M_CONTACT>"
                        sResult = sResult  + "<M_PHONE>" + Cstr(x) + "</M_PHONE>"
                        sResult = sResult + "</M_CONTACT>"
                    End Forall
                    sResult = sResult + "</M_CONTACTS>"
         */
    }

    public class M_CONTACT
    {
       public string M_PHONE = "";
    }

}
