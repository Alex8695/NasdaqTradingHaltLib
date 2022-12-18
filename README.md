# NasdaqTradingHaltLib
Unofficial Nasdaq Trading Halt API

Leverages [Nasdaq Trading Halt RSS Feed](https://www.nasdaqtrader.com/Trader.aspx?id=TradeHaltRSS), providing Event notifications based on RSS data changes.

### New Trading Halt Event Notification

```
///Subscribe To Event
NasdaqTradingHaltLib.HaltNotification.NewTradingHalt += (object? sender, NasdaqTradingHaltLib.Model.TradingHalt[] e)=> {

  _itemCount += e.Length;
};

///Initilize Halt Notifications
NasdaqTradingHaltLib.HaltNotification.Init();
```

### Trading Halt Code Reference Data

```
var codes = NasdaqTradingHaltLib.Data.GetHaltCodes();
```


### Manual Query Of Trading Halts

```
var halts = NasdaqTradingHaltLib.Data.GetTradingHalts(NasdaqTradingHaltLib.Model.HaltResumeType.ISSUED_TODAY);
```

Use [HaltResumeType](/NasdaqTradingHaltLib/Model/HaltResumeType.cs) to change the returned resutls
*  ISSUED_TODAY: Returns All Symbols With A Trading Halt That Was Implemented Today
*  RESUMING_TODAY: Returns All Symbols With A Trading Halt Ending Today
