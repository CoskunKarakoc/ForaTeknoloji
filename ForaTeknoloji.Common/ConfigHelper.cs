using ForaTeknoloji.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Common
{
    public class ConfigHelper
    {
        public static T Get<T>(string key)
        {
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));

        }

        public static void SetEmailConfig(EMailSetting eMailSetting)
        {
            try
            {
                var settings = ConfigurationManager.AppSettings;
                if (settings["MailHost"] == null)
                    settings.Add("MailHost", eMailSetting.SMPT_Server);
                else
                    settings.Set("MailHost", eMailSetting.SMPT_Server);

                if (settings["MailPort"] == null)
                    settings.Add("MailPort", eMailSetting.SMPT_Server_Port.ToString());
                else
                    settings.Set("MailPort", eMailSetting.SMPT_Server_Port.ToString());

                if (settings["MailUser"] == null)
                    settings.Add("MailUser", eMailSetting.E_Mail_Adres);
                else
                    settings.Set("MailUser", eMailSetting.E_Mail_Adres);

                if (settings["MailPass"] == null)
                    settings.Add("MailPass", eMailSetting.Sifre);
                else
                    settings.Set("MailPass", eMailSetting.Sifre);
            }
            catch (Exception)
            {

            }

        }


    }
}
