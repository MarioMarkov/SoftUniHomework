namespace _03BarracksFactory.Models.Units
{
    public class Horseman : Unit
    {
        private const int DefaultHealth = 30;
        private const int DefaultDamage = 15;

        public Horseman()
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}

