using System;
using System.Collections.Generic;

namespace Zoo_Simulator
{
    public abstract class Animal
    {
        protected Animal(string name)
        {
            Name = name;
            Health = 100f;
        }

        public string Name { get; set; }

        public float Health { get; set; }

        public abstract void UpdateHealth(float percentage);

        public abstract bool IsDead();

        public void Feed(float amount)
        {
            Health += Health * (amount / 100f);
            Health = Math.Min(Health, 100f);
        }
    }
}
