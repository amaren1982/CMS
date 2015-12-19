<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageQualifications.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.Qualification.ManageQualifications"
     MasterPageFile="~/Web/Shared/Site.Master"  %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>

<asp:Content ID="contentManageSectorsView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <asp:UpdatePanel ID="uptPanelManageNews" runat="server">
             <ContentTemplate>
                     <table border="0" style="vertical-align:top;width:100%;" >
                        <tr>
                            <td></td>
                              <td style="vertical-align:top;">                            
                                  <techKriti:HyperlinkControl ID="linkAddQualification" Text="Add Qualification" runat="server" RequiredActionPermission="AddQualification"  />
                              </td>
                        </tr>
                         <tr>
                             <td colspan="2">
                                   <asp:Label ID="lblStatus" runat="server" Visible="false" ></asp:Label>
                             </td>
                         </tr>
                        <tr>
                            <td colspan="2">
                                  <table border="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCategory" runat="server" Text="Choose Category"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="drpDownSubCategories" runat="server" Width="200px">
                                                     </asp:DropDownList>
                                                </td>
                                                 <td style="width:20px;">&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                                                </td>                                                
                                                <td>
                                                    <asp:Button ID="btnQualificationSearch" runat="server" Text="Search" OnClick="btnQualificationSearch_Click" />
                                                </td>
                                            </tr>
                                  </table>
                            </td>
                        </tr>
                         <tr>
                             <td style="width:10px;">
                         </tr>
                        <tr>
                            <td>
                              
                            </td>
                            <td>
                                <table border="0" style="width:100%;border: dashed;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblTotalNumberOfRecords" runat="server" ></asp:Label>
                                            <asp:GridView ID="gridQualifications" DataKeyNames="Id" runat="server" AutoGenerateColumns="false"
                                                AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridDownloads_PageIndexChanging" OnRowCommand="gridDownloads_RowCommand" >
                                                <Columns>
                                                        <asp:BoundField HeaderText="Description" DataField="Description" ItemStyle-Width="300px" />                                                                                                                                                                 
                                                        <asp:TemplateField HeaderText="Action" >
                                                        <ItemTemplate>
                                                             <techKriti:ButtonControl ID="btnEditQualification" runat="server" CommandName='<%# TechKriti.CMS.Client.Web.Views.Qualification.ManageQualifications.EditCommandName  %>' 
                                                                RequiredActionPermission="UpdateQualification" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                                             <techKriti:ButtonControl ID="btnDeleteQualification" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Web.Views.Qualification.ManageQualifications.DeleteCommandName  %>' 
                                                                RequiredActionPermission="DeleteQualification" CommandArgument='<%# Eval("Id") %>'  OnClientClick="return confirm('Are you sure you want to delete?')" />
                                                        </ItemTemplate>
                                        
                                                    </asp:TemplateField>                                    
                                                </Columns>
                                            </asp:GridView> 
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
               </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>



