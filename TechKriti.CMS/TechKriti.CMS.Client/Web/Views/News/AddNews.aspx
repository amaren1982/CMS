<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="TechKriti.CMS.Client.Views.News.AddNews" MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentEditView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddEditNews" runat="server">
        <h1 class="page-header">Add News</h1>
        <asp:Label ID="lblStatus" CssClass="alert alert-success" Style="display: table;" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblDescription" runat="server" Text="Description"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValtxtUsername" CssClass="alert alert-error" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please enter news description"></asp:RequiredFieldValidator>
                </div>

                <asp:Label ID="lblDate" CssClass="col-sm-2 control-label" runat="server" Text="Date"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                    <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" PopupButtonID="Image1"></ajaxToolKit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="reqValtxtDate" CssClass="alert alert-error" runat="server" ControlToValidate="txtDate" ErrorMessage="Please select date"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-2 control-label">Status</div>
                <div class="col-sm-2">
                    <asp:CheckBox ID="chkIsActive" CssClass="form-control checkbox" Text="Is Active" runat="server" />
                    <%--<asp:Label ID="lblIsActive" runat="server" Text="Is Active"></asp:Label>--%>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-2 control-label">&nbsp;</div>
                <div class="col-sm-10">
                    <techKriti:ButtonControl ID="btnSave" CssClass="btn btn-primary" Text="Save" runat="server" OnClick="btnSave_Click" RequiredActionPermission="AddNews"></techKriti:ButtonControl>
                    <techKriti:ButtonControl ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateNews"></techKriti:ButtonControl>
                    <asp:Button ID="btnClear" Text="Cancel" CssClass="btn btn-warning" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>
                </div>
            </div>

        </div>
    </asp:Panel>
</asp:Content>
