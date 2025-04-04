using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Bnfo
{
	public enum BnfoEmployeePayRate : uint
	{
		/// <summary>
		/// Ridiculously Underpaid (25%)
		/// </summary>
		[DisplayName("Ridiculously Underpaid (25%)")]
		RidiculouslyUnderpaid,
		/// <summary>
		/// Very Underpaid (50%)
		/// </summary>
		[DisplayName("Very Underpaid (50%)")]
		VeryUnderpaid,
		/// <summary>
		/// Underpaid (75%)
		/// </summary>
		[DisplayName("Underpaid (75%)")]
		Underpaid,
		/// <summary>
		/// Fairly Paid (100%)
		/// </summary>
		[DisplayName("Fairly Paid (100%)")]
		FairlyPaid,
		/// <summary>
		/// Overpaid (125%)
		/// </summary>
		[DisplayName("Overpaid (125%)")]
		Overpaid,
		/// <summary>
		/// Very Overpaid (150%)
		/// </summary>
		[DisplayName("Very Overpaid (150%)")]
		VeryOverpaid,
		/// <summary>
		/// Ridiculously Overpaid (175%)
		/// </summary>
		[DisplayName("Ridiculously Overpaid (175%)")]
		RidiculouslyOverpaid
	}
}
