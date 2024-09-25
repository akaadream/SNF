using Collections.Pooled;
using SNF.Observe;

namespace SNF
{
    public sealed class Node
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        private PooledList<int> _features { get; set; }

        private Observer? _observer { get; set; }

        private Node(int id)
        {
            _features = [];
        }

        /// <summary>
        /// Create a new node
        /// </summary>
        /// <returns></returns>
        internal static Node Instanciate(int id) => new(id);

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

        public void AddFeature(int id)
        {

        }

        public void Update()
        {
            if (!IsActive)
            {
                return;
            }

            _observer?.Run();
        }
    }
}
