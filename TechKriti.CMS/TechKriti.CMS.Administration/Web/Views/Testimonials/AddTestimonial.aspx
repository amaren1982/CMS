<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTestimonial.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Testimonial.AddTestimonial"
      MasterPageFile="~/Web/Shared/Site.Master" %>
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
                    <td>                      
                        <table border="0" style="border: dashed;width:70%;">
                            <tr>
                                <td style="width:30%">
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
                                    <asp:Label ID="lblUpload" runat="server" Text="Upload"></asp:Label>
                                </td>
                                 <td>
                                    <asp:FileUpload ID="uploadGallery" runat="server" AllowMultiple="true" />  
                                     <asp:Label ID="lblUploadInfo" runat="server" Text="(Select multiple files to upload. Please upload images only)"  ></asp:Label>                                                                                  
                                </td>
                            </tr>                           
                            <tr>
                                <td style="width:20px;">&nbsp;</td>
                                <td>
                                    <techKriti:ButtonControl ID="btnSave" runat="server" Text="Save" onClick="btnSave_Click" RequiredActionPermission="AddTestimonial" />
                                    <techKriti:ButtonControl ID="btnUpdate" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateTestimonial" />                                    
                                    <asp:Button ID="btnClear" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>  
                                </td>
                            </tr>
                        </table>
                    </td>
                  <td>
                     <asp:Panel ID="pnlAttachments" runat="server" Visible="false" >
                        <asp:Repeater ID="repeaterAttachments" runat="server" >
                            <HeaderTemplate >
                                <table border="0" style="width:100%">
                                    <tr>
                                        <td> <asp:Label ID="lblAttachmentHeader" runat="server" Text="Attachments Uploaded"></asp:Label></td>
                                    </tr>                               
                            </HeaderTemplate>                            
                            <ItemTemplate>
                                <tr>
                                    <td>                                      
                                        <asp:Image ID="imgAttachment" runat="server" Width="100px" Height="100px"
                                            ImageUrl='<%# DataBinder.Eval(Container.DataItem, "AttachmentPath") %>' 
                                            BorderStyle="Dotted"  />                                       
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                     </asp:Panel>
                 </td>
                 </tr>
        </table>
    </asp:Panel>
</asp:Content>