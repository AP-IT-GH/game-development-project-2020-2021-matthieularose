﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameDevProject.Collision;
using GameDevProject.GameObjects;
using GameDevProject.GameObjects.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.LevelDesign
{
    public class Level
    {
        //ScreenRes: 800px * 480px (800/32 = 25 & 480/32 = 15)
        public Texture2D texture;
        public List<Rectangle> tileTypes = new List<Rectangle>();

        public int levelWidth = 800;
        public int levelHeight = 480;

        public byte[] tileArray = new Byte[]
        {
            8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 9, 0, 0, 7, 9, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 9, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 9, 0, 0, 0, 0, 0, 0, 0, 7, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 0, 0, 0, 0, 1, 2, 3, 0, 0, 4, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 5, 6, 0, 0, 0, 0, 4, 5, 6, 0, 0, 4, 5, 5, 2, 2, 2, 2, 2, 2, 2, 3, 0, 0, 4, 5, 6, 0, 0, 0, 0, 4, 5, 6, 0, 0, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 0, 0, 4, 5, 6, 0, 0, 0, 0, 4, 5, 6, 0, 0, 4, 5, 5
        };

        public Tile[,] tArray = new Tile[4, 6];

        public List<Tile> tiles = new List<Tile>();

        //public Tile t;

        private ContentManager content;

        public Level(ContentManager content, Texture2D text)
        {
            this.content = content;
            texture = text;
            GetTileSprites(96, 96, 32, 32);
        }


        public void Create()
        {
            int count = 0;
            for (int y = 0; y < levelHeight; y += 32)
            {
                for (int x = 0; x < levelWidth; x += 32)
                {
                    if (tileArray[count] != 0)
                    {
                        tiles.Add(new Tile(texture, new Vector2(x, y), tileTypes[tileArray[count]]));
                    }
                    count++;
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Tile tile in tiles)
            {
                tile.Draw(spritebatch);
            }
        }

        //Temporarily
        public void GetTileSprites(int imgWidth, int imgHeight, int tileWidth, int tileHeight)
        {
            tileTypes.Add(new Rectangle()); //0 = Empty
            for (int h = 0; h < imgHeight; h += tileHeight)
            {
                for (int w = 0; w < imgWidth; w += tileWidth)
                {
                    tileTypes.Add(new Rectangle(w, h, tileWidth, tileHeight));
                }
            }
        }
    }
}