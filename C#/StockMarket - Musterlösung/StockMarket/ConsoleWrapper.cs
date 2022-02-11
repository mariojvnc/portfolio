using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StockMarket
{
    class ConsoleWrapper
    {
        private TextBlock console;

        public ConsoleWrapper(TextBlock console)
        {
            this.console = console;
        }

        public void WriteLine(string s)
        {
            Write(s + '\n');
        }

        public void Write(string s)
        {
            console.Text += s;

            if (console.Parent is ScrollViewer sv)
                sv.ScrollToEnd();
        }
    }
}
