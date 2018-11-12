using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Student.IsAuthenticated(Session, Request))
        {
            userInfo.Visible = true;
            navStudent.Visible = true;
            lblHeaderName.Text = Session["studentName"].ToString();
        }
    }
}
