using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
	private AnimationClip m_IdleAnimClip;        
	private AnimationClip m_AttackAnimClip;      
	private AnimationClip m_MoveAnimClip;        
	private Animation m_AnimationComponent;      
	private Transform m_Tr;
	private Vector3 m_LastPosition = Vector3.zero;
	private Vector3 m_Velocity = Vector3.zero;
	private Vector3 m_LocalVelocity = Vector3.zero;
	private float m_MaxIdleSpeed = 0.5f; 
	private float m_MinWalkSpeed = 2.0f; 
	private float m_Speed = 0f;
	private float m_IdleWeight = 0f;
	//---------------------------------------------------------------------------
	// Use this for initialization
	void Start () 
	{
		m_Tr = this.transform;
		m_LastPosition = m_Tr.position;

		if (m_AnimationComponent != null)
			return;

		m_AnimationComponent = GetComponentInChildren<Animation>() as Animation;
		if (m_AnimationComponent == null)
			return;
				
		foreach (AnimationState theAnimation in m_AnimationComponent)
		{
			if (theAnimation.name.IndexOf("stand", System.StringComparison.OrdinalIgnoreCase) >= 0)
				m_IdleAnimClip = theAnimation.clip;
			if (theAnimation.name.IndexOf("attack", System.StringComparison.OrdinalIgnoreCase) >= 0)
				m_AttackAnimClip = theAnimation.clip;
			if (theAnimation.name.IndexOf("move", System.StringComparison.OrdinalIgnoreCase) >= 0)
				m_MoveAnimClip = theAnimation.clip;
		}

		m_AnimationComponent[m_MoveAnimClip.name].layer = 1;
		m_AnimationComponent[m_MoveAnimClip.name].enabled = true;
		m_AnimationComponent[m_IdleAnimClip.name].layer = 2;
		m_AnimationComponent[m_IdleAnimClip.name].enabled = true;
		m_AnimationComponent[m_AttackAnimClip.name].layer = 3;
		m_AnimationComponent[m_AttackAnimClip.name].weight = 1f;
		m_AnimationComponent[m_AttackAnimClip.name].wrapMode = WrapMode.Once;			
	}	
	//---------------------------------------------------------------------------------------
	void FixedUpdate()
	{
		m_Velocity = (m_Tr.position - m_LastPosition) / Time.deltaTime;
		m_LocalVelocity = m_Tr.InverseTransformDirection(m_Velocity);
		m_LocalVelocity.y = 0;
		m_Speed = m_LocalVelocity.magnitude;
		m_LastPosition = m_Tr.position;
	}    
		
	//---------------------------------------------------------------------------
	// Update is called once per frame
	void Update () 
	{
		m_IdleWeight = Mathf.Lerp (m_IdleWeight, Mathf.InverseLerp (m_MinWalkSpeed, m_MaxIdleSpeed, m_Speed), Time.deltaTime * 10);
		m_AnimationComponent[m_IdleAnimClip.name].weight = m_IdleWeight;
		if (m_Speed > 0)
			m_AnimationComponent.CrossFade(m_MoveAnimClip.name);
		
	}
	//---------------------------------------------------------------------------------------
	// 顯示攻擊動作
	public void PlayAttackAnim()
	{			
		// 停止一般動態
		//StopAnim();
		
		// 移除現有的融合動態        
		//RemoveAttackMixingTransform();
		
		// 停掉前一個開攻擊動作,讓攻擊動能配合上技能發出的頻率
		m_AnimationComponent.Stop(m_AttackAnimClip.name);
		
		// 有移動的狀態要加入融接
		/*if (m_Speed > 0.2)
		{
			m_AnimationComponent[m_AttackAnimClip.name].AddMixingTransform(m_UpperBodyBone);
			m_AttackAnimClip.bAddMixingTransformed = true;
		}*/
		
		m_AnimationComponent[m_AttackAnimClip.name].enabled = true;
		m_AnimationComponent.CrossFade(m_AttackAnimClip.name,0);        
	}
}
