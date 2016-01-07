using UnityEngine;
using System.Collections.Generic;

// 角色的AI
public abstract class ICharacterAI 
{
	protected ICharacter m_Character = null;
	protected float		m_AttackRange = 2;
	protected IAIState  m_AIState = null;

	protected const float ATTACK_COOLD_DOWN = 1f; // 攻擊的CoolDown
	protected float m_CoolDown = ATTACK_COOLD_DOWN;

	public ICharacterAI( ICharacter Character)
	{
		m_Character = Character;
		m_AttackRange = Character.GetAttackRange() ;
	}

	// 更換AI狀態
	public virtual void ChangeAIState( IAIState NewAIState)
	{
		m_AIState = NewAIState;
		m_AIState.SetCharacterAI( this );
	}

	// 攻擊目標
	public virtual void Attack( ICharacter Target )
	{
		// 時間到了才攻擊
		m_CoolDown -= Time.deltaTime;
		if( m_CoolDown >0)
			return ;
		m_CoolDown = ATTACK_COOLD_DOWN;

		//Debug.Log ("攻擊目標:"+Target.GetGameObject().gameObject.name);
		m_Character.Attack( Target );
	}

	// 是否在攻擊距離內
	public bool TargetInAttackRange( ICharacter Target )
	{
		float dist = Vector3.Distance( m_Character.GetPosition() , 
		                               Target.GetPosition() );
		return ( dist <= m_AttackRange );
	}

	// 目前的位置
	public Vector3 GetPosition()
	{
		return m_Character.GetGameObject().transform.position;
	}

	// 移動
	public void MoveTo( Vector3 Position )
	{
		m_Character.MoveTo( Position );
	}

	// 停止移動
	public void StopMove()
	{
		m_Character.StopMove();
	}

	// 設定陣亡
	public void Killed()
	{
		m_Character.Killed();
	}

	// 是否陣亡
	public bool IsKilled()
	{
		return m_Character.IsKilled(); 
	}

	// 目標移除
	public void RemoveAITarget( ICharacter Target ) 
	{
		m_AIState.RemoveTarget( Target);  
	}

	// 更新AI
	public void Update(List<ICharacter> Targets)
	{
		m_AIState.Update( Targets );
	}

	// 是否可以攻擊Heart
	public abstract bool CanAttackHeart();



}
