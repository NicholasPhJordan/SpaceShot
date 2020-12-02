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
        int X = rnd.Next(40, 51);  // creates a number between 40 and 50
        int Y = rnd.Next(3, 23);  //random number between 3 and 22 

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

            Enemy enemy = new Enemy(X, Y);
            enemy.Rotate(-1.6f);
            enemy.SetScale(2, 2);
            enemy.Velocity.X = -3.0f;
            scene1.AddActor(enemy);

            Player player = new Player(2f, 10.5f);
            player.Rotate(-1.58f);
            player.SetScale(2, 2);
            scene1.AddActor(player);

            //checks for collision between actors
            enemy.CheckCollision(player);
            player.CheckCollision(enemy);

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
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.DrawText("SPACE SHOT", 500, 10, 50, Color.VIOLET);
            Raylib.DrawFPS(1, 1);

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

            while (!_gameOver && !Raylib.WindowShouldClose())
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
