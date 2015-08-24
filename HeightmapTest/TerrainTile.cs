using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HeightmapTest
{
	public abstract class TerrainTile
	{
		private static Effect TerrainEffect = null;


		#region Terrain Settings

		#endregion

		#region Terrain Data
		#endregion

		protected TerrainTile()
		{
			
		}

		// Override to load the terrain in the terrain tile
		protected abstract void LoadTerrainData();
	}
}
