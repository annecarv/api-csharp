using System.Collections.Generic;
using System.Threading.Tasks;
using Dws.Note_one.Api.Domain.Services;
using Dws.Note_one.Api.Domain.Repositories.IRepositories;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Domain.Services.Communication;

namespace Dws.Note_one.Api.Domain.Services.Communication
{
    public class StoreResponse : BaseResponse {
    public Store Store { get; private set;}

    private StoreResponse(bool success, string message, Store store) : base(success, message)
    {
        Store = store;
    }

    public StoreResponse(Store store) : this(true, string.Empty, store)
    { }

    public StoreResponse(string message) : this(false, message, null)
    { }
    }
}