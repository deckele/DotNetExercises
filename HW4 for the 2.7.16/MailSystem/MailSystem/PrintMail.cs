using System;

namespace MailSystem
{
    public class PrintMail
    {
        public void OnMailArrived(object sender, MailArrivedEventArgs args)
        {
            Console.WriteLine("\nTitle: {0}\nBody: {1}", args.Title, args.Body);
        }
    }
}