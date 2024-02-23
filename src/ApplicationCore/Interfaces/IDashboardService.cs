﻿using ApplicationCore.DTOs;
using ApplicationCore.Wrappers;

namespace ApplicationCore.Interfaces
{
    public interface IDashboardService
    {
        Task<Response<object>> GetData();
        //Task<Response<int>> CreateUserAsync(UserDto request);
    }
}
