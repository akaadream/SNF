namespace SNF.Observe
{
    internal class Observable(int id, Func<bool> condition)
    {
        public int Id { get; set; } = id;

        public Func<bool> Condition { get; set; } = condition;
    }
}
