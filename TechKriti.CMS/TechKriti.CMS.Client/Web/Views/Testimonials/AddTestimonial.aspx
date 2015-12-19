<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTestimonial.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Testimonial.AddTestimonial"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddSectorView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddSector" runat="server">
        <h1 class="page-header">Add Testimonials</h1>
        <asp:Label ID="lblStatus" CssClass="alert alert-error" Style="display: table;" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblSection" runat="server" Text="Section"></asp:Label>
                <div class="col-sm-2">
                    <asp:DropDownList ID="drpDownSections" CssClass="form-control dropdown" runat="server">                      
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqValSectionId" CssClass="alert alert-error" runat="server" ControlToValidate="drpDownSections" ErrorMessage="Select section">
                    </asp:RequiredFieldValidator>
                    <asp:LinkButton ID="lbnAddSection" runat="server" Text="Add Section" Font-Names="Calibri"></asp:LinkButton>
                </div>

                <asp:Label CssClass="col-sm-2 control-label" ID="lblDisplayName" runat="server" Text="Display Name"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtDisplayName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValDisplayName" CssClass="alert alert-error" runat="server" ControlToValidate="txtDisplayName" ErrorMessage="Please enter display name">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblUpload" CssClass="col-sm-2 control-label" runat="server" Text="Upload"></asp:Label>
                <div class="col-sm-7">
                    <asp:FileUpload ID="uploadGallery" CssClass="form-control" runat="server" AllowMultiple="true" />
                    <asp:Label ID="lblUploadInfo" runat="server" CssClass="text-info" Text="(Select multiple files to upload. Please upload images only)"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2 control-label">&nbsp;</div>
                <div class="col-sm-10">
                    <techKriti:ButtonControl ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" RequiredActionPermission="AddTestimonial" />
                    <techKriti:ButtonControl ID="btnUpdate" CssClass="btn btn-primary" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateTestimonial" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>
                </div>
            </div>
        </div>
        <div class="table-responsive">
            <asp:Panel ID="pnlAttachments" runat="server" Visible="false">
                <asp:Repeater ID="repeaterAttachments" runat="server">
                    <HeaderTemplate>
                        <table border="0" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblAttachmentHeader" runat="server" Text="Attachments Uploaded"></asp:Label></td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%-- <asp:Image ID="imgAttachment" runat="server" Width="100px" Height="100px"
                                            ImageUrl='<%# DataBinder.Eval(Container.DataItem, "AttachmentPath") %>' 
                                            BorderStyle="Dotted"  />    --%>  
                                           <asp:HyperLink ID="imgAttachment" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "AttachmentPath") %>'  Text="Attachment" Target="_blank" />     
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </asp:Panel>
        </div>
    </asp:Panel>

     <ajaxtoolkit:modalpopupextender id="ModalPopupExtender" runat="server" backgroundcssclass="modalBackground"
             dropshadow="true" popupcontrolid="Panel1" popupdraghandlecontrolid="Panel3" targetcontrolid="lbnAddSection"></ajaxtoolkit:modalpopupextender>

     <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none" Width="668px">                 
                    <table style="width:80%">
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSectionName" runat="server"  Text="Section name"  CssClass="control-label" ></asp:Label>
                            </td>
                            <td>
                                   <asp:TextBox ID="txtSectionName" runat="server" ValidationGroup="section"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="reqValSectionName" CssClass="alert alert-error" runat="server" ControlToValidate="txtSectionName" 
                                      ErrorMessage="Please enter section name" ValidationGroup="section">
                                  </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="OkButton" runat="server" Text="Save" OnClick="OkButtonPopUp_Click" ValidationGroup="section" />
                                    <asp:Button ID="CancelButton" runat="server" Text="Cancel" CausesValidation="false" />
                                </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                    </table>             
         </asp:Panel>

</asp:Content>
