namespace FruitsApi
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Rating { get; set; }

        public string Review { get; set; } = string.Empty;
    }
}
