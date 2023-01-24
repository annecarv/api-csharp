using Dws.Note_one.Api.Domain.Models;

namespace Dws.Note_one.Api.Domain.Services.Communication
{
    public Category Category { get; private set;}

    private SaveCategoryResponse(bool success, string message, Category category) : base(success, message)
    {
        Category = category;
    }

    public SaveCategoryResponse(Category category) : this(true, string.Empty, category)
    { }

    public SaveCategoryResponse(string message) : this(false, message, null)
    { }
}