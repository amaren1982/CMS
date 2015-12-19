using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.ContentManagement;
using Common.UserManagement;
using Datacontracts.ContentManagement;
using Techkriti.Common.Controllers.CMS;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Wrappers;

namespace TechKriti.CMS.Administration.Web.Views.CMS
{
    public partial class AddPage : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddPage; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidatePageId = Request.Params["pageId"];

                if (!string.IsNullOrEmpty(candidatePageId))
                {
                    int result;
                    if (int.TryParse(candidatePageId, out result))
                    {
                        PageToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetPageModel();
                GetAllMenus();
                BuildView();
            }
        }

        private void GetAllMenus()
        {
            try
            {
                List<MenuDataContract> source = new List<MenuDataContract>();
                source.Add(new MenuDataContract { MenuName = "Select" });

                drpDownMenu.DataTextField = "MenuName";
                drpDownMenu.DataValueField = "Id";
                source.AddRange(MenuController.GetAllMenus());

                drpDownMenu.DataSource = source;
                drpDownMenu.DataBind();
            }
            catch (Exception e)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed to load menus";
            }
        }

        private void BuildView()
        {
            txtTitle.Text = PageModel.Title;
            drpDownMenu.SelectedValue = PageModel.MenuId.ToString();
            drpDownStatus.SelectedValue = PageModel.Status == PageStatus.Draft ? "1" : "2";
            txtContent.Text = PageModel.Content;

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

        private void SavePage()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;           

                BuildPageRequest();
                isCreated = PageController.Save(PageModel);

                if (isCreated)
                {
                    lblStatus.Text = "Page saved successfully";
                    ClearForm();
                }
                else
                {
                    lblStatus.Text = "Failed to save Page ";                   
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save page";
            }
        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            drpDownMenu.SelectedIndex = 1;
            txtContent.Text =string.Empty;
        }

        private void BuildPageRequest()
        {
            PageModel.Title = txtTitle.Text;
            PageModel.MenuId = int.Parse(drpDownMenu.SelectedValue);
            PageModel.Status = drpDownStatus.SelectedValue == "1" ? PageStatus.Draft : PageStatus.Published;
            PageModel.Content = txtContent.Text;
            PageModel.CreatedBy = SessionWrapper.LoggedInUser.Id; 
        }

        private void GetPageModel()
        {
            if (PageToBeEdited > 0) PageModel = PageController.GetPageById(PageToBeEdited);
            else PageModel = new PageDataContract();
        }

        protected void btnCancel_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManagePages); }

        protected void btnSave_Click(object sender, EventArgs e) { SavePage(); }

        private Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        private int PageToBeEdited
        {
            get { return GetPropertyValue<int>("PageToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("PageToBeEdited", value); }
        }

        private PageDataContract PageModel
        {
            get { return GetPropertyValue<PageDataContract>("PageModel", null); }
            set { SetPropertyValue<PageDataContract>("PageModel", value); }
        }

        protected void btnUpdate_Click(object sender, EventArgs e) { SavePage(); }     
    }
}