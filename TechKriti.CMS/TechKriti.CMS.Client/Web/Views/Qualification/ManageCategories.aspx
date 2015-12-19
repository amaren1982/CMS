<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Qualification.ManageCategories"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="contentManageSectorsView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageNews" runat="server">
        <ContentTemplate>

            <h1 class="page-header">Categories
                  <techKriti:HyperlinkControl ID="linkAddCategory" CssClass="btn btn-danger" Text="Add Category" runat="server" RequiredActionPermission="AddCategory" />
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

             <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label ID="lblSearchName" CssClass="col-sm-2 control-label" runat="server" Text="Category name"></asp:Label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtSearchCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-2">
                        <asp:Button ID="btnNewSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnCategorySearch_Click" />
                    </div>
                </div>

            </div>

                <div class="table-responsive">
                    <asp:Label ID="lblTotalNumberOfRecords"  runat="server"></asp:Label>              
                    <asp:GridView CssClass="table table-striped" ID="gridCategories" DataKeyNames="Id" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridCategories_PageIndexChanging" OnRowCommand="gridCategories_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="Name" ItemStyle-Width="300px" />
                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <techKriti:ButtonControl ID="btnEditCategory" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Client.Web.Views.Qualification.ManageCategories.EditCommandName  %>'
                                        RequiredActionPermission="UpdateCategory" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                    <techKriti:ButtonControl ID="btnDeleteCategory" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Web.Views.Qualification.ManageCategories.DeleteCommandName  %>'
                                        RequiredActionPermission="DeleteCategory" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
