using UnityEngine;
using System.Collections;

// 關卡分數確認:敵人陣亡數
public class StageScoreEnemyKilledCount :  IStageScore
{
	private int m_EnemyKilledCount = 0;
	private StageSystem m_StageSystem = null;
	
	public StageScoreEnemyKilledCount( int KilledCount, StageSystem theStageSystem)
	{
		m_EnemyKilledCount = KilledCount;
		m_StageSystem = theStageSystem;
	}

	// 確認關卡分數是否達成
	public override bool CheckScore()
	{
		return ( m_StageSystem.GetEnemyKilledCount() >=  m_EnemyKilledCount);
	}
}
