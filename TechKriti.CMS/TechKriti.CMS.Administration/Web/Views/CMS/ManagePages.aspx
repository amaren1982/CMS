<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePages.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.CMS.ManagePages" MasterPageFile="~/Web/Shared/Site.Master" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentManageMenuView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
         <asp:UpdatePanel ID="uptPanelManageMenus" runat="server">
             <ContentTemplate>
                  <table border="0" style="vertical-align:top;width:100%;" >
                        <tr>
                            <td></td>
                              <td style="vertical-align:top;"> 
                                    <techKriti:HyperlinkControl ID="linkAddPage" runat="server" Text="Add" RequiredActionPermission="AddPage" />
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
                                                    <asp:Label ID="lblMenuName" runat="server" Text="Menu name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMenuName" runat="server"></asp:TextBox>
                                                </td>
                                              <td>
                                                    <asp:Label ID="lblPageStatus" runat="server" Text="Status"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:DropDownList ID="drpDownStatus" runat="server" Width="200px">
                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Draft"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Publish"></asp:ListItem>                                    
                                                     </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnPageSearch_Click" />
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
                                                 <asp:GridView ID="gridPages" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnRowCommand="gridPages_RowCommand"
                                                     AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridPages_PageIndexChanging"  >
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Page Title" DataField="Title" ItemStyle-Width="300px" />
                                                        <asp:TemplateField HeaderText="Action" >
                                                        <ItemTemplate>
                                                             <techKriti:ButtonControl ID="btnEditMenu" runat="server" CommandName='<%# TechKriti.CMS.Administration.Web.Views.CMS.ManagePages.EditCommandName  %>' 
                                                                RequiredActionPermission="UpdatePage" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                                             <techKriti:ButtonControl ID="btnDeleteMenu" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Administration.Web.Views.CMS.ManagePages.DeleteCommandName  %>' 
                                                                 RequiredActionPermission="DeletePage"  CommandArgument='<%# Eval("Id") %>'  OnClientClick="return confirm('Are you sure you want to delete?')" />
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
