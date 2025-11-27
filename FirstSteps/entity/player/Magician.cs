using System;

namespace FirstSteps.entity.player
{
    public abstract class Magician : LivingEntity
    {
        private Random _random = new Random();

        public int MagicEnergy { get; protected set; } = 0;
        
        protected bool CanApplyMagicEnergy()
        {
            bool result = false;

            if (GetRandomNumber(1, 100) < MagicEnergy)
            {
                result = true;
            }

            // Reduce the energy for the next round
            MagicEnergy = MagicEnergy / 2;

            return result;
        }

        protected int GetRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public override void DisplayObject()
        {
            base.DisplayObject();
            base.Display($"Magic energy {MagicEnergy}");
        }
    }
}
