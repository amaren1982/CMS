<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSectors.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Sectors.ManageSectors"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentManageSectorsView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageSectors" runat="server">
        <ContentTemplate>
            <h1 class="page-header">Sectors
                <techKriti:HyperlinkControl CssClass="btn btn-danger" ID="linkAddSector" Text="Add Sector" runat="server" RequiredActionPermission="AddSector" />
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblSectorName" runat="server" Text="Sector Name"></asp:Label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtSectorName" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-2">
                        <asp:Button ID="btnSectorSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSectorSearch_Click" />
                    </div>
                </div>

            </div>
            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView CssClass="table table-striped" ID="gridSectors" DataKeyNames="Id" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridSectors_PageIndexChanging" OnRowCommand="gridSectors_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Display Name" DataField="SectorName" ItemStyle-Width="300px" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <techKriti:ButtonControl ID="btnEditSector" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Client.Web.Shared.BasePage.EditCommand  %>'
                                    RequiredActionPermission="UpdateSector" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnDeleteSector" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Web.Shared.BasePage.DeleteCommand  %>'
                                    RequiredActionPermission="DeleteSector" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
