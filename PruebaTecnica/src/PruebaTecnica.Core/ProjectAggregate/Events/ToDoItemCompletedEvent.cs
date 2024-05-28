using PruebaTecnica.Core.ProjectAggregate;
using PruebaTecnica.SharedKernel;

namespace PruebaTecnica.Core.ProjectAggregate.Events;
public class ToDoItemCompletedEvent : BaseDomainEvent
{
  public ToDoItem CompletedItem { get; set; }

  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }
}
