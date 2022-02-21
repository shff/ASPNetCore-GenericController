# GenericController

Provides a way to use a generic controller parametrizable with routeable models.

### Usage

Start by creating a class with a single generic parameter that either has `Controller` in its name, inherits from `Controller` or has the `[Controller]` attribute. You have to use just one single generic controller.

```
public class MainController<TModel>
{
}
```

Next, create models and annotate them with the regular `[Route]` attribute. Anything annotated with `[Route]` that is not a controller will be discovered by the library.

```
using Microsoft.AspNetCore.Mvc;

[Route("/route")]
public class SomeModel
{
}
```

Last, but not least, call `app.UseGenericController()` in your `ConfigureServices` method to wire it up. This package will discover the controller and the models and wire up everything.

```
using SHF.GenericController;

public void ConfigureServices(IServiceCollection services)
{
  services.UseGenericController();
}
```

## License

```
MIT License

Copyright (c) 2019 Silvio Henrique Ferreira

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
