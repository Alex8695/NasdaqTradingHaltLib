using NasdaqTradingHaltLib.Model;
using HALT_CODE = NasdaqTradingHaltLib.Model.HaltCode;
using TRADING_HALT = NasdaqTradingHaltLib.Model.TradingHalt;


namespace NasdaqTradingHaltLib
{
	public class Data
	{

		/// <summary>
		/// <c>GetHaltCodes</c>
		/// <para>Reference Collection Of Halt Code Detail</para>
		/// </summary>
		/// <returns></returns>
		public static HALT_CODE[] GetHaltCodes()
		{
			return Control.HaltCode.GetHaltCodes();
		}

		/// <summary>
		/// <c>GetTradingHalts</c>
		/// <para>Returns Collection Of Trading Halts</para>
		/// <para>Should Only Query Once Per Minute Per 
		/// <seealso href="https://www.nasdaqtrader.com/Trader.aspx?id=TradeHaltRSS">
		/// NASDAQ Guidelines
		/// </seealso>
		/// </para>
		/// </summary>
		/// <returns></returns>
		public static TRADING_HALT[] GetTradingHalts(HaltResumeType halt_resume_type)
		{
			switch (halt_resume_type)
			{
				case HaltResumeType.RESUMING_TODAY:
					
					return Control.DataRead.ReadTradingHaltsResumingToday();
				case HaltResumeType.ISSUED_TODAY:
				default:
					return Control.DataRead.ReadTradingHaltsCurrent();
			}
		}

	}
}