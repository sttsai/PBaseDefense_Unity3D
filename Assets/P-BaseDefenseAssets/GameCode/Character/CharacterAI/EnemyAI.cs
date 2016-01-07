using UnityEngine;
using System.Collections.Generic;

// 敵方角色AI
public class EnemyAI : ICharacterAI 
{
	private static StageSystem	m_StageSystem = null;
	private Vector3 m_AttackPosition = Vector3.zero;

	// 直接將關卡系統直接注入給EnemyAI類別使用
	public static void SetStageSystem(StageSystem StageSystem)
	{
		m_StageSystem = StageSystem;
	}

	public EnemyAI(ICharacter Character, Vector3 AttackPosition):base(Character)
	{
		m_AttackPosition = AttackPosition;

		// 一開始起始的狀態
		ChangeAIState(new IdleAIState());
	}

	// 更換AI狀態
	public override void ChangeAIState( IAIState NewAIState)
	{
		base.ChangeAIState( NewAIState);

		// Enemy的AI要設定攻擊的目標
		NewAIState.SetAttackPosition( m_AttackPosition );
	}
	
	// 是否可以攻擊Heart
	public override bool CanAttackHeart()
	{
		// 通知少一個heart
		m_StageSystem.LoseHeart();
		return true;
	}
}
