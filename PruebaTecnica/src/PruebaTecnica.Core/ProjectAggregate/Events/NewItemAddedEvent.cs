﻿using PruebaTecnica.SharedKernel;

namespace PruebaTecnica.Core.ProjectAggregate.Events;
public class NewItemAddedEvent : BaseDomainEvent
{
  public ToDoItem NewItem { get; set; }
  public Project Project { get; set; }

  public NewItemAddedEvent(Project project,
      ToDoItem newItem)
  {
    Project = project;
    NewItem = newItem;
  }
}
