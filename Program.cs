using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

class Game : GameWindow
{
    private Vector2 trianglePosition = new Vector2(0.0f, 0.0f);
    private float triangleSpeed = 2.0f;

    public Game(int width, int height) : base(width, height, GraphicsMode.Default, "Triunghi") { }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GL.ClearColor(0.2f, 0.3f, 0.4f, 1.0f);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        var keyboardState = Keyboard.GetState();
        var mouseState = Mouse.GetState();

        if (keyboardState.IsKeyDown(Key.Escape))
            Exit();

        float moveAmount = triangleSpeed * (float)e.Time;

        // Muta triughiul cu L si R
        if (keyboardState.IsKeyDown(Key.L))
            trianglePosition.X -= moveAmount;
        if (keyboardState.IsKeyDown(Key.R))
            trianglePosition.X += moveAmount;

        // Muta triunghiul cu mouse
        float normalizedX = (2.0f * mouseState.X / Width) - 1.0f;
        float normalizedY = 1.0f - (2.0f * mouseState.Y / Height);
        trianglePosition = new Vector2(normalizedX, -normalizedY);
    }


    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        GL.Begin(PrimitiveType.Triangles);
        GL.Color3(1.0f, 0.0f, 0.0f);
        GL.Vertex2(trianglePosition.X - 0.1f, trianglePosition.Y - 0.1f);
        GL.Color3(0.0f, 1.0f, 0.0f);
        GL.Vertex2(trianglePosition.X + 0.1f, trianglePosition.Y - 0.1f);
        GL.Color3(0.0f, 0.0f, 1.0f);
        GL.Vertex2(trianglePosition.X, trianglePosition.Y + 0.1f);
        GL.End();

        SwapBuffers();
    }

    static void Main()
    {
        using (Game game = new Game(800, 600))
        {
            game.Run(60.0);
        }
    }
}
