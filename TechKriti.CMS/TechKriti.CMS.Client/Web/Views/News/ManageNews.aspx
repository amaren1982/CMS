<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web/Shared/Site.Master" CodeBehind="ManageNews.aspx.cs" Inherits="TechKriti.CMS.Client.Views.News.ManageNews" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentManageNewsView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageNews" runat="server">
        <ContentTemplate>
            <h1 class="page-header">News
                 <techKriti:HyperlinkControl ID="linkAddNews" CssClass="btn btn-danger" Text="Add News" runat="server" RequiredActionPermission="AddNews">
                 </techKriti:HyperlinkControl>
            </h1>

            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label ID="lblSearchDescription" CssClass="col-sm-2 control-label" runat="server" Text="Description"></asp:Label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtSearchDescription" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <asp:Label ID="lblSearchDate" CssClass="col-sm-1 control-label" runat="server" Text="Date"></asp:Label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtSearchDate" CssClass="form-control" runat="server"></asp:TextBox>
                        <ajaxToolKit:CalendarExtender ID="calendarExtenderSearchNews" runat="server"
                            TargetControlID="txtSearchDate" PopupButtonID="Image1">
                        </ajaxToolKit:CalendarExtender>
                    </div>

                    <div class="col-sm-1 control-label">Status</div>
                    <div class="col-sm-2">
                        <asp:CheckBox ID="chkSearchIsActive" CssClass="form-control checkbox" Text="Is Active" runat="server" />
                        <%--<asp:Label ID="lblSearchIsActive" runat="server" Text="Is Active"></asp:Label>--%>
                    </div>

                    <div class="col-sm-2">
                        <asp:Button ID="btnNewSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnNewsSearch_Click" />
                    </div>
                </div>

            </div>
            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView CssClass="table table-striped" ID="gridNews" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" OnRowCommand="gridNews_RowCommand"
                    AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridNews_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="Description" DataField="NewsDescription" />
                        <asp:BoundField HeaderText="Active" DataField="IsActive" ItemStyle-Width="100px" />
                        <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="100px" DataFormatString="{0:d}" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Button ID="btnEditNews" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Client.Views.News.ManageNews.EditCommandName  %>'
                                    Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <asp:Button ID="btnDeleteNews" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Views.News.ManageNews.DeleteCommandName  %>'
                                    CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
