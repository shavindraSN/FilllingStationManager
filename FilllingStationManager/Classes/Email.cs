using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillingStationManager.Classes
{
    class Email
    {
        /*
         * This class is responsible for sending emails
         * Sends emails to Customers, Admin and managers,  Developers
         */
        private String errorEmailTo = "shavindramms1@gmail.com";
        public int sendEmail(String emailAddressTo, String emailSubject, String emailBody)
        {
            Classes.InternetConnection ic = new InternetConnection();

            if (ic.isConnected())
            {
                try
                {
                    String senderAddress = "fillingstationmayadunne@gmail.com";
                    MailMessage mail = new MailMessage(senderAddress, emailAddressTo, emailSubject, emailBody);
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("fillingstationmayadunne@gmail.com","Mayadunne Filling Station");
                    client.Port = 587;
                    client.Credentials = new System.Net.NetworkCredential("fillingstationmayadunne@gmail.com", "maya3station");
                    client.EnableSsl = true;
                    client.Send(mail);
                    return 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpcted Error", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw;
                }
            }

            else
            {
                MessageBox.Show("No Internet Connection Available. Please Connect to Internet and then proceed", "Unable send Email.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }

        // This method send email with an attachment
        public int sendEmail(String emailAddressTo, String emailSubject, String emailBody, String attachmentFileName)
        {
            Classes.InternetConnection ic = new InternetConnection();

            if (ic.isConnected())
            {
                if (attachmentFileName != null)
                {
                    try
                    {

                        String senderAddress = "fillingstationmayadunne@gmail.com";
                        MailMessage mail = new MailMessage(senderAddress, emailAddressTo, emailSubject, emailBody);
                        SmtpClient client = new SmtpClient("smtp.gmail.com");
                        client.Port = 587;
                        client.Credentials = new System.Net.NetworkCredential("fillingstationmayadunne@gmail.com", "maya3station");
                        client.EnableSsl = true;

                        Attachment attachment = new Attachment(attachmentFileName, MediaTypeNames.Application.Octet);
                        ContentDisposition disposition = attachment.ContentDisposition;
                        disposition.CreationDate = File.GetCreationTime(attachmentFileName);
                        disposition.ModificationDate = File.GetLastWriteTime(attachmentFileName);
                        disposition.ReadDate = File.GetLastAccessTime(attachmentFileName);
                        disposition.FileName = Path.GetFileName(attachmentFileName);
                        disposition.Size = new FileInfo(attachmentFileName).Length;
                        disposition.DispositionType = DispositionTypeNames.Attachment;
                        mail.Attachments.Add(attachment); 

                        client.Send(mail);
                        return 0;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Unexpected Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        throw;
                    }
                }
                else
                {
                    return -2;
                }
            }

            else
            {
                MessageBox.Show("No Internet Connection Available. Please Connect to Internet and then proceed", "Unable send Email.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }

        public int sendErrorEmail(String emailSubject, String emailBody)
        {
            return sendEmail(errorEmailTo, emailSubject, emailBody);
        }

        //This method save emails for errors in the system
        //all the exceptions are saved in the database
        public void saveErrorEmail(String emailSubject, String emailBody, int stat)
        {
            DateTime now = DateTime.Now;
            String iQuery = "INSERT INTO ErrorEmailBuffer Values('"+errorEmailTo+"', '"+emailSubject+"', '"+emailBody+"', '"+now.ToString()+"', "+stat+")";
            DBUtil dbu = new DBUtil();
            dbu.writeToDB(iQuery);
        }

        //this method is used to send Notification Emails
        public void saveEmail(String emailAddressTo, String emailSubject, String emailBody, int stat)
        {

        }

        // This method is the implementation of saving Email in the Error or Email Buffers
        private void saveToDB(String query)
        {

        }
    }
}
