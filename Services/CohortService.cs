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
		public Cohort UpdateCohortName(string name, int id);
	}

	public class CohortService : Service<Cohort>, ICohortService
	{
		public CohortService(DataContext context) : base(context) { }

		public Cohort UpdateCohortName(string name, int id)
		{
			var cohort = _context.Cohorts.Find(id);

			if (cohort == null)
				throw new AppException("The cohort you're trying to update doesn't exist");

			cohort.Name = name;
			_context.SaveChanges();

			return cohort;
		}

		public void gg()
		{
			//_context.Cohorts.Find(1).Assignments.Add(new Assignment());
		}
	}
}
