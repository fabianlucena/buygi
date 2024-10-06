﻿using backend_buygi.Entities;

namespace backend_buygi.IServices
{
    public interface IPasswordService
    {
        Task<Password> GetSingleForUserId(Int64 userId);
        Task<Password> GetSingleForUser(User user);
        string Hash(string password);
        bool Verify(string rawPassword, string hash);
        bool Verify(string rawPassword, Password password);
    }
}
