using UnityEngine;
using System.Collections;

// Soldier類型
public enum ENUM_Soldier
{
	Null = 0,
	Rookie	= 1,	// 新兵
	Sergeant= 2,	// 中士
	Captain = 3,	// 上尉
	Captive	= 4, 	// 俘兵
	Max,
}

// Soldier角色界面
public abstract class ISoldier : ICharacter
{
	protected ENUM_Soldier m_emSoldier = ENUM_Soldier.Null;
	protected int		   m_MedalCount	= 0; 				// 勳章數
	protected const int	   MAX_MEDAL = 3; 					// 最多勳章數 
	protected const int    MEDAL_VALUE_ID = 20;				// 勳章數值起始值

	public ISoldier()
	{
	}

	public ENUM_Soldier GetSoldierType()
	{
		return m_emSoldier;
	}

	// 取得目前的角色值
	public SoldierAttr GetSoldierValue()
	{
		return m_Attribute as SoldierAttr;
	}
	
	// 被武器攻擊
	public override void UnderAttack( ICharacter Attacker )
	{
		// 計算傷害值
		m_Attribute.CalDmgValue( Attacker );

		// 是否陣亡
		if( m_Attribute.GetNowHP() <= 0 )
		{
			DoPlayKilledSound();	// 音效
			DoShowKilledEffect();	// 特效 
			Killed();			// 陣亡
		}
	}

	// 增加勳章
	public virtual void AddMedal()
	{
		if( m_MedalCount >= MAX_MEDAL)
			return ;

		// 增加勳章
		m_MedalCount++;
		// 取得對映的勳章加乘值
		int AttrID =  m_MedalCount + MEDAL_VALUE_ID;

        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();

		// 加上字尾能力
		SoldierAttr SufAttr = theAttrFactory.GetEliteSoldierAttr(ENUM_AttrDecorator.Suffix, AttrID, m_Attribute as SoldierAttr);
        SetCharacterAttr(SufAttr);
	}

	// 執行Visitor
	public override void RunVisitor(ICharacterVisitor Visitor)
	{
		Visitor.VisitSoldier(this);
	}

	// 播放音效
	public abstract void DoPlayKilledSound();

	// 播放特效
	public abstract void DoShowKilledEffect();


	
}