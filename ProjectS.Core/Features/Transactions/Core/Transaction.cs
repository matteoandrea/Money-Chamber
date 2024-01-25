using ProjectS.Core.Features.Users.Core;
using Standard.Core.Shared.Core.Objects;
using Standard.Core.Shared.ValueObjects;

namespace ProjectS.Core.Features.Transactions.Core;

public class Transaction : Entity
{
	public Transaction(User user, DateTime date, Description payee, ICollection<SubTransaction> subTransactions)
	{
		User = user;
		Date = date;
		Payee = payee;
		SubTransactions = subTransactions;
	}

	#region Propreties

	public User User { get; init; }
	public DateTime Date { get; init; }
	public Description Payee { get; init; }
	public ICollection<SubTransaction> SubTransactions { get; init; }

	public decimal TotalAmount
	{
		get => SubTransactions.Sum(x => x.TotalAmount);
	}


	#endregion
}
