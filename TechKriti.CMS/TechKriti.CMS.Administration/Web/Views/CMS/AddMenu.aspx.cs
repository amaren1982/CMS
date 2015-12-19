using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.UserManagement;
using Datacontracts.ContentManagement;
using Techkriti.Common.Controllers.CMS;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;

namespace TechKriti.CMS.Administration.Web.Views.CMS
{
    public partial class AddMenu : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddMenu; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateMenuId = Request.Params["menuId"];

                if (!string.IsNullOrEmpty(candidateMenuId))
                {
                    int result;
                    if (int.TryParse(candidateMenuId, out result))
                    {
                        MenuToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetMenuModel();
                GetAllMenus();
                BuildView();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) { SaveMenu(); }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageMenus); }  

        private void GetAllMenus()
        {
            try
            {
                List<MenuDataContract> source = new List<MenuDataContract>();
                source.Add(new MenuDataContract {  MenuName = "Select" });

                drpDownParentMenu.DataTextField = "MenuName";
                drpDownParentMenu.DataValueField = "Id";
                source.AddRange( MenuController.GetAllMenus() );

                drpDownParentMenu.DataSource = source;
                drpDownParentMenu.DataBind();
            }
            catch (Exception e)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load menus";
            }
        }

        private void BuildView()
        {
            txtMenuName.Text = MenuModel.MenuName;
            chkIsActive.Checked = MenuModel.IsActive.HasValue ? MenuModel.IsActive.Value : false;
            drpDownDisplayorder.SelectedValue = MenuModel.DisplayOrderId.ToString();
            if (MenuModel.ParentMenuId.HasValue) drpDownParentMenu.SelectedValue = MenuModel.ParentMenuId.Value.ToString();

            if (IsEditMode.HasValue && IsEditMode.Value)
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
        }

        private void SaveMenu()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;            

                if (!IsMenuHierarchyOK()) return;
                BuildMenuRequest();
                isCreated = MenuController.Save(MenuModel);

                if (isCreated)
                {
                    lblStatus.Text = "Menu saved successfully";
                    ClearForm();
                }
                else
                {
                    lblStatus.Text = "Failed to save menu ";
                   
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save menu";
            }
        }

        private bool IsMenuHierarchyOK()
        {
             if ( drpDownParentMenu.SelectedValue == "0"  ) return true;

             if (MenuModel.Id == int.Parse(drpDownParentMenu.SelectedValue))
             {
                lblStatus.Text = "Menu cannot be same as assigned as it's own parent menu";
                 return false;
             }

             return true;
        }

        private void ClearForm()
        {
            txtMenuName.Text = string.Empty;
            drpDownDisplayorder.SelectedValue = "1";
            drpDownParentMenu.SelectedValue = "0";
            chkIsActive.Checked = false;
        }

        private void BuildMenuRequest()
        {
            MenuModel.MenuName = txtMenuName.Text;
            MenuModel.IsActive = chkIsActive.Checked;
            MenuModel.DisplayOrderId = int.Parse(drpDownDisplayorder.SelectedValue);
           
            if ( drpDownParentMenu.SelectedValue == "0"  )  MenuModel.ParentMenuId = null;           
            else  MenuModel.ParentMenuId = int.Parse(drpDownParentMenu.SelectedValue);
        }

        private void GetMenuModel()
        {
            if (MenuToBeEdited > 0) MenuModel = MenuController.GetMenuById(MenuToBeEdited);
            else MenuModel = new MenuDataContract();
        }

        protected void btnCancel_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageMenus); }  

        private Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        private int MenuToBeEdited
        {
            get { return GetPropertyValue<int>("MenuToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("MenuToBeEdited", value); }
        }

        private MenuDataContract MenuModel
        {
            get { return GetPropertyValue<MenuDataContract>("MenuModel", null); }
            set { SetPropertyValue<MenuDataContract>("MenuModel", value); }
        }

        protected void btnUpdate_Click(object sender, EventArgs e) { SaveMenu(); }        
    }
}