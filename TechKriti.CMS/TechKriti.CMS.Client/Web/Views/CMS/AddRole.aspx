<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.Admin.AddRole" 
     MasterPageFile="~/Web/Shared/Site.Master" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddRoleView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <asp:Panel ID="pnlAddRole" runat="server" align="center">
            <table style="width:100%;" border="0">
                <tr>                               
                     <td>
                            <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>                           
                     </td>
               </tr>
               <tr>                    
                     <td>
                        <table border="0" style="border: dashed;">                            
                            <tr>
                                <td>
                                    <asp:Label ID="lblRoleName" runat="server" Text="Role:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="reqValRoleName" runat="server" ControlToValidate="txtRoleName" ErrorMessage="Please enter role name">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server" Text="Description:"  ></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="9" Columns="10" ></asp:TextBox>
                                </td>                               
                             </tr>                            
                            <tr>
                                <td>
                                    <asp:Label ID="lblChoosePermissions" Text="Choose permisions:" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <table border="0" >
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblRolesPermissions" runat="server" Text="Roles"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManageRoles" runat="server" Text="Manage Roles" />
                                                <asp:CheckBox ID="chkAddRole" runat="server" Text="Add role" />
                                                <asp:CheckBox ID="chkUpdateRole" runat="server" Text="Update role" />
                                                <asp:CheckBox ID="chkDeleteRole" runat="server" Text="Delete role" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblUserPermissions" runat="server" Text="Users"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManageUsers" runat="server" Text="Manage users" />
                                                <asp:CheckBox ID="chkAddUser" runat="server" Text="Add user" />
                                                <asp:CheckBox ID="chkUpdateUser" runat="server" Text="Update user" />
                                                <asp:CheckBox ID="chkDeleteUser" runat="server" Text="Delete user" />
                                            </td>
                                        </tr>
                                         <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblNewsPermissions" runat="server" Text="News"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManageNews" runat="server" Text="Manage news" />
                                                <asp:CheckBox ID="chkAddNews" runat="server" Text="Add news" />
                                                <asp:CheckBox ID="chkUpdateNews" runat="server" Text="Update news" />
                                                <asp:CheckBox ID="chkDeleteNews" runat="server" Text="Delete news" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblPhotoGalleryPermissions" runat="server" Text="Photo Gallery"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManagePhotoGallery" runat="server" Text="Manage Photo gallery" />
                                                <asp:CheckBox ID="chkAddPhotoGallery" runat="server" Text="Add Photo gallery" />
                                                <asp:CheckBox ID="chkUpdatePhotoGallery" runat="server" Text="Update Photo gallery" />
                                                <asp:CheckBox ID="chkDeletePhotoGallery" runat="server" Text="Delete Photo gallery" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblTestimonialsPermissions" runat="server" Text="Testimonials"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManageTestimonial" runat="server" Text="Manage Testimonials" />
                                                <asp:CheckBox ID="chkAddTestimonial" runat="server" Text="Add Testimonial" />
                                                <asp:CheckBox ID="chkUpdateTestimonial" runat="server" Text="Update Testimonial" />
                                                <asp:CheckBox ID="chkDeleteTestimonial" runat="server" Text="Delete Testimonial" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblDownloadsPermissions" runat="server" Text="Downloads"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManageDownloads" runat="server" Text="Manage Downloads" />
                                                <asp:CheckBox ID="chkAddDownload" runat="server" Text="Add Download" />
                                                <asp:CheckBox ID="chkUpdateDownload" runat="server" Text="Update Download" />
                                                <asp:CheckBox ID="chkDeleteDownload" runat="server" Text="Delete Download" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblSectorsPermissions" runat="server" Text="Sectors"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManageSectors" runat="server" Text="Manage Sectors" />
                                                <asp:CheckBox ID="chkAddSector" runat="server" Text="Add Sector" />
                                                <asp:CheckBox ID="chkUpdateSector" runat="server" Text="Update Sector" />
                                                <asp:CheckBox ID="chkDeleteSector" runat="server" Text="Delete Sector" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblQualificationsPermissions" runat="server" Text="Qualifications"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManageQualifications" runat="server" Text="Manage Qualifications" />
                                                <asp:CheckBox ID="chkAddQualification" runat="server" Text="Add Qualification" />
                                                <asp:CheckBox ID="chkUpdateQualification" runat="server" Text="Update Qualification" />
                                                <asp:CheckBox ID="chkDeleteQualification" runat="server" Text="Delete Qualification" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblCurrentOpeningsPermissions" runat="server" Text="Current Openings"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManageCurrentOpenings" runat="server" Text="Manage Current openings" />
                                                <asp:CheckBox ID="chkAddCurrentOpening" runat="server" Text="Add Current Opening" />
                                                <asp:CheckBox ID="chkUpdateCurrentOpening" runat="server" Text="Update Current Opening" />
                                                <asp:CheckBox ID="chkDeleteCurrentOpening" runat="server" Text="Delete Current Opening" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblMenuPermissions" runat="server" Text="Menus"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManageMenus" runat="server" Text="Manage menus" />
                                                <asp:CheckBox ID="chkAddMenu" runat="server" Text="Add menu" />
                                                <asp:CheckBox ID="chkUpdateMenu" runat="server" Text="Update menu" />
                                                <asp:CheckBox ID="chkDeleteMenu" runat="server" Text="Delete menu" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblPagesPermissions" runat="server" Text="Pages"  ></asp:Label><br />
                                                <hr />
                                                 <asp:CheckBox ID="chkManagePages" runat="server" Text="Manage pages" />
                                                <asp:CheckBox ID="chkAddPage" runat="server" Text="Add page" />
                                                <asp:CheckBox ID="chkUpdatePage" runat="server" Text="Update page" />
                                                <asp:CheckBox ID="chkDeletePage" runat="server" Text="Delete page" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <techKriti:ButtonControl ID="btnSave" runat="server" Text="Save" RequiredActionPermission="AddRole" OnClick="btnSave_Click" ></techKriti:ButtonControl>
                                    <techKriti:ButtonControl ID="btnUpdate" runat="server" Text="Update" RequiredActionPermission="UpdateRole" OnClick="btnSave_Click" ></techKriti:ButtonControl>
                                    <techKriti:ButtonControl ID="btnCancel" runat="server" Text="Cancel" RequiredActionPermission="None" OnClick="btnClear_Click" CausesValidation="false"  ></techKriti:ButtonControl>
                                </td>                               
                            </tr>
                        </table>
                     </td>
                </tr>
            </table>
        </asp:Panel>
</asp:Content>  