using UnityEngine;
using System.Collections;

// Enemy類型
public enum ENUM_Enemy
{
	Null 	= 0,
	Elf		= 1,// 精靈
	Troll	= 2,// 山妖
	Ogre	= 3,// 怪物
	Catpive = 4,// 俘兵
	Max,
}

// Enemy角色界面
public abstract class IEnemy : ICharacter
{
	protected ENUM_Enemy m_emEnemyType = ENUM_Enemy.Null;

	public IEnemy()
	{}

	public ENUM_Enemy GetEnemyType() 
	{
		return m_emEnemyType;
	}
	
	// 被武器攻擊
	public override void UnderAttack( ICharacter Attacker)
	{
		// 計算傷害值
		m_Attribute.CalDmgValue( Attacker );

		DoPlayHitSound();// 音效
		DoShowHitEffect();// 特效 

		// 是否陣亡
		if( m_Attribute.GetNowHP() <= 0 )		
		{
			Killed();
		}
	}

	// 執行Visitor
	public override void RunVisitor(ICharacterVisitor Visitor)
	{
		Visitor.VisitEnemy(this);
	}

	// 播放音效
	public abstract void DoPlayHitSound();
	
	// 播放特效
	public abstract void DoShowHitEffect();


}
