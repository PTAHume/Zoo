using System;

namespace Zoo_Simulator
{
    public class Elephant : Animal
    {
        private int _life = 2;

        public Elephant(string name) : base(name)
        {
        }

        public override void UpdateHealth(float percentage)
        {
            Health -= Health * (percentage / 100.0f);
            if (Health >= 70.0f)
            {
                _life = 2;
            }
        }

        public override void Feed(float amount)
        {
            Health += Health * (amount / 100f);
            Health = Math.Min(Health, 100f);
            if (Health >= 70.0f)
            {
                _life = 2;
            }
        }

        public override bool IsDead()
        {
            return _life == 0;
        }

        // Unque to Elephants
        public bool CanWalk()
        {
            if (Health < 70.0f && Health >= 0.0f)
            {
                _life--;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
