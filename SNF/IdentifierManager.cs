using SNF.Testing;

namespace SNF
{
    internal enum IdType
    {
        SCENE = 0,
        NODE = 1,
        FEATURE = 2,
        CHUNK = 3,
    }

    internal static class IdentifierManager
    {
        private static int currentSceneId { get; set; } = 0;
        private static int currentNodeId { get; set; } = 0;
        private static int currentFeatureId { get; set; } = 0;

        private static int currentChunkId { get; set; } = 0;

        internal static int GetNextId(IdType idType)
        {
            return idType switch
            {
                IdType.SCENE => currentSceneId++,
                IdType.NODE => currentNodeId++,
                IdType.FEATURE => currentFeatureId++,
                IdType.CHUNK => currentChunkId++,
                _ => throw new SNFException("Undefined ID type!"),
            };
        }
    }
}
