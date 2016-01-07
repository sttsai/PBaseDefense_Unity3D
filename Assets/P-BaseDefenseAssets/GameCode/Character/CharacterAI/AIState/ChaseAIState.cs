using UnityEngine;
using System.Collections.Generic;

// 追擊狀態
public class ChaseAIState : IAIState 
{
	private ICharacter m_ChaseTarget = null; // 追擊的目標

	private const float CHASE_CHECK_DIST = 0.2f; //
	private Vector3 m_ChasePosition = Vector3.zero;
	private bool m_bOnChase = false;

	public ChaseAIState(ICharacter ChaseTarget)
	{
		m_ChaseTarget = ChaseTarget;
	}			

	// 更新
	public override void Update( List<ICharacter> Targets )
	{
		// 沒有目標時,改為待機
		if(m_ChaseTarget == null || m_ChaseTarget.IsKilled() )
		{
			m_CharacterAI.ChangeAIState( new IdleAIState());
			return ;
		}

		// 在攻擊目標內,改為攻擊
		if( m_CharacterAI.TargetInAttackRange( m_ChaseTarget ))
		{
			m_CharacterAI.StopMove();
			m_CharacterAI.ChangeAIState( new AttackAIState(m_ChaseTarget)); 
			return ;
		}

		// 已經在追擊
		if( m_bOnChase)
		{
			// 已到達追擊目標,但目標不見,改為待機
			float dist = Vector3.Distance( m_ChasePosition, m_CharacterAI.GetPosition());
			if( dist < CHASE_CHECK_DIST )
				m_CharacterAI.ChangeAIState( new IdleAIState()); 
			return ;
		}

		// 往目標移動
		m_bOnChase = true;
		m_ChasePosition = m_ChaseTarget.GetPosition();
		m_CharacterAI.MoveTo( m_ChasePosition );
	}

	// 目標被移除
	public override void RemoveTarget(ICharacter Target)
	{
		if( m_ChaseTarget.GetGameObject().name == Target.GetGameObject().name )
			m_ChaseTarget = null;
	}
}
