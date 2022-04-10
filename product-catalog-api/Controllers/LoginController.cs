﻿using Microsoft.AspNetCore.Mvc;
using product_catalog_api.Filters;
using product_catalog_api.Model.Dto;
using product_catalog_api.Model.Security;
using product_catalog_data_access.Interfaces;
using product_catalog_data_model.Exceptions;

namespace product_catalog_api.Controllers;

/// <summary>
/// Kontroller pro přihlašování
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/login")]
[ApiVersion("1.0", Deprecated = true)]
[ApiVersion("2.0")]
public class LoginController : ControllerBase
{
    private readonly IUserDao _userDao;

    private readonly ITokenService _tokenService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="userDao"></param>
    /// <param name="tokenService"></param>
    public LoginController(IUserDao userDao, ITokenService tokenService)
    {
        _userDao = userDao;
        _tokenService = tokenService;
    }

    /// <summary>
    /// Autentifikace uživatele
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("authenticate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserTokenDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
    public async Task<IActionResult> AuthenticateUser(JwtLoginRequest request)
    {
        var user = await _userDao.GetByLogin(request.Username);

        //V produkčním prostředí by byla nějaká validační funkce která by porovnala hashované heslo
        if (user.Password != request.Password)
        {
            return NotFound(new ErrorResult
            {
                Type = nameof(ItemNotFoundException),
                StatusCode = StatusCodes.Status404NotFound,
                Message = "Uživatel nebyl nalezen."
            });
        }

        var token = await _tokenService.GenerateToken(user);

        return Ok(new UserTokenDto { Login = user.Login, Token = token });
    }
}