using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.UserManagement;
using Datacontracts.UserManagement;
using Techkriti.Common.Controllers.Admin;
using Techkriti.Common.Encryption;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;

namespace TechKriti.CMS.Administration.Web.Views.Admin
{
    public partial class AddUser : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddUser; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateUserId  = Request.Params["userId"];

                if (!string.IsNullOrEmpty(candidateUserId))
                {
                    int result;
                    if (int.TryParse(candidateUserId, out result))
                    {
                        UserToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetUserModel();
                GetUserRoles();
                BuildView();               
            }
        }

        private void GetUserRoles()
        {
            try
            {
                List<RoleDataContract> source = new List<RoleDataContract>();
                source.Add(new RoleDataContract { Id = 0, RoleName = "Select" });

                drpRoles.DataTextField = "RoleName";
                drpRoles.DataValueField = "Id";
                source.AddRange(RolesController.GetAllRoles());

                drpRoles.DataSource = source;
                drpRoles.DataBind();
            }
            catch (Exception e)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load user roles";
            }
        }

        private void BuildView()
        {
            txtUsername.Text = UserModel.Username;            
            drpRoles.SelectedValue = UserModel.RoleId.ToString();

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

        private void GetUserModel()
        {
            if (UserToBeEdited > 0) UserModel = UsersController.GetUserById(UserToBeEdited);
            else UserModel = new UserTypeDataContract();
        }

        protected void btnSave_Click(object sender, EventArgs e) { SaveUser(); }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageRoles); }

        private void SaveUser()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;
                string errorMessage = string.Empty;

                BuildUserRequest();
                isCreated = UsersController.SaveUser(UserModel, out errorMessage);

                if (isCreated)
                {
                    lblStatus.Text = "User saved successfully";
                }
                else
                {
                    lblStatus.Text = "Failed to save user " + errorMessage;
                    ClearForm();
                }               
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save user";
            }
        }

        private void BuildUserRequest()
        {
            UserModel.Username = txtUsername.Text.Trim();
            UserModel.Password = string.IsNullOrEmpty( txtPassword.Text ) ? string.Empty : ComputeMD5.MD5( txtUsername.Text );
            UserModel.RoleId = int.Parse(drpRoles.SelectedValue);           
        }

        private void ClearForm()
        {
            txtUsername.Text = string.Empty;
            drpRoles.SelectedValue = "0";
        }

        protected void btnCancel_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageUsers); }  

        private Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        private int UserToBeEdited
        {
            get { return GetPropertyValue<int>("UserToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("UserToBeEdited", value); }
        }

        private UserTypeDataContract UserModel
        {
            get { return GetPropertyValue<UserTypeDataContract>("UserModel", null); }
            set { SetPropertyValue<UserTypeDataContract>("UserModel", value); }
        }

        protected void btnUpdate_Click(object sender, EventArgs e) { SaveUser(); }
    }
}