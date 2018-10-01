using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Security;
using CustomProviders;
using System.Transactions;

namespace DotNetSoft.Web.Users.Order
{
    public partial class AddOrder : System.Web.UI.Page
    {
        CustomProfileCommon profile;
        BLL.OrderInfo bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                WebHelper.PageHelper.LoadHeaderForProduct(Page, ltrTheme);

                Bind();

                BindAddress();

                BindSelectAddress();
            }
        }

        private void Bind()
        {
            if (profile == null) profile = new CustomProfileCommon();
            rpData.DataSource = profile.ShoppingCart.CartItems;
            rpData.DataBind();
        }

        private void BindAddress()
        {
            if (profile == null) profile = new CustomProfileCommon();
            List<Model.UserAddress> list = profile.UserAddress.GetList();
            if (list != null && list.Count > 0)
            {
                string addressAppend = "";
                int n = 0;
                foreach (Model.UserAddress model in list)
                {
                    n++;
                    addressAppend += string.Format("<div class=\"item\"><input type=\"radio\" class=\"hookbox\" name=\"consignee_radio\" id=\"r{1}\" value=\"{0}\" {2} />", model.NumberID, n, model.IsDefault ? "checked=\"checked\"" : "");
                    addressAppend += string.Format("<label for=\"r"+n+"\"><b>{2}</b>&nbsp; {1} &nbsp; {0} &nbsp;</label>", model.Mobilephone, model.ProvinceCity.Replace("-", "") + model.Address, model.Receiver);
                    addressAppend += "<span class=\"item-action hide\"><a id=\"abtnEdit" + n + "\" href=\"javascript:void(0)\">编辑</a> &nbsp;<a id=\"abtnDel" + n + "\" href=\"javascript:void(0)\">删除</a>&nbsp;</span></div>";
                }

                ltrAddress.Text = addressAppend;
            }
        }

        private void BindSelectAddress()
        {
            if (profile == null) profile = new CustomProfileCommon();
            List<Model.UserAddress> list = profile.UserAddress.GetList();
            if (list != null && list.Count > 0)
            {
                Model.UserAddress selectModel = list.Find(delegate(Model.UserAddress m) { return m.IsDefault == true; });
                if (selectModel == null)
                {
                    selectModel = list.Find(delegate(Model.UserAddress m) { return m.LastUpdatedDate == list.Max(mi => mi.LastUpdatedDate); });
                }

                ltrHasAddress.Text = string.Format("<p>{3} &nbsp; {2} &nbsp;  &nbsp; <br />{1} &nbsp; {0} </p>", selectModel.Address, selectModel.ProvinceCity.Replace("-", " "), selectModel.Mobilephone + " " + selectModel.Telephone, selectModel.Receiver);
                hNId.Value = selectModel.NumberID.ToString();
            }
        }

        protected string GetCount()
        {
            if (profile == null) profile = new CustomProfileCommon();
            return profile.ShoppingCart.Count.ToString();
        }

        protected string GetTotalPrice()
        {
            if (profile == null) profile = new CustomProfileCommon();
            return profile.ShoppingCart.TotalPrice.ToString();
        }

        /// <summary>
        /// 按钮OnCommand事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Command(object sender, CommandEventArgs e)
        {
            string commName = hOp.Value.Trim();
            switch (commName)
            {
                case "saveAddress":
                    OnSaveAddress();
                    break;
                case "editGetAddress":
                    OnEditGetAddress();
                    break;
                case "editAddress":
                    OnEditAddress();
                    break;
                case "delAddress":
                    OnDelAddress();
                    break;
                case "changeAddress":
                    OnChangeAddress();
                    break;
                case "commit":
                    OnCommit();
                    break;
                default:
                    break;
            }
        }

        private void OnEditGetAddress()
        {
            string numberId = hNId.Value.Trim();
            if (!string.IsNullOrEmpty(numberId))
            {
                if (profile == null) profile = new CustomProfileCommon();
                Model.UserAddress model = profile.UserAddress.GetModel(Guid.Parse(numberId));
                if (model != null)
                {
                    txtReceiver.Value = model.Receiver;
                    txtProvinceCity.Value = model.ProvinceCity;
                    txtAddress.Value = model.Address;
                    txtMobilephone.Value = model.Mobilephone;
                    txtTelephone.Value = model.Telephone;
                    txtEmail.Value = model.Email;

                    hOp.Value = "editAddress";
                }
            }
        }

        private void OnSaveAddress()
        {
            if (profile == null) profile = new CustomProfileCommon();
            if (profile.UserAddress.Count >= 5)
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "当前地址数量已达上限（5个），若要继续添加新地址，请先删除部分收货地址。");
                return;
            }

            Model.UserAddress model = new Model.UserAddress();
            if (!OnCheckForm(ref model))
            {
                return;
            }

            model.NumberID = Guid.NewGuid();

            List<Model.UserAddress> list = profile.UserAddress.GetList();
            foreach (Model.UserAddress item in list)
            {
                item.IsDefault = false;
            }
            profile.UserAddress.Insert(model);
            profile.Save();

            BindAddress();

            BindSelectAddress();
        }

        private void OnEditAddress()
        {
            string numberId = hNId.Value.Trim();
            if (!string.IsNullOrEmpty(numberId))
            {
                if (profile == null) profile = new CustomProfileCommon();
                Model.UserAddress model = profile.UserAddress.GetModel(Guid.Parse(numberId));
                if (!OnCheckForm(ref model))
                {
                    return;
                }

                if (model != null)
                {
                    profile.UserAddress.Update(model);

                    profile.Save();

                    BindAddress();

                    BindSelectAddress();

                    hOp.Value = "savaAddress";
                }
            }
        }

        private void OnDelAddress()
        {
            string numberId = hNId.Value.Trim();
            if (!string.IsNullOrEmpty(numberId))
            {
                if (profile == null) profile = new CustomProfileCommon();
                profile.UserAddress.Remove(Guid.Parse(numberId));

                profile.Save();

                BindAddress();

                BindSelectAddress();

                hOp.Value = "saveAddress";
            }
        }

        private void OnChangeAddress()
        {
            string numberId = hNId.Value.Trim();
            if (!string.IsNullOrEmpty(numberId))
            {
                if (profile == null) profile = new CustomProfileCommon();
                Model.UserAddress selectModel = profile.UserAddress.GetModel(Guid.Parse(numberId));
                if (selectModel != null)
                {
                    ltrHasAddress.Text = string.Format("<p>{3} &nbsp; {2} &nbsp;  &nbsp; <br />{1} &nbsp; {0} </p>", selectModel.Address, selectModel.ProvinceCity.Replace("-", " "), selectModel.Mobilephone + " " + selectModel.Telephone, selectModel.Receiver);
                }
            }
        }

        private bool OnCheckForm(ref Model.UserAddress model)
        {
            #region 获取输入并验证
            string sReceiver = txtReceiver.Value.Trim();
            if (string.IsNullOrEmpty(sReceiver))
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请您填写收货人姓名", "操作错误", "error");
                return false;
            }
            string sProvinceCity = txtProvinceCity.Value.Trim();
            if (string.IsNullOrEmpty(sProvinceCity))
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请选择所在地区", "操作错误", "error");
                return false;
            }
            string[] pArr = sProvinceCity.Split('-');
            if (pArr.Length != 3)
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请正确选择所在地区中的省市区", "操作错误", "error");
                return false;
            }
            string sAddress = txtAddress.Value.Trim();
            if (string.IsNullOrEmpty(sAddress))
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请填写详细地址","操作错误","error");
                return false;
            }
            string sMobilephone = txtMobilephone.Value.Trim();
            string sTelephone = txtTelephone.Value.Trim();
            if (string.IsNullOrEmpty(sMobilephone) && string.IsNullOrEmpty(sTelephone))
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "手机或固定电话至少填写一个","操作错误","error");
                return false;
            }

            Regex r = null;
            if (!string.IsNullOrEmpty(sMobilephone))
            {
                r = new Regex(@"^1[3|4|5|8][0-9]\d{4,8}$");
                if (!r.IsMatch(sMobilephone))
                {
                    WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请输入正确的手机号码格式", "操作错误", "error");
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(sTelephone))
            {
                r = new Regex(@"(\(\d{3,4}\)|\d{3,4}-|\s)?\d{8}");
                if (!r.IsMatch(sTelephone))
                {
                    WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请输入正确的电话号码格式", "操作错误", "error");
                    return false;
                }
            }

            string sEmail = txtEmail.Value.Trim();
            if (!string.IsNullOrEmpty(sEmail))
            {
                r = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (!r.IsMatch(sEmail))
                {
                    WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请输入正确的电子邮箱格式", "操作错误", "error");
                    return false;
                }
            }

            model.Receiver = sReceiver;
            model.ProvinceCity = sProvinceCity;
            model.Address = sAddress;
            model.Mobilephone = sMobilephone;
            model.Telephone = sTelephone;
            model.Email = sEmail;
            model.IsDefault = true;
            model.LastUpdatedDate = DateTime.Now;

            #endregion

            return true;
        }

        private void OnCommit()
        {
            if (WebHelper.Common.GetUserId() != Guid.Empty)
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请先登录再执行操作");
                return;
            }
            string addressId = hNId.Value.Trim();
            if (string.IsNullOrEmpty(addressId))
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请选择收货人信息","操作错误","error");
                return;
            }
            if(profile == null) profile = new CustomProfileCommon();
            Model.UserAddress addressModel = profile.UserAddress.GetModel(Guid.Parse(addressId));
            if (addressModel == null)
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "不存在当前收货人信息记录，请检查", "操作错误", "error");
                return;
            }
            string payOption = selectPay.InnerText.Trim();
            if (string.IsNullOrEmpty(payOption))
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "请选择支付及配送方式", "操作错误", "error");
                return;
            }

            int totalCount = profile.ShoppingCart.Count;
            decimal totalPrice = profile.ShoppingCart.TotalPrice;
            if (totalCount < 1)
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, "商品清单不存在任何商品，请检查", "操作错误", "error");
                return;
            }

            string sProducts = "";
            ICollection<Model.CartItemInfo> items = profile.ShoppingCart.CartItems;
            foreach (Model.CartItemInfo item in items)
            {
                sProducts += string.Format("{2},{1},{0}|", item.Subtotal, item.Quantity, item.ProductId);
            }
            sProducts = sProducts.Trim('|');

            DateTime dtime = DateTime.Now;
            Model.OrderInfo model = new Model.OrderInfo();
            model.OrderNum = WebHelper.CustomsHelper.CreateDateTimeString();
            model.UserId = WebHelper.Common.GetUserId();
            model.Receiver = addressModel.Receiver;
            model.ProviceCity = addressModel.ProvinceCity;
            model.Address = addressModel.Address;
            model.Mobilephone = addressModel.Mobilephone;
            model.Telephone = addressModel.Telephone;
            model.Email = addressModel.Email;
            model.Products = sProducts;
            model.TotalCount = totalCount;
            model.TotalPrice = totalPrice;
            model.PayOption = payOption;
            model.LastUpdatedDate = dtime;
            model.CreateDate = dtime;

            string errorMsg = "";
            try
            {
                TransactionOptions options = new TransactionOptions();
                options.IsolationLevel = IsolationLevel.ReadUncommitted;
                options.Timeout = TimeSpan.FromSeconds(90);
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
                {
                    if (bll == null) bll = new BLL.OrderInfo();
                    if (bll.Insert(model) > 0)
                    {
                        profile.ShoppingCart.Clear();
                        profile.Save();
                    }

                    //提交事务
                    scope.Complete();
                }

                Response.Redirect(string.Format("AddOrderSucceed.aspx?oN={0}", HttpUtility.UrlEncode(model.OrderNum)), true);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
            if (!string.IsNullOrEmpty(errorMsg))
            {
                WebHelper.MessageBox.Messager(this.Page, lbtnSave, errorMsg,"系统异常提醒");
                return;
            }
        }
    }
}