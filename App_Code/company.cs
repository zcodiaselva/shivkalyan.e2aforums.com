using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CsCompany {

    public abstract class clscon
    {
        protected SqlConnection con = new SqlConnection();
        public clscon()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
     
       }

    }
#region InterfaceComp
    public interface Int_Comp
    {
        Int32  CompID	{get;set;}
        String CompLogo	{get;set;}
        String CompName	{get;set;}
        String CompAdd1	{get;set;}
        String CompAdd2	{get;set;}
        String CompAdd3	{get;set;}
        Int32 CompStateID	{get;set;}
        Int32 CompCityID	{get;set;}
        String  CompPhnNO	{get;set;}
        String CompInBusinessSince	{get;set;}
        String CompAbout	{get;set;}
        String  EMail {get;set;}
        String Password {get;set;}
        String Full_Name { get; set; }
        String LastName { get; set; }    
    }
#endregion InterfaceComp

    #region PropertyClass
    public class clsCompPrp : Int_Comp
    {
        Int32  PCompID	;
        String PCompLogo;
        String PCompName;
        String PCompAdd1;
        String PCompAdd2;
        String PCompAdd3;
        Int32 PCompStateID;
        Int32 PCompCityID	;
        String PCompPhnNO	;
        String PCompInBusinessSince	;
        String PCompAbout;
       //Add Fields
        String PEMail;
        String PPassword;
        String PFull_Name;
        String PLastName;

        // Extra Fiels Start
        public string LastName
        {
            get
            {
                return PLastName;
            }
            set
            {
                PLastName = value;
            }
        }
        public string EMail
        {
            get
            {
                return PEMail;
            }
            set
            {
                PEMail = value;
            }
        }
        public string Password
        {
            get
            {
                return PPassword;
            }
            set
            {
                PPassword = value;
            }
        }
        public string Full_Name
        {
            get
            {
                return PFull_Name;
            }
            set
            {
                PFull_Name = value;
            }
        }
        // Extra Fiels End
        
        public int CompID
        {
            get
            {
                return PCompID;
            }
            set
            {
                PCompID = value;
            }
        }

        public string CompLogo
        {
            get
            {
                return PCompLogo;
            }
            set
            {
                PCompLogo = value;
            }
        }

        public string CompName
        {
            get
            {
                return PCompName;
            }
            set
            {
                PCompName = value;
            }
        }

        public string CompAdd1
        {
            get
            {
                return PCompAdd1;
            }
            set
            {
                PCompAdd1 = value;
            }
        }

        public string CompAdd2
        {
            get
            {
                return PCompAdd2;
            }
            set
            {
                PCompAdd2 = value;
            }
        }

        public string CompAdd3
        {
            get
            {
                return PCompAdd3;
            }
            set
            {
                PCompAdd3 = value;
            }
        }

        public int CompStateID
        {
            get
            {
                return PCompStateID;
            }
            set
            {
                PCompStateID = value;
            }
        }

        public int CompCityID
        {
            get
            {
                return PCompCityID;
            }
            set
            {
                PCompCityID = value;
            }
        }

        public string CompPhnNO
        {
            get
            {
                return PCompPhnNO;
            }
            set
            {
                PCompPhnNO = value;
            }
        }

        public string CompInBusinessSince
        {
            get
            {
                return PCompInBusinessSince;
            }
            set
            {
                PCompInBusinessSince = value;
            }
        }

        public string CompAbout
        {
            get
            {
                return PCompAbout;
            }
            set
            {
                PCompAbout = value;
            }
        }
    }
    #endregion PropertyClass

#region Class

    public class clscomp:clscon
    {
        



    }


#endregion Class  

}