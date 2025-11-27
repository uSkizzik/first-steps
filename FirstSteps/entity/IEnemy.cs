namespace FirstSteps.entity
{
    public interface IEnemy
    {
        bool IsAlive { get; }

        int ProduceHit();
        void ReceiveHit(int forseApplied);
    }
}