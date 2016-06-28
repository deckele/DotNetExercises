using System;
using System.Data.SqlClient;

namespace MailSystem
{
    public class MailArrivedEventArgs : EventArgs
    {
        public MailArrivedEventArgs(string title, string body)
        {
            Title = title;
            Body = body;
        }
        public string Title { get; }
        public string Body { get; }
    }

    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        public void SimulateMailArrived(MailArrivedEventArgs args)
        {
            Console.WriteLine("Sending e-mail...");
            OnMailArrived(args);
        }

        protected virtual void OnMailArrived(MailArrivedEventArgs args)
        {
            if (MailArrived != null)
            {
                MailArrived(this, args);
            }
        }
    }
}