# Vostok.AspNetCore.Context

[![Build status](https://ci.appveyor.com/api/projects/status/github/vostok/aspnetcore.context?svg=true&branch=master)](https://ci.appveyor.com/project/vostok/aspnetcore.context/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Vostok.AspNetCore.Context.svg)](https://www.nuget.org/packages/Vostok.AspNetCore.Context)

Middleware for restoring distributed context properties and globals from HttpContext


**Build guide**: https://github.com/vostok/devtools/blob/master/library-dev-conventions/how-to-build-a-library.md

**User documentation**: not written yet.

**Usage**:

Add nuget package `Vostok.AspNetCore.Context`:
```powershell
Install-Package Vostok.AspNetCore.Context -ProjectName MyProject
```

Add required services and add middleware to the pipeline before all other middlewares
```C#
public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddDistributedContext(); // registers required services
  }
  
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.UseDistributedContext(); // add middleware to the pipeline
    
    // other middlewares, e.g. app.UseMvc();
  }
}
```
