using System;
using System.Drawing;
using System.Windows.Forms;

using System.IO; // file stream
using iTextSharp.text; // pdf
using iTextSharp.text.pdf; // pdf

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
    public partial class frmBank : Form
    {
        /// <summary>
        /// Timer
        /// </summary>
        System.Timers.Timer CLock = new System.Timers.Timer();
        int h, m, s;
        /// <summary>
        /// Timer speed
        /// </summary>
        int interval = 1000;
        /// <summary>
        /// Bank Object -> Initialize
        /// </summary>
        public static clsNationalBank myBank = new clsNationalBank();
        /// <summary>
        /// Director Object
        /// </summary>
        clsDirecteur actualDirecteur;
        /// <summary>
        /// Admin Object
        /// </summary>
        clsAdmin actualAdmin;
        /// <summary>
        /// Agency Object
        /// </summary>
        public static clsAgency actualAgency = new clsAgency();
        /// <summary>
        /// Employee Object
        /// </summary>
        clsEmployee actualEmployee;
        /// <summary>
        /// Client Object
        /// </summary>
        public static clsClient actualClient = new clsClient();
        /// <summary>
        /// UnpaidAccount Object
        /// </summary>
        clsUnpaidAccount actualUnpaidAccount;
        /// <summary>
        /// PaidAccount Object
        /// </summary>
        public static clsPaidAccount actualPaidAccount = new clsPaidAccount();
        /// <summary>
        /// Initial height tab control
        /// </summary>
        static int tabControlBankHeight = 370;
        /// <summary>
        /// Initial height form
        /// </summary>
        static int thisHeight = 470;
        /// <summary>
        /// Internal bank height tab control tabControlBank
        /// </summary>
        static int InternatabControlBankHeight = 459;
        /// <summary>
        /// Internal bank height form : 554
        /// </summary>
        static int InternalBankthisHeight = 554;
        /// <summary>
        /// Internal bank height tab control tabControlBank
        /// </summary>
        static int InternatabControlBankHeightAdminSpace = 759;
        /// <summary>
        /// Internal bank height form : 554
        /// </summary>
        static int InternalBankthisHeightAdminSpace = 854;
        /// <summary>
        /// Static variable (staticVariableDirectorPhoto) that contains the photo string selectione in 'Create Bank'
        /// </summary>
        static string staticVariableDirectorPhoto;
        /// <summary>
        /// Static variable that contains the agenci number for admin and controls the employee search
        /// </summary>
        static string staticAdminAgenciesNumber;
        /// <summary>
        /// Static variable that contains the client number for admin and controls the account search
        /// </summary>
        static string staticAdminClientsNumber;
        /// <summary>
        /// Varaible counter in the btnBwrDirector and btnFwrDirector
        /// </summary>
        public int directorCnc;
        /// <summary>
        /// Varaible counter in the btnBwrAdmin and btnFwrAdmin
        /// </summary>
        public int adminCnc;
        /// <summary>
        /// Varaible counter in the btnBwrAgencies and btnFwrAgencies
        /// </summary>
        public int agenciesCnc;

        /// <summary>
        ///  Variable to write a deposit receipt in the Strategy design pattern
        /// </summary>
        public clsReceiptDepositPdf WritingDepositPdf =  new clsReceiptDepositPdf();
        /// <summary>
        ///  Variable to write a withdraw receipt in the Strategy design pattern
        /// </summary>
        public clsReceiptWithdrawPdf WritingWithdrawPdf = new clsReceiptWithdrawPdf();
        /// <summary>
        ///  Variable to write a consult receipt in the Strategy design pattern
        /// </summary>
        public clsReceiptConsultPdf WritingConsultPdf = new clsReceiptConsultPdf();

        private void frmBank_Load(object sender, EventArgs e)
        {
            try
            {
                // Admin
                txtAdminDirectorNumber.Text = "D2D2";
                /// <summary>
                /// Static variable that contains the agenci number for admin
                /// </summary>
                txtAdminAgenciesNumber.Text = staticAdminAgenciesNumber = "A1A1";

                txtAdminAdminsNumber.Text = txtAdminAdminNumber.Text = "admin01";
                txtAdminAdminPassword.Text = "sql";
                // admin employees
                txtAdminEmployeesAgency.Enabled = false;
                // admin clients
                txtAdminClientsAgency.Enabled = false;
                // admin clients adviser
                txtAdminClientAdviserClientNumber.Enabled = false;

                // fill list director
                myBank.vListDirecteurs = clsDataSource.fnGetDirecteurs();
                // fill list admins
                myBank.vListAdmins = clsDataSource.fncGetAdmins();
                // fill list agencies
                myBank.vListAgencies = clsDataSource.fncGetAgencies();

                // start values
                lblBankTransactionDescriptionName.Text = "National Bank";
                lblBankTransactionDescriptionAddress.Text = "3030 Hochelaga";
                lblBankTransactionDescriptionDirector.Text = "Director : " + " " + "Patrick" + " " + "Dorre";
                pictureBoxBankTransactionDescriptionDirector.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Directors/dorre.png");
                txtTransactionsClientNumber.Text = "C1C1";
                txtTransactionsClientNip.Text = "windows";

                // start transaction controls
                txtTransactionsDeposit.Visible = false;
                txtTransactionsWithdraw.Visible = false;
                radTransactionsDeposit.Checked = false;
                radTransactionsWithdraw.Checked = false;
                radTransactionsConsult.Checked = true;

                /// <summary>
                /// function load agencies in the combos : comboBankTransactionsAgency, comboBankAgency, comboAgenciesAgency
                /// </summary>
                fncLoadCombosAgencies();
                /// <summary>
                /// // function load directors in comboCreateBankDirector
                /// </summary>
                fncLoadComboDirector();
                /// <summary>
                /// Load combo admins in Tab Bank
                /// </summary>
                fncLoadComboBankAdmins();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public frmBank()
        {
            InitializeComponent();

            /// <summary>
            /// Function that size the form when it is load
            /// </summary>
            fncFormInitialSize();
            /// <summary>
            /// PictureBox photo Employee : Path to get the picture in file
            /// </summary>
            pictureBoxAgenciesEmployee.Image = pictureBoxClientsAdviser.Image = pictureBoxAdminSpaceAdminEmployees.Image = pictureBoxAdminSpaceClientAdviser.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/InitializeComponent/robotica.png");
            // <summary>
            /// PictureBox photo Director : Path to get the picture in file
            /// </summary>
            pictureBoxCreateDirector.Image = pictureBoxBankDescriptionDirector.Image = pictureBoxDirector.Image = pictureBoxAdminSpaceAdminDirector.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/InitializeComponent/robotica.png");
            // <summary>
            /// PictureBox photo Admin : Path to get the picture in file
            /// </summary>
            pictureBoxAdminSpaceAdminAdmin.Image = pictureBoxAdminSpaceAdminAdmins.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/InitializeComponent/robotica.png");

            btnFwrDirector.Enabled = false;
            btnBwrDirector.Enabled = false;
            btnFwrAdmin.Enabled = false;
            btnBwrAdmin.Enabled = false;
            btnFwrAgencies.Enabled = false;
            btnBwrAgencies.Enabled = false;
            lblTick_Tack.Visible = false;
            listBoxAdmin.Visible = false;

            groupBoxAdminDirector.Enabled = groupBoxAdminAdmins.Enabled = groupBoxAdminAgencies.Enabled = groupBoxAdminEmployees.Enabled = false;
            groupBoxAdminClients.Enabled = groupBoxAdminAdviser.Enabled = groupBoxAdminPaidAccount.Enabled = groupBoxAdminUnPaidAccount.Enabled = false;
        }

        /// <summary>
        /// starts the trtansaction with the client number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransactionsClientNumber_Click(object sender, EventArgs e)
        {
            try
            {
                string clientNumber = txtTransactionsClientNumber.Text.Trim();

                actualClient = actualAgency.vListClients.fncFind(clientNumber);
                if (actualClient == null)
                {
                    MessageBox.Show("Invalid Card, Try Again !", "Number not found");
                    txtTransactionsClientNumber.Clear();
                    txtTransactionsClientNumber.Focus();
                    return;
                }
                fncSizeFormPinValidation();
                lblTransactionsClientDisplay.Text = "Welcome to NB, " + actualClient.vName + " " + actualClient.vLastName;
                groupBoxTransactionsReadingCard.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end btnTransactionsClientNumber

        public static clsClient  fncActualClient()
        {
            return actualClient;
        }


        /// <summary>
        /// Function to transfer actual vListDirecteurs to others classes need to be static
        /// </summary>
        /// <returns>myBank.vListDirecteurs</returns>
        //public static clsListDirecteurs fncGetvListDirecteurs()
        //{
        //    return myBank.vListDirecteurs;
        //}

        /// <summary>
        /// Select agency in the transaction tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBankTransactionsAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (clsAgency tmp in myBank.vListAgencies.Elements)
                {
                    if (tmp.vAgencyName == comboBankTransactionsAgency.SelectedItem.ToString())
                    {
                        actualAgency = tmp;
                        /// <summary>
                        /// Fills the client list for agency by agency number -> actualAgency.vAgencyNumber
                        /// </summary>
                        actualAgency.vListClients = clsDataSource.fncGetClients(actualAgency.vAgencyNumber);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end Select agency in the transaction tab
 
        // validate the customer's nip
        private void btnTransactionsClientNip_Click(object sender, EventArgs e)
        {
            try
            {
                string nip = txtTransactionsClientNip.Text.Trim();
                if (nip != actualClient.vNip)
                {
                    MessageBox.Show("Invalid Nip, Try Again !", "Incorrect Nip");
                    txtTransactionsClientNip.Clear();
                    txtTransactionsClientNip.Focus();
                    return;
                }
                actualClient.vListUnpaidAccounts = clsDataSource.fncGetUnpaidAccounts(actualClient.vNumber);
                foreach (clsUnpaidAccount tmp in actualClient.vListUnpaidAccounts.Elements)
                {
                    actualUnpaidAccount = tmp;
                    lblTransactionsAccountsUnpaidAccountNumber.Text = actualUnpaidAccount.vNumber;
                    lblTransactionsAccountsUnpaidAccountType.Text = actualUnpaidAccount.vType;
                    lblTransactionsAccountsUnpaidAccountCommission.Text = (actualUnpaidAccount.vCommission * 100).ToString() + " " + " % ";
                    lblTransactionsAccountsUnpaidAccountOverdraft.Text = actualUnpaidAccount.vOverdraft.ToString() + " " + " $ ";
                    lblTransactionsAccountsUnpaidAccountBalance.Text = actualUnpaidAccount.vBalance.ToString() + " " + " $ ";

                    // MessageBox.Show(tmp.vNumber);
                    // MessageBox.Show(tmp.vType);
                }
                actualClient.vListPaidAccounts = clsDataSource.fncGetPaidAccounts(actualClient.vNumber);
                foreach (clsPaidAccount tmp in actualClient.vListPaidAccounts.Elements)
                {
                    actualPaidAccount = tmp;
                    lblTransactionsAccountsPaidAccountNumber.Text = actualPaidAccount.vNumber;
                    lblTransactionsAccountsPaidAccountType.Text = actualPaidAccount.vType;
                    lblTransactionsAccountsPaidAccountInterestPayable.Text = (actualPaidAccount.vInterestRate).ToString() + " " + " % ";
                    lblTransactionsAccountsPaidAccountBalance.Text = actualPaidAccount.vBalance.ToString() + " " + " $ ";
                }
                /// <summary>
                /// Function that size the form by clicking the button next in pin validation
                /// </summary>
                fncSizeFormAccounts();
                groupBoxTransactionsReadingNip.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// end btnTransactionsClientNumber

        // opens the customers unpaid accounts
        private void btnTransactionsUnpaidAccount_Click(object sender, EventArgs e)
        {
            try
            {
                lblTransactionsDisplayAccountNumber.Text = actualUnpaidAccount.vNumber;
                lblTransactionsDisplayAccountType.Text = actualUnpaidAccount.vType;
                /// <summary>
                /// Function that size th form by clicking the button next in accounts
                /// </summary>
                fncSizeFormTransactionAccounts();
                groupBoxTransactionsAccounts.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// end btnTransactionsUnpaidAccount

        // opens the customers paid accounts
        private void btnTransactionsPaidAccount_Click(object sender, EventArgs e)
        {
            try
            {
                lblTransactionsDisplayAccountType.Text = actualPaidAccount.vType;
                lblTransactionsDisplayAccountNumber.Text = actualPaidAccount.vNumber;
                /// <summary>
                /// Function that size th form by clicking the button next in accounts
                /// </summary>
                fncSizeFormTransactionAccounts();
                groupBoxTransactionsAccounts.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }// end btnTransactionsPaidAccount


        /// <summary>
        /// make the transactions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransactionsTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                /// <summary>
                /// Deposit : radTransactionsDeposit : actualUnpaidAccount
                /// </summary>
                if (radTransactionsDeposit.Checked && actualUnpaidAccount.vType == lblTransactionsDisplayAccountType.Text)
                {
                    double deposit = Convert.ToDouble(txtTransactionsDeposit.Text.Trim());
                    if (actualUnpaidAccount.fncDeposit(deposit) == false)
                    {
                        MessageBox.Show("The amount to be deposited must be between 5 000 $ and 20 $ !", "Invalid Depot");
                        txtTransactionsDeposit.Clear();
                        txtTransactionsDeposit.Focus();
                        return;
                    }
                    lblInfo.Text = actualUnpaidAccount.fncPrintBalanceUnPaidAccount();//funcion q viene de la clsAcount
                    MessageBox.Show(deposit.ToString() + " $ has been deposited in the Unpaid Account !");
                    /// <summary>
                    /// Add actualUnpaidAccount object to actualClient.vListUnpaidAccounts.
                    /// </summary>
                    actualClient.vListUnpaidAccounts.fncAdd(actualUnpaidAccount);
                    /// <summary>
                    /// Write actualUnpaidAccount object in to XML document.
                    /// </summary>
                    clsDataSave.fncWriteUnPaidAccountsinXML();
                    /// <summary>
                    /// writing PDF
                    /// </summary>
                    fncMessageBoxWritePdf();
                }
                /// <summary>
                /// Withdraw : radTransactionsWithdraw : actualUnpaidAccount
                /// </summary>
                else if (radTransactionsWithdraw.Checked && actualUnpaidAccount.vType == lblTransactionsDisplayAccountType.Text)
                {
                    double amount = Convert.ToInt32(txtTransactionsWithdraw.Text.Trim());
                    /// <summary>
                    /// Functions : Withdrawal
                    /// </summary>
                    /// <param name="amount"></param>
                    /// <returns>base.fncWithdrawl(amount);</returns>
                    int result = actualUnpaidAccount.fncWithdrawal(amount);
                    switch (result)
                    {
                        case 1:
                            MessageBox.Show("Inadequate funds, your current balance is  " + actualUnpaidAccount.vBalance, " Invalid Withdrawal ");
                            return;
                        case 2:
                            MessageBox.Show(" The amount must be a multiple of 20", " Invalid Withdrawal ");
                            return;
                        case -2:
                            MessageBox.Show(" The maximum amount to be withdrawn shall be 500 $", " Invalid Withdrawal ");
                            return;
                        case -1:
                            MessageBox.Show(" The minimum amount to be withdrawn shall be 20 $", " Invalid Withdrawal ");
                            return;
                    }
                    lblInfo.Text = actualUnpaidAccount.fncPrintBalanceUnPaidAccount();//funcion q viene de la clsAcount
                    MessageBox.Show(amount.ToString() + " $ has been withdrawen in the Unpaid Account !");
                    /// <summary>
                    /// Add actualUnpaidAccount object to actualClient.vListUnpaidAccounts.
                    /// </summary>
                    actualClient.vListUnpaidAccounts.fncAdd(actualUnpaidAccount);
                    /// <summary>
                    /// Write actualUnpaidAccount object in to XML document.
                    /// </summary>
                    clsDataSave.fncWriteUnPaidAccountsinXML();
                    /// <summary>
                    /// writing PDF
                    /// </summary>
                    fncMessageBoxWritePdf();
                }
                /// <summary>
                /// Deposit : radTransactionsDeposit : actualPaidAccount -> Paying interes in each transaction
                /// </summary>
                else if (radTransactionsDeposit.Checked && actualPaidAccount.vType == lblTransactionsDisplayAccountType.Text)
                {
                    double deposit = Convert.ToDouble(txtTransactionsDeposit.Text.Trim());
                    // 1.- The proces strat in this function -> fncDeposit(deposit)
                    if (actualPaidAccount.fncDeposit(deposit) == false)
                    {
                        MessageBox.Show("The amount to be deposited must be between 5 000 $ and 20 $ !", "Invalid Depot");
                        txtTransactionsDeposit.Clear();
                        txtTransactionsDeposit.Focus();
                        return;
                    }
                    // 2.- Print info account
                    lblInfo.Text = actualPaidAccount.fncPrintBalancePaidAccount();// funcion q viene de la clase padre clsAcount
                    // Interest added to the account function in thr clsPaidAccount
                    double interest = actualPaidAccount.fncInterestComission();
                    MessageBox.Show(" an amount of : " + deposit.ToString() + " $ deposit " + " +   " + interest + " $ of interest has been deposited in the Paid Accoun!");
                    /// <summary>
                    /// Add actualPaidAccount object to actualClient.vListUnpaidAccounts.
                    /// </summary>
                    actualClient.vListPaidAccounts.fncAdd(actualPaidAccount);
                    /// <summary>
                    /// Write actualPaidAccount object in to XML document.
                    /// </summary>
                    clsDataSave.fncWritePaidAccountsinXML();
                    /// <summary>
                    /// writing PDF
                    /// </summary>
                    fncMessageBoxWritePdf();
                }
                /// <summary>
                /// Withdraw : radTransactionsWithdraw : actualPaidAccount
                /// </summary>
                else if (radTransactionsWithdraw.Checked && actualPaidAccount.vType == lblTransactionsDisplayAccountType.Text)
                {
                    int amount = Convert.ToInt32(txtTransactionsWithdraw.Text.Trim());
                    int result = actualPaidAccount.fncWithdrawal(amount);

                    switch (result)
                    {
                        case 1:
                            MessageBox.Show("Inadequate funds, your current balance is  " + actualUnpaidAccount.vBalance, " Invalid Withdrawal ");
                            return;
                        case 2:
                            MessageBox.Show(" The amount must be a multiple of 20", " Invalid Withdrawal ");
                            return;
                        case -2:
                            MessageBox.Show(" The maximum amount to be withdrawn shall be 500 $", " Invalid Withdrawal ");
                            return;
                        case -1:
                            MessageBox.Show(" The minimum amount to be withdrawn shall be 20 $", " Invalid Withdrawal ");
                            return;
                    }
                    // 2.- Print info account
                    lblInfo.Text = actualPaidAccount.fncPrintBalancePaidAccount();// funcion q viene de la clase padre clsAcount
                    MessageBox.Show(amount.ToString() + " $ has been withdrawen  in the Paid Accoun!");
                    /// <summary>
                    /// Add actualPaidAccount object to actualClient.vListUnpaidAccounts.
                    /// </summary>
                    actualClient.vListPaidAccounts.fncAdd(actualPaidAccount);
                    /// <summary>
                    /// Write actualPaidAccount object in to XML document.
                    /// </summary>
                    clsDataSave.fncWritePaidAccountsinXML();
                    /// <summary>
                    /// writing PDF
                    /// </summary>
                    fncMessageBoxWritePdf();
                }
                /// <summary>
                /// actualPaidAccount
                /// </summary>
                else if (radTransactionsConsult.Checked && actualPaidAccount.vType == lblTransactionsDisplayAccountType.Text)
                {
                    lblInfo.Text = actualPaidAccount.fncPrintBalancePaidAccount();//funcion q viene de la clsAcount

                    /// <summary>
                    /// writing PDF
                    /// </summary>
                    fncMessageBoxWritePdf();
                }
                /// <summary>
                /// actualUnpaidAccount
                /// </summary>
                else if (radTransactionsConsult.Checked && actualUnpaidAccount.vType == lblTransactionsDisplayAccountType.Text)
                {
                    lblInfo.Text = actualUnpaidAccount.fncPrintBalanceUnPaidAccount();//funcion q viene de la clsAcount

                    /// <summary>
                    /// writing PDF
                    /// </summary>
                    fncMessageBoxWritePdf();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // End btnTransactionsTransaction

        /// <summary>
        /// Shows a message box button to write a pdf
        /// </summary>
        public void fncMessageBoxWritePdf()
        {
            // Initializes the variables to pass to the MessageBox.Show method.
            string message = "Would you like to print a receipt ?";
            string caption = "Write PDF";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(this, message, caption, buttons,
                            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Writing the PDF.
                try
                {
                    if (radTransactionsDeposit.Checked)
                    {
                        WritingDepositPdf.fncWriteDepositPdf();
                    }
                    if (radTransactionsWithdraw.Checked)
                    {
                        WritingWithdrawPdf.fncWriteWithdrawPdf();
                    }
                    if (radTransactionsConsult.Checked)
                    {
                        WritingConsultPdf.fncWriteConsultPdf();
                    }
                    /// <summary>
                    /// init transactions type
                    /// </summary>
                    fncInitTransactionTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        } // end message box button

        /// <summary>
        /// Init the transaction text boxes 
        /// </summary>
        public void fncInitTransactionTextBoxes()
        {
            txtTransactionsDeposit.Clear();
            txtTransactionsWithdraw.Clear();
            txtTransactionsDeposit.Visible = false;
            txtTransactionsWithdraw.Visible = false;

            radTransactionsConsult.Checked = true;
            radTransactionsWithdraw.Enabled = true;
            radTransactionsConsult.Enabled = true;
        } // end init the transaction text boxes

        // radio controls in the transaction : deposit
        private void radTransactionsDeposit_CheckedChanged(object sender, EventArgs e)
        {
            lblInfo.Text = actualPaidAccount.fncPrintBalancePaidAccount();// funcion q viene de la clase padre clsAcount
            btnTransactionsTransaction.BackColor = Color.Aquamarine;
            btnTransactionsTransaction.Text = "Deposit";
            txtTransactionsDeposit.Visible = radTransactionsDeposit.Checked;
            txtTransactionsDeposit.Focus();
        }

        // radio controls in the transaction : withdraw
        private void radTransactionsWithdraw_CheckedChanged(object sender, EventArgs e)
        {
            lblInfo.Text = actualPaidAccount.fncPrintBalancePaidAccount();// funcion q viene de la clase padre clsAcount
            btnTransactionsTransaction.BackColor = Color.SteelBlue;
            btnTransactionsTransaction.Text = "Withdraw";
            txtTransactionsWithdraw.Visible = radTransactionsWithdraw.Checked;
            txtTransactionsWithdraw.Focus();
        }

        // radio controls in the transaction : consult
        private void radTransactionsConsult_CheckedChanged(object sender, EventArgs e)
        {
            btnTransactionsTransaction.BackColor = Color.CadetBlue;
            btnTransactionsTransaction.Text = "Consult";
        }

        private void btnBackTransactionsAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (clsUnpaidAccount tmp in actualClient.vListUnpaidAccounts.Elements)
                {
                    actualUnpaidAccount = tmp;
                    lblTransactionsAccountsUnpaidAccountNumber.Text = actualUnpaidAccount.vNumber;
                    lblTransactionsAccountsUnpaidAccountType.Text = actualUnpaidAccount.vType;
                    lblTransactionsAccountsUnpaidAccountCommission.Text = (actualUnpaidAccount.vCommission * 100).ToString() + " " + " % ";
                    lblTransactionsAccountsUnpaidAccountOverdraft.Text = actualUnpaidAccount.vOverdraft.ToString() + " " + " $ ";
                    lblTransactionsAccountsUnpaidAccountBalance.Text = actualUnpaidAccount.vBalance.ToString() + " " + " $ ";
                }
                /// <summary>
                /// Function that size the form by clicking the button next in pin validation
                /// </summary>
                fncSizeFormAccounts();
                groupBoxTransactionsAccounts.Enabled = true;
                lblInfo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            fncFormInitialSize();
            groupBoxTransactionsReadingCard.Enabled = true;
            groupBoxTransactionsReadingNip.Enabled = true;
            groupBoxTransactionsAccounts.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            try
            {
                fncInitTransactionTextBoxes();
                //Document doc = new Document(iTextSharp.text.PageSize.LETTER, 100, 100, 50, 50);
                //PdfWriter writingPdf = PdfWriter.GetInstance(doc, new FileStream("NationalBank.pdf", FileMode.Create));
                //doc.Open(); // Open document to write
                //DateTime today = clsDataSource.fncTodayDate();
                //Paragraph paregraph = new Paragraph("National Bank of Canada : " + "\n" + "Date : " + today.ToString() + "\n" + actualClient.fncDisplayHuman());
                //doc.Add(paregraph);
                //doc.Close(); // Close document
                //MessageBox.Show("a PDF has been written");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// tabControlBank : resize form to create a new bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">resize form to create a new bank</param>
        private void tabControlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            fncSizeTabControlBank();
        }// resize form to create a new bank

        // comboBankDirector
        /// <summary>
        /// comboDirector -> Select the Director in the bank
        /// </summary>
        /// <param name="sender">clsDirecteur tmp</param>
        /// <param name="e"></param>
        private void comboCreateBankDirector_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (clsDirecteur tmp in myBank.vListDirecteurs.Elements)
            {
                if (tmp.vName == comboCreateBankDirector.SelectedItem.ToString())
                {
                    try
                    {
                        actualDirecteur = tmp;
                        txtCreateBankDirectorNumber.Text = actualDirecteur.vNumber;
                        txtCreateBankDirectorName.Text = actualDirecteur.vName;
                        txtCreateBankDirectorLastName.Text = actualDirecteur.vLastName;
                        txtCreateBankDirectorSalary.Text = actualDirecteur.vSalary.ToString();
                        /// <summary>
                        /// PictureBox photo Director : Path to get the picture in file
                        /// </summary>
                        pictureBoxCreateDirector.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Directors/" + actualDirecteur.vPhoto);
                        /// <summary>
                        /// Function that keeps the string of the director photo selectione in Create Bank
                        /// Static variable (staticVariableDirectorPhoto) that contains the photo string selectione in 'Create Bank'
                        /// </summary>
                        staticVariableDirectorPhoto = fnccomboDirectoPhoto(actualDirecteur.vPhoto);
                        // start values for Description Bank in Create Bank
                        txtCreateBankName.Text = "National Bank";
                        txtCreateBankAddress.Text = "3030 Hochelaga";
                        txtCreateBankCapital.Text = "50000";
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }// end select director in the bank

        /// <summary>
        /// Create the bank informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateBank_Click(object sender, EventArgs e)
        {
            try
            {
                // Constructor variables
                string number = txtCreateBankDirectorNumber.Text;
                string name = txtCreateBankDirectorName.Text;
                string lastName = txtCreateBankDirectorLastName.Text;
                double salary = Convert.ToDouble(txtCreateBankDirectorSalary.Text);
                string photo = staticVariableDirectorPhoto; // Static variable (staticVariableDirectorPhoto) that contains the photo string selectione in 'Create Bank'
                string bankName = txtCreateBankName.Text;
                string bankAddress = txtCreateBankAddress.Text;
                double bankCapital = Convert.ToDouble(txtCreateBankCapital.Text);
                /// <summary>
                /// Constructor that takes three arguments, the director as an object and the director list, agencies list and the admin list.
                /// </summary>
                myBank = new clsNationalBank(number, name, lastName, salary, photo, bankName, bankAddress, bankCapital, myBank.vListDirecteurs, myBank.vListAgencies, myBank.vListAdmins);
                /// <summary>
                /// Function : fncCreatemyBank() -> Function that Creates Bank
                /// </summary>
                fncCreatemyBank();
                /// <summary>
                /// Function : fncClearBankCreateBankTextBox() -> Clear textBox in Create Bank
                /// </summary>
                fncClearBankCreateBankTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// end bank informations

        // comboBankAgency
        /// <summary>
        /// comboAgency -> Select the Agency in the bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBankAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (clsAgency tmp in myBank.vListAgencies.Elements)
            {
                if (tmp.vAgencyName == comboBankAgency.SelectedItem.ToString())
                {
                    actualAgency = tmp;
                    //MessageBox.Show(actualAgency.vAgencyNumber);
                    txtBankAgenyNumber.Text = actualAgency.vAgencyNumber;
                    txtBankAgenyName.Text = actualAgency.vAgencyName;
                    txtBankAgenyAddress.Text = actualAgency.vAgencyAddress;
                    break;
                }
            }
        }// Select the Agency in the bank

        // comboBankAdmin
        /// <summary>
        /// comboAdmin -> Select the Admin in the bank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Select the Admin in the bank</param>
        private void comboBankAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (clsAdmin tmp in myBank.vListAdmins.Elements)
            {
                if (tmp.vName == comboBankAdmin.SelectedItem.ToString())
                {
                    actualAdmin = tmp;
                    //MessageBox.Show(actualAdmin.vLastName);
                    txtBankAdminNumber.Text = actualAdmin.vNumber;
                    txtBankAdminName.Text = actualAdmin.vName;
                    txtBankAdminLastName.Text = actualAdmin.vLastName;
                    txtBankAdminEmail.Text = actualAdmin.vEmail;
                    txtBankAdminPassword.Text = actualAdmin.vPassword;
                    txtBankAdminPhoto.Text = actualAdmin.vPhoto;
                    break;
                }
            }
        }// end Select the Admin in the bank

        /// <summary>
        /// comboAgenciesAgency -> Select the Agency and the employees in the agency
        /// </summary>
        /// <param name="sender">clsAgency tmp</param>
        /// <param name="e"></param>
        private void comboAgenciesAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (clsAgency tmp in myBank.vListAgencies.Elements)
                {
                    if (tmp.vAgencyName == comboAgenciesAgency.SelectedItem.ToString())
                    {
                        actualAgency = tmp;
                        //MessageBox.Show(actualAgency.vAgencyAddress);
                        txtAgenciesAgencyNumber.Text = actualAgency.vAgencyNumber;
                        txtAgenciesAgencyName.Text = actualAgency.vAgencyName;
                        txtAgenciesAgencyAddress.Text = actualAgency.vAgencyAddress;
                        // Description agency
                        lblAgenciesAgencyDescriptionNumber.Text = lblClientsAgencyDescriptionNumber.Text = lblAdminSpaceAgencyDescriptionNumber.Text = "Agency number : " + " " + actualAgency.vAgencyNumber;
                        lblAgenciesAgencyDescriptionName.Text = lblClientsAgencyDescriptionName.Text = lblAdminSpaceAgencyDescriptionName.Text = "Name : " + " " + actualAgency.vAgencyName;
                        lblAgenciesAgencyDescriptionAddress.Text = lblClientsAgencyDescriptionAddress.Text = lblAdminSpaceAgencyDescriptionAddress.Text = "Address : " + " " + actualAgency.vAgencyAddress;

                        /// <summary>
                        /// comboAgenciesEmployeey -> After the agency selection, cleans the combo agency employye
                        /// </summary>
                        comboAgenciesEmployee.Items.Clear();
                        comboAgenciesEmployee.Text = "";
                        /// <summary>
                        /// fncClearAgenciesEmployeeTextBox() -> Cleans the employees attributs textBox in tab agencies
                        /// </summary>
                        fncClearAgenciesEmployeeTextBox();
                        /// comboAgenciesClient -> After the agency selection, cleans the combo agency client
                        /// </summary>
                        comboAgenciesClient.Items.Clear();
                        comboAgenciesClient.Text = "";
                        /// <summary>
                        /// fncClearAgenciesClientTextBox() -> Cleans the clients attributes in textBoxes in tab agencies
                        /// </summary>
                        fncClearAgenciesClientTextBox();
                        /// <summary>
                        /// comboClientsClient -> After the client selection, cleans the combo client client
                        /// </summary>
                        comboClientsClient.Items.Clear();
                        //comboClientsClient.Text = "";
                        /// <summary>
                        /// fncClearClientsClientTextBox() -> Cleans the clients attributes in textBoxes in tab clients
                        /// </summary>
                        fncClearClientsClientTextBox();
                        /// <summary>
                        /// fncClearClientsAdviserTextBox() -> Cleans the adviser attributes in textBoxes in tab clients
                        /// </summary>
                        fncClearClientsAdviserTextBox();
                        /// <summary>
                        /// fncClearClientsAccountsTextBox() -> Cleans the accounts attributes in textBoxes in tab clients
                        /// </summary>
                        fncClearClientsAccountsTextBox();
                        /// <summary>
                        /// clsDataSource.fncGetEmployees(actualAgency.vAgencyNumber) -> Fills the employee list from employee txt file.
                        /// </summary>
                        actualAgency.vListEmployees = clsDataSource.fncGetEmployees(actualAgency.vAgencyNumber);
                        foreach (clsEmployee employee in actualAgency.vListEmployees.Elements)
                        {
                            /// fill employee combo in tab agency
                            comboAgenciesEmployee.Items.Add(employee.vName);
                        }
                        /// <summary>
                        /// clsDataSource.fncGetClients(actualAgency.vAgencyNumber) -> Fills the client list from client txt file.
                        /// </summary>
                        actualAgency.vListClients = clsDataSource.fncGetClients(actualAgency.vAgencyNumber);
                        foreach (clsClient client in actualAgency.vListClients.Elements)
                        {
                            /// fill client combo in tab agency
                            comboAgenciesClient.Items.Add(client.vName);
                            /// fill client combo in tab client
                            comboClientsClient.Items.Add(client.vName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end comboAgenciesAgency

        /// <summary>
        /// comboAgenciesEmployee -> Select the employee attributes in the agency tab
        /// </summary>
        /// <param name="sender">vListEmployees</param>
        /// <param name="e">employee</param>
        private void comboAgenciesEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (clsEmployee employee in actualAgency.vListEmployees.Elements)
            {
                if (employee.vName == comboAgenciesEmployee.SelectedItem.ToString())
                {
                    try
                    {
                        actualEmployee = employee;
                        //MessageBox.Show(actualEmployee.vPhoto);
                        /// <summary>
                        /// Path to get the picture in file
                        /// </summary>
                        //MessageBox.Show(actualEmployee.vLastName);
                        txtAgenciesEmployeeNumber.Text = actualEmployee.vNumber;
                        txtAgenciesEmployeeName.Text = actualEmployee.vName;
                        txtAgenciesEmployeeLastName.Text = actualEmployee.vLastName;
                        txtAgenciesEmployeeHdYear.Text = actualEmployee.vHiringDate.vYear.ToString();
                        txtAgenciesEmployeeHdMonth.Text = actualEmployee.vHiringDate.vMonth.ToString();
                        txtAgenciesEmployeeHdDay.Text = actualEmployee.vHiringDate.vDay.ToString();
                        /// <summary>
                        /// PictureBox photo Employee
                        /// </summary>
                        pictureBoxAgenciesEmployee.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Employees/" + actualEmployee.vPhoto);
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        } // end the employee attributes in the agency tab

        /// <summary>
        /// comboAgenciesClient -> Select the client attributes in the agency tab
        /// </summary>
        /// <param name="sender">vListClients</param>
        /// <param name="e">client</param>
        private void comboAgenciesClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (clsClient client in actualAgency.vListClients.Elements)
                {
                    if (client.vName == comboAgenciesClient.SelectedItem.ToString())
                    {
                        actualClient = client;
                        //MessageBox.Show(actualClient.vLastName);
                        txtAgenciesClientNumber.Text = actualClient.vNumber;
                        txtAgenciesClientName.Text = actualClient.vName;
                        txtAgenciesClientLastName.Text = actualClient.vLastName;
                        txtAgenciesClientNip.Text = actualClient.vNip;
                        txtAgenciesClientAddress.Text = actualClient.vAddress;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        /// <summary>
        /// comboClientsClient -> Select the client attributes and accounts in the client tab
        /// </summary>
        /// <param name="sender">actualAgency.vListClients</param>
        /// <param name="e">client</param>
        private void comboClientsClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (clsClient client in actualAgency.vListClients.Elements)
                {
                    if (client.vName == comboClientsClient.SelectedItem.ToString())
                    {
                        actualClient = client;
                        //MessageBox.Show(actualClient.vLastName);
                        txtClientsClientNumber.Text = actualClient.vNumber;
                        txtClientsClientName.Text = actualClient.vName;
                        txtClientsClientLastName.Text = actualClient.vLastName;
                        txtClientsClientNip.Text = actualClient.vNip;
                        txtClientsClientAddress.Text = actualClient.vAddress;
                        // Employee
                        txtClientsAviserNumber.Text = actualClient.vEmployee.vNumber;
                        txtClientsAdviserName.Text = actualClient.vEmployee.vName;
                        txtClientsAdviserLastName.Text = actualClient.vEmployee.vLastName;
                        txtClientsEmployeeHdDay.Text = actualClient.vEmployee.vHiringDate.vDay.ToString();
                        txtClientsAviserHdMonth.Text = actualClient.vEmployee.vHiringDate.vMonth.ToString();
                        txtClientsAviserHdYear.Text = actualClient.vEmployee.vHiringDate.vYear.ToString();
                        /// <summary>
                        /// PictureBox photo Employee
                        /// </summary>
                        pictureBoxClientsAdviser.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Employees/" + actualClient.vEmployee.vPhoto);
                        /// <summary>
                        /// Get Paid Accounts for each customer
                        /// </summary>
                        actualClient.vListPaidAccounts = clsDataSource.fncGetPaidAccounts(actualClient.vNumber);
                        /// <summary>
                        /// Paid Account
                        /// </summary>
                        foreach (clsPaidAccount paidAccount in actualClient.vListPaidAccounts.Elements)
                        {
                            // Count data
                            txtClientsPaNumber.Text = paidAccount.vNumber;
                            txtClientsPaInterestPayable.Text = (paidAccount.vInterestRate).ToString();
                            txtClientsPaBalance.Text = paidAccount.vBalance.ToString();
                            // Time
                            txtClientsPaYear.Text = paidAccount.vOpenDate.vYear.ToString();
                            txtClientsPaMonth.Text = paidAccount.vOpenDate.vMonth.ToString();
                            txtClientsPaDay.Text = paidAccount.vOpenDate.vDay.ToString();
                        }
                        /// <summary>
                        /// Get the UnPaid Accounts for each customer
                        /// </summary>
                        actualClient.vListUnpaidAccounts = clsDataSource.fncGetUnpaidAccounts(actualClient.vNumber);
                        /// <summary>
                        /// Paid Account
                        /// </summary>
                        foreach (clsUnpaidAccount unpaidAccount in actualClient.vListUnpaidAccounts.Elements)
                        {
                            // Count data
                            txtClientsUPaNumber.Text = unpaidAccount.vNumber;
                            txtClientsUPaCommission.Text = (unpaidAccount.vCommission * 100).ToString();
                            txtClientsUPaOverdraft.Text = unpaidAccount.vOverdraft.ToString();
                            txtClientsUPaBalance.Text = unpaidAccount.vBalance.ToString();
                            // Time
                            txtClientsUPaYear.Text = unpaidAccount.vOpenDate.vYear.ToString();
                            txtClientsUPaMonth.Text = unpaidAccount.vOpenDate.vMonth.ToString();
                            txtClientsUPaDay.Text = unpaidAccount.vOpenDate.vDay.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Admin Space Admin Admin
        /// <summary>
        ///  btnAdminAdmin -> this button opens the admin
        /// </summary>
        private void btnAdminAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                // number and password
                string adminNumber = txtAdminAdminNumber.Text.Trim();
                string adminPassword = txtAdminAdminPassword.Text.Trim();
                // find the admins in the list
                clsAdmin admin = myBank.vListAdmins.fncFind(adminNumber); // sent the event
                if (admin == null || admin.vPassword != adminPassword)
                {
                    MessageBox.Show("ID or Password Incorect , Try Again !");
                    txtAdminAdminPassword.Clear();
                    txtAdminAdminPassword.Focus();
                    txtAdminAdminNumber.Clear();
                    txtAdminAdminNumber.Focus();
                    return;
                }
                else
                {
                    lblAdminAdminName.Text = "Welcom  " + admin.vName;
                    this.BackColor = Color.Silver;
                    /// <summary>
                    /// Function that size the tabControlBank to admin space by clicking in btnAdminAdmin
                    /// </summary>
                    fncSizeTabControlBankAdminSpace();
                    // enlight the grup boxes in admin
                    groupBoxAdminDirector.Enabled = groupBoxAdminAdmins.Enabled = groupBoxAdminAgencies.Enabled = groupBoxAdminEmployees.Enabled = true;
                    groupBoxAdminClients.Enabled = groupBoxAdminAdviser.Enabled = groupBoxAdminPaidAccount.Enabled = groupBoxAdminUnPaidAccount.Enabled = true;
                    pictureBoxAdminSpaceAdminAdmin.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Admins/" + admin.vPhoto);
                    // MessageBox.Show(admin.vNumber + admin.vPassword);
                    
                    // Start suscriber
                    // Handler
                    admin.ApplicationClosed += fncAdminHandler; // reference or pointer to this methode
                    listBoxAdmin.Items.Add(admin.vName + "" + admin.vLastName);

                    // Event : suscriber
                    admin.OnApplicationClosed();
                    // Timer
                    lblTick_Tack.Visible = true;
                    listBoxAdmin.Visible = true;
                    CLock.Interval = interval; // milliseconds : 1s

                    // Handler
                    // System.Timers.Timer CLock = new System.Timers.Timer();
                    CLock.Elapsed += OnTimeEvent; // System.Timers; // reference or pointer to this methode
                    CLock.Start();
                    // End suscriber
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end btnAdminAdmin

        // functions
        /// <summary>
        /// Function that size the form when it is load
        /// </summary>
        public void fncFormInitialSize()
        {
            // Transactions Form initial size
            this.Width = 358;
            this.Height = thisHeight;

            // tabControlBank initialn size  
            tabControlBank.Width = 315;
            tabControlBank.Height = tabControlBankHeight;
        }// the form when it is load

        /// <summary>
        /// Function that size the form by clicking the button next in reading cards
        /// </summary>
        public void fncSizeFormPinValidation()
        {
            // Transactions read card size
            this.Width = 644;
            this.Height = thisHeight;
            // tabControlBank read card size
            tabControlBank.Width = 600;
            tabControlBank.Height = tabControlBankHeight;
        } // end size the form

        /// <summary>
        /// Function that size the form by clicking the button next in pin validation
        /// </summary>
        public void fncSizeFormAccounts()
        {
            // Transactions nip card size
            this.Width = 929;
            this.Height = thisHeight;
            // tabControlBank nip card size
            tabControlBank.Width = 888;
            tabControlBank.Height = tabControlBankHeight;
        }// end the form by clicking the button next in pin validation

        /// <summary>
        /// Function that size the form by clicking the button next in accounts
        /// </summary>
        public void fncSizeFormTransactionAccounts()
        {
            // Form Transactions types size
            this.Width = 1216;
            this.Height = thisHeight;
            // tabControlBank types size
            tabControlBank.Width = 1176;
            tabControlBank.Height = tabControlBankHeight;
        } // end the form by clicking the button next in accounts

        /// <summary>
        /// function that loads agencies in the combos : comboBankTransactionsAgency, comboBankAgency, comboAgenciesAgency
        /// </summary>
        public void fncLoadCombosAgencies()
        {
            foreach (clsAgency tmp in myBank.vListAgencies.Elements)
            {
                /// fill agency combo in tab transactions
                comboBankTransactionsAgency.Items.Add(tmp.vAgencyName);
                /// fill agency combo in tab bank
                comboBankAgency.Items.Add(tmp.vAgencyName);
                /// fill agency combo in tab agency
                comboAgenciesAgency.Items.Add(tmp.vAgencyName);
            }
        }// end load agencies in the combos

        /// <summary>
        /// // function load directors in comboCreateBankDirector
        /// </summary>
        public void fncLoadComboDirector()
        {
            foreach (clsDirecteur tmp in myBank.vListDirecteurs.Elements)
            {
                /// fill director combo in tab bank
                comboCreateBankDirector.Items.Add(tmp.vName);
            }
        } // End Admin Space Admin Director


        /// <summary>
        /// Function that keeps the photo director string selectione in Create Bank
        /// </summary>
        /// <param name="photo"></param>
        /// <returns>photo director selectione in Create Bank</returns>
        public string fnccomboDirectoPhoto(string photo)
        {
            return photo;
        } // end the photo director string

        /// <summary>
        /// Function that size the tabControlBank by clicking in its tab
        /// </summary>
        public void fncSizeTabControlBank()
        {
            // form size
            this.Width = 1530;
            this.Height = InternalBankthisHeight;
            // tabControlBank size
            tabControlBank.Width = 1490;
            tabControlBank.Height = InternatabControlBankHeight;
        }// end the tabControlBank

        /// <summary>
        /// Function : fncCreatemyBank() -> Function that Creates Bank
        /// </summary>
        public void fncCreatemyBank()
        {
            try
            {
                // Director
                txtBankDirectorNumber.Text = myBank.vDirector.vNumber;
                txtBankDirectorName.Text = myBank.vDirector.vName;
                txtBankDirectorLastName.Text = myBank.vDirector.vLastName;
                txtBankDirectorSalary.Text = myBank.vDirector.vSalary.ToString();
                /// <summary>
                /// Picture box that contains the directore photo selectione
                /// </summary>
                pictureBoxDirector.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Directors/" + myBank.vDirector.vPhoto);
                // Bank Description
                txtBankName.Text = myBank.vBankName;
                txtBankAddress.Text = myBank.vBankAddress;
                txtBankCapital.Text = myBank.vBankCapital.ToString();
                // Bank Headers
                lblBankDescriptionName.Text = lblAgenciesBankDescriptionName.Text = lblClientsBankDescriptionName.Text = lblAdminSpaceBankDescriptionName.Text = "Bank Name : " + " " + myBank.vBankName;
                lblBankDescriptionAddress.Text = lblAgenciesBankDescriptionAddress.Text = lblClientsBankDescriptionAddress.Text = lblAdminSpaceBankDescriptionAddress.Text = "Address : " + " " + myBank.vBankAddress;
                pictureBoxBankDescriptionDirector.Image = pictureBoxAgenciesDescriptionDirector.Image = pictureBoxClientsDescriptionDirector.Image = pictureBoxAdminSpaceDescriptionDirector.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Directors/" + myBank.vDirector.vPhoto);
                lblBankDescriptionDirector.Text = lblAgenciesBankDescriptionDirector.Text = lblClientsBankDescriptionDirector.Text = lblAdminSpaceBankDescriptionDirector.Text = "Director : " + " " + myBank.vDirector.vName + " " + myBank.vDirector.vLastName;
                // Bank Transactions
                lblBankTransactionDescriptionName.Text = myBank.vBankName;
                pictureBoxBankTransactionDescriptionDirector.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Directors/" + myBank.vDirector.vPhoto);
                lblBankTransactionDescriptionAddress.Text = myBank.vBankAddress;
                lblBankTransactionDescriptionDirector.Text = "Director : " + " " + myBank.vDirector.vName + " " + myBank.vDirector.vLastName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }// end bank creation

        

        // Functions Clear
        /// <summary>
        /// Function : fncClearBankCreateBankTextBox() -> Clear textBox in Create Bank
        /// </summary>
        public void fncClearBankCreateBankTextBox()
        {
            // Director
            comboCreateBankDirector.Text = "";
            txtCreateBankDirectorNumber.Text = "";
            txtCreateBankDirectorName.Text = "";
            txtCreateBankDirectorLastName.Text = "";
            txtCreateBankDirectorSalary.Text = "";
            /// <summary>
            /// pictureBoxCreateDirector photo Director : Path to get the picture in file
            /// </summary>
            pictureBoxCreateDirector.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Directors/robotica.png");
            // start values for Description Bank in Create Bank
            txtCreateBankName.Text = "";
            txtCreateBankAddress.Text = "";
            txtCreateBankCapital.Text = "";
        }// end Clear textBox in Create Bank
        /// <summary>
        /// Function : fncClearAgenciesEmployeeTextBox() -> Clear textBox employees in tab agencies
        /// </summary>
        public void fncClearAgenciesEmployeeTextBox()
        {
            txtAgenciesEmployeeNumber.Text = "";
            txtAgenciesEmployeeName.Text = "";
            txtAgenciesEmployeeLastName.Text = "";
            txtAgenciesEmployeeHdYear.Text = "";
            txtAgenciesEmployeeHdMonth.Text = "";
            txtAgenciesEmployeeHdDay.Text = "";
            /// <summary>
            /// PictureBox photo Employee : Path to get the picture in file
            /// </summary>
            pictureBoxAgenciesEmployee.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Employees/robotica.png");
        } // end clear textBox employees in tab agencies

        /// <summary>
        /// fncClearAgenciesClientTextBox() -> Cleans the clients attributes in textBoxes in tab agencies
        /// </summary>
        public void fncClearAgenciesClientTextBox()
        {
            txtAgenciesClientNumber.Text = "";
            txtAgenciesClientName.Text = "";
            txtAgenciesClientLastName.Text = "";
            txtAgenciesClientNip.Text = "";
            txtAgenciesClientAddress.Text = "";
        } // end Cleans the clients attributes in textBoxes in tab agencies

        /// <summary>
        /// fncClearClientsClientTextBox() -> Cleans the clients attributes in textBoxes in tab clients
        /// </summary>
        public void fncClearClientsClientTextBox()
        {
            txtClientsClientNumber.Text = "";
            txtClientsClientName.Text = "";
            txtClientsClientLastName.Text = "";
            txtClientsClientNip.Text = "";
            txtClientsClientAddress.Text = "";
        }// Cleans the clients attributes in textBoxes in tab clients

        /// <summary>
        /// fncClearClientsAdviserTextBox() -> Cleans the adviser attributes in textBoxes in tab clients
        /// </summary>
        public void fncClearClientsAdviserTextBox()
        {
            txtClientsAviserNumber.Text = "";
            txtClientsAdviserName.Text = "";
            txtClientsAdviserLastName.Text = "";
            txtClientsAviserHdYear.Text = "";
            txtClientsAviserHdMonth.Text = "";
            txtClientsEmployeeHdDay.Text = "";
            /// <summary>
            /// PictureBox photo Adviser : Path to get the picture in file
            /// </summary>
            pictureBoxClientsAdviser.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Employees/robotica.png");
        } // end Cleans the adviser attributes in textBoxes in tab clients


        /// <summary>
        /// fncClearClientsAccountsTextBox() -> Cleans the accounts attributes in textBoxes in tab clients
        /// </summary>
        public void fncClearClientsAccountsTextBox()
        {
            // Clients Account Paid account
            txtClientsPaNumber.Text = "";
            txtClientsPaInterestPayable.Text = "";
            txtClientsPaBalance.Text = "";
            txtClientsPaYear.Text = "";
            txtClientsPaMonth.Text = "";
            txtClientsPaDay.Text = "";
            // Clients Account UnPaid account
            txtClientsUPaNumber.Text = "";
            txtClientsUPaCommission.Text = "";
            txtClientsUPaOverdraft.Text = "";
            txtClientsUPaBalance.Text = "";
            txtClientsUPaYear.Text = "";
            txtClientsUPaMonth.Text = "";
            txtClientsUPaDay.Text = "";
        } // end Cleans the accounts attributes in textBoxes in tab clients

        /// <summary>
        /// Load combo admins in Tab Bank
        /// </summary>
        public void fncLoadComboBankAdmins()
        {
            foreach (clsAdmin tmp in myBank.vListAdmins.Elements)
            {
                /// fill admin combo in tab bank
                comboBankAdmin.Items.Add(tmp.vName);
            }
        } // end load combo admins in Tab Bank

        // space admin
        /// <summary>
        /// Function that size the tabControlBank to admin space by clicking in btnAdminAdmin
        /// </summary>
        public void fncSizeTabControlBankAdminSpace()
        {
            // form size
            this.Width = 1530;
            this.Height = InternalBankthisHeightAdminSpace;
            // tabControlBank size
            tabControlBank.Width = 1490;
            tabControlBank.Height = InternatabControlBankHeightAdminSpace;
        } // end size the tabControlBank

        // events
        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void fncAdminHandler(object source, clsAdminEventAgrs e)
        {
            listBoxAdmin.Items.Add(e.Message);
        }
        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void fncWarnedHandler(object source, clsAdminEventAgrs e)
        {
            listBoxAdmin.Items.Add(e.Message);
        }

        //  Start Suscribers
        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Invoke(new Action(() =>
                {

                    s += 1;
                    if (s == 60)
                    {
                        s = 0;
                        m += 1;
                    }
                    if (m == 3)
                    {
                        this.BackColor = Color.DarkSalmon;
                        string adminNumber, adminPassword;
                        adminNumber = txtAdminAdminNumber.Text.Trim();
                        adminPassword = txtAdminAdminPassword.Text.Trim();
                        //string id = txtIdAdmin.Text.Trim();
                        //string password = txtPassword.Text.Trim();
                        myBank.vListAdmins = clsDataSource.fncGetAdmins();
                        clsAdmin admin = myBank.vListAdmins.fncFind(adminNumber); // sent the event
                        admin.ApplicationWarned += fncWarnedHandler;
                        admin.OnApplicationWarned();
                    }
                    if (m == 5)
                    {
                        Application.Exit();
                    }
                    if (m == 60)
                    {
                        m = 0;
                        h += 1;
                    }
                    /// <summary>
                    /// Display timer in the window
                    /// </summary>
                    lblTick_Tack.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                }
                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXMLcontrol_FormClosing(object sender, FormClosingEventArgs e)
        {
            CLock.Stop();
            Application.DoEvents();
        } // End Suscribers

        // Start Admin Space : Director
        /// <summary>
        /// Search a director in the list director -> myBank.vListDirecteurs
        /// </summary>
        /// <param name="sender">myBank.vListDirecteurs.fncExist(ID)</param>
        /// <param name="e">clsDirecteur director</param>
        private void btnAdminDirectorSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search director number
                string ID = txtAdminDirectorNumber.Text.Trim();
                // if ID exist
                if (myBank.vListDirecteurs.fncExist(ID))
                {
                    /// <summary>
                    /// Find by Id a director in the director list
                    /// </summary>
                    clsDirecteur director = myBank.vListDirecteurs.fncFind(ID);
                    /// <summary>
                    /// Fill the the text boxes with the directeur object 
                    /// </summary>
                    fncFillTextBoxControlDirecto(director);
                }
                else
                {
                    MessageBox.Show("Director " + " " + "do not exist !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Fill the the text boxes with the directeur object 
        /// </summary>
        /// <param name="director">clsDirecteur director</param>
        public void fncFillTextBoxControlDirecto(clsDirecteur director)
        {
            txtAdminDirectorNumber.Text = director.vNumber;
            txtAdminDirectorName.Text = director.vName;
            txtAdminDirectorLastName.Text = director.vLastName;
            txtAdminDirectorSalary.Text = director.vSalary.ToString();
            txtAdminDirectorPhotoFile.Text = director.vPhoto;
            pictureBoxAdminSpaceAdminDirector.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Directors/" + director.vPhoto);
        } // end fncFillTextBoxControlDirecto()

        /// <summary>
        /// Erase a director in the list director -> myBank.vListDirecteurs
        /// </summary>
        /// <param name="sender">myBank.vListDirecteurs.fncErase(ID);</param>
        /// <param name="e">clsDirecteur director</param>
        private void btnAdminDirectorErase_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search director number
                string ID = txtAdminDirectorNumber.Text.Trim();
                /// <summary>
                /// Erase by Id a Director in the Director list
                /// </summary>
                myBank.vListDirecteurs.fncErase(ID);
                /// <summary>
                /// Clear the comboCreateBankDirector
                /// </summary>
                comboCreateBankDirector.Items.Clear();
                /// <summary>
                /// function load directors in comboCreateBankDirector
                /// </summary>
                fncLoadComboDirector();
                /// <summary>
                /// Enable btnFwrDirector
                /// </summary>
                btnFwrDirector.Enabled = false;
                /// <summary>
                /// Enable btnBwrDirector
                /// </summary>
                btnBwrDirector.Enabled = false;
                /// <summary>
                /// function clear text box directors in Admin
                /// </summary>
                fncClearTextBoxAdminDirector();
                MessageBox.Show(" Director : " + ID + " " + " in the Direector doc has been deleted ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end Erase a director

        /// <summary>
        /// function clear text box directors in Admin
        /// </summary>
        public void fncClearTextBoxAdminDirector()
        {
            txtAdminDirectorNumber.Text = "";
            txtAdminDirectorName.Text = "";
            txtAdminDirectorLastName.Text = "";
            txtAdminDirectorSalary.Text = "";
            txtAdminDirectorPhotoFile.Text = "";
            lblDirectorCounter.Text = "";
            lblAdminnbDirector.Text = "";
            pictureBoxAdminSpaceAdminDirector.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Directors/robotica.png");
        } // end clear text box directors

        /// <summary>
        /// Add a director in the list director -> myBank.vListDirecteurs
        /// </summary>
        /// <param name="sender">clsDirecteur director</param>
        /// <param name="e">!myBank.vListDirecteurs.fncExist(ID)</param>
        private void btnAdminDirectorAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search director number
                string ID = txtAdminDirectorNumber.Text.Trim();
                // if ID do not exist
                if (!myBank.vListDirecteurs.fncExist(ID))
                {
                    clsDirecteur director = new clsDirecteur();
                    director.vNumber = txtAdminDirectorNumber.Text.Trim();
                    director.vName = txtAdminDirectorName.Text.Trim();
                    director.vLastName = txtAdminDirectorLastName.Text.Trim();
                    director.vSalary = Convert.ToDouble(txtAdminDirectorSalary.Text.Trim());
                    director.vPhoto = txtAdminDirectorPhotoFile.Text.Trim();
                    /// <summary>
                    /// Add a Director in the director list
                    /// </summary>
                    myBank.vListDirecteurs.fncAdd(director);
                    /// <summary>
                    /// Clear the comboCreateBankDirector
                    /// </summary>
                    comboCreateBankDirector.Items.Clear();
                    /// <summary>
                    /// Enable btnFwrDirector
                    /// </summary>
                    btnFwrDirector.Enabled = false;
                    /// <summary>
                    /// Enable btnBwrDirector
                    /// </summary>
                    btnBwrDirector.Enabled = false;
                    /// <summary>
                    /// function load directors in comboCreateBankDirector
                    /// </summary>
                    fncLoadComboDirector();
                    /// <summary>
                    /// function clear text box directors in Admin
                    /// </summary>
                    fncClearTextBoxAdminDirector();
                    MessageBox.Show(" Director : " + director.vName + " " + director.vLastName + " " + " in the Direector doc has been added ");
                }
                else
                {
                    MessageBox.Show("Director " + " " + ID + " " + " exist !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminDirectorUpdate_Click(object sender, EventArgs e)
        { // buikding function
        }

        /// <summary>
        /// Display director for every click and each index
        /// </summary>
        /// <param name="sender">fncDisplayDirectors(directorCnc)</param>
        /// <param name="e">clcDirecteur</param>
        private void btnBwrDirector_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// DIsplays directors attributes in he text box in admin Director
            /// </summary>
            /// <param name="index">directorCnc</param>
            fncDisplayDirectors(directorCnc);
            btnFwrDirector.Enabled = true;
            lblDirectorMessage.Text = "";
        }

        /// <summary>
        /// DIsplays directors attributes in he text box in admin Director
        /// </summary>
        /// <param name="index">id director</param>
        public void fncDisplayDirectors(int index)
        {
            directorCnc = index - 1;
            if (directorCnc == 0)
            {
                btnBwrDirector.Enabled = false;
            }
            else
            {
                btnBwrDirector.Enabled = true;
            }
            try
            {
                foreach (clsDirecteur actual in myBank.vListDirecteurs.Elements)
                {
                    // MessageBox.Show(myBank.vListDirecteurs.Quantity.ToString());
                    if ((actual.vdirectorIdCounter - 1) == directorCnc)
                    {
                        /// <summary>
                        /// Fill the the text boxes with the directeur object 
                        /// </summary>
                        /// <param name="director">clsDirecteur director</param>
                        fncFillTextBoxControlDirecto(actual);
                        lblDirectorCounter.Text = Convert.ToString("director index : " + (actual.vdirectorIdCounter));
                        if (actual.vdirectorIdCounter == myBank.vListDirecteurs.Quantity)
                        {
                            btnFwrDirector.Enabled = false;
                            lblDirectorMessage.Text = " Directors List is out of range !";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                /// <summary>
                /// function clear text box directors in Admin
                /// </summary>
                fncClearTextBoxAdminDirector();
            }
        }

        /// <summary>
        /// Displays director for every click at each index
        /// </summary>
        /// <param name="sender">myBank.vListDirecteurs</param>
        /// <param name="e">id director = 1</param>
        private void btnLoadDirector_Click(object sender, EventArgs e)
        {
            btnFwrDirector.Enabled = true;
            /// <summary>
            /// DIsplays directors attributes in he text box in admin Director
            /// </summary>
            /// <param name="index">id director = 1</param>
            fncDisplayDirectors(1);
        } // end load directors

        /// <summary>
        /// Displays director for every click at each index
        /// </summary>
        /// <param name="sender">myBank.vListDirecteurs</param>
        /// <param name="e">directorCnc + 2</param>
        private void btnFwrDirector_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// DIsplays directors attributes in he text box in admin Director
            /// </summary>
            /// <param name="index">id director = directorCnc + 2</param>
            fncDisplayDirectors(directorCnc + 2);
        }

        /// <summary>
        /// saves directors in a XML documen
        /// </summary>
        /// <param name="sender">clsListDirecteurs fncGetvListDirecteurs()</param>
        /// <param name="e"></param>
        private void btnSavelineXML_Click(object sender, EventArgs e)
        {
            clsDataSave.fncWriteDirectorsinlineXML();
        } // end save in XML

        /// <summary>
        /// Function to transfer actual vListDirecteurs to others classes need to be static
        /// </summary>
        /// <returns>myBank.vListDirecteurs</returns>
        public static clsListDirecteurs fncGetvListDirecteurs()
        {
            return myBank.vListDirecteurs;
        }

        //admin space : Admin
        /// <summary>
        /// Search a admin in the list admin -> myBank.vListDirecteurs
        /// </summary>
        /// <param name="sender">clsAdmin admin = myBank.vListAdmins.fncFind(ID)</param>
        /// <param name="e">clsAdmin admin</param>
        private void btnAdminAdminsSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search admin number
                string ID = txtAdminAdminsNumber.Text.Trim();
                // if ID exist
                if (myBank.vListAdmins.fncExist(ID))
                {
                    /// <summary>
                    /// Find by Id an admin in the admin list
                    /// </summary>
                    clsAdmin admin = myBank.vListAdmins.fncFind(ID);
                    /// <summary>
                    /// Fill the text boxes with the admin object 
                    /// </summary>
                    fncFillTextBoxControlAdmins(admin);
                }
                else
                {
                    MessageBox.Show("Agency " + " " + "do not exist !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        /// <summary>
        /// Fill the the text boxes with the admin object 
        /// </summary>
        /// <param name="director">clsAdmin admin</param>
        public void fncFillTextBoxControlAdmins(clsAdmin admin)
        {
            txtAdminAdminsNumber.Text = admin.vNumber;
            txtAdminAdminsName.Text = admin.vName;
            txtAdminAdminsLastName.Text = admin.vLastName;
            txtAdminAdminsEmail.Text = admin.vEmail;
            txtAdminAdminsPassWord.Text = admin.vPassword;
            txtAdminAdminsPhotoFile.Text = admin.vPhoto;
            pictureBoxAdminSpaceAdminAdmins.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Admins/" + admin.vPhoto);
        } // end fill admin object


        /// <summary>
        /// Erase an admin in the list admin -> myBank.vListAdmins
        /// </summary>
        /// <param name="sender">myBank.vListAdmins.fncErase(ID);</param>
        /// <param name="e">clsAdmin admin</param>
        private void btnAdminAdminsErase_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search admins number
                string ID = txtAdminAdminsNumber.Text.Trim();
                /// <summary>
                /// Erase by Id Admins in the admins list
                /// </summary>
                myBank.vListAdmins.fncErase(ID);
                /// <summary>
                /// Clear the comboBankAdmin
                /// </summary>
                comboBankAdmin.Items.Clear();
                /// <summary>
                /// Load combo admins in Tab Bank
                /// </summary>
                fncLoadComboBankAdmins();
                /// <summary>
                /// function clear text box admins in Tab Admin
                /// </summary>
                fncClearTextBoxAdminAdmins();
                /// <summary>
                /// function clear text box admins in Tab Bank
                /// </summary>
                fncCleartextBoxBankAdmins();
                /// <summary>
                /// Enable btnFwrAdmin
                /// </summary>
                btnFwrAdmin.Enabled = false;
                /// <summary>
                /// Enable btnBwrAdmin
                /// </summary>
                btnBwrAdmin.Enabled = false;
                MessageBox.Show(" Admin : " + ID + " " + " in the Admin doc has been deleted ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end function erase admin

        /// <summary>
        /// function clear text box admins in Tab Admin
        /// </summary>
        public void fncClearTextBoxAdminAdmins()
        {
            txtAdminAdminsNumber.Text = "";
            txtAdminAdminsName.Text = "";
            txtAdminAdminsLastName.Text = "";
            txtAdminAdminsEmail.Text = "";
            txtAdminAdminsPassWord.Text = "";
            txtAdminAdminsPhotoFile.Text = "";
        } // end clear textBox admins

        /// <summary>
        /// /// <summary>
        /// function clear text box admins in Tab Create Bank
        /// </summary>
        public void fncCleartextBoxBankAdmins()
        {
            comboBankAdmin.Text = "";
            txtBankAdminNumber.Text = "";
            txtBankAdminName.Text = "";
            txtBankAdminLastName.Text = "";
            txtBankAdminEmail.Text = "";
            txtBankAdminPassword.Text = "";
            txtBankAdminPhoto.Text = "";
            lblAdminCounter.Text = "";
            pictureBoxAdminSpaceAdminAdmins.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Admins/robotica.png");
        } // end clear textBox admins

        /// <summary>
        /// Add an admin in the list admin -> myBank.vListAdmins
        /// </summary>
        /// <param name="sender">!myBank.vListAdmins.fncExist(ID)</param>
        /// <param name="e">clsAdmin admin</param>
        private void btnAdminAdminsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search director number
                string ID = txtAdminAdminsNumber.Text.Trim();
                // if ID do not exist
                if (!myBank.vListAdmins.fncExist(ID))
                {
                    clsAdmin admin = new clsAdmin();
                    admin.vNumber = txtAdminAdminsNumber.Text.Trim();
                    admin.vName = txtAdminAdminsName.Text.Trim();
                    admin.vLastName = txtAdminAdminsLastName.Text.Trim();
                    admin.vEmail = txtAdminAdminsEmail.Text.Trim();
                    admin.vPassword = txtAdminAdminsPassWord.Text.Trim();
                    admin.vPhoto = txtAdminAdminsPhotoFile.Text.Trim();
                    /// <summary>
                    /// Add Admin in the admin list
                    /// </summary>
                    myBank.vListAdmins.fncAdd(admin);
                    /// <summary>
                    /// Clear the comboBankAdmin
                    /// </summary>
                    comboBankAdmin.Items.Clear();
                    // <summary>
                    /// Load combo admins in Tab Bank
                    /// </summary>
                    fncLoadComboBankAdmins();
                    /// <summary>
                    /// function clear text box admins in Tab Admin
                    /// </summary>
                    fncClearTextBoxAdminAdmins();
                    /// <summary>
                    /// function clear text box admins in Tab Bank
                    /// </summary>
                    fncCleartextBoxBankAdmins();
                    /// <summary>
                    /// Enable btnFwrAdmin
                    /// </summary>
                    btnFwrAdmin.Enabled = false;
                    /// <summary>
                    /// Enable btnBwrAdmin
                    /// </summary>
                    btnBwrAdmin.Enabled = false;
                    MessageBox.Show(" Admin : " + admin.vName + " " + admin.vLastName + " " + " in the Admin doc has been added ");
                }
                else
                {
                    MessageBox.Show("Admin :" + " " + ID + " " + " exist !");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end add admin
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminAdminsUpdate_Click(object sender, EventArgs e)
        {
            // building function
        }

        /// <summary>
        /// Displays admin for every click at each index
        /// </summary>
        /// <param name="sender">fncDisplayAdmins(adminCnc);</param>
        /// <param name="e">clsAdmin</param>
        private void btnBwrAdmin_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// DIsplays admin attributes in the text box in admin Admins
            /// </summary>
            /// <param name="index">directorCnc</param>
            fncDisplayAdmins(adminCnc);
            btnFwrAdmin.Enabled = true;
            lblAdminMessage.Text = "";
        } // end display admins

        /// <summary>
        /// DIsplays admin attributes in the text box in admin Admin
        /// </summary>
        /// <param name="index">id admin</param>
        public void fncDisplayAdmins(int index)
        {
            adminCnc = index - 1;
            if (adminCnc == 0)
            {
                btnBwrAdmin.Enabled = false;
            }
            else
            {
                btnBwrAdmin.Enabled = true;
            }
            try
            {
                foreach (clsAdmin actual in myBank.vListAdmins.Elements)
                {
                    if ((actual.vadminIdCounter - 1) == adminCnc)
                    {
                        /// <summary>
                        /// Fill the the text boxes with the admin object 
                        /// </summary>
                        /// <param name="director">clsDirecteur director</param>
                        fncFillTextBoxControlAdmins(actual);
                        lblAdminCounter.Text = Convert.ToString("admin index : " + (actual.vadminIdCounter));
                        if (actual.vadminIdCounter == myBank.vListAdmins.Quantity)
                        {
                            btnFwrAdmin.Enabled = false;
                            lblAdminMessage.Text = "Admin List is out of range !";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end displays admin

        /// <summary>
        /// Displays an admin for every click and et index
        /// </summary>
        /// <param name="sender">myBank.vListAdmins</param>
        /// <param name="e">id admin = 1</param>
        private void btnLoadAdmin_Click(object sender, EventArgs e)
        {
            btnFwrAdmin.Enabled = true;
            /// <summary>
            /// DIsplays admin attributes in the text box in admin Admin
            /// </summary>
            /// <param name="index">id admin = 1</param>
            fncDisplayAdmins(1);
        } // end load admins

        /// <summary>
        /// Displays admin for every click at each index
        /// </summary>
        /// <param name="sender">fncDisplayAdmins(adminCnc + 2;</param>
        /// <param name="e">clsAdmin</param>
        private void btnFwrAdmin_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// DIsplays admin attributes in the text box in admin Admins
            /// </summary>
            /// <param name="index">(adminCnc + 2)</param>
            fncDisplayAdmins(adminCnc + 2);
        }

        /// <summary>
        /// saves admins in a XML documen
        /// </summary>
        /// <param name="sender">clsListDirecteurs fncGetvListDirecteurs()</param>
        /// <param name="e"></param>
        private void btnSaveAdminXML_Click(object sender, EventArgs e)
        {
            clsDataSave.fncWriteAdminsinXML();
        } // end save XML

        /// <summary>
        /// Function to transfer actual myBank.vListAdmins to others classes need to be static
        /// </summary>
        /// <returns>myBank.vListAdmins</returns>
        public static clsListAdmins fncGetvListAdmins()
        {
            return myBank.vListAdmins;
        } // end static function

        //admin space : Agencies
        /// <summary>
        /// Search a agencies in the list agency -> myBank.vListAgencies
        /// </summary>
        /// <param name="sender">actualAgency = myBank.vListAgencies.fncFind(staticAdminAgenciesNumber)</param>
        /// <param name="e">clsAgency agency</param>
        private void btnAdminAgenciesSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // if the agency exist
                if (myBank.vListAgencies.fncExist(staticAdminAgenciesNumber))
                {
                    /// <summary>
                    /// Find by Id an agency in the agencies list
                    /// </summary>
                    actualAgency = myBank.vListAgencies.fncFind(staticAdminAgenciesNumber);
                    /// <summary>
                    /// Fill the text boxes with the agency object 
                    /// </summary>
                    fncFillTextBoxControlAdminAgencies(actualAgency);
                }
                else
                {
                    MessageBox.Show("Agency " + " " + "do not exist !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end search agency

        /// <summary>
        /// Fill the text boxes in admin agencies Employees
        /// </summary>
        /// <param name="agency">void</param>
        public void fncFillTextBoxControlAdminAgencies(clsAgency agency)
        {
            // admin employees
            txtAdminEmployeesAgency.Text = agency.vAgencyNumber;
            // admin clients
            txtAdminClientsAgency.Text = agency.vAgencyNumber;
            // Admin Agencies Space
            txtAdminAgenciesNumber.Text = staticAdminAgenciesNumber = agency.vAgencyNumber; // static variable search agency by number
            txtAdminAgenciesName.Text = agency.vAgencyName;
            txtAdminAgenciesAddress.Text = agency.vAgencyAddress;
        }

        /// <summary>
        /// Erase an agency in the list agency -> myBank.vListAgency
        /// </summary>
        /// <param name="sender"> myBank.vListAgencies.fncErase(staticAdminAgenciesNumber)</param>
        /// <param name="e">clsAgency agency</param>
        private void btnAdminAgenciesErase_Click(object sender, EventArgs e)
        {
            try
            {
                /// <summary>
                /// Erase by Id Agency in the agency list
                /// </summary>
                myBank.vListAgencies.fncErase(staticAdminAgenciesNumber);
                /// <summary>
                /// function clear agencies in combo agencies
                /// </summary>
                fncClearCombosAgencies();
                /// <summary>
                /// function load agencies in combo agencies
                /// </summary>
                fncLoadCombosAgencies();
                /// <summary>
                /// function clear text box directors in Admin
                /// </summary>
                fncClearTextBoxAdminAgencies();
                /// <summary>
                /// Enable btnFwrAgencies
                /// </summary>
                btnFwrAgencies.Enabled = false;
                /// <summary>
                /// Enable btnBwrAgencies
                /// </summary>
                btnBwrAgencies.Enabled = false;
                /// <summary>
                /// fncClearTextBoxControlAdminEmployees() -> clear text box employees in Tab Admin
                /// </summary>
                fncClearTextBoxControlAdminEmployees();
                /// <summary>
                /// actualAgency.vListEmployees.fncClear() -> After the agency selection, cleans the vListEmployees
                /// </summary>
                actualAgency.vListEmployees.fncClear();
                comboAdminSpaceAdminEmployee.Items.Clear();
                MessageBox.Show(" Agency : " + staticAdminAgenciesNumber + " " + " in the Agency doc has been deleted ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end Erase agency

        /// <summary>
        /// function clear agencies in combos agencies
        /// </summary>
        public void fncClearCombosAgencies()
        {
            /// <summary>
            /// Clear the comboBankTransactionsAgency
            /// </summary>
            comboBankTransactionsAgency.Items.Clear();
            /// <summary>
            /// Clear the comboBankAgency
            /// </summary>
            comboBankAgency.Items.Clear();
            /// <summary>
            /// Clear the comboAgenciesAgency
            /// </summary>
            comboAgenciesAgency.Items.Clear();
        } // end clear agencies

        /// <summary>
        /// function clear text boxes agencies in admin agencies
        /// </summary>
        public void fncClearTextBoxAdminAgencies()
        {
            txtAdminAgenciesNumber.Text = "";
            txtAdminAgenciesName.Text = "";
            txtAdminAgenciesAddress.Text = "";
            txtAdminAgenciesPhotoFile.Text = "";
            lblAgenciesCounter.Text = "";
            lblAgenciesMessage.Text = "";
            // admin employees
            txtAdminEmployeesAgency.Text = "";
            // admin clients
            txtAdminClientsAgency.Text = "";
        } // end clear textBoxes de admin agencies

        /// <summary>
        /// fncClearTextBoxControlAdminEmployees() -> clear text box employees in Tab Admin
        /// </summary>
        public void fncClearTextBoxControlAdminEmployees()
        {
            comboAdminSpaceAdminEmployee.Text = "";
            txtAdminEmployeesName.Text = "";
            txtAdminEmployeesLastName.Text = "";
            txtAdminEmployeesHdYear.Text = "";
            txtAdminEmployeesHdMonth.Text = "";
            txtAdminEmployeesHdDay.Text = "";
            txtAdminEmployeesPhotoFile.Text = "";
            pictureBoxAdminSpaceAdminEmployees.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Employees/robotica.png");
        } // end clear text box employees in Tab Admin

        /// <summary>
        /// Add an agency in the list agency -> myBank.vListAgency
        /// </summary>
        /// <param name="sender">!myBank.vListAgencies.fncExist(staticAdminAgenciesNumber)</param>
        /// <param name="e">clsAgency agency</param>
        private void btnAdminAgenciesAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // static variable search agency by number
                staticAdminAgenciesNumber = txtAdminAgenciesNumber.Text.Trim();
                // if ID do not exist
                if (!myBank.vListAgencies.fncExist(staticAdminAgenciesNumber))
                {
                    clsAgency agency = new clsAgency();
                    agency.vAgencyNumber = txtAdminAgenciesNumber.Text.Trim();
                    agency.vAgencyName = txtAdminAgenciesName.Text.Trim();
                    agency.vAgencyAddress = txtAdminAgenciesAddress.Text.Trim();

                    /// <summary>
                    /// Add Agency in the agency list
                    /// </summary>
                    myBank.vListAgencies.fncAdd(agency);
                    /// <summary>
                    /// Clear the comboCreateBankDirector
                    /// </summary>
                    fncClearCombosAgencies();
                    /// <summary>
                    /// function load agencies in combos agencies
                    /// </summary>
                    fncLoadCombosAgencies();
                    /// <summary>
                    /// function clear text box agencies in Admin
                    /// </summary>
                    fncClearTextBoxAdminAgencies();
                    /// <summary>
                    /// Enable btnFwrAgencies
                    /// </summary>
                    btnFwrAgencies.Enabled = false;
                    /// <summary>
                    /// Enable btnBwrAgencies
                    /// </summary>
                    btnBwrAgencies.Enabled = false;
                    MessageBox.Show(" Agency: " + agency.vAgencyName + ": " + agency.vAgencyNumber + " " + " in the Agency doc has been added ");
                }
                else
                {
                    MessageBox.Show("Agency " + " " + staticAdminAgenciesNumber + " " + " exist !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end add agency

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminAgenciesUpdate_Click(object sender, EventArgs e)
        {
            // building function
        }

        /// <summary>
        /// Displays agency for every click at each index
        /// </summary>
        /// <param name="sender">fncDisplayAgencies(agenciesCnc)</param>
        /// <param name="e">adminCnc</param>
        private void btnBwrAgencies_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Displays agency attributes in the text box in admin Agencies
            /// </summary>
            /// <param name="index">directorCnc</param>
            fncDisplayAgencies(agenciesCnc);
            btnFwrAgencies.Enabled = true;
            lblAgenciesMessage.Text = "";
        } // end displays agency

        /// <summary>
        /// Displays agencies attributes in the text box in admin Agencies
        /// </summary>
        /// <param name="index">id agency</param>
        public void fncDisplayAgencies(int index)
        {
            agenciesCnc = index - 1;
            if (agenciesCnc == 0)
            {
                btnBwrAgencies.Enabled = false;
            }
            else
            {
                btnBwrAgencies.Enabled = true;
            }
            try
            {
                foreach (clsAgency actual in myBank.vListAgencies.Elements)
                {
                    if ((actual.vagencyIdCounter - 1) == agenciesCnc)
                    {
                        fncFillTextBoxControlAdminAgencies(actual);
                        // Admin Employee Space -> Load combo in Admin Employee Space
                        fncLoadcomboAdminSpaceAdminEmployee(actual);
                        // Admin Employee Space -> Load combo in Admin Clients Space
                        fncLoadcomboAdminSpaceAdminClients(actual);
                        lblAgenciesCounter.Text = Convert.ToString("agency index : " + (actual.vagencyIdCounter));
                        if (actual.vagencyIdCounter == myBank.vListAgencies.Quantity)
                        {
                            btnFwrAgencies.Enabled = false;
                            lblAgenciesMessage.Text = "Agency List is out of range ! ";
                        }
                    }
                }
                /// <summary>
                /// fncClearTextBoxControlAdminEmployees() -> clear text box employees in Tab Admin
                /// </summary>
                fncClearTextBoxControlAdminEmployees();
                /// <summary>
                /// fncClearTextBoxControlAdminClients() -> clear text box client in Tab Admin
                /// </summary>
                fncClearTextBoxControlAdminClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end display agencies

        /// <summary>
        /// loads the combo box in admin space Admin employees
        /// </summary>
        /// <param name="agency"></param>
        public void fncLoadcomboAdminSpaceAdminEmployee(clsAgency agency)
        {
            /// <summary>
            /// actualAgency.vListEmployees.fncClear() -> After the agency selection, cleans the vListEmployees
            /// </summary>
            actualAgency.vListEmployees.fncClear();
            /// <summary>
            /// comboAdminSpaceAdminEmployee.Items.Clear() -> After the agency selection, cleans the combo box
            /// </summary>
            comboAdminSpaceAdminEmployee.Items.Clear();
            /// <summary>
            /// actualAgency.vListEmployees = clsDataSource.fncGetEmployees(agency.vAgencyNumber) -> load  the list employees
            /// </summary>
            actualAgency.vListEmployees = clsDataSource.fncGetEmployees(agency.vAgencyNumber);


            lblAdminnbEmployee.Text = "";
            lblAdminnbEmployee.Text = "number of empoyees in the list ! : " + actualAgency.vListEmployees.Quantity.ToString();

            foreach (clsEmployee employee in actualAgency.vListEmployees.Elements)
            {
                comboAdminSpaceAdminEmployee.Items.Add(employee.vNumber);
            }
        } // end load combo admin employees

        /// <summary>
        /// loads the combo box in admin space Admin clients
        /// </summary>
        /// <param name="agency"></param>
        public void fncLoadcomboAdminSpaceAdminClients(clsAgency agency)
        {
            /// <summary>
            /// actualAgency.vListClients.fncClear() -> After the agency selection, cleans the vListClients
            /// </summary>
            actualAgency.vListClients.fncClear();
            /// <summary>
            /// comboAdminSpaceAdminClients.Items.Clear() -> After the agency selection, cleans the combo box
            /// </summary>
            comboAdminSpaceAdminClients.Items.Clear();
            /// <summary>
            /// actualAgency.vListEmployees = clsDataSource.fncGetEmployees(agency.vAgencyNumber) -> load  the list employees
            /// </summary>
            actualAgency.vListClients = clsDataSource.fncGetClients(agency.vAgencyNumber);
            /// <summary>
            /// Number of clients in the list
            /// </summary>
            lblAdminnbClient.Text = "";
            lblAdminnbClient.Text = "number of clients in the list ! : " + actualAgency.vListClients.Quantity.ToString();
            /// <summary>
            /// <summary>
            /// Load the combo
            /// </summary>
            foreach (clsClient client in actualAgency.vListClients.Elements)
            {
                comboAdminSpaceAdminClients.Items.Add(client.vNumber);
            }
        } // end load combo Admin clients

        /// <summary>
        /// fncClearTextBoxControlAdminClients() -> clear text box clients in Tab Admin
        /// </summary>
        public void fncClearTextBoxControlAdminClients()
        {
            comboAdminSpaceAdminClients.Text = "";
            txtAdminClientAdviserClientNumber.Text = "";
            txtAdminClientName.Text = "";
            txtAdminClientLastName.Text = "";
            txtAdminClientNip.Text = "";
            txtAdminClientAddress.Text = "";
            txtAdminClientAdviserNumber.Text = "";
            txtAdminClientAdviserName.Text = "";
            txtAdminClientAdviserLastName.Text = "";
            txtAdminClientAdviserHdYear.Text = "";
            txtAdminClientAdviserHdMonth.Text = "";
            txtAdminClientAdviserHdDay.Text = "";
            txtAdminClientAviserPhotoFile.Text = "";
            pictureBoxAdminSpaceClientAdviser.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/InitializeComponent/robotica.png");
        } // end clear text box clients in Tab Admin

        /// <summary>
        /// Displays an agencies for every click and et index
        /// </summary>
        /// <param name="sender">myBank.vListAgencies</param>
        /// <param name="e">id agency = 1</param>
        private void btnLoadAgencies_Click(object sender, EventArgs e)
        {
            btnFwrAgencies.Enabled = true;
            /// <summary>
            /// Displays agency attributes in the text box in admin Agency
            /// </summary>
            /// <param name="index">id agency = 1</param>
            fncDisplayAgencies(1);
        } // end display agencies

        /// <summary>
        /// Displays agencies for every click at each index
        /// </summary>
        /// <param name="sender">fncDisplayAgencies(agenciesCnc + 2)</param>
        /// <param name="e">clsAgency</param>
        private void btnFwrAgencies_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Displays admin attributes in the text box in admin Agencies
            /// </summary>
            /// <param name="index">(agenciesCnc + 2)</param>
            fncDisplayAgencies(agenciesCnc + 2);
        } // end displays agencies

        /// <summary>
        /// saves agencies in a XML documen
        /// </summary>
        /// <param name="sender">clsDataSave.fncWriteAgencieslineinXML()</param>
        /// <param name="e"></param>
        private void btnSavelineAgenciesXML_Click(object sender, EventArgs e)
        {
            clsDataSave.fncWriteAgencieslineinXML();
        } // end save agencies in a XML document

        /// <summary>
        /// Function to transfer actual myBank.vListAgencies to others classes need to be static
        /// </summary>
        /// <returns>myBank.vListAgencies</returns>
        public static clsListAgencies fncGetvListAgencies()
        {
            return myBank.vListAgencies;
        } // end static function

        //admin space : EMployees
        /// <summary>
        /// Event to fill the employee text boxes
        /// </summary>
        /// <param name="sender">actualAgency.vListEmployees.fncExist(ID)</param>
        /// <param name="e"></param>
        private void comboAdminSpaceAdminEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            fncAdminSpaceAdminEmployeesSearch();
        } // end fill the employee text boxes

        /// <summary>
        /// Function to find employee by specific key in the employee list
        /// </summary>
        public void fncAdminSpaceAdminEmployeesSearch()
        {
            try
            {
                // variable search employees number in the agency
                string ID = comboAdminSpaceAdminEmployee.Text.Trim();
                // MessageBox.Show(actualAgency.vListEmployees.Quantity.ToString());
                // if ID exist
                if (actualAgency.vListEmployees.fncExist(ID))
                {
                    /// <summary>
                    /// Find by Id an employee in the employee list
                    /// </summary>
                    clsEmployee employee = actualAgency.vListEmployees.fncFind(ID);
                    fncFillTextBoxControlAdminEmployees(employee);
                }
                else
                {
                    MessageBox.Show("Employee " + " " + ID + " " + "do not exist in the agency !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end find employee

        /// <summary>
        /// Fills text boxes in admin emplyees
        /// </summary>
        /// <param name="employee">clsEmployee employee</param>
        public void fncFillTextBoxControlAdminEmployees(clsEmployee employee)
        {
            txtAdminEmployeesName.Text = employee.vName;
            txtAdminEmployeesLastName.Text = employee.vLastName;
            txtAdminEmployeesHdYear.Text = employee.vHiringDate.vYear.ToString();
            txtAdminEmployeesHdMonth.Text = employee.vHiringDate.vMonth.ToString();
            txtAdminEmployeesHdDay.Text = employee.vHiringDate.vDay.ToString();
            txtAdminEmployeesPhotoFile.Text = employee.vPhoto;
            pictureBoxAdminSpaceAdminEmployees.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Employees/" + employee.vPhoto);
        } // end text boxes admin employee

        /// <summary>
        /// Search employee by specific key
        /// </summary>
        /// <param name="sender">actualAgency.vListEmployees.fncExist(ID)</param>
        /// <param name="e"></param>
        private void btnAdminEmployeesSearch_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// Function to find employee by specific key in the employee list
            /// </summary>
            fncAdminSpaceAdminEmployeesSearch();
        }

        /// <summary>
        /// Erase one employee in the list employee -> myBank.vListEmployee
        /// </summary>
        /// <param name="sender"> actualAgency.vListEmployees.fncErase(ID)</param>
        /// <param name="e">clsEmployee employee</param>
        private void btnAdminEmployeesErase_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search employees number in the agency
                string ID = comboAdminSpaceAdminEmployee.Text.Trim();
                /// <summary>
                /// Erase by Id Employees in the Agency list
                /// </summary>
                actualAgency.vListEmployees.fncErase(ID);
                // MessageBox.Show(actualAgency.vListEmployees.Quantity.ToString());
                /// <summary>
                /// Clear the comboBankAdmin
                /// </summary>
                comboAgenciesEmployee.Items.Clear();

                comboAdminSpaceAdminEmployee.Items.Clear();
                /// <summary>
                /// clsDataSource.fncGetEmployees(actualAgency.vAgencyNumber) -> Fills the employee list from employee txt file.
                /// </summary>
                fncLoadCombosEmployees();
                /// <summary>
                /// fncClearTextBoxControlAdminEmployees() -> clear text box employees in Tab Admin
                /// </summary>
                fncClearTextBoxControlAdminEmployees();
                lblAdminnbEmployee.Text = "";
                // MessageBox.Show(actualAgency.vListEmployees.Quantity.ToString());
                MessageBox.Show(" Employee : " + ID + " " + " in the Employee doc has been deleted");
                lblAdminnbEmployee.Text = "";
                lblAdminnbEmployee.Text = "number of empoyees in the list ! : " + actualAgency.vListEmployees.Quantity.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end erase employee

        /// <summary>
        /// function load employees in combos employees
        /// </summary>
        public void fncLoadCombosEmployees()
        {
            try
            {
                foreach (clsEmployee employee in actualAgency.vListEmployees.Elements)
                {
                    /// fill employee combo in tab agency
                    comboAgenciesEmployee.Items.Add(employee.vName);
                    /// fill employee combo in tab Admin Space
                    comboAdminSpaceAdminEmployee.Items.Add(employee.vNumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // End load employees

        /// <summary>
        /// Add one employee in the list employee -> myBank.vListEmployee
        /// </summary>
        /// <param name="sender">!actualAgency.vListEmployees.fncExist(ID)</param>
        /// <param name="e">clsEmployee employee</param>
        private void btnAdminEmployeesAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search employees number in the agency
                string ID = comboAdminSpaceAdminEmployee.Text.Trim();
                // if ID do not exist
                if (!actualAgency.vListEmployees.fncExist(ID))
                {
                    clsEmployee employee = new clsEmployee();
                    employee.vNumber = comboAdminSpaceAdminEmployee.Text.Trim();
                    employee.vName = txtAdminEmployeesName.Text.Trim();
                    employee.vLastName = txtAdminEmployeesLastName.Text.Trim();
                    employee.vHiringDate.vYear = Convert.ToInt32(txtAdminEmployeesHdYear.Text.Trim());
                    employee.vHiringDate.vMonth = Convert.ToInt32(txtAdminEmployeesHdMonth.Text.Trim());
                    employee.vHiringDate.vDay = Convert.ToInt32(txtAdminEmployeesHdDay.Text.Trim());
                    employee.vPhoto = txtAdminEmployeesPhotoFile.Text.Trim();
                    /// <summary>
                    /// Add employee in the agency list
                    /// </summary>
                    actualAgency.vListEmployees.fncAdd(employee);
                    /// <summary>
                    /// Clear the comboBankAdmin
                    /// </summary>
                    comboAgenciesEmployee.Items.Clear();
                    /// <summary>
                    /// Clear the ccomboAdminSpaceAdminEmploye
                    /// </summary>
                    comboAdminSpaceAdminEmployee.Items.Clear();
                    // <summary>
                    /// (clsEmployee employee in actualAgency.vListEmployees.Elements) -> Fills the combos employee.
                    /// </summary>
                    fncLoadCombosEmployees();
                    /// <summary>
                    /// fncClearTextBoxControlAdminEmployees() -> clear text box employees in Tab Admin
                    /// </summary>
                    fncClearTextBoxControlAdminEmployees();
                    // MessageBox.Show(actualAgency.vListEmployees.Quantity.ToString());
                    MessageBox.Show(" Employee : " + ID + " " + " in the Employee doc has been added ");
                    lblAdminnbEmployee.Text = "";
                    lblAdminnbEmployee.Text = "number of empoyees in the list ! : " + actualAgency.vListEmployees.Quantity.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end Add one employee in the list employee

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminEmployeesUpdate_Click(object sender, EventArgs e)
        {
            // building function
        }

        /// <summary>
        /// saves employee in a XML documen
        /// </summary>
        /// <param name="sender">clsDataSave.fncWriteEmployeeslineinXML()</param>
        /// <param name="e"></param>
        private void btnSavelineEmployeesXML_Click(object sender, EventArgs e)
        {
            clsDataSave.fncWriteEmployeeslineinXML();
        } // end saves employee in a XML documen

        /// <summary>
        /// Function to transfer actual actualAgency.vListEmployees to others classes need to be static
        /// </summary>
        /// <returns>actualAgency.vListEmployees</returns>
        public static clsListEmployees fncGetvListEmployees()
        {
            return actualAgency.vListEmployees;
        } // end static function

        //admin space : Clients
        /// <summary>
        /// Event to fill the clients text boxes
        /// </summary>
        /// <param name="sender">actualAgency.vListClients.fncExist(ID)</param>
        /// <param name="e"></param>
        private void comboAdminSpaceAdminClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            fncAdminSpaceAdminClientsSearch();
        } // end Event to fill the clients

        /// <summary>
        /// Function to find employee by specific key in the clients list
        /// </summary>
        public void fncAdminSpaceAdminClientsSearch()
        {
            try
            {
                // variable search employees number in the agency
                string ID = comboAdminSpaceAdminClients.Text.Trim();
                // if ID exist
                if (actualAgency.vListClients.fncExist(ID))
                {
                    /// <summary>
                    /// Find by Id a client in the client list
                    /// </summary>
                    clsClient client = actualAgency.vListClients.fncFind(ID);
                    /// <summary>
                    /// Load text box in admin clients
                    /// </summary>
                    fncFillTextBoxControlAdminClients(client);
                }
                else
                {
                    MessageBox.Show("Client " + " " + ID + " " + "do not exist in the agency !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end Function find employee

        /// <summary>
        /// Fills text boxes in clients admin
        /// </summary>
        /// <param name="client"></param>
        public void fncFillTextBoxControlAdminClients(clsClient client)
        {
            /// <summary>
            /// Static variable that contains the client number for admin and controls the account search
            /// </summary>
            txtAdminClientAdviserClientNumber.Text = staticAdminClientsNumber = client.vNumber;
            txtAdminClientName.Text = client.vName;
            txtAdminClientLastName.Text = client.vLastName;
            txtAdminClientNip.Text = client.vNip;
            txtAdminClientAddress.Text = client.vAddress;
            txtAdminClientAdviserNumber.Text = client.vEmployee.vNumber;
            txtAdminClientAdviserName.Text = client.vEmployee.vName;
            txtAdminClientAdviserLastName.Text = client.vEmployee.vLastName;
            txtAdminClientAdviserHdYear.Text = client.vEmployee.vHiringDate.vYear.ToString();
            txtAdminClientAdviserHdMonth.Text = client.vEmployee.vHiringDate.vMonth.ToString();
            txtAdminClientAdviserHdDay.Text = client.vEmployee.vHiringDate.vDay.ToString();
            txtAdminClientAviserPhotoFile.Text = client.vEmployee.vPhoto;
            pictureBoxAdminSpaceClientAdviser.Image = System.Drawing.Image.FromFile(Application.StartupPath + @"/Employees/" + client.vEmployee.vPhoto);
            /// <summary>
            /// fncLoadPaidAccounts -> load the actualClient.vListPaidAccounts and fills the paid account text boxes 
            /// </summary>
            fncLoadPaidAccounts(client);
            /// <summary>
            /// fncLoadUnPaidAccounts -> load the actualClient.vListUnPaidAccounts and fills the unpaid account text boxes 
            /// </summary>
            fncLoadUnPaidAccounts(client);
        } // end Fills text boxes in clients admin

        /// <summary>
        /// fncLoadPaidAccounts -> load the actualClient.vListPaidAccounts and fills the paid account text boxes 
        /// </summary>
        /// <param name="client">clsClient client</param>
        public void fncLoadPaidAccounts(clsClient client)
        {
            /// <summary>
            /// Load paid accounts
            /// </summary>
            actualClient.vListPaidAccounts = clsDataSource.fncGetPaidAccounts(client.vNumber);
            // MessageBox.Show("paid accounts for this customer : " + actualClient.vListPaidAccounts.Quantity.ToString());
            /// <summary>
            /// Number of accounts in the list
            /// </summary>
            lblAdminnbClientPaidAccount.Text = "";
            lblAdminnbClientPaidAccount.Text = "number of accounts in the list ! : " + actualClient.vListPaidAccounts.Quantity.ToString();
            /// <summary>
            /// Paid Account
            /// </summary>
            foreach (clsPaidAccount paidAccount in actualClient.vListPaidAccounts.Elements)
            {
                // Count data
                txtAdminClientPaidAccountNumber.Text = paidAccount.vNumber;
                txtAdminClientPaidAccountInterestPayable.Text = (paidAccount.vInterestRate).ToString();
                txtAdminClientPaidAccountBalance.Text = paidAccount.vBalance.ToString();
                // Time
                txtAdminClientPaidAccountOpenDateYear.Text = paidAccount.vOpenDate.vYear.ToString();
                txtAdminClientPaidAccountOpenDateMonth.Text = paidAccount.vOpenDate.vMonth.ToString();
                txtAdminClientPaidAccountOpenDateDay.Text = paidAccount.vOpenDate.vDay.ToString();
            }
        } // end fncLoadPaidAccounts()

        /// <summary>
        /// fncLoadUnPaidAccounts -> load the actualClient.vListUnPaidAccounts and fills the unpaid account text boxes 
        /// </summary>
        /// <param name="client"></param>
        public void fncLoadUnPaidAccounts(clsClient client)
        {
            /// <summary>
            /// Load un paid accounts
            /// </summary>
            actualClient.vListUnpaidAccounts = clsDataSource.fncGetUnpaidAccounts(client.vNumber);
            /// <summary>
            /// Number of accounts in the list
            /// </summary>
            lblAdminnbClientUnPaidAccount.Text = "";
            lblAdminnbClientUnPaidAccount.Text = "number of accounts in the list ! : " + actualClient.vListUnpaidAccounts.Quantity.ToString();
            /// <summary>
            /// Un Paid Account
            /// </summary>
            foreach (clsUnpaidAccount unpaidAccount in actualClient.vListUnpaidAccounts.Elements)
            {
                // Count data
                txtAdminClientUnPaidAccountNumber.Text = unpaidAccount.vNumber;
                txtAdminClientUnPaidAccountCommission.Text = unpaidAccount.vCommission.ToString();
                txtAdminClientUnPaidAccountOverdraft.Text = unpaidAccount.vOverdraft.ToString();
                txtAdminClientUnPaidAccountBalance.Text = unpaidAccount.vBalance.ToString();
                // Time
                txtAdminClientUnPaidAccountOpenDateYear.Text = unpaidAccount.vOpenDate.vYear.ToString();
                txtAdminClientUnPaidAccountOpenDateMonth.Text = unpaidAccount.vOpenDate.vMonth.ToString();
                txtAdminClientUnPaidAccountOpenDateDay.Text = unpaidAccount.vOpenDate.vDay.ToString();
            }
        } // end fncLoadUnPaidAccounts()

        /// <summary>
        /// Search employee by specific key
        /// </summary>
        /// <param name="sender">actualAgency.vListEmployees.fncExist(ID)</param>
        /// <param name="e"></param>
        private void btnAdminClientsSearch_Click(object sender, EventArgs e)
        {
            fncAdminSpaceAdminClientsSearch();
        } // end search employee

        /// <summary>
        /// Erase one client in the list client -> myBank.vListClient
        /// </summary>
        /// <param name="sender"> actualAgency.vListClients.fncErase(ID) </param>
        /// <param name="e">clsClient client</param>
        private void btnAdminClientsErase_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search clients number in the agency
                string ID = comboAdminSpaceAdminClients.Text.Trim();
                /// <summary>
                /// Erase by Id Clients in the Agency list
                /// </summary>
                actualAgency.vListClients.fncErase(ID);
                // MessageBox.Show(actualAgency.vListClients.Quantity.ToString());
                /// <summary>
                /// Clear the comboAgenciesClient
                /// </summary>
                comboAgenciesClient.Items.Clear();
                /// <summary>
                /// Clear the comboAdminSpaceAdminCLients
                /// </summary>
                comboAdminSpaceAdminClients.Items.Clear();
                /// <summary>
                /// Fills ths combos client in all the view.
                /// </summary>
                fncLoadCombosClients();
                /// <summary>
                /// fncClearTextBoxControlAdminEmployees() -> clear text box employees in Tab Admin
                /// </summary>
                fncClearTextBoxControlAdminClients();
                lblAdminnbClient.Text = "";
                // MessageBox.Show(actualAgency.vListClients.Quantity.ToString());
                MessageBox.Show(" Client : " + ID + " " + " in the Client doc has been deleted");
                /// <summary>
                /// Number of clients in the list
                /// </summary>
                lblAdminnbClient.Text = "";
                lblAdminnbClient.Text = "number of clients in the list ! : " + actualAgency.vListClients.Quantity.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end Erase client

        /// <summary>
        /// function load clients in combos clients
        /// </summary>
        public void fncLoadCombosClients()
        {
            try
            {
                foreach (clsClient client in actualAgency.vListClients.Elements)
                {
                    /// fill client combo in tab agency
                    comboAgenciesClient.Items.Add(client.vName);
                    /// fill client combo in tab Admin Space
                    comboAdminSpaceAdminClients.Items.Add(client.vNumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end load combo client

        /// <summary>
        /// Add one client in the list client -> myBank.vListClient
        /// </summary>
        /// <param name="sender">!actualAgency.vListClients.fncExist(ID</param>
        /// <param name="e">clsClient client</param>
        private void btnAdminClientsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search clients number in the agency
                string ID = comboAdminSpaceAdminClients.Text.Trim();
                // if ID do not exist
                if (!actualAgency.vListClients.fncExist(ID))
                {
                    clsClient client = new clsClient();
                    client.vNumber = comboAdminSpaceAdminClients.Text.Trim();
                    client.vName = txtAdminClientName.Text.Trim();
                    client.vLastName = txtAdminClientLastName.Text.Trim();
                    client.vNip = txtAdminClientNip.Text.Trim();
                    client.vAddress = txtAdminClientAddress.Text.Trim();

                    /// <summary>
                    /// Add client in the agency list
                    /// </summary>
                    actualAgency.vListClients.fncAdd(client);
                    // MessageBox.Show(actualAgency.vListClients.Quantity.ToString());
                    /// </summary>
                    /// Clear the comboAgenciesClient
                    /// </summary>
                    comboAgenciesClient.Items.Clear();
                    /// <summary>
                    /// Clear the comboAdminSpaceAdminCLients
                    /// </summary>
                    comboAdminSpaceAdminClients.Items.Clear();
                    /// <summary>
                    /// Fills ths combos client in all the view.
                    /// </summary>
                    fncLoadCombosClients();
                    /// <summary>
                    /// fncClearTextBoxControlAdminEmployees() -> clear text box employees in Tab Admin
                    /// </summary>
                    fncClearTextBoxControlAdminClients();
                    lblAdminnbClient.Text = "";
                    // MessageBox.Show(actualAgency.vListClients.Quantity.ToString());
                    MessageBox.Show(" Client : " + ID + " " + " in the Client doc has been Added");
                    /// <summary>
                    /// Number of clients in the list
                    /// </summary>
                    lblAdminnbClient.Text = "";
                    lblAdminnbClient.Text = "number of clients in the list ! : " + actualAgency.vListClients.Quantity.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end Add one client in the list client

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminClientsUpdate_Click(object sender, EventArgs e)
        {
            // building function
        }

        /// <summary>
        /// saves client in a XML documen
        /// </summary>
        /// <param name="sender">clsDataSave.fncWriteEmployeeslineinXML()</param>
        /// <param name="e"></param>
        private void btnSavelineClientXML_Click(object sender, EventArgs e)
        {
            clsDataSave.fncWriteClientslineinXML();
        } // end saves client in a XML documen

        /// <summary>
        /// Function to transfer actual actualAgency.vListClients to others classes, it needs to be static
        /// </summary>
        /// <returns>actualAgency.vListEmployees</returns>
        public static clsListClients fncGetvListClients()
        {
            return actualAgency.vListClients;
        } // end static function

        //admin space : Paid Account
        /// <summary>
        /// Event to find paid account by specific key in the clients list
        /// </summary>
        /// <param name="sender">actualClient.vListPaidAccounts.fncExist(PaidAccountNumber)</param>
        /// <param name="e"></param>
        private void btnAdminClientsPaSearch_Click(object sender, EventArgs e)
        {
            fncAdminSpaceAdminClientsPaidAccountSearch();
        } // end search a Paid Account

        /// <summary>
        /// Function to find paid account by specific key in the clients list
        /// </summary>
        public void fncAdminSpaceAdminClientsPaidAccountSearch()
        {
            try
            {
                // variable search account payable number by customer
                string PaidAccountNumber = txtAdminClientPaidAccountNumber.Text.Trim();
                // if ID exist
                if (actualClient.vListPaidAccounts.fncExist(PaidAccountNumber))
                {
                    ///// <summary>
                    ///// Find account by Id a client in the client list
                    ///// </summary>
                    clsAccount account = actualClient.vListPaidAccounts.fncFind(PaidAccountNumber);
                    fncFillTextBoxControlAdminClientsPaidAccount(account);
                    // MessageBox.Show(actualClient.vListPaidAccounts.Quantity.ToString());
                }
                else
                {
                    MessageBox.Show("Account " + " " + PaidAccountNumber + " " + "do not exist in the client potafolio !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end function search a Paid Account

        /// <summary>
        /// Function to fill the text boxes in paid account in admin
        /// </summary>
        /// <param name="account"></param>
        public void fncFillTextBoxControlAdminClientsPaidAccount(clsAccount account)
        {
            try
            {
                txtAdminClientPaidAccountInterestPayable.Text = account.vInterestRate.ToString();
                txtAdminClientPaidAccountBalance.Text = account.vBalance.ToString();
                txtAdminClientPaidAccountOpenDateYear.Text = account.vOpenDate.vYear.ToString();
                txtAdminClientPaidAccountOpenDateMonth.Text = account.vOpenDate.vMonth.ToString();
                txtAdminClientPaidAccountOpenDateDay.Text = account.vOpenDate.vDay.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end fill the text boxes in paid account

        /// <summary>
        /// Function to erase a Paid Account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">actualClient.vListPaidAccounts.fncErase(PaidAccountNumber)</param>
        private void btnAdminClientsPaErase_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search account number
                string PaidAccountNumber = txtAdminClientPaidAccountNumber.Text.Trim();
                /// <summary>
                /// Erase by Id Accounts in the Account list
                /// </summary>
                actualClient.vListPaidAccounts.fncErase(PaidAccountNumber);
                // MessageBox.Show(actualClient.vListPaidAccounts..Quantity.ToString());
                /// <summary>
                /// fncClearTextBoxControlAdminEmployees() -> clear text box employees in Tab Admin
                /// </summary>
                fncClearTextBoxControlAdminClientsPaidAccount();
                /// <summary>
                /// Number of accounts in the list
                /// </summary>
                lblAdminnbClientPaidAccount.Text = "";
                lblAdminnbClientPaidAccount.Text = "number of accounts in the list ! : " + actualClient.vListPaidAccounts.Quantity.ToString();
                MessageBox.Show(" Account : " + PaidAccountNumber + " " + " in the Account Client doc has been deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end erase a Paid Account

        /// <summary>
        /// Function to clear text boxes in Paid Account
        /// </summary>
        private void fncClearTextBoxControlAdminClientsPaidAccount()
        {
            txtAdminClientPaidAccountNumber.Text = "";
            txtAdminClientPaidAccountInterestPayable.Text = "";
            txtAdminClientPaidAccountBalance.Text = "";
            txtAdminClientPaidAccountOpenDateYear.Text = "";
            txtAdminClientPaidAccountOpenDateMonth.Text = "";
            txtAdminClientPaidAccountOpenDateDay.Text = "";
        } // end clear text boxes in Paid Account

        /// <summary>
        /// Event to add a paid account to a client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminPaClientsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search account number
                string PaidAccountNumber = txtAdminClientPaidAccountNumber.Text.Trim();
                // if PaidAccountNumber do not exist
                if (!actualClient.vListPaidAccounts.fncExist(PaidAccountNumber))
                {
                    clsPaidAccount paidAccount = new clsPaidAccount();
                    // Count data
                    paidAccount.vNumber = txtAdminClientPaidAccountNumber.Text.Trim();
                    paidAccount.vInterestRate = (Convert.ToDouble(txtAdminClientPaidAccountInterestPayable.Text.Trim())) / 100;
                    paidAccount.vBalance = Convert.ToDouble(txtAdminClientPaidAccountBalance.Text.Trim());
                    // Time
                    paidAccount.vOpenDate.vYear = Convert.ToInt32(txtAdminClientPaidAccountOpenDateYear.Text.Trim());
                    paidAccount.vOpenDate.vMonth = Convert.ToInt32(txtAdminClientPaidAccountOpenDateMonth.Text.Trim());
                    paidAccount.vOpenDate.vDay = Convert.ToInt32(txtAdminClientPaidAccountOpenDateDay.Text.Trim());
                    /// <summary>
                    /// Add account in the account list
                    /// </summary>
                    actualClient.vListPaidAccounts.fncAdd(paidAccount);
                    // MessageBox.Show(actualClient.vListPaidAccounts.Quantity.ToString());
                    /// <summary>
                    /// fncClearTextBoxControlAdminEmployees() -> clear text box employees in Tab Admin
                    /// </summary>
                    fncClearTextBoxControlAdminClientsPaidAccount();
                    /// <summary>
                    /// Number of clients in the list
                    /// </summary>
                    lblAdminnbClientPaidAccount.Text = "";
                    lblAdminnbClientPaidAccount.Text = "number of accounts in the list ! : " + actualClient.vListPaidAccounts.Quantity.ToString();
                    MessageBox.Show(" Account : " + PaidAccountNumber + " " + " in the Account doc has been Added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end add a paid account to a client

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminClientsPaUpdate_Click(object sender, EventArgs e)
        {
            // building function
        }

        /// <summary>
        /// Event save Paid Account in XML document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavelineClientPaXML_Click(object sender, EventArgs e)
        {
            clsDataSave.fncWritePaidAccountsinXML();
        } // end save Paid Account in XML document

        /// <summary>
        /// Function to transfer actual Paid Account (actualClient.vListPaidAccounts) to others classes, it needs to be static
        /// </summary>
        /// <returns>actualClient.vListPaidAccounts</returns>
        public static clsListPaidAccounts fncGetvListPaidAccounts()
        {
            return actualClient.vListPaidAccounts;
        } // end transfer actual Paid Account

        //admin space : Un Paid Account
        /// <summary>
        /// Event to find un paid account by specific key in the clients list
        /// </summary>
        /// <param name="sender">actualClient.vListUnpaidAccounts.fncExist(UnPaidAccountNumber)</param>
        /// <param name="e"></param>
        private void btnAdminClientsUnPaSearch_Click(object sender, EventArgs e)
        {
            fncAdminSpaceAdminClientsUnPaidAccountSearch();
        } // end search a un paid Account

        /// <summary>
        /// Function to find unpaid account by specific key in the un paid list
        /// </summary>
        public void fncAdminSpaceAdminClientsUnPaidAccountSearch()
        {
            try
            {
                // variable search unpay account number by customer
                string UnPaidAccountNumber = txtAdminClientUnPaidAccountNumber.Text.Trim();
                // if ID exist
                if (actualClient.vListUnpaidAccounts.fncExist(UnPaidAccountNumber))
                {
                    ///// <summary>
                    ///// Find account by Id in the account list
                    ///// </summary>
                    clsAccount account = actualClient.vListUnpaidAccounts.fncFind(UnPaidAccountNumber);
                    fncFillTextBoxControlAdminClientsUnPaidAccount(account);
                    // MessageBox.Show(actualClient.vListUnpaidAccounts.Quantity.ToString());
                }
                else
                {
                    MessageBox.Show("Account " + " " + UnPaidAccountNumber + " " + "do not exist in the client potafolio !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end find unpaid account

        /// <summary>
        /// Function to fill text boxes in un paid account
        /// </summary>
        /// <param name="account"></param>
        public void fncFillTextBoxControlAdminClientsUnPaidAccount(clsAccount account)
        {
            try
            {
                txtAdminClientUnPaidAccountCommission.Text = account.vCommission.ToString();
                txtAdminClientUnPaidAccountOverdraft.Text = account.vOverdraft.ToString();
                txtAdminClientUnPaidAccountBalance.Text = account.vBalance.ToString();
                txtAdminClientPaidAccountOpenDateYear.Text = account.vOpenDate.vYear.ToString();
                txtAdminClientPaidAccountOpenDateMonth.Text = account.vOpenDate.vMonth.ToString();
                txtAdminClientPaidAccountOpenDateDay.Text = account.vOpenDate.vDay.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end fill text boxes in un paid account

        /// <summary>
        /// Function to erase a Un Paid Account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">actualClient.vListUnpaidAccounts.fncErase(UnPaidAccountNumber)</param>
        private void btnAdminClientsUnPaErase_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search account number
                string UnPaidAccountNumber = txtAdminClientUnPaidAccountNumber.Text.Trim();
                /// <summary>
                /// Erase by Id Accounts in the Account list
                /// </summary>
                actualClient.vListUnpaidAccounts.fncErase(UnPaidAccountNumber);
                // MessageBox.Show(actualClient.vListUnpaidAccounts..Quantity.ToString());
                /// <summary>
                /// fncClearTextBoxControlAdminClientsPaidAccount() -> clear text box UnPaidAccount in Tab Admin
                /// </summary>
                fncClearTextBoxControlAdminClientsUnPaidAccount();
                /// <summary>
                /// Number of accounts in the list
                /// </summary>
                lblAdminnbClientUnPaidAccount.Text = "";
                lblAdminnbClientUnPaidAccount.Text = "number of accounts in the list ! : " + actualClient.vListUnpaidAccounts.Quantity.ToString();
                MessageBox.Show(" Account : " + UnPaidAccountNumber + " " + " in the Account Client doc has been deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end erase a Un Paid Account

        /// <summary>
        /// Function to clear text boxes in un paid account in admin
        /// </summary>
        private void fncClearTextBoxControlAdminClientsUnPaidAccount()
        {
            txtAdminClientUnPaidAccountNumber.Text = "";
            txtAdminClientUnPaidAccountCommission.Text = "";
            txtAdminClientUnPaidAccountOverdraft.Text = "";
            txtAdminClientUnPaidAccountBalance.Text = "";
            txtAdminClientUnPaidAccountOpenDateYear.Text = "";
            txtAdminClientUnPaidAccountOpenDateMonth.Text = "";
            txtAdminClientUnPaidAccountOpenDateDay.Text = "";
        } // end clear text boxes in un paid account 

        /// <summary>
        /// Event to add a un paid account to a client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminUnPaClientsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // variable search account number
                string UnPaidAccountNumber = txtAdminClientPaidAccountNumber.Text.Trim();
                // if PaidAccountNumber do not exist
                if (!actualClient.vListUnpaidAccounts.fncExist(UnPaidAccountNumber))
                {
                    clsUnpaidAccount UnpaidAccount = new clsUnpaidAccount();
                    // Count data
                    UnpaidAccount.vCommission = (Convert.ToDouble(txtAdminClientUnPaidAccountCommission.Text.Trim())) / 100;
                    UnpaidAccount.vOverdraft = Convert.ToInt32(txtAdminClientUnPaidAccountOverdraft.Text.Trim());
                    UnpaidAccount.vNumber = txtAdminClientUnPaidAccountNumber.Text.Trim();
                    UnpaidAccount.vBalance = Convert.ToDouble(txtAdminClientUnPaidAccountBalance.Text.Trim());
                    // Time
                    UnpaidAccount.vOpenDate.vYear = Convert.ToInt32(txtAdminClientUnPaidAccountOpenDateYear.Text.Trim());
                    UnpaidAccount.vOpenDate.vMonth = Convert.ToInt32(txtAdminClientUnPaidAccountOpenDateMonth.Text.Trim());
                    UnpaidAccount.vOpenDate.vDay = Convert.ToInt32(txtAdminClientUnPaidAccountOpenDateDay.Text.Trim());
                    /// <summary>
                    /// Add account in the account list
                    /// </summary>
                    actualClient.vListUnpaidAccounts.fncAdd(UnpaidAccount);
                    // MessageBox.Show(actualClient.vListPaidAccounts.Quantity.ToString());
                    /// <summary>
                    /// fncClearTextBoxControlAdminClientsUnPaidAccount() -> clear text box UnPaidAccount in Tab Admin
                    /// </summary>
                    fncClearTextBoxControlAdminClientsUnPaidAccount();
                    /// <summary>
                    /// Number of clients in the list
                    /// </summary>
                    lblAdminnbClientUnPaidAccount.Text = "";
                    lblAdminnbClientUnPaidAccount.Text = "number of accounts in the list ! : " + actualClient.vListUnpaidAccounts.Quantity.ToString();
                    MessageBox.Show(" Account : " + UnPaidAccountNumber + " " + " in the Account doc has been Added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // end to add a un paid account

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminClientsUnPaUpdate_Click(object sender, EventArgs e)
        {
            // building function
        }

        /// <summary>
        /// Event save Un Paid Account in XML document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavelineClientUnPaXML_Click(object sender, EventArgs e)
        {
            clsDataSave.fncWriteUnPaidAccountsinXML();
        } // end save  Un Paid Account in XML document

        /// <summary>
        /// Function to transfer the un paid accoun list (actual actualClient.vListUnpaidAccounts) to others classes, it needs to be static
        /// </summary>
        /// <returns>actualAgency.vListEmployees</returns>
        public static clsListUnpaidAccounts fncGetvListUnPaidAccounts()
        {
            return actualClient.vListUnpaidAccounts;
        } // end transfer the un paid accoun list
    } // end public partial class frmBank
}
