using Collections.Pooled;

namespace SNF
{
    public abstract class Scene()
    {
        private PooledList<Node> _nodes = [];

        internal void Load()
        {

        }

        public Feature Find<T>() where T : Feature
        {
            return _nodes.First<T>() ?? default;
        }
    }
}
