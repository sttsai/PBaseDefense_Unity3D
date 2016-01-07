using UnityEngine;
using System.Collections;

// UI觀測Enemey陣亡事件
public class EnemyKilledObserverUI : IGameEventObserver 
{
	private EnemyKilledSubject m_Subject = null;
	private PBaseDefenseGame m_PBDGame = null;

	public EnemyKilledObserverUI(PBaseDefenseGame PBDGame  )
	{
		m_PBDGame = PBDGame;
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
		if(m_PBDGame!=null)
			m_PBDGame.ShowGameMsg("敵方單位陣亡");

	}

}
