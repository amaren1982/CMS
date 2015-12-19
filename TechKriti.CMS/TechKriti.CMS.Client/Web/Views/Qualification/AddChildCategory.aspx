<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddChildCategory.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Qualification.AddChildCategory" 
     MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentEditView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
     <asp:Panel ID="pnlAddEditCategory" runat="server" >  
	 <h1 class="page-header">Add Sub-Category</h1>
        <asp:Label ID="lblStatus" CssClass="alert alert-success" Style="display: table;"  runat="server" Visible="false"></asp:Label>

		<div class="form-horizontal">

               <div class="form-group">
				 <asp:Label ID="Label1" CssClass="col-sm-3 control-label" runat="server" Text="Choose Parent Category"></asp:Label>
				 <div class="col-sm-7">
					<asp:DropDownList ID="drpDownCategories" CssClass="form-control dropdown" runat="server" Width="200px"  AutoPostBack="true" OnSelectedIndexChanged="drpDownCategories_SelectedIndexChanged" >
                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqValParentCategory" runat="server" InitialValue="0" ControlToValidate="drpDownCategories" ErrorMessage="Select parent category">
                    </asp:RequiredFieldValidator>    
			  </div>
           </div>

            <div class="form-group">
				<asp:Label ID="lblCategory" CssClass="col-sm-3 control-label" runat="server" Text="Choose Sub Category"></asp:Label>
				 <div class="col-sm-7">
					<asp:DropDownList ID="drpDownSubCategories" CssClass="form-control dropdown" runat="server" Width="200px" Enabled="false">
                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqValCategory" runat="server" InitialValue="0" ControlToValidate="drpDownSubCategories" ErrorMessage="Select sub category">
                    </asp:RequiredFieldValidator>    
			</div>
        </div>
		
		<div class="form-group">
			<asp:Label ID="lblName" CssClass="col-sm-3 control-label" runat="server" Text="Name"></asp:Label>
			<div class="col-sm-5">
			    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" MaxLength="1000" Width="300px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValtxtName" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter category name" ></asp:RequiredFieldValidator>
            </div>
        </div>                   

		<div class="form-group">
			<asp:Label ID="lblCode" CssClass="col-sm-3 control-label" runat="server" Text="Code"></asp:Label>
			<div class="col-sm-5">
			    <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" MaxLength="1000" Width="300px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValtxtCode" runat="server" ControlToValidate="txtCode" ErrorMessage="Please enter category code" ></asp:RequiredFieldValidator>
            </div>
        </div>                    
		
		 <div class="form-group">
            <div class="col-sm-3 control-label">&nbsp;</div>
            <div class="col-sm-5">
				<techKriti:ButtonControl ID="btnSave" CssClass="btn btn-primary" Text="Save" runat="server" OnClick="btnSave_Click" RequiredActionPermission="AddSubCategory" ></techKriti:ButtonControl>
                <techKriti:ButtonControl ID="btnUpdate" CssClass="btn btn-primary" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdateSubCategory" ></techKriti:ButtonControl>
                <asp:Button ID="btnClear" CssClass="btn btn-warning" Text="Cancel" runat="server" OnClick="btnClear_Click" CausesValidation="false"></asp:Button>  
            </div>
        </div>
	</div>
   </asp:Panel>  
</asp:Content>