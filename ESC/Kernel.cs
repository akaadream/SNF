namespace ESC
{
    public sealed class Kernel
    {
        public static Kernel Instance { get; private set; } = new();

        internal List<string>? LoadedScenes { get; set; }

        private Kernel()
        {

        }

        private void Initialize()
        {
            LoadedScenes = [];
            Router.Initialize();
        }

        public static void Run()
        {
            Instance.Initialize();
        }

        internal bool AddLoadedScene(string name)
        {
            if (LoadedScenes == null)
            {
                throw new Exception("The kernel needs to be initialized before any use!");
            }

            if (LoadedScenes.Contains(name))
            {
                return false;
            }

            LoadedScenes.Add(name);

            return true;
        }
    }
}
