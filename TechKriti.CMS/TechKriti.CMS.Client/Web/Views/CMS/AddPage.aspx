<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="TechKriti.CMS.Administration.Web.Views.CMS.AddPage" MasterPageFile="~/Web/Shared/Site.Master" ValidateRequest="false" %>

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

            <h1 class="page-header">Add Pages</h1>
            <asp:Label ID="lblStatus" CssClass="alert alert-success" Style="display: table;" runat="server" Visible="false"></asp:Label>

            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblTitle" runat="server" Text="Title"></asp:Label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqValtxtTitle" Display="Dynamic" SetFocusOnError="True" CssClass="alert alert-danger"
                            runat="server" ControlToValidate="txtTitle" ErrorMessage="Please enter news page title"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblSeoTitle" runat="server" Text="Seo Title"></asp:Label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtSeoTitle" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblMetaKeys" runat="server" Text="Meta Keys"></asp:Label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtMetaKeys" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblDescription" runat="server" Text="Description"></asp:Label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblH1" runat="server" Text="H1"></asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtH1" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <asp:Label CssClass="col-sm-1 control-label" ID="lblH2" runat="server" Text="H2"></asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtH2" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblMenu" runat="server" Text="Select Menu"></asp:Label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="drpDownMenu" CssClass="form-control dropdown" runat="server">
                            <asp:ListItem Value="" Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqValMenu" Display="Dynamic" SetFocusOnError="True" CssClass="alert alert-danger" runat="server" InitialValue="0" ControlToValidate="drpDownMenu" ErrorMessage="Select menu">
                        </asp:RequiredFieldValidator>
                    </div>

                    <asp:Label CssClass="col-sm-2 control-label" ID="lblPageStatus" runat="server" Text="Select status"></asp:Label>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="drpDownStatus" CssClass="form-control dropdown" runat="server">
                            <asp:ListItem Value="1" Text="Draft"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Publish"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label CssClass="col-sm-2 control-label" ID="lblContent" runat="server" Text="Content"></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtContent" CssClass="mcetiny form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-2 control-label">&nbsp;</div>
                    <div class="col-sm-10">
                        <techKriti:ButtonControl ID="btnSave" CssClass="btn btn-primary" Text="Save" runat="server" OnClick="btnSave_Click" RequiredActionPermission="AddPage" OnClientClick="tinyMCE.triggerSave(false,true);"></techKriti:ButtonControl>
                        <techKriti:ButtonControl ID="btnUpdate" CssClass="btn btn-primary" Text="Update" runat="server" OnClick="btnSave_Click" RequiredActionPermission="UpdatePage" OnClientClick="tinyMCE.triggerSave(false,true);"></techKriti:ButtonControl>
                        <asp:Button ID="btnCancel" CssClass="btn btn-warning" Text="Cancel" runat="server" OnClick="btnCancel_Click" CausesValidation="false"></asp:Button>
                    </div>
                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
