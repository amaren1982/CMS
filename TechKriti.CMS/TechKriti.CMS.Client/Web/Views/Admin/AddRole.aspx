<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.Admin.AddRole"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddRoleView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddRole" runat="server">
        <h1 class="page-header">Add Roles</h1>
        <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">

            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblRoleName" runat="server" Text="Role"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtRoleName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValRoleName" Display="Dynamic" SetFocusOnError="True" CssClass="alert alert-danger"
                        runat="server" ControlToValidate="txtRoleName" ErrorMessage="Please enter role name"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblDescription" runat="server" Text="Description"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" SetFocusOnError="True" CssClass="alert alert-danger"
                        runat="server" ControlToValidate="txtRoleName" ErrorMessage="Please enter role name"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Choose permisions:</h3>
                </div>
                <div class="panel-body">
                    <p>Please pick a permission you want to assign for this role.</p>
                </div>
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Roles</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManageRoles" runat="server" Text="Manage Roles" />
                                <asp:CheckBox ID="chkAddRole" runat="server" Text="Add role" />
                                <asp:CheckBox ID="chkUpdateRole" runat="server" Text="Update role" />
                                <asp:CheckBox ID="chkDeleteRole" runat="server" Text="Delete role" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Users</div>
                            <div class="col-sm-10 ">
                                <asp:CheckBox ID="chkManageUsers" runat="server" Text="Manage users" />
                                <asp:CheckBox ID="chkAddUser" runat="server" Text="Add user" />
                                <asp:CheckBox ID="chkUpdateUser" runat="server" Text="Update user" />
                                <asp:CheckBox ID="chkDeleteUser" runat="server" Text="Delete user" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2  control-label">News</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManageNews" runat="server" Text="Manage news" />
                                <asp:CheckBox ID="chkAddNews" runat="server" Text="Add news" />
                                <asp:CheckBox ID="chkUpdateNews" runat="server" Text="Update news" />
                                <asp:CheckBox ID="chkDeleteNews" runat="server" Text="Delete news" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Photo Gallery</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManagePhotoGallery" runat="server" Text="Manage Photo gallery" />
                                <asp:CheckBox ID="chkAddPhotoGallery" runat="server" Text="Add Photo gallery" />
                                <asp:CheckBox ID="chkUpdatePhotoGallery" runat="server" Text="Update Photo gallery" />
                                <asp:CheckBox ID="chkDeletePhotoGallery" runat="server" Text="Delete Photo gallery" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Testimonials</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManageTestimonial" runat="server" Text="Manage Testimonials" />
                                <asp:CheckBox ID="chkAddTestimonial" runat="server" Text="Add Testimonial" />
                                <asp:CheckBox ID="chkUpdateTestimonial" runat="server" Text="Update Testimonial" />
                                <asp:CheckBox ID="chkDeleteTestimonial" runat="server" Text="Delete Testimonial" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Downloads</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManageDownloads" runat="server" Text="Manage Downloads" />
                                <asp:CheckBox ID="chkAddDownload" runat="server" Text="Add Download" />
                                <asp:CheckBox ID="chkUpdateDownload" runat="server" Text="Update Download" />
                                <asp:CheckBox ID="chkDeleteDownload" runat="server" Text="Delete Download" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Sectors</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManageSectors" runat="server" Text="Manage Sectors" />
                                <asp:CheckBox ID="chkAddSector" runat="server" Text="Add Sector" />
                                <asp:CheckBox ID="chkUpdateSector" runat="server" Text="Update Sector" />
                                <asp:CheckBox ID="chkDeleteSector" runat="server" Text="Delete Sector" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Qualifications</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManageQualifications" runat="server" Text="Manage Qualifications" />
                                <asp:CheckBox ID="chkAddQualification" runat="server" Text="Add Qualification" />
                                <asp:CheckBox ID="chkUpdateQualification" runat="server" Text="Update Qualification" />
                                <asp:CheckBox ID="chkDeleteQualification" runat="server" Text="Delete Qualification" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Current Openings</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManageCurrentOpenings" runat="server" Text="Manage Current openings" />
                                <asp:CheckBox ID="chkAddCurrentOpening" runat="server" Text="Add Current Opening" />
                                <asp:CheckBox ID="chkUpdateCurrentOpening" runat="server" Text="Update Current Opening" />
                                <asp:CheckBox ID="chkDeleteCurrentOpening" runat="server" Text="Delete Current Opening" />
                                 <!-- New addition -->
                                <br />
                                <asp:CheckBox ID="chkManageCategories" runat="server" Text="Manage Categories" />
                                <asp:CheckBox ID="chkAddCategory" runat="server" Text="Add Category" />
                                <asp:CheckBox ID="chkUpdateCategory" runat="server" Text="Update Category" />
                                <asp:CheckBox ID="chkDeleteCategory" runat="server" Text="Delete Category" />
                                <br />
                                <asp:CheckBox ID="chkManageSubCategories" runat="server" Text="Manage Sub Categories" />
                                <asp:CheckBox ID="chkAddSubCategory" runat="server" Text="Add Sub Category" />
                                <asp:CheckBox ID="chkUpdateSubCategory" runat="server" Text="Update Sub Category" />
                                <asp:CheckBox ID="chkDeleteSubCategory" runat="server" Text="Delete Sub Category" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Manage Menu</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManageMenus" runat="server" Text=" menus" />
                                <asp:CheckBox ID="chkAddMenu" runat="server" Text="Add menu" />
                                <asp:CheckBox ID="chkUpdateMenu" runat="server" Text="Update menu" />
                                <asp:CheckBox ID="chkDeleteMenu" runat="server" Text="Delete menu" />
                            </div>
                        </div>
                    </li>

                    <li class="list-group-item">
                        <div class="form-group">
                            <div class="col-sm-2 control-label">Manage Pages</div>
                            <div class="col-sm-10">
                                <asp:CheckBox ID="chkManagePages" runat="server" Text="Manage pages" />
                                <asp:CheckBox ID="chkAddPage" runat="server" Text="Add page" />
                                <asp:CheckBox ID="chkUpdatePage" runat="server" Text="Update page" />
                                <asp:CheckBox ID="chkDeletePage" runat="server" Text="Delete page" />
                            </div>
                        </div>
                    </li>

                </ul>
            </div>


            <div class="form-group">
                <div class="col-sm-3 control-label">&nbsp;</div>
                <div class="col-sm-3">
                    <techKriti:ButtonControl ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" RequiredActionPermission="AddRole" OnClick="btnSave_Click"></techKriti:ButtonControl>
                    <techKriti:ButtonControl ID="btnUpdate" CssClass="btn btn-primary" runat="server" Text="Update" RequiredActionPermission="UpdateRole" OnClick="btnSave_Click"></techKriti:ButtonControl>
                    <techKriti:ButtonControl ID="btnCancel" CssClass="btn btn-warning" runat="server" Text="Cancel" RequiredActionPermission="None" OnClick="btnClear_Click" CausesValidation="false"></techKriti:ButtonControl>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-12 control-label">&nbsp;</div>
            </div>
        </div>

    </asp:Panel>
</asp:Content>
