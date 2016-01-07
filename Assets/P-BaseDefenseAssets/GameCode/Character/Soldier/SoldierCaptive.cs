using UnityEngine;
using System.Collections;

// 俘兵
public class SoldierCaptive : ISoldier 
{
	private IEnemy m_Captive = null;

	// 
	public SoldierCaptive( IEnemy theEnemy)
	{
		m_emSoldier = ENUM_Soldier.Captive;
		m_Captive = theEnemy;

		// 設定成像
		SetGameObject( theEnemy.GetGameObject() );

		// 將Enemy數值轉成Soldier用的
		SoldierAttr tempAttr = new SoldierAttr();
		tempAttr.SetSoldierAttr( theEnemy.GetCharacterAttr().GetBaseAttr() );
		tempAttr.SetAttStrategy( theEnemy.GetCharacterAttr().GetAttStrategy());
		tempAttr.SetSoldierLv( 1 );	// 設定為1級
		SetCharacterAttr( tempAttr );

		// 設定武器
		SetWeapon( theEnemy.GetWeapon() );

		// 更改為SoldierAI
		m_AI = new SoldierAI( this );
		m_AI.ChangeAIState( new IdleAIState() );
	}

	// 播放音效
	public override void DoPlayKilledSound()
	{
		m_Captive.DoPlayHitSound();
	}
	
	// 播放特效
	public override void DoShowKilledEffect()
	{
		m_Captive.DoShowHitEffect();
	}

	// 執行Visitor
	public override void RunVisitor(ICharacterVisitor Visitor)
	{
		Visitor.VisitSoldierCaptive(this);
	}

}
