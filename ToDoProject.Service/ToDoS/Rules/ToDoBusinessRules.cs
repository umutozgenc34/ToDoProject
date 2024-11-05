
using Core.Entities.ReturnModels;
using Core.Exceptions;
using ToDoProject.Model.ToDos.Entity;
using ToDoProject.Repository.ToDos.Abstracts;

namespace ToDoProject.Service.ToDoS.Rules;

public class ToDoBusinessRules(IToDoRepository toDoRepository)
{
    public  void ToDoExists(ToDo? toDo)
    {
        if (toDo is null)
        {
            throw new NotFoundException("ToDo bulunamadı");
            //return ReturnModel.Fail("ToDo bulunamadı.");
        }
        //return null;
    }

    public  void ToDoTitleDoesNotExist(bool titleExists)
    {
        if (titleExists)
        {
            throw new BusinessException("ToDo ismi veritabanında bulunmaktadır");
            //return ReturnModel.Fail("ToDo ismi veritabanında bulunmaktadır");
        }
        //return null;
    }
}
