using System;

namespace Example_07
{
    public enum Device
    {
        FlashCard,
        WiFi
    }
    public class CopyMachine
    {
        public IState State { get; set; }
        public readonly int CostOfPage;
        public int Money;
        public Device Device;
        public string DocumentName;
        public int DocumentPages;

        public CopyMachine(int costOfPage)
        {
            CostOfPage = costOfPage;
            State = new InitState(this);
        }

        public void InsertMoney(int money)
        {
            State.InsertMoney(money);
        }

        public void ChooseDevice(Device device)
        {
            State.ChooseDevice(device);
        }

        public void ChooseDocument(string documentName, int documentPages)
        {
            State.ChooseDocument(documentName, documentPages);
        }

        public void PrintDocument()
        {
            State.PrintDocument();
        }

        public void PrintMoreDocuments(bool print)
        {
            State.PrintMoreDocuments(print);
        }

        public int GetChange()
        {
            return State.GetChange();
        }
    }

    public interface IState
    {
        void InsertMoney(int money);
        void ChooseDevice(Device device);
        void ChooseDocument(string documentName, int documentPages);
        void PrintDocument();
        void PrintMoreDocuments(bool print);
        int GetChange();
        void Finish();
    }

    public abstract class StateBase : IState
    {
        public CopyMachine Context;

        public StateBase(CopyMachine context)
        {
            Context = context;
        }

        public virtual void InsertMoney(int money)
        {
            throw new Exception("impossible action");
        }

        public virtual void ChooseDevice(Device device)
        {
            throw new Exception("impossible action");
        }

        public virtual void ChooseDocument(string documentName, int documentPages)
        {
            throw new Exception("impossible action");
        }

        public virtual void PrintDocument()
        {
            throw new Exception("impossible action");
        }

        public virtual void PrintMoreDocuments(bool print)
        {
            throw new Exception("impossible action");
        }

        public virtual int GetChange()
        {
            throw new Exception("impossible action");
        }

        public void Finish()
        {
            Context.State = new FinishState(Context);
        }
    }

    public class InitState : StateBase
    {
        public InitState(CopyMachine context) : base(context)
        {
        }

        public override void InsertMoney(int money)
        {
            Context.Money = money;
            Console.WriteLine(money + " was inserted");
            Context.State = new ChooseDeviceState(Context);
        }
    }

    public class ChooseDeviceState : StateBase
    {
        public ChooseDeviceState(CopyMachine context) : base(context)
        {
        }

        public override void ChooseDevice(Device device)
        {
            Context.Device = device;
            Console.WriteLine(device + " was chosen");
            Context.State = new ChooseDocumentState(Context);
        }
    }

    public class ChooseDocumentState : StateBase
    {
        public ChooseDocumentState(CopyMachine context) : base(context)
        {
        }

        public override void ChooseDocument(string documentName, int documentPages)
        {
            var cost = documentPages * Context.CostOfPage;
            Context.DocumentName = documentName;
            Context.DocumentPages = documentPages;
            Console.WriteLine(documentName + " was chosen");

            if (Context.Money >= cost)
            {
                Context.Money -= cost;
                Context.State = new PrintDocumentState(Context);
            }
            else
            {
                Console.WriteLine("Need " + (cost - Context.Money) + " more");
                Context.State = new InsertMoreMoneyState(Context);
            }
        }
    }

    public class InsertMoreMoneyState : StateBase
    {
        public InsertMoreMoneyState(CopyMachine context) : base(context)
        {
        }

        public override void InsertMoney(int money)
        {
            Context.Money += money;
            Console.WriteLine(money + " was inserted");
            var cost = Context.DocumentPages * Context.CostOfPage;
            if (Context.Money >= cost)
            {
                Context.Money -= cost;
                Context.State = new PrintDocumentState(Context);
            }
            else
            {
                Console.WriteLine("Need more money");
                Context.State = new InsertMoreMoneyState(Context);
            }
        }
    }

    public class PrintDocumentState : StateBase
    {
        public PrintDocumentState(CopyMachine context) : base(context)
        {
        }

        public override void PrintDocument()
        {
            Console.WriteLine($"Print {Context.DocumentName}");
            Context.DocumentName = null;
            Context.DocumentPages = 0;
            Context.State = new PrintMoreDocumentsState(Context);
        }
    }

    public class PrintMoreDocumentsState : StateBase
    {
        public PrintMoreDocumentsState(CopyMachine context) : base(context)
        {
        }

        public override void PrintMoreDocuments(bool print)
        {
            if (print)
            {
                Context.State = new ChooseDeviceState(Context);
            }
            else
            {
                Context.State = new GetChangeState(Context);
            }
        }
    }

    public class GetChangeState : StateBase
    {
        public GetChangeState(CopyMachine context) : base(context)
        {
        }

        public override int GetChange()
        {
            var change = Context.Money;
            Context.Money = 0;
            Console.WriteLine("Your change is " + change);
            Context.State = new FinishState(Context);
            return change;
        }
    }

    public class FinishState : StateBase
    {
        public FinishState(CopyMachine context) : base(context)
        {
        }
    }
}
