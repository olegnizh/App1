﻿using System;
namespace App1.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public List<User> Users { get; set; } = new List<User>();
    }
}

