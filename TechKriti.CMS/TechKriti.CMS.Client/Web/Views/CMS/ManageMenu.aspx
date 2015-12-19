<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageMenu.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.CMS.ManageMenu" MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentManageMenuView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageMenus" runat="server">
        <ContentTemplate>
            <h1 class="page-header">Menus
                   <techKriti:HyperlinkControl ID="linkAddMenu" CssClass="btn btn-danger" runat="server" Text="Add" RequiredActionPermission="AddMenu" />
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <%-- <asp:Label ID="lblMenuName" CssClass="col-sm-2 control-label" runat="server" Text="Menu name"></asp:Label>--%>
                    <div class="col-sm-2 control-label">Menu name</div>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtMenuName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 control-label">Status</div>
                    <div class="col-sm-2">
                        <asp:CheckBox ID="chkSearchIsActive" CssClass="form-control checkbox" runat="server" Text="Is Active" />
                        <%--<asp:Label ID="lblSearchIsActive" runat="server" Text="Is Active"></asp:Label>--%>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnMenuSearch_Click" />
                    </div>
                </div>

            </div>

            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView ID="gridMenus" CssClass="table table-striped" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnRowCommand="gridMenus_RowCommand"
                    AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridMenus_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="MenuName" DataField="MenuName" />
                        <asp:BoundField HeaderText="Active" DataField="IsActive" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <techKriti:ButtonControl ID="btnEditMenu" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Administration.Web.Views.CMS.ManageMenu.EditCommandName  %>'
                                    RequiredActionPermission="UpdateMenu" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnDeleteMenu" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Administration.Web.Views.CMS.ManageMenu.DeleteCommandName  %>'
                                    RequiredActionPermission="DeleteMenu" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
