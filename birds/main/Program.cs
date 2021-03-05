namespace main
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var kiwi = new Kiwi("Wop", 155.5, "grey", Kind.Smart);
            kiwi.TO_Fly();
            kiwi.BirdProperties();
            var duckFirst = new Duck("Kria", 1500, "brown&green", Variety.DomesticDuck);
            duckFirst.TO_Fly();
            duckFirst.BirdProperties();
            var duckSecond = new Duck("Kriakva", 2248, "yellow&green", Variety.Mallard);
            duckSecond.TO_Swim();
            duckSecond.BirdProperties();
            var penguin = new Penguin("Tolia", 4060, "white&black", Sex.Male);
            penguin.TO_Swim();
            penguin.BirdProperties();
            var parrot = new Parrot("Kesha", 11, "green&yellow", Words.AlexTurner);
            parrot.TO_Swim();
            parrot.TO_Fly();
            parrot.BirdProperties();
        }
    }
}
