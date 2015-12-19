using Common.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;
using Techkriti.Common.Controllers.News;

namespace TechKriti.CMS.Client.Views.News
{
    public partial class ManageNews : BasePage
    {
        public const string EditCommandName = "EditNews";
        public const string DeleteCommandName = "DeleteNews";

        public override Permissions RequiredActionPermission { get { return Permissions.ManageNews; } }      

        protected void Page_Load(object sender, EventArgs e) 
        {
            lblStatus.Visible = false;
            if (!Page.IsPostBack) 
            {
                linkAddNews.NavigateUrl = Pages.AddNews;
                RefreshNews(0);  
            }           
        }

        private void RefreshNews(int startIndex)
        {
            try
            {
                int totalNumberOfRecords = 0;

                this.gridNews.DataSource = NewsController.SearchNews(txtSearchDescription.Text, Helper.ConvertStringToDate(txtSearchDate.Text),
                                                                     startIndex, PageSize, chkSearchIsActive.Checked,out totalNumberOfRecords);

                this.gridNews.VirtualItemCount = totalNumberOfRecords;
                this.lblTotalNumberOfRecords.Text = "Total records: " + totalNumberOfRecords;
                this.gridNews.DataBind();
                
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to get news";
                lblStatus.Visible = true;
            }
        }

        protected void gridNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int newsId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == EditCommandName)
            {
                // string newsId = e.CommandArgument.ToString();
                 Response.Redirect("~/Web/Views/News/AddNews.aspx?newsId=" + newsId);
            }
            else if (e.CommandName == DeleteCommandName)
            {
              
                DeleteNews(newsId);
            }         
        }      

        private void DeleteNews(int newsId)
        {
            try
            {
                lblStatus.Visible = true;
                bool isDeleted = NewsController.DeleteNews(newsId);

                if (isDeleted)
                {
                    RefreshNews(0);
                    lblStatus.Text = "News deleted successfully";                   
                }
                else lblStatus.Text = "Failed to delete news";
            }

            catch (Exception ex)
            {
                lblStatus.Text = "Failed to delete news";
            }
        }       

        protected void gridNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int startIndex = e.NewPageIndex * PageSize;
            this.gridNews.PageIndex = e.NewPageIndex;

            RefreshNews(startIndex);
        }

        protected void btnNewsSearch_Click(object sender, EventArgs e) { RefreshNews(0); }

        private int PageSize { get { return this.gridNews.PageSize; } }
    }
}