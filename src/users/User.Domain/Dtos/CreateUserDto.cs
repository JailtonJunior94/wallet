﻿using System;

namespace User.Domain.Dtos
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
