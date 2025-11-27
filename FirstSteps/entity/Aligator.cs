namespace FirstSteps.entity
{
    public class Aligator : Creature
    {
        public Aligator()
        {
            Blood = 40;
            Attack = 31;
            Defense = 0;
        }

        public override string FighterType
        {
            get
            {
                return "Aligator";
            }
        }
    }
}
