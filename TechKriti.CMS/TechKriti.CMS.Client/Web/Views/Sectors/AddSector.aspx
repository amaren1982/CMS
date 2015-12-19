<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSector.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Sectors.AddSector"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddSectorView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddSector" runat="server">
        <h1 class="page-header">Add Sector</h1>
        <asp:Label ID="lblStatus" CssClass="alert alert-success" Style="display: table;" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="lblParentSector" CssClass="col-sm-2 control-label" runat="server" Text="Select parent sector"></asp:Label>

                <div class="col-sm-2">
                    <asp:DropDownList ID="drpDownParentSectors" CssClass="form-control" runat="server" Width="200px" AutoPostBack="true"
                        OnSelectedIndexChanged="drpDownParentSectors_SelectedIndexChanged">
                        <asp:ListItem Value="" Text="Select parent sector"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <asp:Label ID="lblSectorName" CssClass="col-sm-2 control-label" runat="server" Text="Sector Name"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtSectorName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValSectorName" CssClass="alert alert-error" runat="server" ControlToValidate="txtSectorName" ErrorMessage="Please enter sector name">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <asp:Panel ID="pnlUpoadAttachments" runat="server">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <%--<asp:Label ID="lblUploadAttachments" CssClass=" form-control panel-heading" runat="server" Text="Upload attachments"></asp:Label>--%>
                        <h3 class="panel-title">Upload attachments</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="col-sm-2">&nbsp;</div>
                            <div class="col-sm-10">
                                <asp:Label ID="lblAttachment1" runat="server" Text="Caption:"></asp:Label>
                                <asp:TextBox ID="txtCaptionAttachment1" runat="server"></asp:TextBox>
                                <asp:FileUpload ID="uploadSectorAttachment1" runat="server" />
                                <asp:Image ID="imgAttachment1" runat="server" Width="100px" Height="100px" BorderStyle="Dotted" Visible="false" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-2">&nbsp;</div>
                            <div class="col-sm-10">
                                <asp:Label ID="lblAttachment2" runat="server" Text="Caption:"></asp:Label>
                                <asp:TextBox ID="txtCaptionAttachment2" runat="server"></asp:TextBox>
                                <asp:FileUpload ID="uploadSectorAttachment2" runat="server" />
                                <asp:Image ID="imgAttachment2" runat="server" Width="100px" Height="100px" BorderStyle="Dotted" Visible="false" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-2">&nbsp;</div>
                            <div class="col-sm-10">
                                <asp:Label ID="lblAttachment3" runat="server" Text="Caption:"></asp:Label>
                                <asp:TextBox ID="txtCaptionAttachment3" runat="server"></asp:TextBox>
                                <asp:FileUpload ID="uploadSectorAttachment3" runat="server" />
                                <asp:Image ID="imgAttachment3" runat="server" Width="100px" Height="100px" BorderStyle="Dotted" Visible="false" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-2">&nbsp;</div>
                            <div class="col-sm-10">
                                <asp:Label ID="lblAttachment4" runat="server" Text="Caption:"></asp:Label>
                                <asp:TextBox ID="txtCaptionAttachment4" runat="server"></asp:TextBox>
                                <asp:FileUpload ID="uploadSectorAttachment4" runat="server" />
                                <asp:Image ID="imgAttachment4" runat="server" Width="100px" Height="100px" BorderStyle="Dotted" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>

            </asp:Panel>

            <div class="form-group">
                <div class="col-sm-2 control-label">&nbsp;</div>
                <div class="col-sm-10">
                    <techKriti:ButtonControl ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" RequiredActionPermission="AddSector" />
                    <techKriti:ButtonControl ID="btnUpdate" CssClass="btn btn-primary" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateSector" />
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
