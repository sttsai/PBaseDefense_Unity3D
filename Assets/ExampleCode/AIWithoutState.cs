using UnityEngine;
using System.Collections.Generic;

namespace AIWithoutState
{	
	// AI狀態
	public enum ENUM_AI_State
	{
		Idle = 0,	// 閒置
		Chase,		// 追擊
		Attack,		// 攻擊
		Move,		// 移動
	}

	// 角色介面
	public abstract class ICharacter
	{	
		// 狀態
		protected ENUM_AI_State m_AiState =  ENUM_AI_State.Idle;

		// 移動相關
		protected const float MOVE_CHECK_DIST = 1.5f;
		protected bool m_bOnMove = false;

		// 是否有攻擊的地點
		protected bool 	m_bSetAttackPosition = false;
		protected Vector3 m_AttackPosition;

		// 追擊的對像
		protected bool  m_bOnChase = false;
		protected ICharacter m_ChaseTarget = null;
		protected const float  CHASE_CHECK_DIST = 2.0f;

		// 攻擊的對像
		protected ICharacter m_AttackTarget = null;

		// 更新AI
		public abstract void UpdateAI(List<ICharacter> Targets); 

		// 取得最近的目標
		protected ICharacter GetNearTarget( List<ICharacter> Targets)
		{
			return null;
		}

		protected bool TargetInAttackRange( ICharacter Targets)
		{
			return false;
		}

		protected void StopMove()
		{
		}

		protected float GetTargetDist(ICharacter Targets)
		{
			return 0;
		}

		protected float GetTargetDist(Vector3 Position)
		{
			return 0;
		}

		protected void MoveTo( Vector3 Position )
		{
		}

		protected void Attack(ICharacter Targets)
		{
		}

		public Vector3 GetPosition()
		{
			return Vector3.zero;
		}

		public bool IsKilled()
		{
			return true;
		}
		public void Killed()
		{

		}

		public void CanAttackHeart()
		{
		}
	}
	
