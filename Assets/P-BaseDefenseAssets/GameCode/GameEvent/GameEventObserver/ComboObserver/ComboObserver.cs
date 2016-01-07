using UnityEngine;
using System.Collections;

// 我方連續擊退事件
public class ComboObserver : IGameEventObserver 
{
	private SoldierKilledSubject m_SoldierKilledSubject = null;
	private EnemyKilledSubject m_EnemyKilledSubject = null;
	private PBaseDefenseGame m_PBDGame = null;

	private int m_EnemyComboCount =0;
	private int m_SoldierKilledCount = 0;
	private int m_EnemyKilledCount = 0;
	
	public ComboObserver(PBaseDefenseGame  PBDGame)
	{
		m_PBDGame = PBDGame;
	}
	
	// 設定觀察的主題
	public override	void SetSubject( IGameEventSubject theSubject )
	{
		if( theSubject is SoldierKilledSubject )
			m_SoldierKilledSubject = theSubject as SoldierKilledSubject;
		if( theSubject is EnemyKilledSubject)
			m_EnemyKilledSubject = theSubject as EnemyKilledSubject;
	}
	
	// 通知Subject被更新
	public override void Update()
	{
		int NowSoldierKilledCount = m_SoldierKilledSubject.GetKilledCount();
		int NowEnemyKilledCount = m_EnemyKilledSubject.GetKilledCount();

		// 玩家單位陣亡,重置計數器
		if( NowSoldierKilledCount > m_SoldierKilledCount)
			m_EnemyComboCount = 0;

		// 增加計數器
		if( NowEnemyKilledCount > m_EnemyKilledCount)
			m_EnemyComboCount ++;

		m_SoldierKilledCount = NowSoldierKilledCount;
		m_EnemyKilledCount = NowEnemyKilledCount;

		// 通知
		m_PBDGame.ShowGameMsg("連續擊退敵人數:"+m_EnemyComboCount.ToString());
	}	
}
