

using Core.Exceptions;
using ToDoProject.Model.Categories.Entity;

namespace ToDoProject.Service.Categories.Rules;

public class CategoryBusinessRules
{
    public void CategoryExists(Category? category)
    {
        if (category is null)
        {
            throw new NotFoundException("Kategori bulunamadı.");
        }
    }

    public void CategoryNameDoesNotExist(bool nameExists)
    {
        if (nameExists)
        {
            throw new BusinessException("Kategori ismi veritabanında bulunmaktadır.");
        }
    }
}
