using Collections.Pooled;

namespace SNF
{
    public sealed class Node
    {
        public int Id { get; set; }

        private PooledList<Feature> _features { get; set; }

        private Node()
        {
            _features = [];
            Id = (App.Instance.CurrentId++).GetHashCode();
        }

        /// <summary>
        /// Create a new node
        /// </summary>
        /// <returns></returns>
        public Node Instanciate()
        {
            return new Node();
        }

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
