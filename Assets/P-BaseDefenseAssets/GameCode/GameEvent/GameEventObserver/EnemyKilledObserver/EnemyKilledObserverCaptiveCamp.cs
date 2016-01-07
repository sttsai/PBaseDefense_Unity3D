using UnityEngine;
using System.Collections;

// 兵營觀測Enemey陣亡事件
public class EnemyKilledObserverCaptiveCamp : IGameEventObserver 
{
	private EnemyKilledSubject m_Subject = null;
	private CampSystem m_CampSystem = null;
	
	public EnemyKilledObserverCaptiveCamp(CampSystem  theCampSystem)
	{
		m_CampSystem = theCampSystem;
	}

	// 設定觀察的主題
	public override	void SetSubject( IGameEventSubject Subject )
	{
		m_Subject = Subject as EnemyKilledSubject;
	}
	
	// 通知Subject被更新
	public override void Update()
	{
		// 累計陣亡10以上時即示俘兵營
		if( m_Subject.GetKilledCount() > 10 ) 
			m_CampSystem.ShowCaptiveCamp();
	}
	
}