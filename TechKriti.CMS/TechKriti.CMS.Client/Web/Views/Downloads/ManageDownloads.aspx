<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageDownloads.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Downloads.ManageDownloads"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="contentManageSectorsView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageNews" runat="server">
        <ContentTemplate>
            <h1 class="page-header">Downloads
                <techKriti:HyperlinkControl ID="linkAddDownload" CssClass="btn btn-danger" Text="Add Download" runat="server" RequiredActionPermission="AddDownload" />
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label CssClass="col-sm-1 control-label" ID="lblSection" runat="server" Text="Section"></asp:Label>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="drpDownSections" CssClass="form-control dropdown" runat="server">                          
                        </asp:DropDownList>
                    </div>

                    <asp:Label CssClass="col-sm-2 control-label" ID="lblDisplayName" runat="server" Text="Display Name"></asp:Label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtDisplayName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-1 control-label">Status</div>
                    <div class="col-sm-2">
                        <asp:CheckBox ID="chkSearchIsActive" CssClass="form-control checkbox" Text="Is Active" runat="server" />
                        <%--<asp:Label ID="lblSearchIsActive" runat="server" Text="Is Active"></asp:Label>--%>
                    </div>

                    <%--  <div class="col-sm-2 control-label">&nbsp;</div>--%>
                    <div class="col-sm-2">
                        <asp:Button ID="btnSectorSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSectorSearch_Click" />
                    </div>
                </div>

                <div class="form-group">
                </div>
            </div>
            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView CssClass="table table-striped" ID="gridDownloads" DataKeyNames="Id" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridDownloads_PageIndexChanging" OnRowCommand="gridDownloads_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Display Name" DataField="DisplayName" />
                        <asp:BoundField HeaderText="Active" DataField="IsActive" ItemStyle-Width="100px" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <techKriti:ButtonControl ID="btnEditSector" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Client.Web.Views.Downloads.ManageDownloads.EditCommandName  %>'
                                    RequiredActionPermission="UpdateDownload" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnDeleteSector" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Web.Views.Downloads.ManageDownloads.DeleteCommandName  %>'
                                    RequiredActionPermission="DeleteDownload" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
