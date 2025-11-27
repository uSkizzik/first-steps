using System;

namespace FirstSteps.entity
{
    public abstract class LivingEntity : Entity, IEnemy
    {
        public bool IsAlive { get; protected set; } = true;
        public int Blood { get; protected set; }
        public int Attack { get; protected set; }
        public int Defense { get; protected set; }
        public abstract string FighterType { get; }

        public virtual void ReceiveHit(int forseApplied)
        {
            ReduceBlood(forseApplied - Defense);
        }

        public virtual int ProduceHit()
        {
            return Attack;
        }

        public override void DisplayObject()
        {
            Display($"Fighter: {FighterType}", ConsoleColor.Yellow);
            Display($"Blood: {Blood}");
            Display($"Attack: {Attack}");
            Display($"Defense: {Defense}");

        }

        protected void ReduceBlood(int amountOfBloodToReduce)
        {
            if ((Blood - amountOfBloodToReduce) <= 0)
            {
                Blood = 0;
                IsAlive = false;
            }
            else
            {
                Blood -= amountOfBloodToReduce;
            }
        }
    }
}
