using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormRecaptcha.UserControl
{
    public partial class CaptchaGoogle : System.Web.UI.UserControl
    {
        public string ValidationGroup { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetGroupToCustomValidator();
        }
        protected void cvCaptcha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                args.IsValid = false;
                if (hfCaptchaValidation != null)
                    args.IsValid = this.Validate(hfCaptchaValidation.Value);
            }
            catch (Exception ex)
            {

            }
        }
        protected void SetGroupToCustomValidator()
        {
            cvCaptcha.ValidationGroup = ValidationGroup;
        }
        public bool Validate(string encodedResponse)
        {

            var client = new System.Net.WebClient();

            string privateKey = ConfigurationManager.AppSettings["CaptchaSecretKey"];
            string captchaUrl = ConfigurationManager.AppSettings["CaptchaUrl"];
            string url = captchaUrl + $"?secret={privateKey}&response={encodedResponse}";

            var providerResponse = client.DownloadString(url);

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaValidation>(providerResponse);

            return captchaResponse.IsSuccessfull;

        }
        public class CaptchaValidation
        {
            [JsonProperty("success")]
            public string Success
            {
                get { return m_Success; }
                set { m_Success = value; }
            }

            private string m_Success;
            [JsonProperty("error-codes")]
            public List<string> ErrorCodes
            {
                get { return m_ErrorCodes; }
                set { m_ErrorCodes = value; }
            }

            public bool IsSuccessfull
            {
                get
                {
                    bool successfull = false;
                    return bool.TryParse(m_Success, out successfull) ? successfull : false;
                }
            }
            private List<string> m_ErrorCodes;
        }
    }
}