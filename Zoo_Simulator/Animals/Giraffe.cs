namespace Zoo_Simulator
{
    public class Giraffe : Animal
    {
        public Giraffe(string name) : base(name)
        {
        }

        public override void UpdateHealth(float percentage)
        {
            Health -= Health * (percentage / 100.0f);
        }

        public override bool IsDead()
        {
            return Health < 50.0f;
        }
    }
}
