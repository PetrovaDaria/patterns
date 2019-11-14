using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Example_06
{
    public class MyBankomat
    {
        private readonly BanknoteHandler _handler;

        public MyBankomat()
        {
            _handler = new TenHandler(null);
            _handler = new FiftyHandler(_handler);
            _handler = new HundredHandler(_handler);
            _handler = new ThousandHandler(_handler);
        }

        public string Cash(string value)
        {
            var regex = new Regex(@"\d+(?=[ рублей|$])");
            return _Cash(int.Parse(regex.Match(value).Value));
        }

        private string _Cash(int value)
        {
            var alreadyCached = new List<Tuple<int, int>>();
            var result = _handler.Cash(alreadyCached, value);
            var toCash = result.Item1;
            var remain = result.Item2;
            return remain == 0 ? GetCashedBanknotes(toCash) : "Sorry, dude, we can't cash it. Too bad";
        }

        private string GetCashedBanknotes(List<Tuple<int, int>> toCash)
        {
            return String.Join(
                " + ",
                toCash.Select(pair =>
            {
                var banknoteValue = pair.Item1;
                var banknotesCount = pair.Item2;
                return banknoteValue + "*" + banknotesCount;
            }));
        }
    }

    public abstract class BanknoteHandler
    {
        private readonly BanknoteHandler _nextHandler;
        protected abstract int BanknoteValue { get; }

        protected BanknoteHandler(BanknoteHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public virtual Tuple<List<Tuple<int, int>>, int> Cash(List<Tuple<int, int>> alreadyCached, int value)
        {
            var banknoteCount = value / BanknoteValue;
            var remain = value - banknoteCount * BanknoteValue;
            alreadyCached.Add(Tuple.Create(BanknoteValue, banknoteCount));
            return _nextHandler == null
                ? Tuple.Create(alreadyCached, remain)
                : _nextHandler.Cash(alreadyCached, remain);
        }
    }

    public class ThousandHandler : BanknoteHandler
    {
        public ThousandHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        protected override int BanknoteValue => 1000;
    }

    public class HundredHandler : BanknoteHandler
    {
        public HundredHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        protected override int BanknoteValue => 100;
    }

    public class FiftyHandler : BanknoteHandler
    {
        public FiftyHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        protected override int BanknoteValue => 50;
    }

    public class TenHandler : BanknoteHandler
    {
        public TenHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        protected override int BanknoteValue => 10;
    }
}
