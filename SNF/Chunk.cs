using Collections.Pooled;

namespace SNF
{
    /// <summary>
    /// Chunk created each time a new type of component is added to the scene containing this chunk
    /// </summary>
    /// <param name="id"></param>
    internal class Chunk<T>(int id)
    {
        public int Id { get; private set; } = id;

        public Type Type { get; private set; } = typeof(T);

        // <summary>
        /// Pooled list of nodes chunks
        /// </summary>
        private readonly PooledList<Node> nodes = [];
    }
}
