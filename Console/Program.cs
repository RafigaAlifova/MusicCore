using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new PrinterManager(new Printer());
        }
    }
    class PrinterManager
    {
        private IPrinter _printer;

        public PrinterManager(IPrinter printer)
        {
            _printer = printer;
        }

        public void PrinterBase(string data)
        {
            this._printer.Print(data);
        }
    }

    interface IPrinter
    {
        void Print(string data);
    }

    [Obsolete("This class is obsolete because of low performance. Use ModernPrinter instead of this")] //kohnelmis
    class Printer:IPrinter
    {
        public void Print(string data)
        {
            //...
        }
    }

    class ModernPrinter:IPrinter
    {
        public void Print(string data)
        {
            //...
        }
    }
}
