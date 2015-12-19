<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCurrentOpenings.aspx.cs" Inherits="TechKriti.CMS.Client.Web.Views.CurrentOpenings.CurrentOpenings" 
    MasterPageFile="~/Web/Shared/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentEditView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table border="0" style="vertical-align:top;width:100%;" >
        <tr>
            <td></td>
              <td style="vertical-align:top;">                            
                  <techKriti:HyperlinkControl ID="linkAddCurrentOpening" Text="Add Current Opening" runat="server" RequiredActionPermission="AddCurrentOpening"/>                  
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
                                <asp:Label ID="lblSearchCompany" runat="server" Text="Company"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchCompany" runat="server"></asp:TextBox>                                
                            </td>                    
                            <td>
                                <asp:Label ID="lblSearchPosition" runat="server" Text="Position"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchPosition" runat="server"></asp:TextBox>                                   
                            </td>                           
                            <td>
                                <asp:Label ID="lblSearchQualification" runat="server" Text="Qualification"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchQualification" runat="server"></asp:TextBox>                                   
                            </td>                                             
                            <td>
                                <asp:Label ID="lblSearchSkillSet" runat="server" Text="SkillSet"></asp:Label>
                            </td>                           
                            <td>
                                  <asp:TextBox ID="txtSearchSkillSet" runat="server"></asp:TextBox>                                   
                            </td> 
                     </tr>
                     <tr>                           
                            <td>
                                  <asp:Label ID="lblSearchEmailPhone" runat="server" Text="Email/Phone"></asp:Label>
                            </td>
                            <td>
                                  <asp:TextBox ID="txtSearchEmailPhone" runat="server"></asp:TextBox>                                   
                            </td>                           
                            <td>
                                   <asp:Label ID="lblSearchOpenTillDate" runat="server" Text="Open till date"></asp:Label>
                            </td>
                            <td>
                                   <asp:TextBox ID="txtSearchOpenTillDate" runat="server"></asp:TextBox>
                                   <ajaxToolkit:CalendarExtender ID="CalendarExtenderSearchDate"  runat="server" TargetControlID="txtSearchOpenTillDate"  PopupButtonID="Image1"></ajaxToolkit:CalendarExtender>                                    
                            </td>                            
                            <td>
                                   <asp:Label ID="lblSearchIsActive" runat="server" Text="Is Active"></asp:Label>
                            </td>
                            <td>
                                    <asp:CheckBox ID="chkSearchIsActive" runat="server" />
                            </td>
                            <td>
                                   <asp:Button ID="btnSearchCurrentOpening" runat="server" Text="Search" OnClick="btnCurrentOpeningSearch_click" />
                             </td>
                       </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width:10px;"></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <table border="0" style="width:100%;border: dashed;">
                    <tr>
                        <td>
                             <asp:Label ID="lblTotalNumberOfRecords" runat="server" ></asp:Label>
                            <asp:GridView ID="gridCurrentOpenings" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" OnRowCommand="gridCurrentOpenings_RowCommand"
                                AllowPaging="true" AllowCustomPaging="true" PageSize="3" OnPageIndexChanging="gridNews_PageIndexChanging">
                                <Columns>
                                        <asp:BoundField HeaderText="Company" DataField="Company" ItemStyle-Width="300px" />
                                        <asp:BoundField HeaderText="Position" DataField="Position" ItemStyle-Width="300px" />
                                        <asp:BoundField HeaderText="Qualification" DataField="Qualification" ItemStyle-Width="300px" />
                                        <asp:BoundField HeaderText="Active" DataField="IsActive" ItemStyle-Width="100px" />
                                        <asp:BoundField HeaderText="Open till date" DataField="OpenTillDate"  ItemStyle-Width="100px" DataFormatString="{0:d}" />   
                                        <asp:TemplateField HeaderText="Action" >
                                        <ItemTemplate>
                                             <techKriti:ButtonControl ID="btnEditCurrentOpening" runat="server"  Text="Edit" CommandArgument='<%# Eval("Id") %>' 
                                              RequiredActionPermission="UpdateCurrentOpening"   CommandName='<%# TechKriti.CMS.Client.Web.Views.CurrentOpenings.CurrentOpenings.EditCommandName %>'  />
                                             <techKriti:ButtonControl ID="btnDeleteCurrentOpening" runat="server" Text="Delete"    CommandName='<%# TechKriti.CMS.Client.Web.Views.CurrentOpenings.CurrentOpenings.DeleteCommandName %>' 
                                               RequiredActionPermission="DeleteCurrentOpening" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Do you want to delete?')" />
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
</asp:Content>

