using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;

        

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        private void DrawLooseText()
        {
            Raylib.DrawText("YOU DIED", 150, 250, 200, Color.RED);
            Raylib.DrawText("Press ESC to quit", 500, 450, 25, Color.WHITE);
        }

        // Returns the scene that is at the index of the current scene index
        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }

        // Returns the scene at the index given and an empty scene if the index is out of bounds
        public static Scene GetScene(int index)
        {
            return _scenes[index];
        }

        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }

        // Adds the given scene to the array of scenes
        public static int AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;
            tempArray[index] = scene;
            _scenes = tempArray;

            return index;
        }

        // Finds the instance of the scene given that inside of the array and removes it
        public static bool RemoveScene(Scene scene)
        {
            if (scene == null)
            {
                return false;
            }

            bool sceneRemoved = false;

            Scene[] tempArray = new Scene[_scenes.Length - 1];

            int j = 0;
            for (int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            if (sceneRemoved)
                _scenes = tempArray;

            return sceneRemoved;
        }

        // Sets the current scene in the game to be the scene at the given index
        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return;

            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _currentSceneIndex = index;
        }

        // Returns true while a key is being pressed
        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        // Returns true while if key was pressed once
        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        //initializes game array
        public Game()
        {
            _scenes = new Scene[0];
        }

        // function that allows me to make ints with a rnadom number range 
        public static Random rnd = new Random();
        int Xr = rnd.Next(40, 51);  // creates a number between 40 and 50
        int Yr = rnd.Next(3, 23);  //random number between 3 and 22 

        public static void spawnEnemy(Scene scene, float round)
        {
            
            //adds (round * 5) of enemies that spawn in random locations
            for (int i = 0; i < (round * 5); i++)
            {
                int Xr = rnd.Next(40, 61);  // creates a number between 40 and 50
                int Yr = rnd.Next(3, 23);  //random number between 3 and 22
                scene.AddActor(new Enemy(Xr, Yr));
            }
                        
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            //Creates a new window for raylib
            Raylib.InitWindow(1280, 768, "Space Shot");
            Raylib.SetTargetFPS(60);

            //Set up console window
            Console.CursorVisible = false;
            Console.Title = "Space Shot";

            //Create a new scene for our actors to exist in
            Scene scene1 = new Scene();

            //adds player to scene
            Player player = new Player(2f, 10.5f);
            scene1.AddActor(player);

            //Spawns Enemies into the game 
            //spawnEnemy(scene1, 1);

            //Sets the starting scene index and adds the scenes to the scenes array
            int startingSceneIndex = 0;
            startingSceneIndex = AddScene(scene1);

            //Sets the current scene to be the starting scene index
            SetCurrentScene(startingSceneIndex);
        }

        //Called every frame.
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);

            spawnEnemy(GetCurrentScene(), 1);

        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.DrawText("SPACE SHOT", 465, 10, 50, Color.VIOLET);
            Raylib.DrawFPS(1, 1);

            if (_gameOver)
                DrawLooseText();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while (!Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }

            End();
        }
    }
}