	// Enemy角色界面
	public class IEnemy : ICharacter
	{
		// 更新AI
		public override void UpdateAI(List<ICharacter> Targets)
		{
			switch( m_AiState )
			{
			case ENUM_AI_State.Idle:	// 閒置
				// 沒有目標時
				if(Targets == null ||  Targets.Count==0)
				{
					// 有設定目標時,往目標移動
					if( base.m_bSetAttackPosition )
						m_AiState = ENUM_AI_State.Move;						
					return ;
				}
				
				// 找出最近的目標
				ICharacter theNearTarget = GetNearTarget(Targets);				
				if( theNearTarget==null)
					return;
				
				// 是否在距離內
				if( TargetInAttackRange( theNearTarget ))
				{
					m_AttackTarget = theNearTarget;
					m_AiState = ENUM_AI_State.Attack; // 攻擊狀態
				}
				else
				{
					m_ChaseTarget = theNearTarget;
					m_AiState = ENUM_AI_State.Chase;  // 追擊狀態					
				}
				break;
			case ENUM_AI_State.Chase:	// 追擊
				// 沒有目標時,改為閒置
				if(m_ChaseTarget == null || m_ChaseTarget.IsKilled() )
				{
					m_AiState = ENUM_AI_State.Idle;
					return ;
				}
				
				// 在攻擊目標內,改為攻擊
				if( TargetInAttackRange( m_ChaseTarget ))
				{
					StopMove();
					m_AiState = ENUM_AI_State.Attack;
					return ;
				}
				
				// 已經在追擊
				if( m_bOnChase)
				{
					// 超出追擊的距離
					float dist = GetTargetDist( m_ChaseTarget );
					if( dist < CHASE_CHECK_DIST )
						m_AiState = ENUM_AI_State.Idle;						
					return ;
				}
				
				// 往目標移動
				m_bOnChase = true;
				MoveTo( m_ChaseTarget.GetPosition() );
				break;
			case ENUM_AI_State.Attack:	// 攻擊
				// 沒有目標時,改為Idel
				if(m_AttackTarget == null || m_AttackTarget.IsKilled() || Targets == null || Targets.Count==0 )
				{
					m_AiState = ENUM_AI_State.Idle;
					return ;
				}
				
				// 不在攻擊目標內,改為追擊
				if( TargetInAttackRange( m_AttackTarget) ==false)
				{
					m_ChaseTarget = m_AttackTarget;
					m_AiState = ENUM_AI_State.Chase;  // 追擊狀態
					return ;
				}
				
				// 攻擊
				Attack( m_AttackTarget );
				break;
			case ENUM_AI_State.Move:	// 移動

				// 有目標時,改為待機狀態
				if(Targets != null &&  Targets.Count>0)
				{
					m_AiState = ENUM_AI_State.Idle;
					return ;
				}
				
				// 已經目標移動
				if( m_bOnMove)
				{
					//  是否到達目標
					float dist = GetTargetDist( m_AttackPosition );
					if( dist < MOVE_CHECK_DIST )
					{
						m_AiState = ENUM_AI_State.Idle;
						if( IsKilled()==false)
							CanAttackHeart();//攻到目標;
						Killed(); // 設定死亡
					}
					return ;
				}
				
				// 往目標移動
				m_bOnMove = true;
				MoveTo( m_AttackPosition );
				break;
			}
		}
	}
	
	
	// Soldier角色界面
	public class ISoldier : ICharacter
	{
		// 更新AI
		public override void UpdateAI(List<ICharacter> Targets)
		{
			switch( m_AiState )
			{
			case ENUM_AI_State.Idle:	// 閒置

				// 找出最近的目標
				ICharacter theNearTarget = GetNearTarget(Targets);				
				if( theNearTarget==null)
					return;
				
				// 是否在距離內
				if( TargetInAttackRange( theNearTarget ))
				{
					m_AttackTarget = theNearTarget;
					m_AiState = ENUM_AI_State.Attack; // 攻擊狀態
				}
				else
				{
					m_ChaseTarget = theNearTarget;
					m_AiState = ENUM_AI_State.Chase;  // 追擊狀態					
				}
				break;
			case ENUM_AI_State.Chase:	// 追擊
				// 沒有目標時,改為閒置
				if(m_ChaseTarget == null || m_ChaseTarget.IsKilled() )
				{
					m_AiState = ENUM_AI_State.Idle;
					return ;
				}
				
				// 在攻擊目標內,改為攻擊
				if( TargetInAttackRange( m_ChaseTarget ))
				{
					StopMove();
					m_AiState = ENUM_AI_State.Attack;
					return ;
				}
				
				// 已經在追擊
				if( m_bOnChase)
				{
					// 超出追擊的距離
					float dist = GetTargetDist( m_ChaseTarget );
					if( dist < CHASE_CHECK_DIST )
						m_AiState = ENUM_AI_State.Idle;						
					return ;
				}
				
				// 往目標移動
				m_bOnChase = true;
				MoveTo( m_ChaseTarget.GetPosition() );
				break;
			case ENUM_AI_State.Attack:	// 攻擊
				// 沒有目標時,改為Idel
				if(m_AttackTarget == null || m_AttackTarget.IsKilled() || Targets == null || Targets.Count==0 )
				{
					m_AiState = ENUM_AI_State.Idle;
					return ;
				}
				
				// 不在攻擊目標內,改為追擊
				if( TargetInAttackRange( m_AttackTarget) ==false)
				{
					m_ChaseTarget = m_AttackTarget;
					m_AiState = ENUM_AI_State.Chase;  // 追擊狀態
					return ;
				}
				
				// 攻擊
				Attack( m_AttackTarget );
				break;
			case ENUM_AI_State.Move:	// 移動
				break;
			}
		}
	}
}
