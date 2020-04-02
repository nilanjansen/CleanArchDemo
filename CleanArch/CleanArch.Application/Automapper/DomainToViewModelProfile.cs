﻿using AutoMapper;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Automapper
{
    public class DomainToViewModelProfile: Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Course, CourseViewModel>();
        }
    }
}