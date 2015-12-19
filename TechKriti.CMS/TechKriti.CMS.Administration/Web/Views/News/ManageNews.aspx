<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web/Shared/Site.Master" CodeBehind="ManageNews.aspx.cs" Inherits="TechKriti.CMS.Client.Views.News.ManageNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentManageNewsView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
        <asp:UpdatePanel ID="uptPanelManageNews" runat="server">
             <ContentTemplate>
                     <table border="0" style="vertical-align:top;width:100%;" >
                        <tr>
                            <td></td>
                              <td style="vertical-align:top;">                            
                                   <techKriti:HyperlinkControl ID="linkAddNews" Text="Add News" runat="server" RequiredActionPermission="AddNews">
                                   </techKriti:HyperlinkControl>
                              </td>
                        </tr>
                         <tr>
                             <td colspan="2">
                                   <asp:Label ID="lblStatus" runat="server" Visible="false" ></asp:Label>
                             </td>
                         </tr>
                        <tr>
                            <td colspan="2">
                                        <table border="0" style="border: dashed;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSearchDescription" runat="server" Text="Description"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchDescription" runat="server"></asp:TextBox>
                                                </td>
                                                <td style="width:20px;">&nbsp;</td>
                                                 <td>
                                                    <asp:Label ID="lblSearchDate" runat="server" Text="Date"></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:TextBox ID="txtSearchDate" runat="server"></asp:TextBox>
                                                      <ajaxToolkit:CalendarExtender ID="calendarExtenderSearchNews"  runat="server" 
                                                          TargetControlID="txtSearchDate"  PopupButtonID="Image1"></ajaxToolkit:CalendarExtender>
                                                </td>
                                                 <td style="width:20px;">&nbsp;</td>
                                                 <td>
                                                       <asp:Label ID="lblSearchIsActive" runat="server" Text="Is Active"></asp:Label>
                                                </td>
                                                <td>
                                                        <asp:CheckBox ID="chkSearchIsActive" runat="server" />
                                                </td>                                                       
                                                <td>
                                                    <asp:Button ID="btnNewSearch" runat="server" Text="Search" OnClick="btnNewsSearch_Click" />
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
                                            <asp:GridView ID="gridNews" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" OnRowCommand="gridNews_RowCommand"
                                                AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridNews_PageIndexChanging" >
                                                <Columns>
                                                        <asp:BoundField HeaderText="Description" DataField="NewsDescription" ItemStyle-Width="300px" />
                                                        <asp:BoundField HeaderText="Active" DataField="IsActive" ItemStyle-Width="100px" />
                                                        <asp:BoundField HeaderText="Date" DataField="Date"  ItemStyle-Width="100px" DataFormatString="{0:d}" />   
                                                        <asp:TemplateField HeaderText="Action" >
                                                        <ItemTemplate>
                                                             <techKriti:ButtonControl ID="btnEditNews" runat="server" CommandName='<%# TechKriti.CMS.Client.Views.News.ManageNews.EditCommandName  %>' 
                                                                 RequiredActionPermission="UpdateNews" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                                                             <techKriti:ButtonControl ID="btnDeleteNews" runat="server" Text="Delete" CommandName='<%# TechKriti.CMS.Client.Views.News.ManageNews.DeleteCommandName  %>' 
                                                                 RequiredActionPermission="DeleteNews"  CommandArgument='<%# Eval("Id") %>'  OnClientClick="return confirm('Are you sure you want to delete?')" />
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
    
  <%--  <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlAddEditNews"
        BackgroundCssClass="modalBackground" TargetControlID="btnAddNews" CancelControlID="btnClose">
    </asp:ModalPopupExtender>--%>
</asp:Content>

