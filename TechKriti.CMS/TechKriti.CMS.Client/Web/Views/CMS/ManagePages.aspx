<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePages.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.CMS.ManagePages" MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentManageMenuView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageMenus" runat="server">
        <ContentTemplate>
            <h1 class="page-header">Pages
                 <techKriti:HyperlinkControl ID="linkAddPage" CssClass="btn btn-danger" runat="server" Text="Add" RequiredActionPermission="AddPage" />
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label ID="lblMenuName" CssClass="col-sm-2 control-label" runat="server" Text="Menu name"></asp:Label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtMenuName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <asp:Label ID="lblPageStatus" CssClass="col-sm-2 control-label" runat="server" Text="Status"></asp:Label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="drpDownStatus" CssClass="form-control dropdown" runat="server" Width="200px">
                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Draft"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Publish"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnPageSearch_Click" />
                    </div>
                </div>
            </div>
            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView ID="gridPages" CssClass="table table-striped" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnRowCommand="gridPages_RowCommand"
                    AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridPages_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="Page Title" DataField="Title" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <techKriti:ButtonControl ID="btnEditMenu" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Administration.Web.Views.CMS.ManagePages.EditCommandName  %>'
                                    RequiredActionPermission="UpdatePage" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnDeleteMenu" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Administration.Web.Views.CMS.ManagePages.DeleteCommandName  %>'
                                    RequiredActionPermission="DeletePage" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
