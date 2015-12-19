<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageQualifications.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Qualification.ManageQualifications"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="contentManageSectorsView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageNews" runat="server">
        <ContentTemplate>
            <h1 class="page-header">Qualifications
                  <techKriti:HyperlinkControl ID="linkAddQualification" CssClass="btn btn-danger" Text="Add Qualification" runat="server" RequiredActionPermission="AddQualification" />
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblCategory" runat="server" Text="Choose Category"></asp:Label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="drpDownSubCategories" CssClass="form-control dropdown" runat="server">
                        </asp:DropDownList>
                    </div>
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblDescription" runat="server" Text="Description"></asp:Label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-2">
                        <asp:Button ID="btnQualificationSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnQualificationSearch_Click" />
                    </div>
                </div>
            </div>
            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView CssClass="table table-striped" ID="gridQualifications" DataKeyNames="Id" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridDownloads_PageIndexChanging" OnRowCommand="gridDownloads_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Description" DataField="Description" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <techKriti:ButtonControl ID="btnEditQualification" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Client.Web.Views.Qualification.ManageQualifications.EditCommandName  %>'
                                    RequiredActionPermission="UpdateQualification" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnDeleteQualification" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Web.Views.Qualification.ManageQualifications.DeleteCommandName  %>'
                                    RequiredActionPermission="DeleteQualification" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
