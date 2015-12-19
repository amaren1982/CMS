<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="TechKriti.CMS.Client.Public.LogOn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TechKriti CMS</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="web/lib/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="web/css/main.css" rel="stylesheet" type="text/css" />
    <link href="web/lib/bootstrap/css/bootstrap-theme.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js" type="text/javascript"></script>
    <script src="<%= ResolveClientUrl("~/Web/lib/bootstrap/js/bootstrap.js")%>" type="text/javascript"></script>

    <style type="text/css">
        body {
            background: url(web/images/login_bg.jpg) no-repeat;
            padding-top: 40px;
            padding-bottom: 40px;
            color: #fff !important;
        }

        .partnerLogo {
            max-width: 600px;
            text-align: center;
            margin: 0 auto 20px;
        }

        .form-signin {
            background: #353535;
            max-width: 600px;
            margin: 0 auto 20px;
            border-top: 5px solid #222;
            border-bottom: 5px solid #222;
        }

        .form-signin-heading {
            background: #2f3031;
            color: #fff;
            font-family: "Times New Roman", Times, serif;
            font-size: 30px;
            padding: 5px 20px;
            margin: 1px 0px;
        }

        .form-signin-content {
            padding: 25px 20px 15px 20px;
            margin: 1px 0;
            border-top: 1px solid #222;
            border-bottom: 1px solid #222;
        }

            .form-signin-content label {
                color: #fff;
                font-weight: normal;
            }

        .form-signin input[type="text"],
        .form-signin input[type="password"] {
            font-size: 16px;
            height: auto;
            padding: 7px 9px;
            color: #333;
        }

        .refresh_label {
            display: inline;
            padding: 1.2em .6em .3em;
            font-size: 85%;
            color: #fff;
            white-space: nowrap;
        }

        .captcha_img {
            padding: 1px;
            border: 1px solid #fff;
        }
    </style>
</head>
<body>
    <div class="container">
<%--        <div class="partnerLogo">
            <img id="Img1" src="~/Web/images/TechKritiLogo.png" runat="server" />
        </div>--%>
        <form id="form1" class="form-signin" runat="server" defaultbutton="btnLogin">
            <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="uptPanelLogin" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="form-signin-heading">
                        <asp:Label ID="lblHeader" runat="server" Text="Please sign in"></asp:Label></h1>
                    </div>
                    <div class="form-signin-content clearfix">
                        <asp:Label ID="lblErrorMessage" runat="server" Style="display: block; margin-bottom: 10px; padding: 10px; color: #333;" CssClass="bg-danger" Visible="false"></asp:Label>
                        <div class="form-group clearfix">

                            <asp:Label ID="lblUsername" runat="server" Text="Username" class="control-label col-xs-3"></asp:Label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                            </div>
                            <div class="refresh_label col-xs-3">
                                <i>
                                    <asp:RequiredFieldValidator ID="reqValtxtUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter username..."></asp:RequiredFieldValidator>
                                </i>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <asp:Label ID="lblPassword" runat="server" Text="Password" class="control-label col-xs-3"></asp:Label><div class="col-xs-6">
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                            <div class="refresh_label col-xs-3">
                                <i>
                                    <asp:RequiredFieldValidator ID="reqValtxtPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter password..."></asp:RequiredFieldValidator>
                                    &nbsp;</i>
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <label for="inputPassword" class="control-label col-xs-3">Captcha</label>
                            <div class="col-xs-6">
                                <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
                                <asp:Label ID="lblCaptchaLabel" runat="server" Text="Type the text below"></asp:Label>
                            </div>
                            <div class="refresh_label col-xs-3">
                                <i>
                                    <asp:RequiredFieldValidator ID="reqValtxtCaptcha" runat="server" ControlToValidate="txtCaptcha" ErrorMessage="Please enter image text..."></asp:RequiredFieldValidator>
                                </i>
                            </div>
                        </div>
                        <div class="form-group clearfix">

                            <div class="col-xs-offset-3 col-xs-9">
                                <asp:Image ID="imageCaptcha" runat="server" ImageUrl="~/Web/Utilities/CImage.aspx" CssClass="captcha_img" />
                                <asp:Button ID="btnCaptchaRefresh" CssClass="btn btn-info" runat="server" OnClick="btnCaptchaRefresh_Click" Text="Refresh" CausesValidation="false" />
                            </div>
                        </div>
                        <div class="form-group clearfix">
                            <div class="col-xs-offset-3 col-xs-9">
                                <asp:Button ID="btnLogin" Text="Login" runat="server" CssClass="btn btn-primary" OnClick="btnLogin_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </div>
</body>
</html>