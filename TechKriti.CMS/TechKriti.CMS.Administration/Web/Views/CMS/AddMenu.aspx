<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenu.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.CMS.AddMenu" MasterPageFile="~/Web/Shared/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddMenuView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
    <asp:Panel ID="pnlAddEditMenu" runat="server"  align="center">  
         <table>
             <tr>
                   <td style="height:10px;" >&nbsp;</td>
             </tr>
             <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>                                        
                    </td>
             </tr>
             <tr>
                 <td>
                      <table style="border: dashed;" > 
                            <tr>
                                <td>
                                    <asp:Label ID="lblMenu" runat="server" Text="Menu"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMenuName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtUsername" runat="server" ControlToValidate="txtMenuName" ErrorMessage="Please enter menu name" ></asp:RequiredFieldValidator>
                                </td>
                           </tr> 
                           <tr>
                                <td>
                                    <asp:Label ID="lblParentMenu" runat="server" Text="Parent Menu"></asp:Label>
                                </td>
                                <td>
                                     <asp:DropDownList ID="drpDownParentMenu" runat="server" Width="200px">
                                          <asp:ListItem Value="" Text="Select"></asp:ListItem>                                           
                                     </asp:DropDownList>
                                </td>
                            </tr> 
                            <tr>
                                <td>
                                    <asp:Label ID="lblDisplayOrder" runat="server" Text="Display order"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpDownDisplayorder" runat="server" Width="200px">
                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                            <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                            <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                     </asp:DropDownList>
                                </td>
                            </tr> 
                           <tr>
                                <td>
                                    <asp:Label ID="lblIsActive" runat="server" Text="Is Active"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIsActive" runat="server" />
                                </td>
                            </tr>                                                      
                            <tr>
                                <td></td>
                                <td>
                                     <techKriti:ButtonControl ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click"  RequiredActionPermission="AddMenu" ></techKriti:ButtonControl>
                                     <techKriti:ButtonControl ID="btnUpdate" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateMenu" ></techKriti:ButtonControl>
                                     <asp:Button ID="btnClear" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>  
                                </td>
                            </tr>
                      </table>
                 </td>
             </tr>
         </table>
     </asp:Panel>  
</asp:Content>
