namespace SNF
{
    public sealed class App
    {
        /// <summary>
        /// Instance of the app
        /// </summary>
        public static App Instance { get; private set; } = new();

        private Dictionary<string, Func<Scene>> _scenes { get; set; }
        internal List<string> LoadedScenes { get; set; }

        internal int CurrentId;

        private App()
        {
            LoadedScenes = [];
            CurrentId = 0;
            _scenes = [];
        }

        /// <summary>
        /// Register a scene
        /// </summary>
        /// <param name="name"></param>
        /// <param name="callback"></param>
        public void Scene(string name, Func<Scene> callback)
        {
            _scenes.Add(name, callback);
        }

        /// <summary>
        /// Load a scene
        /// </summary>
        /// <param name="name"></param>
        public void Load(string name)
        {
            if (_scenes.TryGetValue(name, out Func<Scene>? callback))
            {
                callback?.Invoke();
            }
        }

        /// <summary>
        /// Use a prefix on all the given scene definitions
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        public void Prefix(string name, (string name, Func<Scene> callback)[] values)
        {
            foreach (var value in values)
            {
                Scene($"{name}.{value.name}", value.callback);
            }
        }
    }
}
