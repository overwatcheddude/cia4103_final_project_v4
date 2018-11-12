using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null)
        {
            switch (Request.QueryString["action"])
            {
                case "logout":
                    Session.Abandon();

                    // delete cookie
                    if (Request.Cookies["studentCookie"] != null)
                    {
                        HttpCookie studentCookie = new HttpCookie("studentCookie");
                        studentCookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(studentCookie);
                        Response.Redirect(Request.RawUrl);
                    }

                    logoutAlert.Visible = true;
                    break;
                default:
                    break;
            }
        }
        else if (Student.IsAuthenticated(Session, Request))
        {
            Response.Redirect("Opportunities.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        clearAlerts();

        //Read email and password from textboxes.
        string id = txtId.Text;
        string password = txtPassword.Text;
        //If the user's account exists, then redirect him to a webpage and store his email as session, else display error message.
        if (Student.Authenticate(id, password))
        {
            Session["studentId"] = id;

            Student std = Student.GetById(id);
            Session["studentName"] = std.FirstName + " " + std.LastName;

            if (cbRemember.Checked)
            {
                HttpCookie studentCookie = new HttpCookie("studentCookie");
                studentCookie.Expires = DateTime.Now.AddMonths(1); // it will expire in a month.
                
                studentCookie.Values["id"] = id;

                // creates a hash token from type, id, and
                // a secret string only known to this app
                string token = BCrypt.Net.BCrypt.HashPassword(id + Config.GetSecretString());

                studentCookie.Values["token"] = token;

                Student.SaveRememberToken(token, id);

                Response.Cookies.Add(studentCookie);
            }

            Response.Redirect("Opportunities.aspx");
        }
        else
        {
            authAlert.Visible = true;
        }
    }

    private void clearAlerts()
    {
        authAlert.Visible = false;
        logoutAlert.Visible = false;
    }
}