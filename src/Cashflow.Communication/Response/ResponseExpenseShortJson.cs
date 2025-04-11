namespace Cashflow.Communication.Response;

public class ResponseExpenseShortJson
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Decimal Amount { get; set; }
}