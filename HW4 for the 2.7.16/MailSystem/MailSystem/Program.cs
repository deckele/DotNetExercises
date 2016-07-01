using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = "Hello, it's me...";
            string body = "I was wondering\nIf after all these years you'd like to meet to go over everything\nThey say that time's supposed to heal, yeah\nBut I ain't done much healing\n";
            var mailManager = new MailManager();
            var printMail = new PrintMail();

            mailManager.MailArrived += printMail.OnMailArrived;

            var timer = new Timer((Object obj) => {
                mailManager.SimulateMailArrived(new MailArrivedEventArgs(title, body));
            }, null, 0, 1000);

            Console.ReadLine();
        }
    }
}
