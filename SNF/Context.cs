using Collections.Pooled;

namespace SNF
{
    public static class Context
    {
        /// <summary>
        /// Pooled list of nodes chunks
        /// </summary>
        private static readonly PooledList<NodesChunk> _nodes = [];

        /// <summary>
        /// Pooled list of features chunks
        /// </summary>
        private static readonly PooledList<FeaturesChunk> _features = [];

        /// <summary>
        /// Create a new chunk
        /// </summary>
        /// <returns></returns>
        internal static int CreateChunk()
        {
            int nextId = _nodes.Count;
            _nodes.Add(new NodesChunk());
            return nextId;
        }

        /// <summary>
        /// Get the next chunk available for a node to be added
        /// </summary>
        /// <returns></returns>
        internal static int GetNodeChunk()
        {
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].IsAvailable)
                {
                    return i;
                }
            }

            return CreateChunk();
        }

        internal static int GetFeatureChunk(Type type)
        {
            for (int i = 0; i < _features.Count; i++)
            {
                if (type.IsEquivalentTo(_features[i].Type))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Add a node in 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static bool AddNode(Node node)
        {
            return AddNode(node, GetNodeChunk());
        }

        private static bool AddNode(Node node, int chunkId)
        {
            return _nodes[chunkId].AddNode(node);
        }

        public static Node CreateNode()
        {
            int chunkId = GetNodeChunk();
            int nodeId = _nodes[chunkId].Count + chunkId * NodesChunk.DEFAULT_NODES_CAPACITY;
            Node node = Node.Instanciate(nodeId);

            AddNode(node, chunkId);

            return node;
        }

        public static Feature? CreateFeature<T>() where T : Feature, new()
        {
            int chunkId = GetFeatureChunk(typeof(T));
            if (chunkId < 0)
            {
                return null;
            }

            return _features[chunkId].AddFeature(new T());
        }
    }
}
