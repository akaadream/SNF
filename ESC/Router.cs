namespace ESC
{
    public static class Router
    {
        private static Dictionary<string, Func<Scene>> _scenes { get; set; }

        internal static void Initialize()
        {
            _scenes = [];
        }

        public static void Register(string name, Func<Scene> callback)
        {
            _scenes.Add(name, callback);
        }

        public static void Load(string name)
        {
            if (_scenes.TryGetValue(name, out Func<Scene>? callback))
            {
                callback?.Invoke();
            }
        }

        public static void Prefix(string name, (string name, Func<Scene> callback)[] values)
        {
            foreach (var value in values)
            {
                Register($"{name}.{value.name}", value.callback);
            }
        }
    }
}
