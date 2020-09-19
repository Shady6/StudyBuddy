using stud_bud_back.Entities;
using stud_bud_back.Helpers;
using stud_bud_back.Models.Cohort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Services
{
	public interface ICohortService : IService<Cohort>
	{
		public Task<Cohort> UpdateCohortName(string name, int cohortId, int userId);
		new public Task<Cohort> Create(Cohort cohort);
		public Task<bool> IsUserAdmin(int cohortId, int userId);
		public Task<bool> IsUserModerator(int cohortId, int userId);
		public Task<bool> IsUserAtLeastModerator(int cohortId, int userId);
	}

	public class CohortService : Service<Cohort>, ICohortService
	{
		private readonly IUserService _userService;

		public CohortService(DataContext context, IUserService userService) : base(context)
		{
			_userService = userService;
		}

		public override async Task<Cohort> Create(Cohort cohort)
		{
			if (await _userService.Exists((int)cohort.AdminId))
			{
				await _context.Cohorts.AddAsync(cohort);
				await _context.SaveChangesAsync();
				return cohort;
			}
			throw new AppException("Something went wrong");
		}

		public async Task<Cohort> UpdateCohortName(string name, int cohortId, int userId)
		{
			var cohort = await GetById(cohortId);

			if (cohort != null && cohort.AdminId == userId) 
			{
				cohort.Name = name;
				await _context.SaveChangesAsync();
				return cohort;
			}

			throw new AppException("Something went wrong");
		}

		public async Task<bool> IsUserAdmin(int cohortId, int userId)
		{
			Cohort foundCohort = await GetById(cohortId);

			if (foundCohort != null)
				return foundCohort.AdminId == userId;

			throw new AppException("Something went wrong");
		}

		public async Task<bool> IsUserModerator(int cohortId, int userId)
		{
			Cohort foundCohort = await GetById(cohortId);

			if (foundCohort != null)
				return foundCohort.CohortModerator.Any(cm => cm.UserId == userId);

			throw new AppException("Something went wrong");
		}

		public async Task<bool> IsUserAtLeastModerator(int cohortId, int userId) 
		{
			Cohort foundCohort = await GetById(cohortId);

			if (foundCohort != null)
				return foundCohort.AdminId == userId || foundCohort.CohortModerator.Any(cm => cm.UserId == userId);

			throw new AppException("Something went wrong");
		}
	}
}
