﻿using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Abstraction.Repositories
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
    }
}