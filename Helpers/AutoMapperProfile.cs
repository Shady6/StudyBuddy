using AutoMapper;
using stud_bud_back.Entities;
using stud_bud_back.Models.Cohort;
using stud_bud_back.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stud_bud_back.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();

            CreateMap<CohortCreationModel, Cohort>();
            CreateMap<Cohort, CohortPublicModel>();
        }
    }
}
