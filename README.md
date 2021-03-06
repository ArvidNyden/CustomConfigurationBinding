# Custom Configuration Bindings

This is probably not a problem when using regular AppSettings but I found it hard to bind my configuration when using environment variables as well as custom providers as Azure Key Vault or AWS Parameter Store. Their naming conventions just don't mapp to what I want my property names to be. 

## Framework

The library is built in Net Standard 2.0 but can be downloaded and rebuilt to whatever you need. 

### How To

[Net Core 2.0 Api Example](NetCoreApiExample)


Startup.cs
```csharp
services.ConfigureCustom<MyConfiguration>(Configuration);
```
ValuesController.cs
```csharp
[HttpGet]
public MyConfiguration Get([FromServices] IOptions<MyConfiguration> conf)
{
    return conf.Value;
}
```

MyConfiguration.cs
```csharp
services.ConfigureCustom<MyConfiguration>(Configuration);

public class MyConfiguration
{
    [BindToConfiguration("setting-1")]
    public string FromAppSettings1 { get; set; }

    [BindToConfiguration("setting-2")]
    public string FromAppSettings2 { get; set; }

    public string FromAppSettings3 { get; set; }
}
```
appsettings.json
```json
{
  "setting-1" :  "Setting1", 
  "setting-2" :  "Setting2", 
  "FromAppSettings3" :  "Setting3"
}
```
