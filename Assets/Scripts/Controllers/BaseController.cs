﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
	[SerializeField]
	protected Define.State _state = Define.State.Idle;

	public virtual Define.State State
	{
		get { return _state; }
		set
		{
			_state = value;

			switch (_state)
			{
				case Define.State.Die:
					break;
				case Define.State.Idle:
					break;
				case Define.State.Moving:
					break;
				case Define.State.Skill:
					break;
				case Define.State.Jumping:
					break;
				case Define.State.Ouch:
					OnOuch();
					break;
			}
		}
	}


	protected virtual void OnOuch() { }

	private void Start()
	{
		Init();
	}

	protected virtual void Update()
	{
		switch (State)
		{
			case Define.State.Die:
				UpdateDie();
				break;
			case Define.State.Moving:
				UpdateMoving();
				break;
			case Define.State.Idle:
				UpdateIdle();
				break;
			case Define.State.Skill:
				UpdateSkill();
				break;
			case Define.State.Jumping:
				UpdateJumping();
				break;
			case Define.State.Ouch:
				UpdateOuch();
				break;
		}
	}

	public abstract void Init();

	protected virtual void UpdateDie() { }
	protected virtual void UpdateMoving() { }
	protected virtual void UpdateIdle() { }
	protected virtual void UpdateSkill() { }
	protected virtual void UpdateJumping() { }
	protected virtual void UpdateOuch() { }
}
