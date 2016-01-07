using UnityEngine;
using System.Collections.Generic;

// 閒置狀態
public class IdleAIState : IAIState 
{
	bool	m_bSetAttackPosition = false; // 是否有設定攻擊目標

	public IdleAIState()
	{}			

	// 設定要攻擊的目標
	public override void SetAttackPosition( Vector3 AttackPosition )		
	{
		m_bSetAttackPosition = true;
	}

	// 更新
	public override void Update( List<ICharacter> Targets )
	{
		// 沒有目標時
		if(Targets == null ||  Targets.Count==0)
		{
			// 有設定目標時,往目標移動
			if( m_bSetAttackPosition )
				m_CharacterAI.ChangeAIState( new MoveAIState());
			return ;
		}

		// 找出最近的目標
		Vector3 NowPosition = m_CharacterAI.GetPosition();
		ICharacter theNearTarget = null;
		float MinDist = 999f;
		foreach(ICharacter Target in  Targets)
		{
			// 已經陣亡的不計算
			if( Target.IsKilled())
				continue;

			float dist = Vector3.Distance( NowPosition, Target.GetGameObject().transform.position);
			if( dist < MinDist)
			{
				MinDist = dist;
				theNearTarget = Target;
			}
		}

		// 沒有目標,會不動
		if( theNearTarget==null)
			return;

		// 是否在距離內
		if( m_CharacterAI.TargetInAttackRange( theNearTarget ))
			m_CharacterAI.ChangeAIState( new AttackAIState( theNearTarget ));
		else
			m_CharacterAI.ChangeAIState( new ChaseAIState( theNearTarget ));
	}
}
