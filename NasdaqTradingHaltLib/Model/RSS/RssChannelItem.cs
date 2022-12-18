using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasdaqTradingHaltLib.Model
{
	public partial class RSS
	{



		[System.SerializableAttribute()]
		[System.ComponentModel.DesignerCategoryAttribute("code")]
		[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
		[System.Xml.Serialization.XmlRootAttribute("rssChannelItem", Namespace = "", IsNullable = false)]
		public class RssChannelItem
		{

			private string titleField;
			private string pubDateField;
			private string haltDateField;
			private System.DateTime haltTimeField;
			private string issueSymbolField;
			private string issueNameField;
			private string marketField;
			private string reasonCodeField;
			private object pauseThresholdPriceField;
			private object resumptionDateField;
			private object resumptionQuoteTimeField;
			private object resumptionTradeTimeField;
			private string descriptionField;


			public string title {  				
				get => this.titleField;
				set =>this.titleField = value;
			}
			public string pubDate {		 				
				get => this.pubDateField;
				set =>this.pubDateField = value;
			}


			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public string HaltDate {					
				get => this.haltDateField;
				set =>this.haltDateField = value;
			}

			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/", DataType = "time")]
			public System.DateTime HaltTime {					
				get => this.haltTimeField;
				set =>this.haltTimeField = value;
			}

			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public string IssueSymbol {			 				
				get => this.issueSymbolField;
				set =>this.issueSymbolField = value;
			}


			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public string IssueName {
				
				get => this.issueNameField;
				set =>this.issueNameField = value;
			}


			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public string Market {		 				
				get => this.marketField;   
				set =>this.marketField = value;
			}


			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public string ReasonCode {	  				
				get => this.reasonCodeField; 
				set =>this.reasonCodeField = value;
			}


			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public object PauseThresholdPrice {	 				
				get => this.pauseThresholdPriceField;  
				set =>this.pauseThresholdPriceField = value;
			}


			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public object ResumptionDate {					
				get => this.resumptionDateField;	 
				set =>this.resumptionDateField = value;
			}


			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public object ResumptionQuoteTime {
				get => this.resumptionQuoteTimeField;
				set => this.resumptionQuoteTimeField = value;
			}


			[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.nasdaqtrader.com/")]
			public object ResumptionTradeTime {					
				get => this.resumptionTradeTimeField;	
				set =>this.resumptionTradeTimeField = value;
			}


			public string description {	  				
				get => this.descriptionField; 
				set =>this.descriptionField = value;
			}

		}
	}
}
