﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using GameDevProject.Animation;
using GameDevProject.Background;
using GameDevProject.Collision;
using GameDevProject.GameObjects;
using GameDevProject.GameObjects.World;
using GameDevProject.Input;
using GameDevProject.LevelDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDev_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //CollisionDetector collisionDetector;
        CollisionManager collisionManager;

        /*---TEXTURES---*/
        private Texture2D idleTextureR;
        private Texture2D idleTextureL;
        private Texture2D runTextureR;
        private Texture2D runTextureL;
        private Texture2D jumpTextureR;
        private Texture2D jumpTextureL;

        private Texture2D tileTexture;

        private List<Texture2D> backgroundTextures = new List<Texture2D>();

        /*---GAMEOBJECTS---*/
        Level level;
        Player player;
        //Tile tile;

        /*---CAMERA---*/
        int cameraOffsetX = 150;
        //int cameraOffsetY = 350;

        /*---BACKGROUND---*/
        ParallaxBackground background;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GetTextures();

            background = new ParallaxBackground(backgroundTextures);
            background.Initialize();
            
            level = new Level(Content, tileTexture);
            level.Initialize();

            player = new Player(new KeyboardInput());
            player.animationManager = new PlayerAnimationManager(idleTextureR, idleTextureL, runTextureR, runTextureL, jumpTextureR, jumpTextureL);

            collisionManager = new CollisionManager(player, level.tiles);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            collisionManager.Update();

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin(transformMatrix: Matrix.CreateTranslation(- player.position.X + cameraOffsetX, 0, 0));

            background.Draw(_spriteBatch);

            level.Draw(_spriteBatch);

            player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
        private void GetTextures()
        {
            //MGCB Editor doesn't work on latest version of MacOS
            string dir = "/Users/matthieu/School/2EA-Cloud/GameDev/game-development-project-2020-2021-matthieularose/game/Content/";

            //Player
            FileStream fileStream = new FileStream(dir + "sprites/idleRight.png", FileMode.Open);
            idleTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/idleLeft.png", FileMode.Open);
            idleTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/runRight.png", FileMode.Open);
            runTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/runLeft.png", FileMode.Open);
            runTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/jumpRight.png", FileMode.Open);
            jumpTextureR = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/jumpLeft.png", FileMode.Open);
            jumpTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            fileStream = new FileStream(dir + "sprites/jumpLeft.png", FileMode.Open);
            jumpTextureL = Texture2D.FromStream(GraphicsDevice, fileStream);

            //Tilesets
            fileStream = new FileStream(dir + "tilesets/tileset1.png", FileMode.Open);
            tileTexture = Texture2D.FromStream(GraphicsDevice, fileStream);

            //Parallax Backgrounds
            fileStream = new FileStream(dir + "backgrounds/plx-1.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-2.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-3.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-4.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream = new FileStream(dir + "backgrounds/plx-5.png", FileMode.Open);
            backgroundTextures.Add(Texture2D.FromStream(GraphicsDevice, fileStream));

            fileStream.Dispose();
        }
    }
}

/*TODO:
 * 
 * 2de Level
 * Menuscherm
 * Player death -> position.Y < 0
 * GameOver Scherm
 * TextureLoader
 * JSONParser + levels in JSON files opslaan
 * root dir veranderen
 * SpriteLoader? (verdeeld sprites in frames)
 * IGameObject verwijderen?
 * 
 */