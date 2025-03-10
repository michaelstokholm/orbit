﻿using Orbit.Engine;

namespace Orbit.GameObjects;

public class Gun : GameObject
{
    private readonly IGameSceneManager gameSceneManager;

    public Ship Ship { get; set; }

    public Gun(IGameSceneManager gameSceneManager)
    {
        this.gameSceneManager = gameSceneManager;
    }

    public override bool IsCollisionDetectionEnabled => true;

    public override void Render(ICanvas canvas, RectF dimensions)
    {
        base.Render(canvas, dimensions);

        canvas.Translate(dimensions.Center.X, dimensions.Center.Y);
        canvas.Rotate(Ship.angle);

        //canvas.StrokeColor = Colors.OrangeRed;
        //canvas.StrokeSize = 4;
        //canvas.StrokeDashPattern = new float[] { 4, 4 };
        //canvas.DrawEllipse(175, -125, 300, 300);
    }
}
