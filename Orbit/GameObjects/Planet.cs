﻿using Orbit.Engine;

namespace Orbit.GameObjects;

public class Planet : GameObject
{
    Microsoft.Maui.Graphics.IImage image;
    float angle = 0;
    const float rotationIncrement = -0.25f;
    private readonly IGameSceneManager gameSceneManager;

    public int HealthPoints { get; private set; } = 100;

    public Planet(IGameSceneManager gameSceneManager)
    {
        image = LoadImage("planet.png");
        this.gameSceneManager = gameSceneManager;
    }

    public override bool IsCollisionDetectionEnabled => true;

    public override void Render(ICanvas canvas, RectF dirtyRect)
    {
        canvas.Rotate(angle, dirtyRect.Center.X, dirtyRect.Center.Y);

        var size = Math.Min(dirtyRect.Width, dirtyRect.Height) / 4;

        Bounds = new RectF(
            dirtyRect.Center.X - size,
            dirtyRect.Center.Y - size,
            size * 2,
            size * 2);

        canvas.DrawImage(image, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

        if (MainPage.ShowBounds)
        {
            canvas.RestoreState();

            canvas.StrokeColor = Colors.OrangeRed;
            canvas.StrokeSize = 4;
            canvas.DrawRectangle(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

            canvas.SaveState();
            canvas.ResetState();
        }

        angle += rotationIncrement;
    }

    public void OnHit(int damage)
    {
        HealthPoints = Math.Max(HealthPoints - damage, 0);

        if (HealthPoints == 0)
        {
            gameSceneManager.GameOver();
        }
    }
}
