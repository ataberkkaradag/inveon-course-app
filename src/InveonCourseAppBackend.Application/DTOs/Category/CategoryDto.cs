﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.DTOs.Category
{
    public class CategoryDto
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
    }
}
