# GenericController

Provides a way to use a generic controller parametrizable with routeable models.

### Usage

Start by creating a class with a single generic parameter that either has `Controller` in its name, inherits from `Controller` or has the `[Controller]` attribute:

```
public class MainController<TModel>
{
}
```

Next, call `app.UseGenericController()` in your `ConfigureServices` method to wire it up.

Models should be annotated with the built-in `[Route]` attribute.

```
using SHF.GenericController

public void ConfigureServices(IServiceCollection services)
{
  services.UseGenericController();
}
```

Last,  but not least, create models and annotate them with the regular `[Route]` attribute.

```
[Route("/route")]
public class SomeModel
{
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
