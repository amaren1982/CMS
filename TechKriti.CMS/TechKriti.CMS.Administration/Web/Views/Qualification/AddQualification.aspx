<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQualification.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Qualification.AddQualification"
     MasterPageFile="~/Web/Shared/Site.Master"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddSectorView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddSector" runat="server" align="center">
        <table style="width:100%;" border="0">
             <tr>
                   <td style="height:10px;" >&nbsp;</td>
             </tr>
             <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>                           
                    </td>
             </tr>
             <tr>
                    <td style="width:90%">                      
                        <table border="0" style="border: dashed;width:100%">
                             <asp:Panel ID="pnlCategories" runat="server">
                                <tr>                                
                                    <td style="width:25%">
                                        <asp:Label ID="lblCategory" runat="server" Text="Choose Category"></asp:Label>
                                    </td>
                                    <td>                                   
                                        <asp:DropDownList ID="drpDownCategories" runat="server" Width="200px" AutoPostBack="true"  OnSelectedIndexChanged="drpDownCategories_SelectedIndexChanged">
                                            <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqValCategory" runat="server" InitialValue="0" ControlToValidate="drpDownCategories" ErrorMessage="Select category">
                                        </asp:RequiredFieldValidator>                                    
                                    </td>
                                </tr> 
                                </asp:Panel>  
                            <tr>
                                <td style="width:25%">
                                    <asp:Label ID="lblSubCategory" runat="server" Text="Choose Sub Category"></asp:Label>
                                </td>
                                <td>
                                   <asp:DropDownList ID="drpDownSubCategory" runat="server" Enabled="false" Width="200px">
                                       <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                   </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpDownSubCategory" 
                                        InitialValue="0" ErrorMessage="Select sub category">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>  
                            <tr>                               
                                <td>
                                    <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                                </td>
                                 <td>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="10" Columns="30" ></asp:TextBox>  
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please enter Description">
                                    </asp:RequiredFieldValidator>                                                   
                                </td>
                            </tr>                           
                            <tr>
                                <td style="width:20px;">&nbsp;</td>
                                <td>
                                    <techKriti:ButtonControl ID="btnSave" runat="server" Text="Save" onClick="btnSave_Click" RequiredActionPermission="AddQualification" />
                                    <techKriti:ButtonControl ID="btnUpdate" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateQualification" />                                  
                                    <asp:Button ID="btnClear" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>  
                                </td>
                            </tr>
                        </table>
                    </td>
                 </tr>
        </table>
    </asp:Panel>
</asp:Content>


