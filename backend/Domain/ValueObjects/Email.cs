using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public partial class Email : ValueObject
{
    private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";


    protected Email()
    {
    }

    public Email(string address)
    {
        if(string.IsNullOrEmpty(address))
            throw new Exception("Email address cannot be empty");

        Address = address.Trim().ToLower();

        if (!EmailRegex().IsMatch(Address))
            throw new Exception("Invalid email address");
    }

    public string Address { get; }

    public static implicit operator string(Email email) => email.ToString();

    public static implicit operator Email(string address) => new Email(address);

    public override string ToString() => Address.Trim().ToLower();

    [GeneratedRegex(EmailPattern)]
    private static partial Regex EmailRegex();
}
