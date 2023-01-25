using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Services;
using Dws.Note_one.Api.Persistence.Repositories.IRepositories;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Services.Communication;

namespace Dws.Note_one.Api.Domain.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse {
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
}