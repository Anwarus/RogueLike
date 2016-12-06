using RLNET;

namespace RogueLike
{
    class Program
    {
        static readonly int _gameWidth = 180;
        static readonly int _gameHeight = 120;
        static RLRootConsole _rootConsole;

        static void Main(string[] args)
        {
            //Setup window settings
            RLSettings settings = new RLSettings();

            settings.BitmapFile = "terminal16x16.png";
            settings.CharHeight = 16;
            settings.CharWidth = 16;
            settings.Width = _gameWidth;
            settings.Height = _gameHeight;
            settings.Title = "RogueLike";
            //settings.StartWindowState

            _rootConsole = new RLRootConsole(settings);

            //Setup update and render methods
            _rootConsole.Update += OnRootConsoleUpdate;
            _rootConsole.Render += OnRootConsoleRender;

            _rootConsole.Run();
        }

        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {
            _rootConsole.Print(110, 80, "Hello World!", RLColor.White);
        }

        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            _rootConsole.Draw();
        }
    }
}
