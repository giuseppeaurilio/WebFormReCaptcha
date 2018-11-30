<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaptchaGoogle.ascx.cs" Inherits="WebFormRecaptcha.UserControl.CaptchaGoogle" %>

<script src="https://www.google.com/recaptcha/api.js"></script>
<script type="text/javascript">
    var onloadCallback = function (data) {
        $("#hfCaptchaValidation").val(data);
    };
    function CaptchaClientValidation(source, args) {
        var isnull = $("#hfCaptchaValidation").val() === "";
        args.IsValid = !isnull;
    };
</script>

<asp:Panel runat="server" ID="divCaptcha" CssClass="login-captcha">
    <asp:HiddenField ID="hfCaptchaValidation" runat="server" ClientIDMode="Static" />
    <asp:CustomValidator ID="cvCaptcha" runat="server"
        OnServerValidate="cvCaptcha_ServerValidate" ClientValidationFunction="CaptchaClientValidation"></asp:CustomValidator>

    <div class="g-recaptcha" id="recaptcha" data-sitekey="<%= ConfigurationManager.AppSettings["CaptchaSiteKey"] %>" data-callback='onloadCallback'></div>
</asp:Panel>
