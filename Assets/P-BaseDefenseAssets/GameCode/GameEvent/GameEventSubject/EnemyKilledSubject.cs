using UnityEngine;
using System.Collections;

// 敵人單位陣亡
public class EnemyKilledSubject : IGameEventSubject
{
	private	int	m_KilledCount = 0;
	private IEnemy m_Enemy = null;

	public EnemyKilledSubject()
	{}

	// 取得對像
	public IEnemy GetEnemy()
	{
		return m_Enemy;
	}

	// 目前敵人單位陣亡數
	public int GetKilledCount()
	{
		return m_KilledCount;
	}

	// 通知敵人單位陣亡
	public override void SetParam( System.Object Param )
	{
		base.SetParam( Param);
		m_Enemy = Param as IEnemy;
		m_KilledCount ++;

		// 通知
		Notify();
	}
}
