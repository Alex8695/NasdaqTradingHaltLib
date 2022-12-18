using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using RSS_QUERY = NasdaqTradingHaltLib.Model.RSS.RssQuery;
using TRADING_HALT = NasdaqTradingHaltLib.Model.TradingHalt;

namespace NasdaqTradingHaltLib.Control
{
	internal class DataRead
	{
		public static RSS_QUERY ReadXML(string uri)
		{
			RSS_QUERY _out = null;
			XmlSerializer _xmlSerializer;
			XmlReader _xmlReader;

			try
			{
				_xmlSerializer = 
					new XmlSerializer(
						type: typeof(RSS_QUERY));

				_xmlReader =
					XmlReader
					.Create(
						inputUri: uri);

				_out =
					(RSS_QUERY)_xmlSerializer
					.Deserialize(
						xmlReader: _xmlReader);	 				


			}
			catch (Exception)
			{
				//TODO: Add Error Handling
				Debugger.Break();
			}

			return _out;
		}

		public static TRADING_HALT[] ReadTradingHaltsCurrent()
		{
			RSS_QUERY _rssQuery;
			TRADING_HALT[] _out = null;

			try
			{
				_rssQuery =
					ReadXML(
						uri: Properties.Resources.RssUriString);

				if (_rssQuery.channel.item.Length>0)
				{
					_out =
						_rssQuery.channel.item
						.Select(s => RssConvert.ToTradingHalt(rss_item: s))
						.ToArray();
				}
			}
			catch (Exception)
			{
				Debugger.Break();
				//TODO: Add Error Handling
			}

			return (_out == null) ? new TRADING_HALT[] { } : _out;
		}

		public static TRADING_HALT[] ReadTradingHaltsResumingToday()
		{
			RSS_QUERY _rssQuery;
			TRADING_HALT[] _out = null;

			try
			{
				_rssQuery =
					ReadXML(
						uri: string.Format(
							format: Properties.Resources.RssUriStringByResumptionDate,
							arg0: DateTime.Now));

				if (_rssQuery.channel.item.Length > 0)
				{
					_out =
						_rssQuery.channel.item
						.Select(s => RssConvert.ToTradingHalt(rss_item: s))
						.ToArray();
				}
			}
			catch (Exception)
			{
				Debugger.Break();
				//TODO: Add Error Handling
			}

			return (_out == null) ? new TRADING_HALT[] { } : _out;
		}

	}
}
