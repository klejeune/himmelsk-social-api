Himmelsk Social Api
===================

A simple C# library for accessing social networks REST APIs.

### Supported commands
- LinkedIn
  - Companies/Share
  - Companies/GetUpdates
  - People/Share
  
### Dependencies
I try to keep the number of dependencies to a minimum. It currently only references Json.NET, which is available as a NuGet package.

### Example
The library is designed to be as user friendly as possible. Here is an example:

    var linkedIn = new LinkedInClient();
	var credentials = linkedIn.GetCredentials("consumerKey", "consumerSecret", "token", "tokenSecret");	

	// Get all updates from company with ID 2414183
	var result = linkedIn.Companies.GetCompanyUpdates(credentials, "2414183");
	
	// Post new update to Company wall
	linkedIn.Commands.CreateCompanyShare(credentials, "2414183", ShareVisibility.Anyone, "Hi everyone, here is a test comment from Paris!");
	
### Upcoming features
- New commands for LinkedIn
- Facebook integration
- Twitter integration