using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasdaqTradingHaltLib.Model
{
	public partial class RSS { 


		[System.SerializableAttribute()]
		[System.ComponentModel.DesignerCategoryAttribute("code")]
		[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
		[System.Xml.Serialization.XmlRootAttribute("rssChannel", Namespace = "", IsNullable = false)]
		public class RssChannel
		{

			private string titleField;
			private string linkField;
			private string descriptionField;
			private string copyrightField;
			private string pubDateField;
			private byte ttlField;
			private byte numItemsField;
			private RssChannelItem[] itemField;


			public string title {
				get => this.titleField;
				set => this.titleField = value;
			}

			public string link {
				get => this.linkField;
				set => this.linkField = value;
			}


			public string description {
				get => this.descriptionField;
				set => this.descriptionField = value;
			}

			public string copyright {
				get => this.copyrightField;
				set => this.copyrightField = value;
			}

			public string pubDate {
				get => this.pubDateField;
				set => this.pubDateField = value;
			}

			public byte ttl {
				get => this.ttlField;
				set => this.ttlField = value;
			}

			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public byte numItems {
				get => this.numItemsField;
				set => this.numItemsField = value;
			}

			[System.Xml.Serialization.XmlElementAttribute("item")]
			public RssChannelItem[] item {
				get => this.itemField;
				set => this.itemField = value;
			}

		}
	}
}
