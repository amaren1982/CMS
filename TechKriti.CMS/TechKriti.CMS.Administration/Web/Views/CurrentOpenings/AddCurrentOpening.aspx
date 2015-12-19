<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCurrentOpening.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.CurrentOpenings.AddCurrentOpening"
    MasterPageFile="~/Web/Shared/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentEditView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
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
                                    <asp:Label ID="lblCompany" runat="server" Text="Company"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompany" runat="server" TextMode="MultiLine" Rows="6" Columns="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtCompany" runat="server" ControlToValidate="txtCompany" ErrorMessage="Please enter company" ></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPosition" runat="server" Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPosition" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtPosition" runat="server" ControlToValidate="txtPosition" ErrorMessage="Please enter position" ></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblQualification" runat="server" Text="Qualification"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQualification" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValQualification" runat="server" ControlToValidate="txtQualification" ErrorMessage="Please enter qualification" ></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSkillSet" runat="server" Text="SkillSet"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSkillSet" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtSkillSet" runat="server" ControlToValidate="txtSkillSet" ErrorMessage="Please enter skill set" ></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                          <tr>
                                <td>
                                    <asp:Label ID="lblEmailPhone" runat="server" Text="Email/Phone"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmailPhone" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtEmailPhone" runat="server" ControlToValidate="txtEmailPhone" ErrorMessage="Please enter email/phone" ></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lblOpenTillDate" runat="server" Text="Open till date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOpenTillDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1"  runat="server" TargetControlID="txtOpenTillDate"  PopupButtonID="Image1"></ajaxToolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="reqValOpenTillDate" runat="server" ControlToValidate="txtOpenTillDate" ErrorMessage="Please select date"></asp:RequiredFieldValidator>
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
                                     <techKriti:ButtonControl ID="btnSave" Text="Save" runat="server" Visible="false" OnClick="btnSave_Click" RequiredActionPermission="AddCurrentOpening" />
                                     <techKriti:ButtonControl ID="btnUpdate" Text="Update" runat="server" Visible="false" OnClick="btnSave_Click" RequiredActionPermission="UpdateCurrentOpening" />
                                     <asp:Button ID="btnClear" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>                                      
                                </td>
                            </tr>
                      </table>
                 </td>
             </tr>
         </table>
     </asp:Panel>
</asp:Content>
