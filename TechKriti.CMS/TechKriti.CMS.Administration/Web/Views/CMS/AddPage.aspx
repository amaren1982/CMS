<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.CMS.AddPage" MasterPageFile="~/Web/Shared/Site.Master"  ValidateRequest="false" %>
<%@ Register Assembly="TechKriti.Custom.Controls" Namespace="TechKriti.Custom.Controls" TagPrefix="techKriti" %>

<asp:Content ID="contentAddPageView" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script src="../../../tinymce_4.1.7/tinymce/js/tinymce/tinymce.min.js"></script>
<script type="text/javascript">

    tinyMCE.init({

        mode: "textareas",
        selector: ".mcetiny",
        theme: "modern",
        plugins: [
         "advlist autolink lists link image charmap print preview hr anchor pagebreak",
         "searchreplace wordcount visualblocks visualchars code fullscreen",
         "insertdatetime media nonbreaking save table contextmenu directionality",
         "emoticons template paste textcolor"
        ],
        toolbar1: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image",
        toolbar2: "print preview media | forecolor backcolor emoticons",
        image_advtab: true,
    });
</script>

      <asp:UpdatePanel ID="uptPanelAddPage" runat="server">
           <ContentTemplate>
                   <table>
                             <tr>
                                   <td style="height:10px;" >&nbsp;</td>
                             </tr>
                             <tr>
                                    <td>
                                        <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>                           
                                    </td>
                             </tr>
                             <tr>
                                 <td>
                                      <table style="border: dashed;" > 
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqValtxtTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="Please enter news page title" ></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMenu" runat="server" Text="Select Menu"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="drpDownMenu" runat="server" Width="200px">
                                                          <asp:ListItem Value="" Text="Select"></asp:ListItem>                                           
                                                     </asp:DropDownList>
                                                     <asp:RequiredFieldValidator ID="reqValMenu" runat="server" InitialValue="0" ControlToValidate="drpDownMenu" ErrorMessage="Select menu">
                                                    </asp:RequiredFieldValidator> 
                                                </td>
                                            </tr> 
                                           <tr>
                                                <td>
                                                    <asp:Label ID="lblPageStatus" runat="server" Text="Select status"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="drpDownStatus" runat="server" Width="200px">
                                                            <asp:ListItem Value="1" Text="Draft"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Publish"></asp:ListItem>                                    
                                                     </asp:DropDownList>
                                                </td>
                                            </tr> 
                                           <tr>
                                                <td>
                                                    <asp:Label ID="lblContent" runat="server" Text="Content"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="30" Columns="80" CssClass="mcetiny"></asp:TextBox>
                                                </td>
                                            </tr> 
                                            <tr>
                                                <td></td>
                                                <td>
                                                     <techKriti:ButtonControl ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" RequiredActionPermission="AddPage" OnClientClick="tinyMCE.triggerSave(false,true);" ></techKriti:ButtonControl>
                                                     <techKriti:ButtonControl ID="btnUpdate" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdatePage" OnClientClick="tinyMCE.triggerSave(false,true);" ></techKriti:ButtonControl>
                                                     <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" CausesValidation="false"></asp:Button>  
                                                </td>
                                            </tr>
                                      </table>
                                 </td>
                             </tr>
                    </table>
           </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
