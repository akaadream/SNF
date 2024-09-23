using Collections.Pooled;

namespace ESC
{
    public sealed class Node()
    {
        public int Id { get; set; }

        private PooledList<Feature> _features { get; set; } = [];

        public T? Find<T>()
        {
            for (int i = 0; i < _features.Count; i++)
            {
                if (_features[i] is T t)
                {
                    return t;
                }
            }

            return default;
        }

        public void Update(float delta)
        {
            for (int i = 0; i < _features.Count; i++)
            {
                if (_features[i] is IUpdate updatable)
                {
                    updatable.Update(delta);
                }
            }
        }

        public void Draw(float delta)
        {
            for (int i = 0; i < _features.Count; i++)
            {
                if (_features[i] is IDraw drawable)
                {
                    drawable.Draw(delta);
                }
            }
        }
    }
}
