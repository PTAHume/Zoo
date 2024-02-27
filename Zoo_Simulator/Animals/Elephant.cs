namespace Zoo_Simulator
{
    public class Elephant : Animal
    {
        public Elephant(string name) : base(name)
        {
        }

        public override void UpdateHealth(float percentage)
        {
            Health -= Health * (percentage / 100.0f);
        }

        public override bool IsDead()
        {
            return Health < 70.0f;
        }

        public bool CanWalk()
        {
            return !(Health < 70.0f && Health >= 0.0f);
        }
    }
}
