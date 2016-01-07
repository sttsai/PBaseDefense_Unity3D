using UnityEngine;
using System.Collections.Generic;

// 攻擊狀態
public class AttackAIState : IAIState 
{

	private ICharacter m_AttackTarget = null; // 攻擊的目標

	public AttackAIState( ICharacter AttackTarget )
	{
		m_AttackTarget = AttackTarget;
	}			

	// 更新
	public override void Update( List<ICharacter> Targets )
	{
		// 沒有目標時,改為Idel
		if(m_AttackTarget == null || m_AttackTarget.IsKilled() || Targets == null || Targets.Count==0 )
		{
			m_CharacterAI.ChangeAIState( new IdleAIState()); 
			return ;
		}

		// 不在攻擊目標內,改為追擊
		if( m_CharacterAI.TargetInAttackRange( m_AttackTarget) ==false)
		{
			m_CharacterAI.ChangeAIState( new ChaseAIState(m_AttackTarget)); 
			return ;
		}

		// 攻擊
		m_CharacterAI.Attack( m_AttackTarget );
	}

	// 目標被移除
	public override void RemoveTarget(ICharacter Target)
	{
		if( m_AttackTarget.GetGameObject().name == Target.GetGameObject().name )
			m_AttackTarget = null;
	}

}
