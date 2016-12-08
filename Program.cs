using RLNET;
using RogueLike.Core;

namespace RogueLike
{
    class Program
    {
        //Root console
        static readonly int _screenWidth = 80;
        static readonly int _screenHeight = 60;
        static RLRootConsole _rootConsole;

        //Map console
        static readonly int _mapPositionX = 0;
        static readonly int _mapPositionY = 0;
        static readonly int _mapWidth = 80;
        static readonly int _mapHeight = 60;
        static RLConsole _mapConsole;

        //Dungeon
        public static DungeonMap DungeonMap { get; private set; }
        //Player

        static void Main(string[] args)
        {
            //Setup window settings
            string bitmapFile = "terminal16x16.png";
            int charHeight = 16;
            int charWidth = 16;
            int width = _screenWidth;
            int height = _screenHeight;
            string title = "RogueLike";

            //Create window
            _rootConsole = new RLRootConsole(bitmapFile, width, height, charWidth, charHeight, 1f, title);

            //Create map sub-window
            _mapConsole = new RLConsole(_mapWidth, _mapHeight);

            //Create dungeon
            DungeonMap = new DungeonMap();

            //Setup update and render methods
            _rootConsole.Update += OnRootConsoleUpdate;
            _rootConsole.Render += OnRootConsoleRender;

            _rootConsole.Run();
        }

        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {
            _mapConsole.Print(1, 1, "Hello World! Welcome in my game!", RLColor.White);
            _mapConsole.Print(0, 0, DungeonMap.ToString(), RLColor.White);
        }

        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            RLConsole.Blit(_mapConsole, 0, 0, _mapWidth, _mapHeight, _rootConsole, _mapPositionX, _mapPositionY);

            _rootConsole.Draw();
        }
    }
}
