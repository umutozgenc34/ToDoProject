
using Core.Entities.ReturnModels;
using Core.Exceptions;
using ToDoProject.Model.ToDos.Entity;
using ToDoProject.Repository.ToDos.Abstracts;
using ToDoProject.Service.Constants;

namespace ToDoProject.Service.ToDoS.Rules;

public class ToDoBusinessRules(IToDoRepository toDoRepository)
{
    public  void ToDoExists(ToDo? toDo)
    {
        if (toDo is null)
        {
            throw new NotFoundException(Messages.ToDoNotFoundMessage);
            //return ReturnModel.Fail("ToDo bulunamadı.");
        }
        //return null;
    }

    public  void ToDoTitleDoesNotExist(bool titleExists)
    {
        if (titleExists)
        {
            throw new BusinessException(Messages.ToDoTitleExistMessage);
            //return ReturnModel.Fail("ToDo ismi veritabanında bulunmaktadır");
        }
        //return null;
    }

    public void ToDoDoesNotExist(List<ToDo> toDos)
    {
        if (!toDos.Any())
        {
            throw new NotFoundException(Messages.NotFoundToDoByTitle);
        }
    }

}
