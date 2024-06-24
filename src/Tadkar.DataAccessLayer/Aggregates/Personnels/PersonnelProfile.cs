using AutoMapper;
using Tadkar.Application.Aggregates.Personnels.Queries;
using Tadkar.Core.Aggregates.Personnels;

namespace Tadkar.DataAccessLayer.Aggregates.Personnels
{
    public class PersonnelProfile: Profile
    {
        public PersonnelProfile()
        {
            CreateMap<Personnel, PersonnelQueryResult>();
        }
    }
}
