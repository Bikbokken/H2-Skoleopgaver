public enum MessageCarrier { Smtp, VMessage }

interface Sender
{
    void SendMessage(MessageCarrier type, Message m, bool isHTML);
    void SendMessageToAll(MessageCarrier type, string[] to, Message m, bool isHTML);
}

public class VMessage : Sender
{
    private Converter Converter = new HTMLConverter();
    public void SendMessage(MessageCarrier type, Message m, bool isHTML)
    {
        if (isHTML)
            m.Body = Converter.Convert(m.Body);
        //her implementeres alt koden til at sende via VMessage
    }

    public void SendMessageToAll(MessageCarrier type, string[] to, Message m, bool isHTML)
    {
        if (isHTML)
            m.Body = Converter.Convert(m.Body);
        //her implementeres alt koden til at sende via VMessage
    }
}

public class SMTPSender : Sender
{
    private Converter Converter = new HTMLConverter();
    public void SendMessage(MessageCarrier type, Message m, bool isHTML)
    {
        //herinde sendes der en email ud til modtageren
        if (isHTML)
            m.Body = Converter.Convert(m.Body);
        //her implementeres alt koden til at sende via Smtp

    }

    public void SendMessageToAll(MessageCarrier type, string[] to, Message m, bool isHTML)
    {
        if (isHTML)
            m.Body = Converter.Convert(m.Body);
        //her implementeres alt koden til at sende via Smtp
    }
}

public interface Converter
{
    string Convert(string message);
}

public class HTMLConverter : Converter
{
    public string Convert(string plainText)
    {
        return "" + plainText + "";
    }
}


public class Message
{

    string to, from, body, subject, cc;

    public Message(string to, string from, string body, string subject, string cc)
    {
        this.to = to;
        this.from = from;
        this.body = body;
        this.subject = subject;
        this.cc = cc;
    }

    public string To { get => to; set => to = value; }
    public string From { get => from; set => from = value; }
    public string Body { get => body; set => body = value; }
    public string Subject { get => subject; set => subject = value; }
    public string Cc { get => cc; set => cc = value; }

    public string GetBody()
    {
        return body;
    }

    public string GetRecipients()
    {
        return to;
    }


}

