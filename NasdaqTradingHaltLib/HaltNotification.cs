using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRADING_HALT = NasdaqTradingHaltLib.Model.TradingHalt;
using TIMER = System.Timers.Timer;
using System.Diagnostics;

namespace NasdaqTradingHaltLib
{


	/// <summary>
	/// <c>HaltNotification</c>
	/// <para>Nasdaq RSS Data Feed Events For Most Recent Trading Halts.</para>
	/// <para>
	/// <seealso href="https://www.nasdaqtrader.com/trader.aspx?id=TradingHaltHistory">Nasdaq Documentation</seealso>
	/// </para>
	/// </summary>
	public static class HaltNotification
	{
		public static event EventHandler<TRADING_HALT[]> NewTradingHalt;

		private static CancellationTokenSource cts;
		private static TRADING_HALT[] halts = null;


		private static readonly TIMER timer = new TIMER(interval: 1000);
		private static readonly object lockerInit = new object();
		private static readonly double timerDelay = TimeSpan.FromMinutes(1).TotalMilliseconds;

		[Conditional("DEBUG")]
		private static void print(string text)
		{
			Debug.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")}: {text}");
		}
		private static void onNewHalts(TRADING_HALT[] e)
		{
			EventHandler<TRADING_HALT[]> _handler;

			_handler =
				NewTradingHalt;

			if (_handler != null)
			{
				_handler(null, e);
			}
		}

		private static void runCheck()
		{
			TRADING_HALT[] _halts;
			TRADING_HALT[] _haltsNew;

			_halts =
				Control.DataRead.ReadTradingHaltsCurrent();

			_haltsNew =
				Control.TradingHalt.GetNotifications(
					existing_halts: halts,
					new_halts: _halts);

			onNewHalts(
				e: _haltsNew);

			halts =
				_halts.ToArray();
		}

		private static void onTimer(object sender, System.Timers.ElapsedEventArgs e)
		{
			timer.Enabled = false;

			print("Timer Fired");

			runCheck();

			timer.Interval = timerDelay;

			timer.Enabled = true;

		}

		private static void init()
		{
			if ((cts == null) ? true : cts.IsCancellationRequested)
			{
				print("Init");

				cts =
					new CancellationTokenSource();

				timer.Interval = 1000;
				timer.SynchronizingObject = null;
				timer.Elapsed += onTimer;
				timer.AutoReset = true;
				timer.Enabled = true;
			}
		}

		public static void Init()
		{
			lock (lockerInit)
			{
				init();
			}
		}
	}
}
