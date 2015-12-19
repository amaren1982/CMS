<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.Admin.ManageUsers" 
     MasterPageFile="~/Web/Shared/Site.Master" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddRoleView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
      <asp:UpdatePanel ID="uptPanelManageUsers" runat="server">
             <ContentTemplate>
                  <table border="0" style="vertical-align:top;width:100%;" >                      
                        <tr>
                            <td></td>
                              <td style="vertical-align:top;">                                                              
                                  <techKriti:HyperlinkControl ID="linkAddUser" Text="Add" runat="server" RequiredActionPermission="AddUser" />
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
                                                    <asp:Label ID="lblUserName" runat="server" Text="User name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnUsersSearch_Click"  />
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
                                                 <asp:GridView ID="gridUsers" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnRowCommand="gridUsers_RowCommand"
                                                 AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridUsers_PageIndexChanging"   >
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Username" DataField="Username" ItemStyle-Width="300px" />
                                                        <asp:TemplateField HeaderText="Action" >
                                                        <ItemTemplate>
                                                              <techKriti:ButtonControl ID="btnEditNews" runat="server" CommandName='<%# TechKriti.CMS.Administration.Web.Views.Admin.ManageUsers.EditCommandName  %>' 
                                                                 RequiredActionPermission="UpdateUser"   Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                                             <techKriti:ButtonControl ID="btnDeleteNews" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Administration.Web.Views.Admin.ManageUsers.DeleteCommandName  %>' 
                                                                   RequiredActionPermission="DeleteUser"  CommandArgument='<%# Eval("Id") %>'  OnClientClick="return confirm('Are you sure you want to delete?')" />
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