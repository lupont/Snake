using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using static SnakeGame.Globals;

namespace SnakeGame
{
    public class Apple
    {
        #region Private fields
        private Texture2D _texture;
        private Vector2 _position;
        #endregion

        #region Public properties
        public Vector2 Position => _position;
        #endregion

        #region Public constructors
        public Apple(float x, float y)
        {
            _position = new Vector2(x, y);
        }
        #endregion

        #region Public methods
        public void SetTexture(GraphicsDevice graphicsDevice)
        {
            _texture = new Texture2D(graphicsDevice, Scale, Scale);
            var data = new Color[_texture.Width * _texture.Height];
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Red;
            _texture.SetData(data);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_texture, _position, Color.White);

            spriteBatch.End();
        } 
        #endregion
    }
}