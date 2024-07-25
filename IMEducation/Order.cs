namespace IMEducation
{
    public class Order
    {
        public string ShopName { get; set; }
        public string City { get; set; }
        public string BookName { get; set; }
        public int Amount { get; set; }

        public Order(string name, string city, string bookName, int amount)
        {
            ShopName = name;
            City = city;
            BookName = bookName;
            Amount = amount;
        }

    }
}
