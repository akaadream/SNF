using Microsoft.Xna.Framework;

namespace SNF.MonoGame.Features
{
    public class Transform : Feature
    {
        /// <summary>
        /// The position of the transform
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// The rotation of the transform
        /// </summary>
        public Quaternion Rotation { get; set; }

        /// <summary>
        /// The scale of the transform
        /// </summary>
        public Vector3 Scale { get; set; }
    }
}
