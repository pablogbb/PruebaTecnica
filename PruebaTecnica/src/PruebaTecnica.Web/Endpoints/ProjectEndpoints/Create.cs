﻿using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.ProjectAggregate;
using PruebaTecnica.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PruebaTecnica.Web.Endpoints.ProjectEndpoints;
public class Create : EndpointBaseAsync
    .WithRequest<CreateProjectRequest>
    .WithActionResult<CreateProjectResponse>
{
  private readonly IRepository<Project> _repository;

  public Create(IRepository<Project> repository)
  {
    _repository = repository;
  }

  [HttpPost("/Projects")]
  [SwaggerOperation(
      Summary = "Creates a new Project",
      Description = "Creates a new Project",
      OperationId = "Project.Create",
      Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<CreateProjectResponse>> HandleAsync(CreateProjectRequest request,
      CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      return BadRequest();
    }

    var newProject = new Project(request.Name, PriorityStatus.Backlog);

    var createdItem = await _repository.AddAsync(newProject); // TODO: pass cancellation token

    var response = new CreateProjectResponse
    (
        id: createdItem.Id,
        name: createdItem.Name
    );

    return Ok(response);
  }
}
