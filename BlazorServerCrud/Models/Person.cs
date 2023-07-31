namespace BlazorServerCrud.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Biodata { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ExpectedSalary { get; set; }
        public bool IsAvailable { get; set; }

    }
}
