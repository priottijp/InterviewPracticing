using System;


namespace InterviewPracticing.DesignPatterns.Structural
{

    public class Bridge : DesignPattern
    {
        public override void TryPattern()
        {
            IMessageSender email = new EmailSender();

            Message message = new SystemMessage();
            message.Subject = "Test Message";
            message.Body = "Hi, This is a Test Message";

            message.SendMessage(new EmailSender());
            message.SendMessage(new MSMQSender());
            message.SendMessage(new WebServiceSender());

            UserMessage usermsg = new UserMessage();
            usermsg.Subject = "Test Message";
            usermsg.Body = "Hi, This is a Test Message";
            usermsg.UserComments = "I hope you are well";

            usermsg.MessageSender = email;
            usermsg.Send();

            Console.ReadKey();
        }
    }

    //Source: https://www.dotnettricks.com/learn/designpatterns/bridge-design-pattern-dotnet

    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public abstract class Message
    {
        public IMessageSender MessageSender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public abstract void Send();
        public abstract void SendMessage(IMessageSender sender);
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class SystemMessage : Message
    {
        public override void Send()
        {
            MessageSender.SendMessage(Subject, Body);
        }

        public override void SendMessage(IMessageSender sender)
        {
            sender.SendMessage(Subject, Body);
        }
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class UserMessage : Message
    {
        public string UserComments { get; set; }

        public override void Send()
        {
            string fullBody = string.Format("{0}\nUser Comments: {1}", Body, UserComments);
            MessageSender.SendMessage(Subject, fullBody);
        }

        public override void SendMessage(IMessageSender sender)
        {
            string fullBody = string.Format("{0}\nUser Comments: {1}", Body, UserComments);
            sender.SendMessage(Subject, fullBody);
        }
    }

    /// <summary>
    /// The 'Bridge/Implementor' interface
    /// </summary>
    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine("Email\n{0}\n{1}\n", subject, body);
        }
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class MSMQSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine("MSMQ\n{0}\n{1}\n", subject, body);
        }
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class WebServiceSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine("Web Service\n{0}\n{1}\n", subject, body);
        }
    }
}
