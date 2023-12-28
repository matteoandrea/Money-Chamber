using Flunt.Validations;
using Standard.Core.Shared.Core.Objects;

namespace Standard.Core.Shared.ValueObjects;

public class Email : ValueObject
{
    public Email(string adress)
    {
        Adress = adress;

        AddNotifications(new CreateEmailContract(this));
    }

    public string Adress { get; private set; }
}

public class CreateEmailContract : Contract<Email>
{
    public CreateEmailContract(Email email)
    {
        Requires()
            .IsEmail(email.Adress, "Email", "Ivalid email");

    }
}