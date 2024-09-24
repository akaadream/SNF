namespace SNF.MonoGame.Features
{
    public class Counter() : Feature, IUpdate
    {
        public int Count = 0;

        public void Update(float delta)
        {
            Count++;
        }
    }
}
