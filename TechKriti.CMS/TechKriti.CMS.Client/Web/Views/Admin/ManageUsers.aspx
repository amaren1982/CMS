<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.Admin.ManageUsers"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddRoleView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageUsers" runat="server">
        <ContentTemplate>
            <h1 class="page-header">Users
                  <techKriti:HyperlinkControl ID="linkAddUser" CssClass="btn btn-danger" Text="Add" runat="server" RequiredActionPermission="AddUser" />
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label ID="lblUserName" CssClass="col-sm-2 control-label" runat="server" Text="User name"></asp:Label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnUsersSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnUsersSearch_Click" />
                    </div>
                </div>

            </div>
            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView ID="gridUsers" CssClass="table table-striped" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnRowCommand="gridUsers_RowCommand"
                    AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridUsers_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="Username" DataField="Username" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <techKriti:ButtonControl ID="btnEditNews" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Administration.Web.Views.Admin.ManageUsers.EditCommandName  %>'
                                    RequiredActionPermission="UpdateUser" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnDeleteNews" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Administration.Web.Views.Admin.ManageUsers.DeleteCommandName  %>'
                                    RequiredActionPermission="DeleteUser" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
