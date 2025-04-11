using Cashflow.Communication.Requests;
using Cashflow.Communication.Response;

namespace Cashflow.Application.UseCases.Login;

public interface IDoLoginUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}