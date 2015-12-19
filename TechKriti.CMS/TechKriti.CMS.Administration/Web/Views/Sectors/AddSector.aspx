<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSector.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Sectors.AddSector"
      MasterPageFile="~/Web/Shared/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddSectorView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddSector" runat="server" align="center">
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
                        <table border="0" style="border: dashed;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblSection" runat="server" Text="Section"></asp:Label>
                                </td>
                                <td>
                                   <asp:DropDownList ID="drpDownSections" runat="server">
                                       <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                       <asp:ListItem Value="1" Text="Section 1"></asp:ListItem>
                                       <asp:ListItem Value="2" Text="Section 2"></asp:ListItem>
                                       <asp:ListItem Value="3" Text="Section 3"></asp:ListItem>
                                       <asp:ListItem Value="4" Text="Section 4"></asp:ListItem>
                                   </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqValSectionId" runat="server" ControlToValidate="drpDownSections" ErrorMessage="Select section">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>                           
                            <tr>
                                <td>
                                    <asp:Label ID="lblDisplayName" runat="server" Text="Display Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDisplayName" runat="server"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="reqValDisplayName" runat="server" ControlToValidate="txtDisplayName" ErrorMessage="Please enter display name">
                                    </asp:RequiredFieldValidator>
                                </td>
                                </tr>
                            <tr>                               
                                <td>
                                    <asp:Label ID="lblPath" runat="server" Text="Path"></asp:Label>
                                </td>
                                 <td>
                                    <asp:TextBox ID="txtPath" runat="server"></asp:TextBox>  
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPath" ErrorMessage="Please enter path">
                                    </asp:RequiredFieldValidator>                                                   
                                </td>
                                </tr>
                            <tr>
                                <td style="width:20px;">&nbsp;</td>
                                <td>
                                    <techKriti:ButtonControl ID="btnSave" runat="server" Text="Save" onClick="btnSave_Click" RequiredActionPermission="AddSector" />
                                    <techKriti:ButtonControl ID="btnUpdate" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateSector" />
                                    <asp:Button ID="btnClear" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>  
                                </td>
                            </tr>
                        </table>
                    </td>
                 </tr>
        </table>
    </asp:Panel>
</asp:Content>