using NasdaqTradingHaltLib.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HALT_CODE = NasdaqTradingHaltLib.Model.HaltCode;
using HALT_CODES = NasdaqTradingHaltLib.Model.HaltCodes;

namespace NasdaqTradingHaltLib.Control
{
	internal class HaltCode
	{

		public static HALT_CODE[] GetHaltCodes()
		{
			string _jsonString;
			MemoryStream _memoryStream;
			HALT_CODES _haltCodes;
			HALT_CODE[] _out=null;

			try
			{
				using (_memoryStream = new MemoryStream(buffer: Properties.Resources.hatlcodes))
				{
					try
					{
						_haltCodes =
							JsonSerializer.Deserialize<HALT_CODES>(
								utf8Json: _memoryStream);

						_out =
							_haltCodes
							.HaltCodeCollection
							.ToArray();
					}
					catch (Exception)
					{
						Debugger.Break();
					}
				}	
			}

			catch (Exception)
			{
				//TODO: Add Error Handling
				Debugger.Break();

			}

			return (_out==null)?new HALT_CODE[] { }:_out;
		}

	}
}
