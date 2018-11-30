using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormRecaptcha.UserControl
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divAnonymousTemplate.Visible = false;
                //divError.Visible = false;
                divLoggedInTemplate.Visible = false;

                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    divAnonymousTemplate.Visible = true;
                }
                divLoggedInTemplate.Visible = !divAnonymousTemplate.Visible;
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.ToString();
                //divError.Visible = true;
            }
        }

        protected void ucLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    TextBox txtUsername = (TextBox)ucLogin.FindControl("Username");
                    TextBox txtPassword = (TextBox)ucLogin.FindControl("Password");
                    e.Authenticated = (txtUsername.Text == "JohnDoe" && txtPassword.Text == "letmein");
                    if (e.Authenticated)
                    {
                        FormsAuthentication.RedirectFromLoginPage(ucLogin.UserName, ucLogin.RememberMeSet);
                    }
                    else
                    {
                        ucLogin.FailureText = "Username and/or password is incorrect.";
                    }
                }
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.ToString();
                //divError.Visible = true;

            }
        }

        //protected void ucLogin_LoginError(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lblError.Text = "Autenticazione Fallita";
        //        divError.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = ex.ToString();
        //        divError.Visible = true;
        //    }
        //}

        //protected void ucLogin_LoggedIn(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        TextBox txtUsername = (TextBox)ucLogin.FindControl("Username");
        //        lblLoggedUser.Text = string.Format("Benvenuto {0}", txtUsername.Text);
        //        divAnonymousTemplate.Visible = false;
        //        divLoggedInTemplate.Visible = !divAnonymousTemplate.Visible;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = ex.ToString();
        //        divError.Visible = true;
        //    }
        //}
    }
}