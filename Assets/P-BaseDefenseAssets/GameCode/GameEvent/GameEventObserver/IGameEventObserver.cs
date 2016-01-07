using UnityEngine;
using System.Collections;

public abstract class IGameEventObserver
{
	public abstract void Update();
	public abstract	void SetSubject( IGameEventSubject Subject );
}
