using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElevReg
{
    public partial class Login : System.Web.UI.Page
    {
        HttpCookie reqCookies;

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button1_Click1(object sender, EventArgs e)
        {

            Dal dataManager = new Dal();

            try
            {

         
            if (dataManager.ValidateUser(uname.Text, passw.Text))
            {
                HttpCookie userInfo = new HttpCookie("uni");
                userInfo["uni"] = uname.Text;
                userInfo.Expires.Add(new TimeSpan(930, 60, 45));
                Response.Cookies.Add(userInfo);


                Response.Redirect("check.aspx");

            }

            }


            catch (Exception ex)
            {

                Label1.Text = ex.Message.ToString();
            }
        }
    }
}