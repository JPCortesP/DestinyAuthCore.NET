# DestinyAuthCore.NET
Example of a .NET Core implementation of the new Bungie Auth

__NOT YET WORKING__

This is a simple example of how to use the new Bungie OAuth authentication in .NET. 
This example is made in .NET Core, but should work as a base for anything else C#.

Please note the following:

-  __Is not meant to be highly secure__. Just Works
-  I'm not using any best practices or something like that. Again, just works.
- Any question related to this, should be made on GitHub, or the Bungie.net's dev community.

Somehow my project creation flow managed to avoid licensing stuff. __This is MIT licensed__.

## References:
- User Secrets: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets
- .NET new Configuration stuff: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration

## Running the Example
- Clone the Repo. You're here, you should know how it works.
- Restore the thing, using dotnet restore
- Save the API Key and your Auth URL (from https://bungie.net/developer) into the UserSecrets storage (https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets).
     - Use "ApiKey" and "AuthURL" to store string values.
- Run the thing. Should work. 