using Cashflow.Communication.Requests;
using Cashflow.Communication.Response;
using Cashflow.Domain.Repositories.User;
using Cashflow.Domain.Security.Cryptography;
using Cashflow.Domain.Security.Tokens;
using Cashflow.Exception.ExceptionBase;

namespace Cashflow.Application.UseCases.Login;

public class DoLoginUseCase:IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPassowordEncripter _passowordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(IUserReadOnlyRepository repository, IPassowordEncripter passowordEncripter,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _repository = repository;
        _passowordEncripter = passowordEncripter;
        _accessTokenGenerator = accessTokenGenerator;
    }
    
    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    { 
        var user = await _repository.GetByEmail(request.Email);

        if (user is null)
        {
            throw new InvalidLoginException();
        }

        var passwordValid = _passowordEncripter.Verify(request.Password, user.Password);

        if (!passwordValid)
        {
            throw new InvalidLoginException();
        }

        return new ResponseRegisteredUserJson
        {
            Name = user.Email,
            Token = _accessTokenGenerator.Generate(user)
        };
    }

    
}