using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HeightmapTest
{
	public abstract class Camera
	{
		public Matrix View;
		public Matrix Projection;
		protected GraphicsDevice GraphicsDevice;

		protected Camera(GraphicsDevice device)
		{
			this.GraphicsDevice = device;
			generatePerspectiveProjectionMatrix(MathHelper.PiOver4);
		}

		private void generatePerspectiveProjectionMatrix(float fov)
		{
			PresentationParameters pp = GraphicsDevice.PresentationParameters;

			float ar = (float)pp.BackBufferWidth / (float)pp.BackBufferHeight;
			this.Projection = Matrix.CreatePerspectiveFieldOfView(fov, ar, 0.1f, 1e6f);
		}

		public virtual void Update() { }
	}

	public class FreeCamera : Camera
	{
		public float Yaw;
		public float Pitch;

		public Vector3 Position;
		public Vector3 Target { get; private set; }

		private Vector3 _translation;

		public FreeCamera(Vector3 pos, float y, float p, GraphicsDevice device) :
			base(device)
		{
			Position = pos;
			Yaw = y;
			Pitch = p;

			_translation = Vector3.Zero;
		}

		public void Rotate(float y, float p)
		{
			Yaw += y;
			Pitch += p;

			Pitch = MathHelper.Clamp(Pitch, -MathHelper.PiOver2, MathHelper.PiOver2);
		}

		public void Move(Vector3 translation)
		{
			_translation += translation;
		}

		public override void Update()
		{
			Matrix rot = Matrix.CreateFromYawPitchRoll(Yaw, Pitch, 0);

			_translation = Vector3.Transform(_translation, rot);
			Position += _translation;
			_translation = Vector3.Zero;

			Vector3 forward = Vector3.Transform(Vector3.Forward, rot);
			Target = Position + forward;

			Vector3 up = Vector3.Transform(Vector3.Up, rot);
			View = Matrix.CreateLookAt(Position, Target, up);
		}
	}
}
