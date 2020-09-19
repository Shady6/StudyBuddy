using stud_bud_back.Entities;
using stud_bud_back.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Services
{
	public interface ICourseService : IService<Course>
	{
		public Task<Course> Add(Course course, int cohortId);
	}

	public class CourseService : Service<Course>, ICourseService
	{
		private readonly ICohortService _cohortService;

		public CourseService(DataContext context, ICohortService cohortService) : base(context)
		{
			_cohortService = cohortService;
		}

		public async Task<Course> Add(Course course, int userId)
		{
			if (await _cohortService.IsUserAtLeastModerator((int)course.CohortId, userId)) { 
				_context.Courses.Add(course);
				await _context.SaveChangesAsync();

				return course;
			}

			throw new AppException("Something went wrong");
		}
	}
}
