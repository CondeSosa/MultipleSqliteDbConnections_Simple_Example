namespace MultipleSqliteDbConnections.SqLiteManager.Models
{
    public class Company
    {
        public int Id { get; set; }
        public int IdType { get; set; } 
        public string IdNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
