using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWin_NationalBank_Rm
{
    /// <summary>
    /// Ricardo Mendoza
    /// National Bank
    /// Institut Teccart
    /// www.teccart.qc.ca
    /// Montréal, Québec
    /// Août 2017
    /// </summary> 
    public class clsAdmin : clsHuman
    {
        /// <summary>
        /// Fields
        /// </summary>
        private string Email;
        private string Password;
        /// <summary>
        /// Admin counter
        /// </summary>
        private int adminIdCounter;
        private static int staticNbcounter;
        /// <summary>
        /// Objet number Admin type 
        /// </summary>
        public static int nbAdmin;
        /// <summary>
        /// Timer : define the time to close application
        /// </summary>
        private int Tick_Tack;
        /// <summary>
        /// DECLARE AN EVENT
        /// 1. define delegate
        /// public delegate void AdminDelegate(object source, clsAdminEventAgrs e);
        /// 2. define un event based on the delegate
        /// public event AdminDelegate ApplicationClosed;
        /// </summary>
        // EventHandler
        // EventHandler<TEventArgs>
        public event EventHandler<clsAdminEventAgrs> ApplicationClosed;
        public event EventHandler<clsAdminEventAgrs> ApplicationWarned;

        /// <summary>
        /// Constructor that takes six arguments.
        /// </summary>
        public clsAdmin(int vTick_Tack, string vNumber, string vName, string vLastName, string vEmail, string vPassword, string vPhoto) : base(vNumber, vName, vLastName, vPhoto)
        {
            clsAdmin.staticNbcounter++;
            adminIdCounter = staticNbcounter;
            nbAdmin++;
            Email = vEmail;
            Password = vPassword;
            Tick_Tack = vTick_Tack * 1000;
        }
        /// <summary>
        /// Constructor that takes five arguments.
        /// </summary>
        public clsAdmin(int vTick_Tack, string vNumber, string vName, string vLastName, string vEmail, string vPassword) : base(vNumber, vName, vLastName)
        {
            clsAdmin.staticNbcounter++;
            adminIdCounter = staticNbcounter;
            nbAdmin++;
            Email = vEmail;
            Password = vPassword;
            Tick_Tack = vTick_Tack * 1000;
        }
        /// <summary>
        /// Constructor that takes no arguments.
        /// </summary>
        public clsAdmin() : base()
        {
            clsAdmin.staticNbcounter++;
            adminIdCounter = staticNbcounter;
            nbAdmin++;
            Email = clsDataSource.fncEmptyConstructor();
            Password = clsDataSource.fncEmptyConstructor();
            Tick_Tack = 1;
        }
        /// <summary>
        /// 3. Raise the event
        /// </summary>
        public void OnApplicationClosed()
        {
            if (ApplicationClosed != null)
            {
                ApplicationClosed(this, new clsAdminEventAgrs("An event started : you just have 5 minuts in admin control !!"));
            }
        }
        public void OnApplicationWarned()
        {
            if (ApplicationWarned != null)
            {
                ApplicationWarned(this, new clsAdminEventAgrs("The application will be closed in 2 minuts !!"));
            }
        }
        /// <summary>
        /// Timer : define the time to close application
        /// </summary>
        public int vTick_Tack
        {
            get { return Tick_Tack; }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        Tick_Tack = 1000;
                    }
                    else
                    {
                        Tick_Tack = value * 1000;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        /// <summary>
        /// Properties.
        /// </summary>
        public int vadminIdCounter
        {
            get { return adminIdCounter; }
        }
        public int vnbAdmin
        {
            get { return nbAdmin; }
        }

        public string vEmail
        {
            get { return Email; }
            set { Email = value; }
        }

        public string vPassword
        {
            get { return Password; }
            set { Password = value; }
        }
        /// <summary>
        /// Override Methods.
        /// fncCreateaHuman(string vName, string vLastName) -> constructs an Admin
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="vLastName"></param>
        public override void fncCreateaHuman(string vName, string vLastName)
        {
            clsAdmin.staticNbcounter++;
            Email = vEmail;
            Password = vPassword;
            base.fncCreateaHuman(vName, vLastName);
        }
        /// <summary>
        /// Override Methods.
        /// fncDisplayHuman() -> info from a Client
        /// </summary>
        /// <returns>info</returns>
        public override string fncDisplayHuman()
        {
            string info = "";
            info += "\nId : " + adminIdCounter;
            info += base.fncDisplayHuman();
            info += "\nUser : " + Email;
            info += "\nPassword : " + Password;
            return info;
        }
    }
}
