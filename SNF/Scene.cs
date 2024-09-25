using Collections.Pooled;
using SNF.Testing;

namespace SNF
{
    public abstract class Scene()
    {
        /// <summary>
        /// Dictionnary of chunk types
        /// </summary>
        private readonly Dictionary<int, ChunkType> chunksTypesIds = [];

        /// <summary>
        /// Pooled list of nodes
        /// </summary>
        private readonly PooledList<Node> nodes = [];

        /// <summary>
        /// Pooled list of chunks
        /// </summary>
        private readonly PooledList<int> chunksIds = [];

        /// <summary>
        /// Nodes IDs contained by the scene
        /// </summary>
        private PooledList<int> nodesIds = [];

        /// <summary>
        /// Features IDs which can be updated
        /// </summary>
        private Dictionary<Type, List<Feature>> features = [];

        /// <summary>
        /// Add a new feature inside the dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="feature"></param>
        /// <returns></returns>
        internal int AddFeature<T>(Feature feature) where T : Feature
        {
            if (features.TryGetValue(typeof(T), out List<Feature>? chunk))
            {
                if (chunk == null)
                {
                    throw new SNFException("A features chunk got an unexpected value of null");
                }

                int nextId = chunk.Count;
                chunk.Add(feature);
                return nextId;
            }

            features.Add(typeof(T), [feature]);
            return 0;
        }

        public bool HasFeature<T>(int featureId) where T : Feature
        {
            if (features.TryGetValue(typeof(T), out List<Feature>? chunk))
            {
                if (chunk == null)
                {
                    return false;
                }

                if (chunk.Count > featureId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Update available features
        /// </summary>
        /// <param name="delta"></param>
        public void Update(float delta)
        {
            for (int i = 0; i < features.Count; i++)
            {
                if (!features[i].IsEnabled ||
                    !features[i].IsUpdatable)
                {
                    continue;
                }

                features[i].Update(delta);
            }
        }

        /// <summary>
        /// Draw available features
        /// </summary>
        /// <param name="delta"></param>
        public void Draw(float delta)
        {
            for (int i = 0; i < features.Count; i++)
            {
                if (!features[i].IsEnabled ||
                    !features[i].IsDrawable)
                {
                    continue;
                }

                features[i].Draw(delta);
            }
        }
    }
}
