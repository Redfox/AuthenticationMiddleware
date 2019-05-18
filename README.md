# Authentication Middleware

 Exemplo de Middleware para verificar usuario logado

### Pages

- Admin (Area Logada)
	- Product
- Home
	- Index
- Accoount
	- Index (Login)

# Middleware


### AuthenticationMiddleware.cs
```C#
public Task Invoke(HttpContext httpContext)
{
	var path = httpContext.Request.Path;

	if(path.HasValue && path.Value.StartsWith("/admin"))
		if (httpContext.Session.GetString("Nome") == null)
	    		httpContext.Response.Redirect("/account");

	return _next(httpContext);
}
```
Verifica se existe uma sessão com "Nome", se não redireciona para logar

### Startup.cs

```C#
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
	//Code

	app.UseMiddleware<AuthenticationMiddleware>();

	//Code
}
```
Implementação do Middleware

### AccountController.cs
```C#
public IActionResult Login(string Nome, string Senha)
{
	if (Nome == null && Senha == null)
		return View("Index");

	HttpContext.Session.SetString("Nome", Nome);
		return View("Welcome");
}
```
Method simples de Login
