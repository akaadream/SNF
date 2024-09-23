using ESC;

namespace ECS.Tests.Utils
{
    public class TitleController : Controller
    {
        public void Index()
        {

        }

        public static Scene Title()
        {
            return new TitleScene();
        }
    }
}
