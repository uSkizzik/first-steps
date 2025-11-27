using System;
using System.Collections.Generic;

namespace FirstSteps.entity.player
{
    public class Hero : LivingEntity
    {
        private string _fighterName;
        public Hero(string fighterName)
        {
            Blood = 100;
            Attack = 10;
            Defense = 5;
            Level = 1;
            _fighterName = fighterName;
        }

        public override string FighterType
        {
            get
            {
                return _fighterName;
            }
        }

        public int Level { get; internal set; }

        public List<Booster> AvailableBoosters { get; private set; } = new List<Booster>();

        public void Fight(IEnemy enemyFighter, Booster booster)
        {
            if (booster != null)
            {
                ApplyBoosterToTheHero(booster);
            }

            do
            {
                enemyFighter.ReceiveHit(Attack);

                if (enemyFighter.IsAlive)
                {
                    int enemyStrikeForse = enemyFighter.ProduceHit() - Defense;

                    if (enemyStrikeForse > 0)
                    { 
                        ReduceBlood(enemyStrikeForse);
                    }
                }
            }
            while (this.IsAlive && enemyFighter.IsAlive);

            if (IsAlive)
            {
                Level++;
                AddBooster();
            }
        }

        private void ApplyBoosterToTheHero(Booster booster)
        {
            switch (booster.Type)
            {
                case BoosterTypes.Healing:
                    Blood += booster.Level;
                    break;
                case BoosterTypes.Armor:
                    Defense += booster.Level;
                    break;
                case BoosterTypes.Energy:
                    Attack += (Attack * booster.Level) / 100;
                    break;
            }

            // this booster should not be used anymore
            AvailableBoosters.Remove(booster);
        }

        private void AddBooster()
        {
            Random random = new Random();

            if (random.Next(1, 3) == 1)
            {
                int boosterTypeId = random.Next(1, 3);
                BoosterTypes boosterType = (BoosterTypes)boosterTypeId;
                int boosterLevel = 0;

                switch (boosterType)
                {
                    case BoosterTypes.Armor:
                    case BoosterTypes.Healing:
                        boosterLevel = (Level * 100) / random.Next(1, 5);
                        break;
                    case BoosterTypes.Energy:
                        boosterLevel = random.Next(10, 30);
                        break;
                }

                Booster booster = new Booster(boosterType, boosterLevel);
                AvailableBoosters.Add(booster);
            }
        } 

        public override void DisplayObject()
        {
            base.DisplayObject();
            base.Display($"Level {Level}");
        }
    }
}
