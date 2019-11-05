# GenericController

Provides a way to use a generic controller parametrizable with classes marked with a certain attribute.

### Usage

Just add a generic controller with one generic parameter and use the `app.useGenericController` function to wire it up.

```
[AutoRoute("/route")]
public class SomeModel
{
}
```

```
public class GenericController<TModel>
{
  // ...
}
```

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
```

### License

```
The MIT License

Copyright (c) 2019 Silvio Henrique Ferreira

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
```
