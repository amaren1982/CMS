<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.Admin.ManageRoles"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddRoleView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageRoles" runat="server">
        <ContentTemplate>
            <h1 class="page-header">Roles
                  <techKriti:HyperlinkControl ID="linkAddRole" CssClass="btn btn-danger" runat="server" Text="Add" RequiredActionPermission="AddRole"></techKriti:HyperlinkControl>
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label ID="lblRoleName" CssClass="col-sm-2 control-label" runat="server" Text="Role name"></asp:Label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtRoleName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnRolesSearch_Click" />
                    </div>
                </div>

            </div>
            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView ID="gridRoles" CssClass="table table-striped" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnRowCommand="gridRoles_RowCommand"
                    AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridRoles_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="RoleName" DataField="RoleName" ItemStyle-Width="300px" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <techKriti:ButtonControl ID="btnEditUser" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Administration.Web.Views.Admin.ManageRoles.EditCommandName  %>'
                                    RequiredActionPermission="UpdateRole" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnDeleteUser" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Administration.Web.Views.Admin.ManageRoles.DeleteCommandName  %>'
                                    RequiredActionPermission="DeleteRole" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
