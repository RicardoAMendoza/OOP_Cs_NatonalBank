using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // windows forms
using System.Xml; // xml documents


namespace prjWin_NationalBank_Rm
{
    /*
       * This project uses the following licenses:
       *  MIT License
       *  Copyright (c) 2017 Ricardo Mendoza 
       *  Montréal Québec Canada
       *  Institut Teccart
       *  www.teccart.qc.ca
       *  Août 2017
       */
    public static class clsDataSave
    {
        // Attributes
        public static clsListDirecteurs listDirectors = new clsListDirecteurs();
        public static clsListAdmins listAdmins = new clsListAdmins();
        public static clsListAgencies listAgencies = new clsListAgencies();
        public static clsListEmployees listEmployees = new clsListEmployees();
        public static clsListClients listClients = new clsListClients();
        public static clsListPaidAccounts listPaidAccounts = new clsListPaidAccounts();
        public static clsListUnpaidAccounts listUnpaidAccounts = new clsListUnpaidAccounts();
        public static string agencyNumber;

        /// <summary>
        /// Write directors information in to a XML file
        /// </summary>
        /// <returns>procedure</returns>
        public static void fncWriteDirectorsinlineXML()
        {
            listDirectors = frmBank.fncGetvListDirecteurs();
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;

            XmlWriter writer = XmlWriter.Create(Application.StartupPath + @"/1.infoDirectorinLine.xml", set);
            writer.WriteStartDocument();
            writer.WriteStartElement("Directors");
            foreach (clsDirecteur element in listDirectors.Elements)
            {
                writer.WriteStartElement("Director");

                writer.WriteAttributeString("number", element.vNumber);
                writer.WriteAttributeString("lastName", element.vLastName);
                writer.WriteAttributeString("salary", element.vSalary.ToString());
                writer.WriteAttributeString("photoString", element.vPhoto);
                writer.WriteElementString("name", element.vName);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show(listDirectors.Quantity.ToString() + " Directors were added to a xml document !");
        }
        /// <summary>
        /// Write admin information in to a XML file
        /// </summary>
        /// <returns>procedure</returns>
        public static void fncWriteAdminsinXML()
        {
           listAdmins = frmBank.fncGetvListAdmins();
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;

            XmlWriter writer = XmlWriter.Create(Application.StartupPath + @"/2.infoAdminin.xml", set);
            writer.WriteStartDocument();
            writer.WriteStartElement("Admins");
            foreach (clsAdmin element in listAdmins.Elements)
            {
                writer.WriteStartElement("Admin");
                writer.WriteElementString("number", element.vNumber);
                writer.WriteElementString("name", element.vName);
                writer.WriteElementString("lastName", element.vLastName);
                writer.WriteElementString("e-mail", element.vEmail);
                writer.WriteElementString("password", element.vPassword);
                writer.WriteElementString("photoString", element.vPhoto);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show(listAdmins.Quantity.ToString() + " Admins were added to a xml document !");
        }
        /// <summary>
        /// Write agencies information in to a XML file
        /// </summary>
        /// <returns>procedure</returns>
        public static void fncWriteAgencieslineinXML()
        {
            try
            {
                listAgencies = frmBank.fncGetvListAgencies();
                XmlWriterSettings set = new XmlWriterSettings();
                set.Indent = true;

                XmlWriter writer = XmlWriter.Create(Application.StartupPath + @"/3.infoAgencyinLine.xml", set);
                writer.WriteStartDocument();
                writer.WriteStartElement("Agencies");
                foreach (clsAgency element in listAgencies.Elements)
                {
                    writer.WriteStartElement("Agency");
                    writer.WriteAttributeString("idCounter", element.vagencyIdCounter.ToString());
                    writer.WriteAttributeString("number", element.vAgencyNumber);
                    writer.WriteAttributeString("adress", element.vAgencyAddress);
                    writer.WriteElementString("name", element.vAgencyName);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                MessageBox.Show(listAgencies.Quantity.ToString() + " Agencies were added to a xml document !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Write employees information in to a XML file
        /// </summary>
        /// <returns>procedure</returns>
        public static void fncWriteEmployeeslineinXML()
        {
            try
            {
                listEmployees = frmBank.fncGetvListEmployees();
                XmlWriterSettings set = new XmlWriterSettings();
                set.Indent = true;
                XmlWriter writer = XmlWriter.Create(Application.StartupPath + @"/4.infoEmployeeinLine.xml", set);
                writer.WriteStartDocument();
                writer.WriteStartElement("Employees");
                foreach (clsEmployee element in listEmployees.Elements)
                {
                    writer.WriteStartElement("Employee");
                    writer.WriteAttributeString("idCounter", element.vemployeeIdCounter.ToString());
                    writer.WriteAttributeString("number", element.vNumber);
                    writer.WriteAttributeString("lastName", element.vLastName);
                    writer.WriteAttributeString("photo", element.vPhoto);
                    writer.WriteAttributeString("year", element.vHiringDate.vYear.ToString());
                    writer.WriteAttributeString("month", element.vHiringDate.vMonth.ToString());
                    writer.WriteAttributeString("day", element.vHiringDate.vDay.ToString());

                    writer.WriteElementString("name", element.vName);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                MessageBox.Show(listEmployees.Quantity.ToString() + " Employees were added to a xml document !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Write clients information in to a XML file
        /// </summary>
        /// <returns>procedure</returns>
        public static void fncWriteClientslineinXML()
        {
            try
            {
                listClients = frmBank.fncGetvListClients();
                XmlWriterSettings set = new XmlWriterSettings();
                set.Indent = true;
                XmlWriter writer = XmlWriter.Create(Application.StartupPath + @"/5.infoClientinLine.xml", set);
                writer.WriteStartDocument();
                writer.WriteStartElement("Clients");
                foreach (clsClient element in listClients.Elements)
                {
                    writer.WriteStartElement("Client");
                    writer.WriteAttributeString("idCounter", element.vclientIdCounter.ToString());
                    writer.WriteAttributeString("number", element.vNumber);
                    writer.WriteAttributeString("lastName", element.vLastName);
                    writer.WriteAttributeString("nip", element.vNip);
                    writer.WriteAttributeString("address", element.vAddress);
                    writer.WriteAttributeString("adviserNumber", element.vEmployee.vNumber);
                    writer.WriteAttributeString("adviserName", element.vEmployee.vName);
                    writer.WriteAttributeString("adviserLastName", element.vEmployee.vLastName);
                    writer.WriteAttributeString("hiringYear", element.vEmployee.vHiringDate.vYear.ToString());
                    writer.WriteAttributeString("hiringMonth", element.vEmployee.vHiringDate.vMonth.ToString());
                    writer.WriteAttributeString("hiringDay", element.vEmployee.vHiringDate.vDay.ToString());
                    writer.WriteAttributeString("photoAdviser", element.vEmployee.vPhoto);
                    writer.WriteElementString("name", element.vName);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                MessageBox.Show(listClients.Quantity.ToString() + " Clients were added to a xml document !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Write paid accounts information in to a XML file
        /// </summary>
        /// <returns>procedure</returns>
        public static void fncWritePaidAccountsinXML()
        {
           listPaidAccounts = frmBank.fncGetvListPaidAccounts();
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;

            XmlWriter writer = XmlWriter.Create(Application.StartupPath + @"/6.infoPaidAccountin.xml", set);
            writer.WriteStartDocument();
            writer.WriteStartElement("PaidAccounts");
            foreach (clsPaidAccount paidAccount in listPaidAccounts.Elements)
            {
                writer.WriteStartElement("PaidAccount");
                writer.WriteElementString("interestRate", (paidAccount.vInterestRate / 100).ToString());
                writer.WriteElementString("number", paidAccount.vNumber);
                writer.WriteElementString("type", paidAccount.vType);
                writer.WriteElementString("balance", paidAccount.vBalance.ToString());
                writer.WriteElementString("openDay", paidAccount.vOpenDate.vDay.ToString());
                writer.WriteElementString("openMonth", paidAccount.vOpenDate.vMonth.ToString());
                writer.WriteElementString("openYear", paidAccount.vOpenDate.vYear.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show(listPaidAccounts.Quantity.ToString() + " Paid Accounts were added to a xml document !");
        }
        /// <summary>
        /// Write un paid account information in to a XML file
        /// </summary>
        /// <returns>procedure</returns>
        public static void fncWriteUnPaidAccountsinXML()
        {
            listUnpaidAccounts = frmBank.fncGetvListUnPaidAccounts();
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;

            XmlWriter writer = XmlWriter.Create(Application.StartupPath + @"/7.infoUnPaidAccountin.xml", set);
            writer.WriteStartDocument();
            writer.WriteStartElement("UnPaidAccounts");
            foreach (clsUnpaidAccount unPaidAccount in listUnpaidAccounts.Elements)
            {
                writer.WriteStartElement("UnPaidAccount");
                writer.WriteElementString("commission", (unPaidAccount.vCommission).ToString());
                writer.WriteElementString("overdraft", (unPaidAccount.vOverdraft).ToString());
                writer.WriteElementString("number", unPaidAccount.vNumber);
                writer.WriteElementString("type", unPaidAccount.vType);
                writer.WriteElementString("balance", unPaidAccount.vBalance.ToString());
                writer.WriteElementString("openDay", unPaidAccount.vOpenDate.vDay.ToString());
                writer.WriteElementString("openMonth", unPaidAccount.vOpenDate.vMonth.ToString());
                writer.WriteElementString("openYear", unPaidAccount.vOpenDate.vYear.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show(listUnpaidAccounts.Quantity.ToString() + " Paid Accounts were added to a xml document !");
        }
    }
}
