﻿using Frontend.Models;
using Frontend.Models.Dto;

namespace Frontend.Services.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto assignRoleRequestDto);
    }
}
