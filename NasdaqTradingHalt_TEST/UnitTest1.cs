using NasdaqTradingHaltLib;
using System.Diagnostics;

namespace NasdaqTradingHalt_TEST
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		public class Data
		{

			[Test]
			public void HaltCodes()
			{
				var codes = NasdaqTradingHaltLib.Data.GetHaltCodes();

				foreach (var item in codes)
				{
					Console.WriteLine(item.ToString());
				}

				Assert.IsNotEmpty(codes);
			}

			[Test]
			public void HaltCodes_Current()
			{
				var halts = NasdaqTradingHaltLib.Data.GetTradingHalts(NasdaqTradingHaltLib.Model.HaltResumeType.ISSUED_TODAY);

				foreach (var item in halts)
				{
					Console.WriteLine(item.ToString());

				}


				Assert.IsNotNull(halts);

			}
		}

		public class Notification
		{

			[Test]
			public void TestNotification()
			{

				NasdaqTradingHaltLib.HaltNotification.Init();

				int _i = 0;
				int _iMax = 30;

				while (true)
				{
					_i++;
					Task.Delay(1000).Wait();

					if (_i>=_iMax)
					{
						break;
					}
				}

				Assert.IsTrue(_i > 0);

			}

			[Test]
			public void TestMultipleInstance() {

				for (int i = 0; i < 10; i++)
				{
					NasdaqTradingHaltLib.HaltNotification.Init();
				}

				Task.Delay(5000).Wait();
				for (int i = 0; i < 10; i++)
				{
					NasdaqTradingHaltLib.HaltNotification.Init();
					Task.Delay(100).Wait();
				}

				Task.Delay(5000).Wait();
				for (int i = 0; i < 10; i++)
				{
					NasdaqTradingHaltLib.HaltNotification.Init();
					Task.Delay(1000).Wait();
				}



				Assert.IsTrue(true);
			}



			[Test]
			public void TestHaltNotification()
			{
				DateTime _dtStart;
				TimeSpan _durationMax = TimeSpan.FromMinutes(5);
				TimeSpan _tsCurrent = TimeSpan.Zero;
				int _itemCount = 0;

				NasdaqTradingHaltLib.HaltNotification.NewTradingHalt += (object? sender, NasdaqTradingHaltLib.Model.TradingHalt[] e)=> {

					_itemCount += e.Length;
				};

				NasdaqTradingHaltLib.HaltNotification.Init();

				_dtStart = DateTime.Now;

				while (_tsCurrent<_durationMax)
				{

					_tsCurrent = DateTime.Now - _dtStart;
					Debug.WriteLine($"Run Time: {_tsCurrent.ToString("hh\\:mm\\:ss\\.ffff")} Total Halts: {_itemCount.ToString()}");
					Task.Delay(1000).Wait();

				}


				Assert.IsTrue(_itemCount > 0);

			}

		}
	}
}