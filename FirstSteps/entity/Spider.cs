namespace FirstSteps.entity
{
    public class Spider : Creature
    {
        public Spider()
        {
            Blood = 22;
            Attack = 15;
            Defense = 3;
        }

        public override string FighterType
        {
            get
            {
                return "Spider";
            }
        }
    }
}
