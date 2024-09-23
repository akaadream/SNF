namespace ESC
{
    public abstract class Feature
    {
        public bool IsUpdatable { get => this is IUpdate; }

        public bool IsDrawable { get => this is IDraw; }
    }
}
