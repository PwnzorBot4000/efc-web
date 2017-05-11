using System;
using System.Web;
using System.Web.UI;

namespace efc_web
{

    public partial class LoginPage : System.Web.UI.Page
    {
        private bool guestmode_on = true;

        protected bool can_guests_enter()
        {
            return guestmode_on;
        }

        protected void login_click(object sender, EventArgs e)
        {
            if (passwdbox.Text == "0000")
            {
                Response.BufferOutput = true;
                Response.Redirect("MotorInterface.aspx");
            }
            else
            {
                passwdbox.Text = "";
                outputbox.Text = "Invalid password";
            }
        }

        protected void guest_click(object sender, EventArgs e)
        {
            if (!guestmode_on) return;
            Response.BufferOutput = true;
            Response.Redirect("MotorInterface.aspx");
        }
    }
}
