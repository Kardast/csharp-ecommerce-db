public class Payment
{
    public int Id { get; set; }
    public string Date { get; set; }
    public string Amount { get; set; }
    public string Status { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}
