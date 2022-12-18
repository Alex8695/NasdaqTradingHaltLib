using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRADING_HALT = NasdaqTradingHaltLib.Model.TradingHalt;
using RSS_ITEM = NasdaqTradingHaltLib.Model.RSS.RssChannelItem;



namespace NasdaqTradingHaltLib.Control
{
	internal class RssConvert
	{
		private static double getDouble(string from_string)
		{
			bool _converted = false;
			double _out = 0.00;

			if ((from_string==null)?false:from_string.Length > 0)
			{
				_converted =
					double.TryParse(
						s: from_string,
						result: out _out);
			}
			return _out;
		}


		public static DateTime TryDateTime(object time, object date)
		{
			DateTime _out = DateTime.MinValue;
			DateTime _dtTime;
			DateTime _dtDate;

			try
			{	 
				_dtTime =
					(DateTime)time;

				if (DateTime.TryParse(
						s: date.ToString(),
						result: out _dtDate))
				{
					_out =
						_dtDate +
						_dtTime.TimeOfDay;
				}
			}
			catch (Exception)
			{
				Debugger.Break();
			}

			return _out;

		}


		public static TRADING_HALT ToTradingHalt(RSS_ITEM rss_item)
		{
			TRADING_HALT _out = null;

			try
			{
				_out =
					new TRADING_HALT();

				_out.Symbol = 
					rss_item.IssueSymbol;

				_out.SymbolFull = 
					rss_item.IssueName;

				_out.Market = 
					rss_item.Market;

				_out.HaltCode = 
					rss_item.ReasonCode;

				_out.ResumePrice =
					getDouble(
						from_string: rss_item.PauseThresholdPrice.ToString()
						);

				if (rss_item.HaltDate != null)
				{
					_out.TimeStampStart =
						Control.RssConvert.TryDateTime(
							time: rss_item.HaltTime,
							date: rss_item.HaltDate);
				}

				if (rss_item.ResumptionDate.GetType() != typeof(object))
				{
					_out.TimeStampQuote =
						TryDateTime(	
							time: rss_item.ResumptionQuoteTime,	
							date: rss_item.ResumptionDate);

					_out.TimeStampResume =
						TryDateTime(
							time: rss_item.ResumptionTradeTime,
							date: rss_item.ResumptionDate);
				}
			}
			catch (Exception)
			{
				//TODO: Add Error Handling
				Debugger.Break();

				_out =
					null;
			}
			
			return _out;
		}




	}
}
