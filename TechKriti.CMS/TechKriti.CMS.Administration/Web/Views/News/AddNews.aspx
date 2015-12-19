<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="TechKriti.CMS.Client.Views.News.AddNews" MasterPageFile="~/Web/Shared/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentEditView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
     <asp:Panel ID="pnlAddEditNews" runat="server"  align="center">  
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
                                    <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="10" Columns="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtUsername" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please enter news description" ></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1"  runat="server" TargetControlID="txtDate"  PopupButtonID="Image1"></ajaxToolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="reqValtxtDate" runat="server" ControlToValidate="txtDate" ErrorMessage="Please select date"></asp:RequiredFieldValidator>
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
                                     <techKriti:ButtonControl ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" RequiredActionPermission="AddNews" ></techKriti:ButtonControl>
                                     <techKriti:ButtonControl ID="btnUpdate" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateNews" ></techKriti:ButtonControl>
                                     <asp:Button ID="btnClear" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>  
                                </td>
                            </tr>
                      </table>
                 </td>
             </tr>
         </table>
     </asp:Panel>  
</asp:Content>

