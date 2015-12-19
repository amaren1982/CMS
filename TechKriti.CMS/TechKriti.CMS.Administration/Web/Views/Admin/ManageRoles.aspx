<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.Admin.ManageRoles" 
     MasterPageFile="~/Web/Shared/Site.Master" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddRoleView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <asp:UpdatePanel ID="uptPanelManageRoles" runat="server">
             <ContentTemplate>
                  <table border="0" style="vertical-align:top;width:100%;" >
                        <tr>
                            <td></td>
                              <td style="vertical-align:top;"> 
                                    <techKriti:HyperlinkControl ID="linkAddRole" runat="server" Text="Add" RequiredActionPermission="AddRole"></techKriti:HyperlinkControl>                                                                                           
                              </td>
                        </tr>
                        <tr>
                             <td colspan="2">
                                   <asp:Label ID="lblStatus" runat="server" Visible="false" ></asp:Label>
                             </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                   <table border="0" style="border: dashed;">
                                         <tr>
                                                <td>
                                                    <asp:Label ID="lblRoleName" runat="server" Text="Role name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnRolesSearch_Click" />
                                                </td>
                                             </tr>
                                   </table>
                            </td>
                        <//tr>
                        <tr>
                           <td style="width:10px;">
                        </tr>
                        <tr>
                            <td>   
                            </td>
                            <td>
                                <table border="0" style="width:100%;border: dashed;">
                                    <tr>
                                         <td>
                                                 <asp:Label ID="lblTotalNumberOfRecords" runat="server" ></asp:Label>
                                                 <asp:GridView ID="gridRoles" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnRowCommand="gridRoles_RowCommand"
                                                     AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridRoles_PageIndexChanging"  >
                                                    <Columns>
                                                        <asp:BoundField HeaderText="RoleName" DataField="RoleName" ItemStyle-Width="300px" />
                                                        <asp:TemplateField HeaderText="Action" >
                                                        <ItemTemplate>
                                                             <techKriti:ButtonControl ID="btnEditUser" runat="server" CommandName='<%# TechKriti.CMS.Administration.Web.Views.Admin.ManageRoles.EditCommandName  %>' 
                                                                RequiredActionPermission="UpdateRole" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                                             <techKriti:ButtonControl ID="btnDeleteUser" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Administration.Web.Views.Admin.ManageRoles.DeleteCommandName  %>' 
                                                                 RequiredActionPermission="DeleteRole"  CommandArgument='<%# Eval("Id") %>'  OnClientClick="return confirm('Are you sure you want to delete?')" />
                                                        </ItemTemplate>                                        
                                                    </asp:TemplateField>                                    
                                                </Columns>
                                                 </asp:GridView> 
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                  </table>
             </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>