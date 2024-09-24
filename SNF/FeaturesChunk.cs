namespace SNF
{
    internal class FeaturesChunk(Type type)
    {
        /// <summary>
        /// Array of the existing features of the given type
        /// </summary>
        internal Feature[] Features = [];

        /// <summary>
        /// The type of the feature contained by this chunk
        /// </summary>
        internal Type Type = type;

        // Current number of features registered inside the array
        private int _count = 0;

        internal Feature AddFeature(Feature feature)
        {
            Features[_count] = feature;
            _count++;

            return feature;
        }
    }
}
