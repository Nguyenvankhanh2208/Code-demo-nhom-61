using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLySanpham
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)// khi ấn vào sẽ chạy để load lại dữ liệu
        {
            lsvData.DataBind();
        }

        protected void lsvData_ItemCommand(object sender, ListViewCommandEventArgs e)//chức năng để xóa
        {
            string idStr = Convert.ToString(e.CommandArgument);
            if (string.IsNullOrEmpty(idStr))
                return;
            if (e.CommandName == "DeleteItem")// nếu ấn nút delete sẽ chạy câu lệnh
            {
                using (var context = new DataContext()) // lấy dữ liệu từ datacontext trong data
                {
                    var item = context.Products.Find(Convert.ToInt32(idStr));// lấy id
                    if (item != null)// nếu có id thì sẽ chạy lệnh dưới để xóa và lưu lại vào database
                    {
                        context.Products.Remove(item);
                        context.SaveChanges();
                        lsvData.DataBind();
                    }

                }
            }
            else if (e.CommandName == "EditItem")// để sửa
            {
                using (var context = new DataContext())
                {
                    var item = context.Products.Find(Convert.ToInt32(idStr));// lấy id
                    if (item != null)
                    {
                        txtName.Text = item.Name;
                        txtPrice.Text = item.Price.ToString();
                        txtDescription.Text = item.Description;
                        hidSelectedId.Value = idStr;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenForm", "OpenForm('edit', '" + idStr + "')", true);
                    }

                }
            }
        }

        protected void lbtSave_Click(object sender, EventArgs e)// nút lưu lại
        {
            if (Page.IsValid)
            {
                if (hidSelectedId.Value == "0") //id ẩn sẽ được thêm ms vào lệnh dưới
                {
                    using (var context = new DataContext())
                    {
                        Core.Models.Product product = new Core.Models.Product()// sau khi ấn nút save sẽ sinh ra product mới
                        {
                            Name = txtName.Text,//gán tên mới do người dùng nhập
                            Price = Convert.ToDouble(txtPrice.Text),
                            Description = txtDescription.Text
                        };
                        context.Products.Add(product);// sẽ lưu vào product trước
                        context.SaveChanges();// sau đó lưu vào database
                        lsvData.DataBind();
                    }
                }
                else
                {
                    using (var context = new DataContext())
                    {
                        Core.Models.Product product = context.Products.Find(Convert.ToInt32(hidSelectedId.Value));

                        product.Name = txtName.Text;
                        product.Price = Convert.ToDouble(txtPrice.Text);
                        product.Description = txtDescription.Text;

                        context.SaveChanges();
                        lsvData.DataBind();
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenForm", "OpenForm('edit');", true);
            }
        }

        protected void lsvData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}