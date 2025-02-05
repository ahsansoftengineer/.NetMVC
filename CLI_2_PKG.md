### EXTERNAL PACKAGES
- Adding Packages to Specific Project
```bash
dotnet add ./Lagoon.Web/ package AutoMapper 
dotnet add ./Lagoon.Web/ package AspNetCoreRateLimit 
dotnet add ./Lagoon.Web/ package Marvin.Cache.Headers 
dotnet add ./Lagoon.Web/ package Microsoft.AspNetCore.Mvc.Versioning 
dotnet add ./Lagoon.Web/ package Microsoft.EntityFrameworkCore.Design 
dotnet add ./Lagoon.Web/ package Microsoft.EntityFrameworkCore.Tools 
dotnet add ./Lagoon.Web/ package X.PagedList.Mvc.Core 

dotnet add ./Lagoon.App/ package OneOf # Drawback of Scalability used in App Layer
dotnet add ./Lagoon.App/ package FluentResults # It has Lack Some Ability of OneOf used in App Layer
dotnet add ./Lagoon.App/ package FluentValidation
dotnet add ./Lagoon.App/ package FluentValidation.AspNetCore
dotnet add ./Lagoon.App/ package Mapster
dotnet add ./Lagoon.App/ package MediatR
dotnet add ./Lagoon.App/ package MediatR.Extension.Microsoft.DependencyInjection
dotnet add ./Lagoon.App/ package Microsoft.Extensions.DependencyInjection.Abstractionst

dotnet add ./Lagoon.Domain/ package ErrorOr # Recommended and Final Approach

dotnet add ./Lagoon.Infra/ package DynamicExpressions.NET
dotnet add ./Lagoon.Infra/ package LinqKit.Core
dotnet add ./Lagoon.Infra/ package Microsoft.EntityFrameworkCore 
dotnet add ./Lagoon.Infra/ package Microsoft.EntityFrameworkCore.SqlServer
dotnet add ./Lagoon.Infra/ package Microsoft.EntityFrameworkCore.Design
dotnet add ./Lagoon.Infra/ package Microsoft.EntityFrameworkCore.Tools
dotnet add ./Lagoon.Infra/ package Microsoft.EntityFrameworkCore.DynamicLinq
dotnet add ./Lagoon.Infra/ package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add ./Lagoon.Infra/ package Microsoft.AspNetCore.Authentication.OpenIdConnect
dotnet add ./Lagoon.Infra/ package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add ./Lagoon.Infra/ package Microsoft.Extensions.Configuration
dotnet add ./Lagoon.Infra/ package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add ./Lagoon.Infra/ package X.PagedList
dotnet add ./Lagoon.Infra/ package X.PagedList.Mvc.Core
```
