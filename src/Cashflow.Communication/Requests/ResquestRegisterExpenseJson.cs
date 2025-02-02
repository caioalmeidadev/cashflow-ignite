using Cashflow.Communication.Enums;

namespace Cashflow.Communication.Requests;

public class ResquestRegisterExpenseJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public PaymentType PaymentType { get; set; }
}