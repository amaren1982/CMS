using Common.UserManagement;
using Datacontracts.NewsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechKriti.CMS.Client.Web.Shared;
using Techkriti.Common.Utilities;
using Techkriti.Common.Controllers.News;

namespace TechKriti.CMS.Client.Views.News
{
    public partial class AddNews : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddNews; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateNewsId = Request.Params["newsId"];

                if (!string.IsNullOrEmpty(candidateNewsId))
                {
                    int result;
                    if (int.TryParse(candidateNewsId, out result))
                    {
                        NewsToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetNewsModel();
                BuildView();
            }
        }  
        
        protected void btnSave_Click(object sender, EventArgs e) { SaveNews(); }

        private void BuildView()
        {
            txtDescription.Text = NewsModel.NewsDescription;
            chkIsActive.Checked = NewsModel.IsActive.HasValue ? NewsModel.IsActive.Value : false;
            if(NewsModel.Date != null) txtDate.Text = NewsModel.Date.ToString();

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

        private void BuildNewsRequest()
        {
            NewsModel.NewsDescription = txtDescription.Text;
            NewsModel.IsActive = chkIsActive.Checked;
            NewsModel.Date = Helper.ConvertStringToDate(txtDate.Text);
        }

        private void SaveNews()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                BuildNewsRequest();
                isCreated = NewsController.SaveNews(NewsModel);

                if (isCreated) { lblStatus.Text = "News saved successfully"; }
                else lblStatus.Text = "Failed to save news";

                ClearForm();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save news";
            }
        }

        private void ClearForm()
        {
            txtDescription.Text = txtDate.Text  = string.Empty;
            chkIsActive.Checked = false;           
        }

        private void GetNewsModel() 
        {
            if (NewsToBeEdited > 0) NewsModel = NewsController.GetNewsById(NewsToBeEdited);
            else NewsModel = new NewsDataContract();
        }

        public Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        public int NewsToBeEdited
        {
            get { return GetPropertyValue<int>("NewsToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("NewsToBeEdited", value); }
        }

        public NewsDataContract NewsModel
        {
            get { return GetPropertyValue<NewsDataContract>("NewsModel", null); }
            set { SetPropertyValue<NewsDataContract>("NewsModel", value); }
        }

        protected void btnClear_Click(object sender, EventArgs e)  { Response.Redirect(Pages.ManageNews);  }        
    }
}