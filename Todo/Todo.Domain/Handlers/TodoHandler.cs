using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
    Notifiable,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        
        {
            //Fail Fest Validation
            command.Validate();
            if(command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que a sua tarefa está errada!", command.Notifications);

            // Gerar Um TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            _repository.Create(todo);

            return new GenericCommandResult(true, "Tarefa Salva", todo);

        }
        
        public ICommandResult Handle(UpdateTodoCommand command)
               {
            //Fail Fest Validation
            command.Validate();
            if(command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que a sua tarefa está errada!", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            // Gerar Um TodoItem
            todo.UpdateTitle(command.Title);

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa Salva", todo);

        }
    
        public ICommandResult Handle(MarkTodoAsDoneCommand command)
               {
            //Fail Fest Validation
            command.Validate();
            if(command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que a sua tarefa está errada!", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            // Gerar Um TodoItem
            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa Salva", todo);

        }
    
    
        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
               {
            //Fail Fest Validation
            command.Validate();
            if(command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que a sua tarefa está errada!", command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            // Gerar Um TodoItem
            todo.MarkAsUnDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa Salva", todo);

        }
    }
}