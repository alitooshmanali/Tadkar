using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tadkar.Application.Aggregates.Personnels.Commands.CreateCommand;
using Tadkar.Application.Aggregates.Personnels.Commands.DeleteCommand;
using Tadkar.Application.Aggregates.Personnels.Commands.UpdateCommand;
using Tadkar.Application.Aggregates.Personnels.Queries.GetPersonnelById;
using Tadkar.Application.Aggregates.Personnels.Queries.GetPersonnelCollection;
using Tadkar.RestApi.Controllers.V1.Models;
using Tadkar.RestApi.Controllers.V1.Personnels.Models;

namespace Tadkar.RestApi.Controllers.V1.Personnels
{
    [ApiVersion("1")]
    [ApiController]
    [Route("rest/api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PersonnelsController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IMediator mediator;

        public PersonnelsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<PersonnelResponse>>> CreatePersonnel(
            [FromBody] CreatePersonnelRequest request,
            CancellationToken cancellationToken)
        {
            var command = mapper.Map<CreatePersonnelCommand>(request);
            await mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ResponseCollectionModel<PersonnelResponse[]>>> GetAllPersonnels(CancellationToken cancellationToken)
        {
            var query = new GetPersonnelCollectionQuery();
            var queryResult = await mediator.Send(query, cancellationToken).ConfigureAwait(false);

            return Ok(new ResponseCollectionModel<PersonnelResponse>
            {
                Values = mapper.Map<PersonnelResponse[]>(queryResult.Result),
                TotalCount = queryResult.TotalCount
            });
        }

        [HttpGet("{personnelId:int}")]
        public async Task<ActionResult<ResponseModel<PersonnelResponse>>> GetPersonnelById(
            int personnelId,
            CancellationToken cancellationToken)
        {
            var query = new GetPersonnelByIdQuery { PersonnelId = personnelId };
            var queryResult = await mediator.Send(query, cancellationToken).ConfigureAwait(false);

            if (queryResult is null)
                return NotFound();

            return Ok(new ResponseModel<PersonnelResponse> { Values = mapper.Map<PersonnelResponse>(queryResult) });
        }

        [HttpPut("{personnelId:int}")]
        public async Task<ActionResult> UpdatePersonnel(
            int personnelId,
            UpdatePersonnelRequest request,
            CancellationToken cancellationToken)
        {
            var command = mapper.Map<UpdatePersonnelCommand>(request);
            command.PersonnelId = personnelId;

            await mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return NoContent();
        }

        [HttpDelete("{personnelId:int}")]
        public async Task<ActionResult> DeleteUser(int personnelId, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeletePersonnelCommand { PersonnelId = personnelId }, cancellationToken)
                .ConfigureAwait(false);

            return Ok();
        }
    }
}
