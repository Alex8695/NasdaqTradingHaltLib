using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NasdaqTradingHaltLib.Model
{


	/// <summary>

	/// <c>HaltCode</c>

	/// <para>Halt Code Details</para>

	/// </summary>

	[DebuggerDisplay("{Code} : {Description}")]

	public class HaltCode

	{

		private string code;
		private string symbol;
		private string symbolDetail;


		[JsonPropertyName("code")]
		public string Code { get => code; set => code = value; }

		[JsonPropertyName("desc")]
		public string Desc { get => symbol; set => symbol = value; }

		[JsonPropertyName("detail")]
		public string DescDetail { get => symbolDetail; set => symbolDetail = value; }



		public override string ToString()
		{
			string _detail = (DescDetail == string.Empty) ? string.Empty : $" : {DescDetail}";
			return $"{Code.PadRight(7)} : {Desc}{_detail}";
		}


		public HaltCode() { }

	}
}
