using UnityEngine;
using System.Collections.Generic;

// AI狀態界面
public abstract class IAIState 
{
	protected ICharacterAI m_CharacterAI = null; // 角色AI(狀態的擁有者
	
	public IAIState()
	{}

	// 設定CharacterAI的對像
	public void SetCharacterAI(ICharacterAI CharacterAI)
	{
		m_CharacterAI = CharacterAI;
	}			

	// 設定要攻擊的目標
	public virtual void SetAttackPosition( Vector3 AttackPosition )
	{}

	// 更新
	public abstract void Update( List<ICharacter> Targets );

	// 目標被移除
	public virtual void RemoveTarget(ICharacter Target)
	{}

}
