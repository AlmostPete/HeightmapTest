using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HeightmapTest
{
	public class HeightmapGame : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		FreeCamera camera;
		HeightMappedTerrain terrain;

		public HeightmapGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			graphics.IsFullScreen = true;
			Window.IsBorderless = true;
			Window.AllowUserResizing = false;
			Window.Position = Point.Zero;
			graphics.ApplyChanges();
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
			graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
			graphics.ApplyChanges();

			camera = new FreeCamera(new Vector3(0, 250, 0), 0f, 0f, graphics.GraphicsDevice);
			terrain = new HeightMappedTerrain(Content.Load<Texture2D>("terrain"), 1, 100, Content.Load<Texture2D>("grass"), 10, new Vector3(1, -1, 0), graphics.GraphicsDevice, Content);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Mouse.SetPosition(1920 / 2, 1080 / 2);
			lastMouseState = Mouse.GetState();

			// TODO: use this.Content to load your game content here
		}

		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		MouseState lastMouseState;
		protected override void Update(GameTime gameTime)
		{
			// TODO: Add your update logic here
			if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
			updateCamera(gameTime);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			terrain.Draw(camera.View, camera.Projection);

			base.Draw(gameTime);
		}

		void updateCamera(GameTime gameTime)
		{
			MouseState mouse = Mouse.GetState();
			KeyboardState keyboard = Keyboard.GetState();

			float dx = (float)lastMouseState.X - (float)mouse.X;
			float dy = (float)lastMouseState.Y - (float)mouse.Y;

			camera.Rotate(dx * 0.01f, dy * 0.01f);

			Vector3 trans = Vector3.Zero;
			if (keyboard.IsKeyDown(Keys.W)) trans += Vector3.Forward;
			if (keyboard.IsKeyDown(Keys.S)) trans += Vector3.Backward;
			if (keyboard.IsKeyDown(Keys.A)) trans += Vector3.Left;
			if (keyboard.IsKeyDown(Keys.D)) trans += Vector3.Right;
			if (keyboard.IsKeyDown(Keys.Space)) trans += Vector3.Up;
			if (keyboard.IsKeyDown(Keys.LeftControl)) trans += Vector3.Down;

			trans *= (15 * (float)gameTime.ElapsedGameTime.TotalSeconds);
			if (keyboard.IsKeyDown(Keys.LeftShift))
				trans *= 5;

			camera.Move(trans);
			camera.Update();
			lastMouseState = mouse;
		}
	}
}
