using UnityEngine;
using System.Collections;

// 關卡分數觀測Enemey陣亡事件
public class EnemyKilledObserverStageScore : IGameEventObserver 
{
	private EnemyKilledSubject m_Subject = null;
	private StageSystem	m_StageSystem = null;

	public EnemyKilledObserverStageScore( StageSystem theStageSystem )
	{
		m_StageSystem = theStageSystem;
	}

	// 設定觀察的主題
	public override	void SetSubject( IGameEventSubject Subject )
	{
		m_Subject = Subject as EnemyKilledSubject;
	}

	// 通知Subject被更新
	public override void Update()
	{
		//Debug.Log("EnemyKilledObserverUI.Update: Count["+ m_Subject.GetKilledCount() +"]");
		m_StageSystem.SetEnemyKilledCount( m_Subject.GetKilledCount() );
	}

}
