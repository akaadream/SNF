using SNF.Flow;

namespace SNF
{
    public abstract class Feature
    {
        /// <summary>
        /// True if this feature can be updated
        /// </summary>
        public bool IsUpdatable { get => this is IUpdate; }

        /// <summary>
        /// True if this feature can be drawn
        /// </summary>
        public bool IsDrawable { get => this is IDraw; }

        /// <summary>
        /// True if the feature is active
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        public virtual void Update(float delta) { }

        public virtual void Draw(float delta) { }
    }
}
