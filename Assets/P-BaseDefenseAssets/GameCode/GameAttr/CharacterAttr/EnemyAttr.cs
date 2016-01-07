using UnityEngine;
using System.Collections;

// Enemy數值
public class EnemyAttr : ICharacterAttr
{
	protected int m_CritRate = 0; // 爆擊機率

	public EnemyAttr()
	{}

	// 設定角色數值(包含外部參數)
	public void SetEnemyAttr(EnemyBaseAttr EnemyBaseAttr)
	{
		// 共用元件
		base.SetBaseAttr( EnemyBaseAttr );

		// 外部參數
		m_CritRate = EnemyBaseAttr.GetInitCritRate();
	}
	
	// 爆擊率
	public int GetCritRate()
	{
		return m_CritRate;
	}

	// 減少爆擊率
	public void CutdownCritRate()
	{
		m_CritRate -= m_CritRate/2;
	}

}
