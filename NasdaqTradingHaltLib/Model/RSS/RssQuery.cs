using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NasdaqTradingHaltLib.Model.RSS;

namespace NasdaqTradingHaltLib.Model
{
	public partial class RSS
	{
		[System.SerializableAttribute()]
		[System.ComponentModel.DesignerCategoryAttribute("code")]
		[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
		[System.Xml.Serialization.XmlRootAttribute("rss", Namespace = "", IsNullable = false)]
		public class RssQuery
		{
			private RssChannel channelField;
			private decimal versionField;

			public RssChannel channel {
                get=>this.channelField;
                set=>this.channelField = value;
			}

			[System.Xml.Serialization.XmlAttributeAttribute()]
			public decimal version {
                get=>this.versionField;
                set=>this.versionField = value;
			}

		}
	}
}
