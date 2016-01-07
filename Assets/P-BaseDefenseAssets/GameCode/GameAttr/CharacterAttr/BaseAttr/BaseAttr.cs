using UnityEngine;
using System.Collections;

// 可以被共用的基本角色數值界面
public abstract class BaseAttr
{			
	public abstract int 	GetMaxHP();
	public abstract float 	GetMoveSpeed();
	public abstract string 	GetAttrName();
}

// 實作可以被共用的基本角色數值
public class CharacterBaseAttr : BaseAttr
{
	private int 	m_MaxHP;		// 最高HP值
	private float  	m_MoveSpeed;	// 目前移動速度
	private string 	m_AttrName;		// 數值的名稱	

	public CharacterBaseAttr(int MaxHP,float MoveSpeed, string AttrName)
	{
		m_MaxHP = MaxHP;
		m_MoveSpeed = MoveSpeed;
		m_AttrName = AttrName;
	}

	public override int GetMaxHP()
	{
		return m_MaxHP;
	}

	public override float GetMoveSpeed()
	{
		return m_MoveSpeed;
	}

	public override string GetAttrName()
	{
		return m_AttrName;
	}
}

// 敵方角色的基本數值
public class EnemyBaseAttr : CharacterBaseAttr
{
	public int 	m_InitCritRate;	// 爆擊率
	public EnemyBaseAttr(int MaxHP,float MoveSpeed, string AttrName, int CritRate):base(MaxHP,MoveSpeed,AttrName)
	{
		m_InitCritRate =CritRate;
	}

	public virtual int GetInitCritRate()
	{
		return m_InitCritRate;
	}
}



