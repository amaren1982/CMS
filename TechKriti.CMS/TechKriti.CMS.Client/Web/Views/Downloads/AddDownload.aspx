<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDownload.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Downloads.AddDownload" MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="contentAddSectorView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddSector" runat="server">
        <h1 class="page-header">Add Downloads</h1>
        <asp:Label ID="lblStatus" Style="display: table;" CssClass="alert alert-success" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="lblSection" CssClass="col-sm-2 control-label" runat="server" Text="Section"></asp:Label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="drpDownSections" CssClass="form-control" runat="server">                       
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqValSectionId" CssClass="alert alert-error" runat="server" ControlToValidate="drpDownSections" ErrorMessage="Select section">
                    </asp:RequiredFieldValidator>
                    <asp:LinkButton ID="lbnAddSection" runat="server" Text="Add Section" Font-Names="Calibri"></asp:LinkButton>
                </div>
                <asp:Label ID="lblDisplayName" CssClass="col-sm-2 control-label" runat="server" Text="Display Name"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtDisplayName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValDisplayName" CssClass="alert alert-error" runat="server" ControlToValidate="txtDisplayName" ErrorMessage="Please enter display name">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblUpload" runat="server" Text="Upload"></asp:Label>
                <div class="col-sm-3">
                    <asp:FileUpload ID="uploadGallery" CssClass="form-control" runat="server" AllowMultiple="true" />
                    <asp:Label ID="lblUploadInfo" CssClass="form-control-static small_txt" runat="server" Text="(Select multiple files to upload. Please upload pdf only)"></asp:Label>
                </div>
                <div class="col-sm-2 control-label">Status</div>
                <div class="col-sm-2">
                    <asp:CheckBox ID="chkIsActive" CssClass="form-control checkbox" Text="Is Active" runat="server" />
                </div>
                <div class="col-sm-3">&nbsp;</div>
            </div>
            <div class="form-group">
                <div class="col-sm-2 control-label">&nbsp;</div>
                <div class="col-sm-8">
                    <techKriti:ButtonControl ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" RequiredActionPermission="AddDownload" />
                    <techKriti:ButtonControl ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" RequiredActionPermission="DeleteDownload" />
                    <asp:Button ID="btnClear" Text="Cancel" CssClass="btn btn-warning" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>
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
                                <asp:HyperLink ID="lnkPdf" Text="Attachment" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "AttachmentPath") %>'></asp:HyperLink>
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
