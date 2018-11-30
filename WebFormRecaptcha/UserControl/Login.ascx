<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="WebFormRecaptcha.UserControl.Login" %>
<%@ Register Src="~/UserControl/CaptchaGoogle.ascx" TagPrefix="uc1" TagName="CaptchaGoogle" %>

<div id="divAnonymousTemplate" runat="server">
    <asp:Login ID="ucLogin" runat="server" OnAuthenticate="ucLogin_Authenticate" ValidationGroup="wcLogin">

        <LayoutTemplate>

            <asp:TextBox ID="UserName" runat="server" placeholder="Nome Utente" class="usernameTxt"
                required />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                ErrorMessage="*" ToolTip="Il nome utente è obbligatorio." ValidationGroup="wcLogin"
                Text="*" SetFocusOnError="true" Display="Dynamic" />
            <asp:TextBox ID="Password" runat="server" TextMode="Password" AutoCompleteType="Disabled"
                class="passwordTxt" autocomplete="off" placeholder="password" MaxLength="20"
                required />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password"
                ErrorMessage="*" ToolTip="La password è obbligatoria." ValidationGroup="wcLogin"
                Text="*" SetFocusOnError="true" Display="Dynamic" />


            <asp:Button ID="btnLogin" runat="server" Text="accedi" CommandName="Login" ValidationGroup="wcLogin"
                ClientIDMode="Static" />

            <uc1:CaptchaGoogle runat="server" ID="CaptchaGoogle" ValidationGroup="wcLogin" />
        </LayoutTemplate>
    </asp:Login>
    <%--<uc1:CaptchaGoogle runat="server" ID="CaptchaGoogle" ValidationGroup="wcLogin" />--%>
</div>
<div id="divLoggedInTemplate" runat="server" style="padding-top: 15px; padding-bottom: 15px">
    Welcome
    <asp:LoginName ID="LoginName1" runat="server" Font-Bold="true" />
    <br />
    <br />
    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Logout" />
</div>
