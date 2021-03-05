namespace main
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var kiwi = new Kiwi("Wop", 155.5, "grey", Kind.Smart);
            kiwi.ToFly();
            kiwi.BirdProperties();
            var duckFirst = new Duck("Kria", 1500, "brown&green", Variety.DomesticDuck);
            duckFirst.ToFly();
            duckFirst.BirdProperties();
            var duckSecond = new Duck("Kriakva", 2248, "yellow&green", Variety.Mallard);
            duckSecond.ToSwim();
            duckSecond.BirdProperties();
            var penguin = new Penguin("Tolia", 4060, "white&black", Sex.Male);
            penguin.ToSwim();
            penguin.BirdProperties();
            var parrot = new Parrot("Kesha", 11, "green&yellow", Words.AlexTurner);
            parrot.ToSwim();
            parrot.ToFly();
            parrot.BirdProperties();
        }
    }
}
