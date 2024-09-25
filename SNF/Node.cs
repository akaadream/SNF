using Collections.Pooled;

namespace SNF
{
    public sealed class Node(Scene scene, int id)
    {
        /// <summary>
        /// The unique ID of this node
        /// </summary>
        public int Id { get; set; } = id;

        /// <summary>
        /// The scene where this node is contained
        /// </summary>
        public Scene Scene { get; private set; } = scene;

        /// <summary>
        /// True if the node is active
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// The features IDs this node is currently using
        /// </summary>
        private PooledList<int> features { get; set; } = [];

        /// <summary>
        /// The children Nodes IDs attached to this node
        /// </summary>
        private PooledList<int> children { get; set; } = [];

        /// <summary>
        /// Create a new node (used internally only as a shortcut)
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static Node Create(Scene scene, int id) => new(scene, id);

        /// <summary>
        /// Add a new feature into this node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="feature"></param>
        public void AddFeature<T>(T feature) where T : Feature
        {
            features.Add(Scene.AddFeature(feature));
        }

        /// <summary>
        /// Add a node as a child
        /// </summary>
        /// <param name="node"></param>
        public void AddChild(Node node)
        {
            children.Add(node.Id);
        }

        /// <summary>
        /// Check if the node has the given feature
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool HasFeature<T>() where T : Feature
        {
            return Scene.HasFeature<T>();
        }
    }
}
