<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Qualification.AddCategory"
         MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentEditView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
     <asp:Panel ID="pnlAddEditCategory" runat="server" >  
          <h1 class="page-header">Add Category</h1>
        <asp:Label CssClass="alert alert-success" Style="display: table;" ID="lblStatus" runat="server" Visible="false"></asp:Label>

        <div class="form-horizontal">

             <div class="form-group">
                <asp:Label CssClass="col-sm-2 control-label" ID="lblName" runat="server" Text="Name"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"  MaxLength="1000" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValtxtName" CssClass="alert alert-error" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter category name">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

              <div class="form-group">
                <div class="col-sm-2 control-label">&nbsp;</div>
                <div class="col-sm-10">
                    <techKriti:ButtonControl ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" RequiredActionPermission="AddCategory" />
                    <techKriti:ButtonControl ID="btnUpdate" Text="Update" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateCategory" />
                    <asp:Button ID="Button1btnClear" Text="Cancel" CssClass="btn btn-warning" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>
                </div>
            </div>

            </div>
     </asp:Panel>  
</asp:Content>