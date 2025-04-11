using Cashflow.Application.UseCases.Expenses.Register;
using Cashflow.Communication.Enums;
using Cashflow.Communication.Requests;
using CommonTestUtilities;
using FluentAssertions;

namespace Validator.Tests.Expenses.Register;

public class RegisterValidatorExpensesTests
{
    [Fact]
    public void Success()
    {
        //Arrenge
        var validator = new ExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        //Act
        var result = validator.Validate(request);
        
        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Error_Title_Empty()
    {
        //Arrenge
        var validator = new ExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = string.Empty;
        
        //Act
        var result = validator.Validate(request);
        
        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Titulo Vazio"));
    }
}