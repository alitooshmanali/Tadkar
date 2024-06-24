using AutoMapper;
using Tadkar.Application.Aggregates.Personnels.Commands.CreateCommand;
using Tadkar.Application.Aggregates.Personnels.Commands.UpdateCommand;
using Tadkar.Application.Aggregates.Personnels.Queries;

namespace Tadkar.RestApi.Controllers.V1.Personnels.Models
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreatePersonnelRequest, CreatePersonnelCommand>();
            CreateMap<UpdatePersonnelRequest, UpdatePersonnelCommand>();
            CreateMap<PersonnelQueryResult, PersonnelResponse>();
        }
    }
}
