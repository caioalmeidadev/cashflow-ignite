using AutoMapper;
using Cashflow.Communication.Requests;
using Cashflow.Communication.Response;
using Cashflow.Domain.Repositories;
using Cashflow.Domain.Repositories.User;
using Cashflow.Domain.Security.Cryptography;
using Cashflow.Domain.Security.Tokens;
using Cashflow.Exception.ExceptionBase;
using FluentValidation.Results;

namespace Cashflow.Application.UseCases.User.Register;

public class RegisterUserUseCase:IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPassowordEncripter _passowordEncripter;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public RegisterUserUseCase(IMapper mapper,IPassowordEncripter passowordEncripter,
        IUserReadOnlyRepository userReadOnlyRepository,
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IUnitOfWork unitOfWork,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _mapper = mapper;
        _passowordEncripter = passowordEncripter;
        _userReadOnlyRepository = userReadOnlyRepository;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _accessTokenGenerator = accessTokenGenerator;
    }
    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);
        
        var user = _mapper.Map<Domain.Entities.User>(request);
        
        user.Password = _passowordEncripter.Encrypt(user.Password);
        user.Identifier = Guid.NewGuid();
        await _userWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();
        
        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _accessTokenGenerator.Generate(user),
        };
    }


    private async Task Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var emailExists = await _userReadOnlyRepository.ExistsActiveUserWithEmail(request.Email);
        
        if(emailExists) result.Errors.Add(new ValidationFailure(string.Empty,"Email já registrado"));
        
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}