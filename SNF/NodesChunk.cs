namespace SNF
{
    internal class NodesChunk
    {
        internal Node[] Nodes;
        internal int Count;

        internal const int DEFAULT_NODES_CAPACITY = 1024;

        internal bool IsAvailable { get => Count < DEFAULT_NODES_CAPACITY; }

        public NodesChunk()
        {
            Nodes = new Node[DEFAULT_NODES_CAPACITY];
        }

        /// <summary>
        /// Add a new node inside the chunk
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        internal bool AddNode(Node node)
        {
            if (Count == Nodes.Length)
            {
                return false;
            }

            Nodes[Count++] = node;
            return true;
        }
    }
}
