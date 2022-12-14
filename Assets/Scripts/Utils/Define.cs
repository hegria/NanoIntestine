using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum WorldObject
    {
        Unknown,
        Player,
        Monster,
    }

	public enum State
	{
		Die,
		Moving,
		Idle,
		Skill,
        Jumping,
        Ouch,
	}

    public enum Layer
    {
        Monster = 8,
        Ground = 9,
        Block = 10,
    }

    public enum Scene
    {
        Lobby,
        Game1,
        Game2,
        Game3,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        Movement,
        Enemy,
        UI,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
    }

    public enum CameraMode
    {
        QuarterView,
    }
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
}
