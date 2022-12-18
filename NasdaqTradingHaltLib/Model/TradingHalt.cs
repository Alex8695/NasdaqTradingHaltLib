using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasdaqTradingHaltLib.Model
{


	/// <summary>

	/// <c>TradingHalt</c>

	/// <para>Halt Event Information</para>

	/// </summary>

	public class TradingHalt

	{
		public string Symbol { get => symbol; set => symbol = value; }
		public string SymbolFull { get => symbolFull; set => symbolFull = value; }
		public string Market { get => market; set => market = value; }
		public string HaltCode { get => haltCode; set => haltCode = value; }
		public double ResumePrice { get => pauseThreasholdPrice; set => pauseThreasholdPrice = value; }
		public DateTime TimeStampStart { get => timestampStart; set => timestampStart = value; }
		public DateTime TimeStampQuote { get => timestampQuote; set => timestampQuote = value; }
		public DateTime TimeStampResume { get => timestampResume; set => timestampResume = value; }

		private string symbol;
		private string symbolFull;
		private string market;
		private string haltCode;
		private double pauseThreasholdPrice;
		private DateTime timestampStart;
		private DateTime timestampQuote;
		private DateTime timestampResume;

		public override string ToString()
		{
			return $"{Symbol.PadRight(7)} - {TimeStampStart} - {HaltCode}";
		}

		public TradingHalt() { }
	}
}
