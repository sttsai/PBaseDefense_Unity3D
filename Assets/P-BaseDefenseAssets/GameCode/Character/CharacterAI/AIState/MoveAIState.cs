using UnityEngine;
using System.Collections.Generic;

// 移動的目標狀態
public class MoveAIState : IAIState 
{
	private const float MOVE_CHECK_DIST = 1.5f; //
	bool 	m_bOnMove = false;
	Vector3	m_AttackPosition = Vector3.zero;
	
	public MoveAIState()
	{}	

	// 設定要攻擊的目標
	public override void SetAttackPosition( Vector3 AttackPosition )
	{
		m_AttackPosition = AttackPosition;
	}

	// 更新
	public override void Update( List<ICharacter> Targets )
	{
		// 有目標時,改為待機狀態
		if(Targets != null &&  Targets.Count>0)
		{
			m_CharacterAI.ChangeAIState( new IdleAIState() );
			return ;
		}

		// 已經目標移動
		if( m_bOnMove)
		{
			//  是否到達目標
			float dist = Vector3.Distance( m_AttackPosition, m_CharacterAI.GetPosition());
			if( dist < MOVE_CHECK_DIST )
			{
				m_CharacterAI.ChangeAIState( new IdleAIState()); 
				if( m_CharacterAI.IsKilled()==false)
					m_CharacterAI.CanAttackHeart();//Debug.Log ("攻到目標");
				m_CharacterAI.Killed();
			}
			return ;
		}

		// 往目標移動
		//Debug.Log ("MoveAIState.往目標移動");
		m_bOnMove = true;
		m_CharacterAI.MoveTo( m_AttackPosition );
	}

}
