﻿namespace MysqlWebApi.DTO
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
