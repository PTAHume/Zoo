using System.Runtime.InteropServices;

namespace Zoo_Simulator
{
    public class Elephant : Animal
    {
        private int Life = 2;

        public Elephant(string name) : base(name)
        {
        }

        public override void UpdateHealth(float percentage)
        {
            Health -= Health * (percentage / 100.0f);
            if(Health >= 70.0f)
            {
                Life = 2;
            }

        }

        public override bool IsDead()
        {
            return  Life == 0;
        }

        // Unque to Elephants
        public bool CanWalk()
        {
            if (Health < 70.0f && Health >= 0.0f)
            {
                Life --;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
