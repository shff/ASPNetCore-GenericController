# GenericController

Provides a way to use a generic controller parametrizable with routeable models.

### Usage

Just add a generic controller annotated with `[GenericController]` and call `app.UseGenericController()` in your `ConfigureServices` method to wire it up.

Models should be annotated with the `[AutoRoute]` attribute.

```
using SHF.GenericController

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
      services.UseGenericController();
  }
}

[GenericController]
public class MainController<TModel>
{
  // ...
}

[AutoRoute("/route")]
public class SomeModel
{
}
```
