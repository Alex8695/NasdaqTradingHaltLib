using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TRADING_HALT = NasdaqTradingHaltLib.Model.TradingHalt;

namespace NasdaqTradingHaltLib.Control
{
	internal class TradingHalt
	{
		private static readonly PropertyInfo[] props = typeof(TradingHalt).GetProperties();

		public static bool AreEqual(TRADING_HALT a, TRADING_HALT b)
		{
			bool _out = true;

			if (a == null && b == null)
			{
				_out =
					true;
			}
			else if (a == null || b == null)
			{
				_out =
					false;
			}
			else
			{
				for (int i = 0; i < props.Length; i++)
				{
					if (props[i].GetValue(a) != props[i].GetValue(b))
					{
						_out =
							false;
						i += props.Length;
					}
				}
			}

			return _out;
		}

		public static bool ShouldNotify(TRADING_HALT of_halt, TRADING_HALT[] trading_halts)
		{
			bool _out = true;

			if ((trading_halts==null)?false:trading_halts.Length>0)
			{
				_out = 
					trading_halts.All(
						a => !AreEqual(a, of_halt));
			}
			return _out;
		}

		public static TRADING_HALT[] GetNotifications(TRADING_HALT[] existing_halts, TRADING_HALT[] new_halts)
		{
			ConcurrentBag<TRADING_HALT> _haltBag;

			_haltBag =
				new ConcurrentBag<TRADING_HALT>();

			for (int i = 0; i < new_halts.Length; i++)
			{
				if (ShouldNotify(of_halt: new_halts[i],trading_halts:existing_halts))
				{
					_haltBag.Add(
						item: new_halts[i]);

				}
			}

			return (_haltBag.Count == 0) ? new TRADING_HALT[] { } : _haltBag.ToArray();
		}
	}
}
