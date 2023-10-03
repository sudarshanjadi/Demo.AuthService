# Demo.AuthService

Demo.AuthService is abstract of an authentication service and the given code has only the 2Factor authentication, its related controller, services written in .Net Core.

Any client can be used to send SMS to user phone number and its related configurations are available in appsettings.json under SMSClientSettings.
Also to generate the code, the allowed characters and the length of confirmation code is as mentioned in the appsettings.json under SMSConfiguration.

We have 2 endpoints
1. api/TwoFactorAuthController/SendConfirmationCode
	For a given phone number, sends the confirmation code generated to users mobile number and if code is successfully sent to user, returns true if not returns false

2. api/TwoFactorAuthController/VerifyConfirmationCode
	Validates the given code and if validation is successful returns true, if not returns false.

