# GenericController

Provides a way to use a generic controller parametrizable with routeable models.

### Usage

Just add a generic controller and then call `app.UseGenericController()` in your `ConfigureServices` method to wire it up.

Models should be annotated with the built-in `[Route]` attribute.

```
using SHF.GenericController

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
      services.UseGenericController();
  }
}

public class MainController<TModel>
{
  // ...
}

[Route("/route")]
public class SomeModel
{
}
```
