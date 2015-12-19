<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.Admin.AddUser" MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddUserView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddEditUser" runat="server">
        <h1 class="page-header">Add Users</h1>
        <asp:Label ID="lblStatus" CssClass="alert alert-error" Style="display: table;" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblUsername" runat="server" Text="Username"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" SetFocusOnError="true" CssClass="alert alert-warning"
                        ID="reqValtxtUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter username"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPassword" CssClass="col-sm-2 control-label" runat="server" Text="Password"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" SetFocusOnError="true" CssClass="alert alert-warning"
                        ID="reqValtxtPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter password"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblRole" CssClass="col-sm-2 control-label" runat="server" Text="Choose role"></asp:Label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="drpRoles" CssClass="form-control dropdown" runat="server" Width="200px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqValRoles" Display="Dynamic" SetFocusOnError="true" CssClass="alert alert-warning"
                        runat="server" InitialValue="0" ControlToValidate="drpRoles"
                        ErrorMessage="Select role"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-2 control-label">&nbsp;</div>
                <div class="col-sm-10">
                    <techKriti:ButtonControl ID="btnSave" CssClass="btn btn-primary" Text="Save" runat="server" OnClick="btnSave_Click" RequiredActionPermission="AddUser"></techKriti:ButtonControl>
                    <techKriti:ButtonControl ID="btnUpdate" CssClass="btn btn-primary" Text="Update" runat="server" OnClick="btnUpdate_Click" OnClientClick="disablePasswordValidator()"
                        RequiredActionPermission="UpdateUser"></techKriti:ButtonControl>
                    <asp:Button ID="btnCancel" Text="Cancel" CssClass="btn btn-warning" runat="server" CausesValidation="false" OnClick="btnCancel_Click"></asp:Button>
                </div>
            </div>
        </div>

    </asp:Panel>
</asp:Content>
