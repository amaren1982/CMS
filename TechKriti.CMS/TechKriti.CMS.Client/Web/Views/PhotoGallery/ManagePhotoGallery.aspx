<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePhotoGallery.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.PhotoGallery.ManagePhotoGallery"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentManageSectorsView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageNews" runat="server">
        <ContentTemplate>
            <h1 class="page-header">Photo Gallery
                  <techKriti:HyperlinkControl ID="linkPhotoGallery" CssClass="btn btn-danger" Text="Add Photo Gallery" runat="server" RequiredActionPermission="AddPhotoGallery" />
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblSection" runat="server" Text="Section"></asp:Label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="drpDownSections" CssClass="form-control dropdown" runat="server">                           
                        </asp:DropDownList>
                    </div>

                    <asp:Label CssClass="col-sm-2 control-label" ID="lblDisplayName" runat="server" Text="Display Name"></asp:Label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtDisplayName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-2">
                        <asp:Button ID="btnPhotoGallerySearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnPhotoGallerySearch_Click" />
                    </div>
                </div>

            </div>
            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView CssClass="table table-striped" ID="gridPhotoGallery" DataKeyNames="Id" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridPhotoGallery_PageIndexChanging" OnRowCommand="gridPhotoGallery_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Display Name" DataField="DisplayName" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <techKriti:ButtonControl ID="btnEditPhotoGallery" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Client.Web.Views.PhotoGallery.ManagePhotoGallery.EditCommandName  %>'
                                    RequiredActionPermission="UpdatePhotoGallery" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnPhotoGallery" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Web.Views.PhotoGallery.ManagePhotoGallery.DeleteCommandName  %>'
                                    RequiredActionPermission="DeletePhotoGallery" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
