

using Core.Exceptions;
using ToDoProject.Model.Categories.Entity;
using ToDoProject.Service.Constants;

namespace ToDoProject.Service.Categories.Rules;

public class CategoryBusinessRules
{
    public void CategoryExists(Category? category)
    {
        if (category is null)
        {
            throw new NotFoundException(Messages.CategoryNotFoundMessage);
        }
    }

    public void CategoryNameDoesNotExist(bool nameExists)
    {
        if (nameExists)
        {
            throw new BusinessException(Messages.CategoryNameExistMessage);
        }
    }
}
