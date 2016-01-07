using UnityEngine;
using System.Collections;

// 遊戲子系統共用界面
public abstract class IGameSystem
{
	protected PBaseDefenseGame m_PBDGame = null;
	public IGameSystem( PBaseDefenseGame PBDGame )
	{
		m_PBDGame = PBDGame;
	}

	public virtual void Initialize(){}
	public virtual void Release(){}
	public virtual void Update(){}

}
