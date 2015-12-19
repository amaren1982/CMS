<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQualification.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Qualification.AddQualification"
    MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddSectorView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="pnlAddSector" runat="server">
        <h1 class="page-header">Add Qualifications</h1>
        <asp:Label CssClass="alert alert-success" Style="display: table;" ID="lblStatus" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Panel ID="pnlCategories" runat="server">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblCategory" runat="server" Text="Main Category"></asp:Label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="drpDownCategories" runat="server" CssClass="form-control dropdown" AutoPostBack="true" OnSelectedIndexChanged="drpDownCategories_SelectedIndexChanged">
                            <asp:ListItem Value="" Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqValCategory" runat="server" CssClass="alert alert-error" InitialValue="0" ControlToValidate="drpDownCategories" ErrorMessage="Select category">
                        </asp:RequiredFieldValidator>
                    </div>
                </asp:Panel>
            </div>
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblSubCategory" runat="server" Text="Category"></asp:Label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="drpDownSubCategory" CssClass="form-control dropdown" runat="server" OnSelectedIndexChanged="drpDownSubCategories_SelectedIndexChanged"
                        AutoPostBack="true" Enabled="false">
                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpDownSubCategory"
                        InitialValue="0" ErrorMessage="Select sub category" CssClass="alert alert-error">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblChildCategory" runat="server" Text="Sub Category"></asp:Label>
                <div class="col-sm-3">
                    <asp:DropDownList ID="drpDownChildCategory" CssClass="form-control dropdown" runat="server" Enabled="false">
                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpDownChildCategory"
                        InitialValue="0" ErrorMessage="Select sub category" CssClass="alert alert-error">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblDescription" runat="server" Text="Description(Qualification Criteria)"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="alert alert-error" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please enter Description">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2 control-label">&nbsp;</div>
                <div class="col-sm-10">
                    <techKriti:ButtonControl ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" RequiredActionPermission="AddQualification" />
                    <techKriti:ButtonControl ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateQualification" />
                    <asp:Button ID="btnClear" Text="Cancel" CssClass="btn btn-warning" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>