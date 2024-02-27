namespace Zoo_Simulator
{
    public class Monkey : Animal
    {
        public Monkey(string name) : base(name)
        {
        }

        public override void UpdateHealth(float percentage)
        {
            Health -= Health * (percentage / 100.0f);
        }

        public override bool IsDead()
        {
            return Health < 30.0f;
        }
    }
}
