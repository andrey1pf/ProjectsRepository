using System;

namespace main
{
    public abstract class Bird
    {
        protected string _name;
        protected double _weight;
        protected string _color;

        protected Bird(string name, double weight, string color)
        {
            _name = name ?? throw new ArgumentNullException("you need a name, but you don't have one");
            _color = color ?? throw new ArgumentNullException("you need a color, but you don't have one");
            if (weight < 0) 
            {
                throw new ArgumentException("weight cannot be less than 0");
            }
            _weight = weight;
        }
    }
    // Kiwi start
    public enum Kind
    {
        Sad,
        Funny,
        Smart
    };

    internal class Kiwi : Bird, IFlyable
    {
        private Kind _kind;

        public Kiwi(string name, double weight, string color, Kind kind) : base(name, weight, color)
        {
            this._kind = kind;
        }

        public void ToFly()
        {
            Console.WriteLine("Kiwi " + _name + " flew");
        }

        public void BirdProperties()
        {
            Console.WriteLine(_name + " weighs " + _weight + " grams. " + "Her color is " + _color + " and she looks like a " + _kind + " bird.");
            Console.WriteLine();
        }
    }
    //Kiwi end
    //Duck start
    public enum Variety
    {
        Mallard,
        DomesticDuck,
        LongNosedRedhead
    };

    internal class Duck : Bird, IFlyable, ISwimable
    {
        private Variety _variety;

        public Duck(string name, double weight, string color, Variety variety) : base(name, weight, color)
        {
            this._variety = variety;
        }
        public void ToFly()
        {
            Console.WriteLine("Duck " + _name + " flew");
        }

        public void ToSwim()
        {
            Console.WriteLine("And duck " + _name + " swam");
        }

        public void BirdProperties()
        {
            Console.WriteLine(_name + " weighs " + _weight + " grams. " + "Her color is " + _color + ". Her breed is " + _variety);
            Console.WriteLine();
        }
    }
    //Duck end
    //Penguin start
    public enum Sex
    {
        Male,
        Female
    };

    internal class Penguin : Bird, ISwimable
    {
        private Sex _sex;

        public Penguin(string name, double weight, string color, Sex sex) : base(name, weight, color)
        {
            this._sex = sex;
        }

        public void ToSwim()
        {
            Console.WriteLine("Penguin " + _name + " swam");
        }
        public void BirdProperties()
        {
            Console.WriteLine(_name + " weighs " + _weight + " grams. " + "His color is " + _color + ".");
            Console.WriteLine();
        }
    }
    //Penguin end
    //Parrot start
    public enum Words
    {
        Andrey,
        Parrot,
        AlexTurner,
        Flint
    };

    internal class Parrot : Bird, IFlyable
    {
        private Words _words;

        public Parrot(string name, double weight, string color, Words words) : base(name, weight, color)
        {
            this._words = words;
        }
        public void ToFly()
        {
            Console.WriteLine("Parrot " + _name + " flew");
        }

        public void BirdProperties()
        {
            Console.WriteLine(_name + " weighs " + _weight + " grams. " + "His color is " + _color + ". " + _name + "'s favorite word is " + _words);
            Console.WriteLine();
        }
        
    }
    //Parrot end
}
