Himmelsk Social Api
===================

A simple C# library for accessing social networks REST APIs.

### Supported commands
- LinkedIn
  - Companies/Share
  - Companies/GetUpdates
  - People/Share
- Facebook
  - User/PublishUserFeed
- Twitter
  - Followers/Ids
  - Statuses/Update
  - Statuses/UserTimeline
  - Statuses/HomeTimeline
  
### Dependencies
I try to keep the number of dependencies to a minimum. It currently only references Json.NET, which is available as a NuGet package and as a Xamarin component.

### Example
The library is designed to be as user friendly as possible. Here is an example:

    var social = new SocialClient();
	var credentials = social.LinkedIn.GetCredentials("consumerKey", "consumerSecret", "token", "tokenSecret");	

	// Get all updates from company with ID 2414183
	var result = social.LinkedIn.Companies.GetCompanyUpdates(credentials, "2414183");
	
	// Post new update to Company wall
	social.LinkedIn.Commands.CreateCompanyShare(credentials, "2414183", ShareVisibility.Anyone, "Hi everyone, here is a test comment from Paris!");
	
### Upcoming features
- New commands for LinkedIn
- New commands for Facebook
- New commands for Twitter