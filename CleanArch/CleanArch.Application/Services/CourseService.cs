using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepo;
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepo, IMediatorHandler bus, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _bus = bus;
            _mapper = mapper;
        }

        public void Create(CourseViewModel courseViewModel)
        {
            //var createCourseCommand = new CreateCourseCommand(
            //        courseViewModel.Name,
            //        courseViewModel.Description,
            //        courseViewModel.ImageUrl
            //    );
            _bus.SendCommand(_mapper.Map<CreateCourseCommand>(courseViewModel));
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            return _courseRepo.GetCourses().ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
