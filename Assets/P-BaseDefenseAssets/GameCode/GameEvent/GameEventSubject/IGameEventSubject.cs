using UnityEngine;
using System.Collections.Generic;

// 遊戲事件主題
public class IGameEventSubject 
{
	private List<IGameEventObserver> m_Observers = new List<IGameEventObserver>(); // 觀測者
	private System.Object m_Param = null;	// 發生事件時附加的參數

	// 加入
	public void Attach(IGameEventObserver theObserver)
	{
		m_Observers.Add( theObserver );
	}

	// 取消
	public void Detach(IGameEventObserver theObserver)
	{
		m_Observers.Remove( theObserver );
	}

	// 通知
	public void Notify()
	{
		foreach( IGameEventObserver theObserver  in m_Observers)
			theObserver.Update();
	}

	// 設定參數
	public virtual void SetParam( System.Object Param )
	{
		m_Param = Param;
	}
}
