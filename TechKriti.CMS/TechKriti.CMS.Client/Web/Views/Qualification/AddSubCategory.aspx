<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSubCategory.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Qualification.AddSubCategory"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentEditView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddEditCategory" runat="server">
        <h1 class="page-header">Add Sub-Category</h1>
        <asp:Label CssClass="alert alert-success" Style="display: table;" ID="lblStatus" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblCategory" runat="server" Text="Parent Category"></asp:Label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="drpDownCategories" CssClass="form-control dropdown" runat="server">
                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqValCategory" CssClass="alert alert-error" runat="server" InitialValue="0" ControlToValidate="drpDownCategories" ErrorMessage="Select category">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblName" runat="server" Text="Name"></asp:Label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" MaxLength="1000"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValtxtName" CssClass="alert alert-error" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter category name"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="Label1lblCode" runat="server" Text="Code"></asp:Label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" MaxLength="1000"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValtxtCode" CssClass="alert alert-error" runat="server" ControlToValidate="txtCode" ErrorMessage="Please enter category code"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-2 control-label">&nbsp;</div>
                <div class="col-sm-10">
                    <techKriti:ButtonControl ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" RequiredActionPermission="AddSubCategory" />
                    <techKriti:ButtonControl ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateSubCategory" />
                    <asp:Button ID="btnClear" Text="Cancel" CssClass="btn btn-warning" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>
                </div>
            </div>

        </div>
    </asp:Panel>
</asp:Content>
