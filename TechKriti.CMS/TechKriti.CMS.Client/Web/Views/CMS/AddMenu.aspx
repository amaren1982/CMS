<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenu.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.CMS.AddMenu" MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddMenuView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddEditMenu" runat="server">
        <h1 class="page-header">Add Menu</h1>
        <asp:Label ID="lblStatus" CssClass="alert alert-success" Style="display: table;" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblMenu" runat="server" Text="Menu"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtMenuName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValtxtUsername" Display="Dynamic" SetFocusOnError="True" CssClass="alert alert-danger"
                        runat="server" ControlToValidate="txtMenuName" ErrorMessage="Please enter menu name"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblParentMenu" runat="server" Text="Parent Menu"></asp:Label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="drpDownParentMenu" CssClass="form-control dropdown" runat="server">
                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblDisplayOrder" runat="server" Text="Display order"></asp:Label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="drpDownDisplayorder" CssClass="form-control dropdown" runat="server">
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                        <asp:ListItem Value="6" Text="6"></asp:ListItem>
                        <asp:ListItem Value="7" Text="7"></asp:ListItem>
                        <asp:ListItem Value="8" Text="8"></asp:ListItem>
                        <asp:ListItem Value="9" Text="9"></asp:ListItem>
                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-2 control-label">Status </div>
                <div class="col-sm-3">
                    <asp:CheckBox ID="chkIsActive" CssClass="form-control checkbox" Text="Is Active" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-2 control-label">&nbsp;</div>
                <div class="col-sm-10">
                    <techKriti:ButtonControl CssClass="btn btn-primary" ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" RequiredActionPermission="AddMenu"></techKriti:ButtonControl>
                    <techKriti:ButtonControl CssClass="btn btn-primary" ID="btnUpdate" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateMenu"></techKriti:ButtonControl>
                    <asp:Button ID="btnClear" CssClass="btn btn-warning" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>
                </div>
            </div>

        </div>

    </asp:Panel>
</asp:Content>
