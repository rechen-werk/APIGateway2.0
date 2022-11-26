namespace APIGateway.Models
{
    public abstract class Agent
    {
        protected Agent()
        {
        }

        protected Agent(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }
}