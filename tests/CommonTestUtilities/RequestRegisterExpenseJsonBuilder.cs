using Bogus;
using Cashflow.Communication.Enums;
using Cashflow.Communication.Requests;

namespace CommonTestUtilities;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestExpenseJson Build()
    {
        return new Faker<RequestExpenseJson>()
            .RuleFor(r => r.Title, f => f.Commerce.ProductName())
            .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.Date, f => f.Date.Past())
            .RuleFor(r => r.Amount, f => f.Random.Decimal(min: 1, max: 100))
            .RuleFor(r => r.PaymentType, f => f.PickRandom<PaymentType>());
    }  
}

