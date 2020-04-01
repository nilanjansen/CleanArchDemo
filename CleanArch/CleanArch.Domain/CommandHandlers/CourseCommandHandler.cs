using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandlers
{
    public class CourseCommandHandler : IRequestHandler<CreateCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepo;
        public CourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepo = courseRepository;
        }
        public Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course()
            {
                Name = request.Name,
                Description = request.CourseDesripion,
                ImageUrl = request.ImageUrl
            };

            _courseRepo.Add(course);

            return Task.FromResult(true);
        }
    }
}
