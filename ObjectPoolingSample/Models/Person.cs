namespace ObjectPoolingSample.Models
{
    internal class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
          
    }
}
