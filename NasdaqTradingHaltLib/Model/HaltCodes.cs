using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NasdaqTradingHaltLib.Model
{
	internal class HaltCodes
	{

		[JsonPropertyName("halt_code")]
		public HaltCode[] HaltCodeCollection { get => haltCodes; set => haltCodes = value; }


		private HaltCode[] haltCodes;


		public HaltCodes() { }

	}
}
