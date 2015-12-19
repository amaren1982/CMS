<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCurrentOpenings.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.CurrentOpenings.CurrentOpenings"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentEditView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <h1 class="page-header">Current Openings
        <techKriti:HyperlinkControl ID="linkAddCurrentOpening" CssClass="btn btn-danger" Text="Add Current Opening" runat="server" RequiredActionPermission="AddCurrentOpening" />
    </h1>

    <asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label CssClass="col-sm-2 control-label" ID="lblSearchCompany" runat="server" Text="Company"></asp:Label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtSearchCompany" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <asp:Label CssClass="col-sm-2 control-label" ID="lblSearchPosition" runat="server" Text="Position"></asp:Label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtSearchPosition" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <asp:Label CssClass="col-sm-2 control-label" ID="lblSearchQualification" runat="server" Text="Qualification"></asp:Label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtSearchQualification" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label CssClass="col-sm-2 control-label" ID="lblSearchOpenTillDate" runat="server" Text="Open till date"></asp:Label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtSearchOpenTillDate" CssClass="form-control" runat="server"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtenderSearchDate" runat="server" TargetControlID="txtSearchOpenTillDate" PopupButtonID="Image1"></ajaxToolKit:CalendarExtender>
            </div>

            <asp:Label CssClass="col-sm-2 control-label" ID="lblSearchSkillSet" runat="server" Text="Skill Set"></asp:Label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtSearchSkillSet" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <asp:Label CssClass="col-sm-2 control-label" ID="lblSearchEmailPhone" runat="server" Text="Email/Phone"></asp:Label>
            <div class="col-sm-2">
                <asp:TextBox ID="txtSearchEmailPhone" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-2 control-label">Status</div>
            <div class="col-sm-2">
                <asp:CheckBox ID="chkSearchIsActive" CssClass=" form-control-static checkbox" Text="Is Active" runat="server" />
                <%--<asp:Label ID="lblSearchIsActive" runat="server" Text="Is Active"></asp:Label>--%>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnSearchCurrentOpening" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnCurrentOpeningSearch_click" />
            </div>
        </div>

        <div class="table-responsive">
            <asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
            <asp:GridView ID="gridCurrentOpenings" CssClass="table table-striped" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" OnRowCommand="gridCurrentOpenings_RowCommand"
                AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridNews_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="Company" DataField="Company" />
                    <asp:BoundField HeaderText="Position" DataField="Position" ItemStyle-Width="150px" />
                    <asp:BoundField HeaderText="Qualification" DataField="Qualification" ItemStyle-Width="150px" />
                    <asp:BoundField HeaderText="Active" DataField="IsActive" ItemStyle-Width="100px" />
                    <asp:BoundField HeaderText="Open till date" DataField="OpenTillDate" ItemStyle-Width="150px" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                        <ItemTemplate>
                            <techKriti:ButtonControl ID="btnEditCurrentOpening" runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" CommandArgument='<%# Eval("Id") %>'
                                RequiredActionPermission="UpdateCurrentOpening" CommandName='<%# TechKriti.CMS.Client.Web.Views.CurrentOpenings.CurrentOpenings.EditCommandName %>' />
                            <techKriti:ButtonControl ID="btnDeleteCurrentOpening" runat="server" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Web.Views.CurrentOpenings.CurrentOpenings.DeleteCommandName %>'
                                RequiredActionPermission="DeleteCurrentOpening" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Do you want to delete?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
