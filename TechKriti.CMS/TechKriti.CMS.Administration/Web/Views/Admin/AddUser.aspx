<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.Admin.AddUser" MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddUserView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
       <asp:Panel ID="pnlAddEditUser" runat="server"  align="center">  
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
                                        <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqValtxtUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter username" ></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                              <tr>
                                    <td>
                                        <asp:Label ID="lblPassword" runat="server" Text="Password"  ></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqValtxtPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter password" ></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>                                
                                        <td style="width:25%">
                                            <asp:Label ID="lblRole" runat="server" Text="Choose role"></asp:Label>
                                        </td>
                                        <td>                                   
                                            <asp:DropDownList ID="drpRoles" runat="server" Width="200px" ></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqValRoles" runat="server" InitialValue="0" ControlToValidate="drpRoles" 
                                                                        ErrorMessage="Select role"></asp:RequiredFieldValidator>                                    
                                        </td>
                                    </tr> 
                                <tr>
                                    <td></td>
                                    <td>
                                         <techKriti:ButtonControl ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" RequiredActionPermission="AddUser" ></techKriti:ButtonControl> 
                                         <techKriti:ButtonControl ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" OnClientClick="disablePasswordValidator()"
                                          RequiredActionPermission="UpdateUser" ></techKriti:ButtonControl>                                     
                                         <asp:Button ID="btnCancel" Text="Cancel" runat="server"  CausesValidation="false"  OnClick="btnCancel_Click"></asp:Button>  
                                    </td>
                                </tr>
                          </table>
                     </td>
                 </tr>
         </table>
       </asp:Panel>  
</asp:Content>  