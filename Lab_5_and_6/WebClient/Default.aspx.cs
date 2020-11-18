using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.ServiceReference1;

namespace WebClient
{
    public partial class _Default : Page
    {
        Service1Client sessionClient = new Service1Client("BasicHttpBinding_IService1");
        static Uri address = new Uri("http://localhost:8733/");
        BasicHttpBinding binding = new BasicHttpBinding();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                sessionClient.ConnectionInfo(binding.Name, address.Port.ToString(), address.LocalPath,
                    address.ToString(), address.Scheme);
                GridView1.DataSource = sessionClient.GetData();
                GridView1.DataBind();
                DropDownList1.DataSource = sessionClient.GetExpSelectData();
                DropDownList1.DataTextField = "name_exp";
                DropDownList1.DataValueField = "id_exp";
                DropDownList1.DataBind();
                DropDownList2.DataSource = sessionClient.GetHallSelectData();
                DropDownList2.DataTextField = "name_h";
                DropDownList2.DataValueField = "id_h";
                DropDownList2.DataBind();
            }

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            var id_Client = DropDownList1.Text;
            var id_Bus = DropDownList2.Text;
            var date = this.TextBox1.Text;
            var autor_order = this.TextBox2.Text;
            if (date == "")
            {
                this.Label20.Visible = true;
            }
            else
            {

                var check = sessionClient.RecCheck(id_Client, id_Bus, date, autor_order);
                if (check == "1")
                {
                    Label5.Visible = true;
                }
                else
                {
                   sessionClient.InsertMethod(id_Client, id_Bus, date, autor_order);

                    Response.Redirect("/Default");
                }
            }
        }
    }
}