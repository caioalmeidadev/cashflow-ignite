namespace Cashflow.Domain.Security.Cryptography;

public interface IPassowordEncripter
{
    string Encrypt(string password);
    bool Verify(string password,string passwordHash);
}