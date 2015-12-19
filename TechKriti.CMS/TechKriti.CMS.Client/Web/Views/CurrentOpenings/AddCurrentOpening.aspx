<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCurrentOpening.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.CurrentOpenings.AddCurrentOpening"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentEditView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddEditNews" runat="server">
        <h1 class="page-header">Add Current Openings</h1>
        <asp:Label ID="lblStatus" CssClass="alert alert-success" Style="display: table;" role="alert" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblCompany" runat="server" Text="Company"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtCompany" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValtxtCompany" CssClass="alert alert-error" runat="server" ControlToValidate="txtCompany" ErrorMessage="Please enter company"></asp:RequiredFieldValidator>
                </div>

                <asp:Label CssClass="col-sm-2 control-label" ID="lblPosition" runat="server" Text="Position"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtPosition" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValtxtPosition" CssClass="alert alert-error" runat="server" ControlToValidate="txtPosition" ErrorMessage="Please enter position"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblQualification" runat="server" Text="Qualification"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtQualification" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValQualification" CssClass="alert alert-error" runat="server" ControlToValidate="txtQualification" ErrorMessage="Please enter qualification"></asp:RequiredFieldValidator>
                </div>

                <asp:Label CssClass="col-sm-2 control-label" ID="lblSkillSet" runat="server" Text="SkillSet"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtSkillSet" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValtxtSkillSet" CssClass="alert alert-error" runat="server" ControlToValidate="txtSkillSet" ErrorMessage="Please enter skill set"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblEmailPhone" runat="server" Text="Email/Phone"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtEmailPhone" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValtxtEmailPhone" CssClass="alert alert-error" runat="server" ControlToValidate="txtEmailPhone" ErrorMessage="Please enter email/phone"></asp:RequiredFieldValidator>
                </div>

                <asp:Label CssClass="col-sm-2 control-label" ID="lblOpenTillDate" runat="server" Text="Open till date"></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtOpenTillDate" CssClass="form-control" runat="server"></asp:TextBox>
                    <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtOpenTillDate" PopupButtonID="Image1"></ajaxToolKit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="reqValOpenTillDate" CssClass="alert alert-error" runat="server" ControlToValidate="txtOpenTillDate" ErrorMessage="Please select date"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2 control-label">
                    Status
                </div>
                <div class="col-sm-2">
                    <asp:CheckBox ID="chkIsActive" CssClass="form-control checkbox" Text="Is Active" runat="server" />
                    <%--<asp:Label ID="lblIsActive" runat="server" Text="Is Active"></asp:Label>--%>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2">
                    &nbsp;
                </div>
                <div class="col-sm-10">
                    <techKriti:ButtonControl ID="btnSave" Text="Save" CssClass="btn btn-primary" runat="server" Visible="false" OnClick="btnSave_Click" RequiredActionPermission="AddCurrentOpening" />
                    <techKriti:ButtonControl ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" Visible="false" OnClick="btnSave_Click" RequiredActionPermission="UpdateCurrentOpening" />
                    <asp:Button ID="btnClear" Text="Cancel" CssClass="btn btn-warning" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>
                </div>
            </div>
        </div>

    </asp:Panel>
</asp:Content>
