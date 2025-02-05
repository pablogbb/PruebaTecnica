﻿using Ardalis.Specification;

namespace PruebaTecnica.Core.ProjectAggregate.Specifications;
public class IncompleteItemsSpec : Specification<ToDoItem>
{
  public IncompleteItemsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}
