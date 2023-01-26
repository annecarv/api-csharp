using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Services;
using Dws.Note_one.Api.Domain.Repositories.IRepositories;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Services.Communication;

namespace Dws.Note_one.Api.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse {
    public Category Category { get; private set;}

    private CategoryResponse(bool success, string message, Category category) : base(success, message)
    {
        Category = category;
    }

    public CategoryResponse(Category category) : this(true, string.Empty, category)
    { }

    public CategoryResponse(string message) : this(false, message, null)
    { }
    }
}