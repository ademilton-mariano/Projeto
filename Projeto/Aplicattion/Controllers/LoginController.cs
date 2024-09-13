using Microsoft.AspNetCore.Mvc;
using Projeto.Aplicattion.Services;
using Projeto.Domain.ViewModels;
using Projeto.Infra;

namespace Projeto.Aplicattion.Controllers;


[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly TokenService _tokenService;

    public LoginController(DataContext dataContext, TokenService tokenService)
    {
        _dataContext = dataContext;
        _tokenService = tokenService;
    }


    [HttpPost]
    public IActionResult Login([FromBody] LoginViewModel login)
    {
        var usuario = _dataContext.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
        
        if (usuario == null)
        {
            return NotFound("Usuário não encontrado");
        }
        
        var token = _tokenService.GerarToken(login);
        
        return Ok(usuario);
    }
    
    
    
}