using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace ProjectS.Core.Shared.ValueObjects;

public class VerificationCode : ValueObject
{
    #region Constructors

    public VerificationCode()
    {
        Code = Guid.NewGuid().ToString("N")[0..6].ToUpper(); ;
        ExpireDate = DateTime.UtcNow.AddMinutes(5);

    }

    #endregion

    #region Propreties

    public string Code { get; }
    public DateTime ExpireDate { get; }
    public DateTime VerifiedDate { get; private set; }
    //public bool Active => ExpireDate > DateTime.UtcNow;

    #endregion

    #region Functions

    public void Verify(string code)
    {
        AddNotifications(new BasicVerificationCodeValidationContract(this, code));

        if (IsValid)
            VerifiedDate = DateTime.UtcNow;
    }

    #endregion
}

public class BasicVerificationCodeValidationContract : Contract<VerificationCode>
{
    public BasicVerificationCodeValidationContract(VerificationCode verification, string code)
    {
        Requires()
            //.IsFalse(verification.Active, "Active", "Verification code not active");
            .IsLowerThan(verification.ExpireDate, DateTime.UtcNow, "ExpireDate", "Verification code expired")
            .AreNotEquals(verification.Code.Trim(), code.Trim(), "Code", "Verification code invalid");

    }
}