<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTestimonials.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Testimonials.ManageTestimonials"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="contentManageSectorsView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:UpdatePanel ID="uptPanelManageNews" runat="server">
        <ContentTemplate>
            <h1 class="page-header">Testimonials
                 <techKriti:HyperlinkControl ID="linkAddTestimonial" CssClass="btn btn-danger" Text="Add Testimonial" runat="server" RequiredActionPermission="AddTestimonial" />
            </h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblSection" runat="server" Text="Section"></asp:Label>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="drpDownSections" CssClass="form-control dropdown" runat="server">                           
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="lblDisplayName" CssClass="col-sm-2 control-label" runat="server" Text="Display Name"></asp:Label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtDisplayName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-2">
                        <asp:Button ID="btnTestimonialSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnTestimonialSearch_Click" />
                    </div>
                </div>

            </div>
            <div class="table-responsive">
                <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
                <asp:GridView CssClass="table table-striped" ID="gridTestimonial" DataKeyNames="Id" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridTestimonial_PageIndexChanging" OnRowCommand="gridTestimonial_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Display Name" DataField="DisplayName" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <techKriti:ButtonControl ID="btnEditTestimonial" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Client.Web.Views.Testimonials.ManageTestimonials.EditCommandName  %>'
                                    RequiredActionPermission="UpdateTestimonial" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnDeleteTestimonial" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Web.Views.Testimonials.ManageTestimonials.DeleteCommandName  %>'
                                    RequiredActionPermission="DeleteTestimonial" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
