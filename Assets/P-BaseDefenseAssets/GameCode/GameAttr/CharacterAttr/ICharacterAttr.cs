using UnityEngine;
using System.Collections;

// 角色數值界面
public abstract class ICharacterAttr
{
	protected BaseAttr m_BaseAttr= null; 	// 基本角色數值
	//protected int    m_MaxHP = 0;			// 最高HP值
	//protected float  m_MoveSpeed = 1.0f;	// 移動速度
	//protected string m_AttrName = "";		// 數值的名稱
	
	protected int 	 m_NowHP = 0;		// 目前HP值
	protected IAttrStrategy m_AttrStrategy=null;// 數值的計算策略

	public ICharacterAttr(){}

	// 設定基本屬性
	public void SetBaseAttr( BaseAttr BaseAttr )
	{
		m_BaseAttr = BaseAttr;
	}

	// 取得基本屬性
	public BaseAttr GetBaseAttr()
	{
		return m_BaseAttr;
	}
	
	// 設定數值的計算策略
	public void SetAttStrategy(IAttrStrategy theAttrStrategy)
	{
		m_AttrStrategy = theAttrStrategy;
	}

	// 取得數值的計算策略
	public IAttrStrategy GetAttStrategy()
	{
		return m_AttrStrategy;
	}

	// 目前HP
	public int GetNowHP()
	{
		return m_NowHP;
	}

	// 最大HP
	public virtual int GetMaxHP()
	{
		return m_BaseAttr.GetMaxHP();
	}

	// 回滿目前HP值
	public void FullNowHP()
	{
		m_NowHP = GetMaxHP();
	}
	
	// 移動速度
	public virtual float GetMoveSpeed()
	{
		return m_BaseAttr.GetMoveSpeed();
	}
		
	// 取得數值名稱
	public virtual string GetAttrName()
	{
		return m_BaseAttr.GetAttrName();
	}

	// 初始角色數值
	public virtual void InitAttr()
	{
		m_AttrStrategy.InitAttr( this ); 
		FullNowHP();
	}

	// 攻擊加乘
	public int GetAtkPlusValue()
	{
		return m_AttrStrategy.GetAtkPlusValue( this );
	}

	// 取得被武器攻擊後的傷害值
	public void CalDmgValue( ICharacter Attacker )
	{
		// 取得武器功擊力
		int AtkValue = Attacker.GetAtkValue();
		
		// 減傷
		AtkValue -= m_AttrStrategy.GetDmgDescValue(this);
		
		// 扣去傷害
		m_NowHP -= AtkValue;
	}

}
