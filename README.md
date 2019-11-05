# GenericController

Provides a way to use a generic controller parametrizable with classes marked with a certain attribute.

### Usage

Just add a generic controller with one generic parameter and use the `app.useGenericController` function to wire it up.

```
using SHF.GenericController

public class Startup
{
  public void Configure(IApplicationBuilder app, IHostingEnvironment env)
  {
    // your startup code
    
    app.useGenericController(typeof(GenericController<>));
  }
}

[AutoRoute("/route")]
public class SomeModel
{
}

public class GenericController<TModel>
{
  // ...
}
```
