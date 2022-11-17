namespace APIGateway2._0.Models
{
    public abstract class Agent
    {
        public string Name { get; set; }
        public string Description { get; set; }

        protected Agent() {}
        protected Agent(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}