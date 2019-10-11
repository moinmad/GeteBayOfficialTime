This program is licensed under the terms of the eBay Common Development and
Distribution License (CDDL) Version 1.0 (the "License") and any subsequent
version thereof released by eBay.  The then-current version of the License
can be found at http://www.opensource.org/licenses/cddl1.php

This is a commmand-line application that gets the current official eBay time. This demonstrates the simplest call that can be made to the eBay API.

This sample was created using Microsoft Visual C# 2005 Express Edition.

To get started with this example Open the GeteBayOfficialTime.csproj file with visual studio.

You must edit the values in the App.config file and insert your Application ID, Developer ID and Certificate ID which are obtained from http://developer.ebay.com. You must also insert the Token representing the eBay user who is making the call. Yu must enter the URL of the eBay server you wish to make the call to. This can be the Sandbox or Production servers. Remember, you will need different keys for each one.

This application uses SOAP to make the request.

