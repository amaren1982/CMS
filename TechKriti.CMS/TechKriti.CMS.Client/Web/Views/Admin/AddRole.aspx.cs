using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.UserManagement;
using Datacontracts.UserManagement;
using Techkriti.Common.Controllers.Admin;
using Techkriti.Common.Utilities;
using Techkriti.Common.Web.Shared;

namespace TechKriti.CMS.Administration.Web.Views.Admin
{
    public partial class AddRole : BasePage
    {
        public override Permissions RequiredActionPermission { get { return Permissions.AddRole; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string candidateRoleId = Request.Params["roleId"];

                if (!string.IsNullOrEmpty(candidateRoleId))
                {
                    int result;
                    if (int.TryParse(candidateRoleId, out result))
                    {
                        RoleToBeEdited = result;
                        IsEditMode = true;
                    }
                }

                GetRoleModel();
                BuildView();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) { SaveRole(); }

        protected void btnClear_Click(object sender, EventArgs e) { Response.Redirect(Pages.ManageRoles); }  

        private void BuildView()
        {
            txtDescription.Text = RoleModel.Description;
            txtRoleName.Text = RoleModel.RoleName;

            if (RoleModel.Permissions != null && RoleModel.Permissions.Any())
            {
                //Set roles permissions
                if (RoleModel.Permissions.Any(item=> item == Permissions.ManageRoles) ) chkManageRoles.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddRole)) chkAddRole.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateRole)) chkUpdateRole.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteRole)) chkDeleteRole.Checked = true;

                //Set users permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManageUsers)) chkManageUsers.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddUser)) chkAddUser.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateUser)) chkUpdateUser.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteUser)) chkDeleteUser.Checked = true;
             
                //Set news permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManageNews)) chkManageNews.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddNews)) chkAddNews.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateNews)) chkUpdateNews.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteNews)) chkDeleteNews.Checked = true;

                //Set photo gallery permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManagePhotoGallery)) chkManagePhotoGallery.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddPhotoGallery)) chkAddPhotoGallery.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdatePhotoGallery)) chkUpdatePhotoGallery.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeletePhotoGallery)) chkDeletePhotoGallery.Checked = true;

                //Set testimonials permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManageTestimonials)) chkManageTestimonial.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddTestimonial)) chkAddTestimonial.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateTestimonial)) chkUpdateTestimonial.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteTestimonial)) chkDeleteTestimonial.Checked = true;

                //Set download permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManageDownloads)) chkManageDownloads.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddDownload)) chkAddDownload.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateDownload)) chkUpdateDownload.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteDownload)) chkDeleteDownload.Checked = true;

                //Set sector permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManageSectors)) chkManageSectors.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddSector)) chkAddSector.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateSector)) chkUpdateSector.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteSector)) chkDeleteSector.Checked = true;

                //Set Qualifications permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManageQualifications)) chkManageQualifications.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddQualification))     chkAddQualification.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateQualification)) chkUpdateQualification.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteQualification)) chkDeleteQualification.Checked = true;

                //Set Category permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManageCategories)) chkManageCategories.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddCategory))    chkAddCategory.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateCategory)) chkUpdateCategory.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteCategory)) chkDeleteCategory.Checked = true;

                if (RoleModel.Permissions.Any(item => item == Permissions.ManageSubCategories)) chkManageSubCategories.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddSubCategory)) chkAddSubCategory.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateSubCategory)) chkUpdateSubCategory.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteSubCategory)) chkDeleteSubCategory.Checked = true;

                //Set Current Openings permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManageCurrentOpenings)) chkManageCurrentOpenings.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddCurrentOpening)) chkAddCurrentOpening.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateCurrentOpening)) chkUpdateCurrentOpening.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteCurrentOpening)) chkDeleteCurrentOpening.Checked = true;

                //Set menu permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManageMenus)) chkManageMenus.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddMenu)) chkAddMenu.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdateMenu)) chkUpdateMenu.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeleteMenu)) chkDeleteMenu.Checked = true;

                //Set pages permissions
                if (RoleModel.Permissions.Any(item => item == Permissions.ManagePages)) chkManagePages.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.AddPage)) chkAddPage.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.UpdatePage)) chkUpdatePage.Checked = true;
                if (RoleModel.Permissions.Any(item => item == Permissions.DeletePage)) chkDeletePage.Checked = true;             
               
            }

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

        private void SaveRole()
        {
            try
            {
                bool isCreated = false;
                lblStatus.Visible = true;

                BuildRoleRequest();
                isCreated = RolesController.SaveRole(RoleModel);

                if (isCreated) { lblStatus.Text = "Role saved successfully"; }
                else lblStatus.Text = "Failed to save role";

                ClearForm();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save news";
            }
        }

        private void GetRoleModel()
        {
            if (RoleToBeEdited > 0) RoleModel = RolesController.GetRoleById(RoleToBeEdited);
            else RoleModel = new RoleDataContract();
        }

        private void BuildRoleRequest()
        {
            RoleModel.Description = txtDescription.Text;
            RoleModel.RoleName = txtRoleName.Text;

            RoleModel.Permissions = GetPermissions();
        }

        private List<Permissions> GetPermissions()
        {
            List<Permissions> candidatePermissions = new List<Permissions>();
            
            //Check for roles permissions
            if (chkManageRoles.Checked) candidatePermissions.Add(Permissions.ManageRoles);
            if (chkAddRole.Checked)    candidatePermissions.Add(Permissions.AddRole);
            if (chkUpdateRole.Checked) candidatePermissions.Add(Permissions.UpdateRole);
            if (chkDeleteRole.Checked) candidatePermissions.Add(Permissions.DeleteRole);

            //Check for users permissions
            if (chkManageUsers.Checked) candidatePermissions.Add(Permissions.ManageUsers);
            if (chkAddUser.Checked) candidatePermissions.Add(Permissions.AddUser);
            if (chkUpdateUser.Checked) candidatePermissions.Add(Permissions.UpdateUser);
            if (chkDeleteUser.Checked) candidatePermissions.Add(Permissions.DeleteUser);

            //Check for news permissions
            if (chkManageNews.Checked) candidatePermissions.Add(Permissions.ManageNews);
            if (chkAddNews.Checked) candidatePermissions.Add(Permissions.AddNews);
            if (chkUpdateNews.Checked) candidatePermissions.Add(Permissions.UpdateNews);
            if (chkDeleteNews.Checked) candidatePermissions.Add(Permissions.DeleteNews);

            //Check for photo gallery
            if (chkManagePhotoGallery.Checked) candidatePermissions.Add(Permissions.ManagePhotoGallery);
            if (chkAddPhotoGallery.Checked) candidatePermissions.Add(Permissions.AddPhotoGallery);
            if (chkUpdatePhotoGallery.Checked) candidatePermissions.Add(Permissions.UpdatePhotoGallery);
            if (chkDeletePhotoGallery.Checked) candidatePermissions.Add(Permissions.DeletePhotoGallery);

            //Check for testimonials
            if (chkManageTestimonial.Checked) candidatePermissions.Add(Permissions.ManageTestimonials);
            if (chkAddTestimonial.Checked) candidatePermissions.Add(Permissions.AddTestimonial);
            if (chkUpdateTestimonial.Checked) candidatePermissions.Add(Permissions.UpdateTestimonial);
            if (chkDeleteTestimonial.Checked) candidatePermissions.Add(Permissions.DeleteTestimonial);

            //Check for download
            if (chkManageDownloads.Checked) candidatePermissions.Add(Permissions.ManageDownloads);
            if (chkAddDownload.Checked) candidatePermissions.Add(Permissions.AddDownload);
            if (chkUpdateDownload.Checked) candidatePermissions.Add(Permissions.UpdateDownload);
            if (chkDeleteDownload.Checked) candidatePermissions.Add(Permissions.DeleteDownload);

            //Check for sector
            if (chkManageSectors.Checked) candidatePermissions.Add(Permissions.ManageSectors);
            if (chkAddSector.Checked) candidatePermissions.Add(Permissions.AddSector);
            if (chkUpdateSector.Checked) candidatePermissions.Add(Permissions.UpdateSector);
            if (chkDeleteSector.Checked) candidatePermissions.Add(Permissions.DeleteSector);

            //Check for Qualifications
            if (chkManageQualifications.Checked) candidatePermissions.Add(Permissions.ManageQualifications);
            if (chkAddQualification.Checked) candidatePermissions.Add(Permissions.AddQualification);
            if (chkUpdateQualification.Checked) candidatePermissions.Add(Permissions.UpdateQualification);
            if (chkDeleteQualification.Checked) candidatePermissions.Add(Permissions.DeleteQualification);

            //Check for Categories
            if (chkManageCategories.Checked) candidatePermissions.Add(Permissions.ManageCategories);
            if (chkAddCategory.Checked) candidatePermissions.Add(Permissions.AddCategory);
            if (chkUpdateCategory.Checked) candidatePermissions.Add(Permissions.UpdateCategory);
            if (chkDeleteCategory.Checked) candidatePermissions.Add(Permissions.DeleteCategory);

            //Check for Sub-Categories
            if (chkManageSubCategories.Checked) candidatePermissions.Add(Permissions.ManageSubCategories);
            if (chkAddSubCategory.Checked) candidatePermissions.Add(Permissions.AddSubCategory);
            if (chkUpdateSubCategory.Checked) candidatePermissions.Add(Permissions.UpdateSubCategory);
            if (chkDeleteSubCategory.Checked) candidatePermissions.Add(Permissions.DeleteSubCategory);

            //Check for Current Openings
            if (chkManageCurrentOpenings.Checked) candidatePermissions.Add(Permissions.ManageCurrentOpenings);
            if (chkAddCurrentOpening.Checked) candidatePermissions.Add(Permissions.AddCurrentOpening);
            if (chkUpdateCurrentOpening.Checked) candidatePermissions.Add(Permissions.UpdateCurrentOpening);
            if (chkDeleteCurrentOpening.Checked) candidatePermissions.Add(Permissions.DeleteCurrentOpening);

            //Check for menu
            if (chkManageMenus.Checked) candidatePermissions.Add(Permissions.ManageMenus);
            if (chkAddMenu.Checked) candidatePermissions.Add(Permissions.AddMenu);
            if (chkUpdateMenu.Checked) candidatePermissions.Add(Permissions.UpdateMenu);
            if (chkDeleteMenu.Checked) candidatePermissions.Add(Permissions.DeleteMenu);

            //Check for pages
            if (chkManagePages.Checked) candidatePermissions.Add(Permissions.ManagePages);
            if (chkAddPage.Checked) candidatePermissions.Add(Permissions.AddPage);
            if (chkUpdatePage.Checked) candidatePermissions.Add(Permissions.UpdatePage);
            if (chkDeletePage.Checked) candidatePermissions.Add(Permissions.DeletePage);


            return candidatePermissions;
        }

        private void ClearForm()
        {
            txtDescription.Text = txtRoleName.Text = string.Empty;           
        }

        private Nullable<bool> IsEditMode
        {
            get { return GetPropertyValue<Nullable<bool>>("IsEditMode", default(Nullable<bool>)); }
            set { SetPropertyValue<Nullable<bool>>("IsEditMode", value); }
        }

        private int RoleToBeEdited
        {
            get { return GetPropertyValue<int>("RoleToBeEdited", 0); }
            set { SetPropertyValue<Nullable<int>>("RoleToBeEdited", value); }
        }

        private RoleDataContract RoleModel
        {
            get { return GetPropertyValue<RoleDataContract>("RoleModel", null); }
            set { SetPropertyValue<RoleDataContract>("RoleModel", value); }
        }
    }
}