<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="TechKriti.CMS.Administration.Public.LogOn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnLogin">

         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="uptPanelLogin" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                 <table border="1" style="width:90%; background-color:aqua;"  >
            <tr>
                <td colspan="2"><h1>
                    <asp:Label ID="lblHeader" runat="server" Text="LOGIN HERE" ></asp:Label></h1> 
                </td>                
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblErrorMessage" runat="server" Visible="false" ></asp:Label>
                </td>
            </tr>
            <tr>
                 <td style="width:50%">
                     <table border="0" style="width:80%" >                        
                         <tr>
                            <td>
                                <h3><asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label></h3>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox>                               
                                <asp:RequiredFieldValidator ID="reqValtxtUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter username..." ></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                         <tr>
                            <td>
                               <h3> <asp:Label ID="lblPassword" runat="server" Text="Password" ></asp:Label></h3>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqValtxtPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter password..." ></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                         <tr>
                             <td>
                                 Word verification
                             </td>
                             <td>
                                   <asp:Label ID="lblCaptchaLabel" runat="server" Text="Type the characters you see below"></asp:Label>
                             </td>
                         </tr>                        
                         <tr>
                             <td></td>
                             <td>
                                  <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="reqValtxtCaptcha" runat="server" ControlToValidate="txtCaptcha" ErrorMessage="Please enter image text..." ></asp:RequiredFieldValidator>
                             </td>                             
                         </tr>
                         <tr>
                             <td>

                             </td>
                             <td>
                                    <asp:Image ID="imageCaptcha" runat="server" ImageUrl="~/Web/Utilities/CImage.aspx" />
                                    <asp:Button ID="btnCaptchaRefresh" runat="server" OnClick="btnCaptchaRefresh_Click" Text="Refresh" CausesValidation="false" />
                             </td>
                         </tr>
                         <tr>
                             <td></td>
                             <td>
                                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click"></asp:Button>
                             </td>
                        </tr> 
                     </table>
                </td>
                 <td>
                      COMPANY LOGO GOES HERE
                </td>
          </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
