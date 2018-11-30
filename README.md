Simple way to use a google recaptcha control in a web form project

https://www.google.com/recaptcha/intro/v3.html

Please edit the web config file with your secret key and site key

This project is developed in FW 4.6.1,but the job in completly done in the file UserControl/CatchaGoogle.ascx

This control allow to use a simple google captcha in your web form login process: the trick consists into the use of a custom validator with both client and server side validation.
Please note that you must specify a validation group where referring the user control, in order to execute all the controls you need. In the example I use Login control with a LayoutTemplate and a Login Button with the same Validation Group of the CaptchaGoogle UC.
