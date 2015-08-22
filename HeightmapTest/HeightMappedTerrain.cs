using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeightmapTest
{
	public class HeightMappedTerrain
	{
		VertexPositionNormalTexture[] vertices;
		VertexBuffer vertexBuffer;
		int[] indices;
		IndexBuffer indexBuffer;
		float[,] heights;
		float height;
		float cellSize;
		int width, length;
		int nVertices, nIndices;
		Effect effect;
		GraphicsDevice GraphicsDevice;
		Texture2D heightMap;

		Texture2D baseTexture;
		float textureTiling;
		Vector3 lightDirection;

		public HeightMappedTerrain(Texture2D heightmap, float cellsize, float height, Texture2D basetex, float textile, Vector3 lightdir, GraphicsDevice device, ContentManager content)
		{
			baseTexture = basetex;
			textureTiling = textile;
			lightDirection = lightdir;

			heightMap = heightmap;
			width = heightmap.Width;
			length = heightMap.Height;

			cellSize = cellsize;
			this.height = height;
			GraphicsDevice = device;

			effect = content.Load<Effect>("TerrainEffect");
			nVertices = width * length;
			nIndices = (width - 1) * (length - 1) * 6;

			vertexBuffer = new VertexBuffer(device, typeof(VertexPositionNormalTexture), nVertices, BufferUsage.WriteOnly);
			indexBuffer = new IndexBuffer(device, IndexElementSize.ThirtyTwoBits, nIndices, BufferUsage.WriteOnly);

			extractHeightData();
			createVertexData();
			createIndexData();
			createNormalData();

			vertexBuffer.SetData<VertexPositionNormalTexture>(vertices);
			indexBuffer.SetData<int>(indices);
		}

		public void Draw(Matrix view, Matrix projection)
		{
			GraphicsDevice.SetVertexBuffer(vertexBuffer);
			GraphicsDevice.Indices = indexBuffer;

			effect.Parameters["View"].SetValue(view);
			effect.Parameters["Projection"].SetValue(projection);
			effect.Parameters["BaseTexture"].SetValue(baseTexture);
			effect.Parameters["TextureTiling"].SetValue(textureTiling);
			effect.Parameters["LightDirection"].SetValue(lightDirection);

			effect.Techniques[0].Passes[0].Apply();
			GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, nVertices, 0, nIndices / 3);
		}

		private void extractHeightData()
		{
			Color[] heightMapData = new Color[width * length];
			heightMap.GetData<Color>(heightMapData);

			heights = new float[width, length];

			for (int y = 0; y < length; ++y)
			{
				for (int x = 0; x < width; ++x)
				{
					float amt = heightMapData[y * width + x].R;
					amt /= 255f;
					heights[x, y] = amt * height;
				}
			}
		}

		private void createVertexData()
		{
			vertices = new VertexPositionNormalTexture[nVertices];

			Vector3 offsetToCenter = -(new Vector3((width / 2f) * cellSize, 0, (height / 2f) + cellSize));

			for (int z = 0; z < length; ++z)
			{
				for (int x = 0; x < width; ++x)
				{
					Vector3 position = new Vector3(x * cellSize, heights[x, z], z * cellSize) + offsetToCenter;
					Vector2 uv = new Vector2((float)x / width, (float)z / length);
					vertices[z * width + x] = new VertexPositionNormalTexture(position, Vector3.Zero, uv);
				}
			}
		}

		private void createIndexData()
		{
			indices = new int[nIndices];

			int i = 0;
			for (int x = 0; x < width - 1; ++x)
			{
				for (int z = 0; z < length - 1; ++z)
				{
					int ul = z * width + x;
					int ur = ul + 1;
					int ll = ul + width;
					int lr = ll + 1;

					// Upper triangle
					indices[i++] = ul;
					indices[i++] = ur;
					indices[i++] = ll;

					// Lower Triangle
					indices[i++] = ll;
					indices[i++] = ur;
					indices[i++] = lr;
				}
			}
		}

		private void createNormalData()
		{
			for (int i = 0; i < nIndices; i += 3)
			{
				Vector3 v1 = vertices[indices[i]].Position;
				Vector3 v2 = vertices[indices[i + 1]].Position;
				Vector3 v3 = vertices[indices[i + 2]].Position;

				Vector3 normal = Vector3.Cross(v1 - v2, v1 - v3);
				normal.Normalize();

				vertices[indices[i]].Normal += normal;
				vertices[indices[i + 1]].Normal += normal;
				vertices[indices[i + 2]].Normal += normal;
			}

			for (int i = 0; i < nVertices; ++i)
				vertices[i].Normal.Normalize();
		}
	}
}
