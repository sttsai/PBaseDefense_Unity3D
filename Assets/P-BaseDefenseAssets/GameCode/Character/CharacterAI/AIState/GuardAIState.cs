using UnityEngine;
using System.Collections.Generic;

// 守衛狀態
public class GuardAIState : IAIState 
{
	bool 	m_bOnMove = false;
	Vector3	m_Position = Vector3.zero;
	const int GUARD_DISTANCE = 3;
	
	public GuardAIState()
	{}	

	// 更新
	public override void Update( List<ICharacter> Targets )
	{
		// 有目標時,改為待機狀態
		if(Targets != null &&  Targets.Count>0)
		{
			m_CharacterAI.ChangeAIState( new IdleAIState() );
			return ;
		}

		if( m_Position == Vector3.zero)
			GetMovePosition();

		// 已經目標移動
		if( m_bOnMove)
		{
			//  是否到達目標
			float dist = Vector3.Distance( m_Position, m_CharacterAI.GetPosition());
			if( dist > 0.5f )			
				return ;

			// 換下一個位置
			GetMovePosition();
		}

		// 往目標移動
		m_bOnMove = true;
		m_CharacterAI.MoveTo( m_Position );
	}

	// 設定移動的位置
	private void GetMovePosition()
	{
		m_bOnMove = false;

		// 取得隨機位置
		Vector3 RandPos = new Vector3( UnityEngine.Random.Range(-GUARD_DISTANCE,GUARD_DISTANCE), 0, UnityEngine.Random.Range(-GUARD_DISTANCE,GUARD_DISTANCE));

		// 設定為新的位置 
		m_Position = m_CharacterAI.GetPosition() + RandPos;
	}

}
