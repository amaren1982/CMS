<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageChildCategories.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Qualification.ManageChildCategories"
 MasterPageFile="~/Web/Shared/Site.Master" %>

<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="contentManageSubCategoriesView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <asp:UpdatePanel ID="uptPanelManageSubCategories" runat="server">
           <ContentTemplate>
		      <h1 class="page-header">Sub-Categories
				<techKriti:HyperlinkControl ID="linkAddSubCategory" CssClass="btn btn-danger" Text="Add Sub Category" runat="server" RequiredActionPermission="AddSubCategory"/>                
            </h1>
			<asp:Label ID="lblStatus" CssClass="alert alert-info" Style="display: table;" runat="server" Visible="false"></asp:Label>

                <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblCategory" runat="server" Text="Choose Category"></asp:Label>
                    <div class="col-sm-3">
                          <asp:TextBox ID="txtSearchSubCategoryName" CssClass="form-control" runat="server"></asp:TextBox>                    
                    </div>
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblDescription" runat="server" Text="Code"></asp:Label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtSearchCode" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-sm-2">
                        <asp:Button ID="btnQualificationSearch" CssClass="btn btn-primary" runat="server" Text="Search"  OnClick="btnChildCategorySearch_Click"  />
                    </div>
                </div>
            </div>
			
			<div class="table-responsive">
				<asp:Label ID="lblTotalNumberOfRecords" runat="server"></asp:Label>
				<asp:GridView ID="gridCategories" CssClass="table table-striped" DataKeyNames="Id" runat="server" AutoGenerateColumns="false"
					AllowPaging="true" AllowCustomPaging="true" PageSize="10" OnPageIndexChanging="gridCategories_PageIndexChanging" OnRowCommand="gridCategories_RowCommand" >
					<Columns>
						<asp:BoundField HeaderText="Name" DataField="Name" ItemStyle-Width="300px" />    
						<asp:BoundField HeaderText="Code" DataField="Code" ItemStyle-Width="300px" />                                                                                                                                                              
						<asp:TemplateField HeaderText="Action" >
							<ItemTemplate>
								 <techKriti:ButtonControl ID="btnEditCategory" CssClass="btn btn-primary btn-sm" runat="server" CommandName='<%# TechKriti.CMS.Client.Web.Views.Qualification.ManageSubCategories.EditCommandName  %>'
                                    RequiredActionPermission="UpdateCategory" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                <techKriti:ButtonControl ID="btnDeleteCategory" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Web.Views.Qualification.ManageSubCategories.DeleteCommandName  %>'
                                    RequiredActionPermission="DeleteCategory" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure you want to delete?')" />
							</ItemTemplate>			
						</asp:TemplateField>                                    
					</Columns>
				</asp:GridView> 
			  </div> 
           </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>