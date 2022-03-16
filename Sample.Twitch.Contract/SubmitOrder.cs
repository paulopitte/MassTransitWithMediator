namespace Sample.Twitch.Contract
{
    public interface SubmitOrder
    {
        Guid OrderID { get; }
        DateTime OrderDate { get; }

        string CustomerName { get; }
    }


    public interface SubmitOrderAccepted
    {
        Guid OrderId { get; }
        DateTime OrderDate { get; }
        string CustomerName { get; }
        string Status { get; }

    }

    public interface SubmitOrderRejeted
    {
        Guid OrderId { get; }
        DateTime OrderDate { get; }
        string CustomerName { get; }
        string Status { get; }

        string Reason { get; }

    }
}
