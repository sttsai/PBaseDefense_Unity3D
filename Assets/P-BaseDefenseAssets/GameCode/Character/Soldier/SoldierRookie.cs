using UnityEngine;
using System.Collections;

// 新兵
public class SoldierRookie : ISoldier
{	
	public SoldierRookie()
	{
		m_emSoldier = ENUM_Soldier.Rookie;
		m_AssetName = "Soldier1";
		m_IconSpriteName = "RookieIcon";
		m_AttrID   = 1;
	}

	// 播放音效
	public override void DoPlayKilledSound()
	{
		PlaySound( "RookieDeath" );
	}
	
	// 播放特效
	public override void DoShowKilledEffect()
	{
		PlayEffect( "RookieDeadEffect" );
	}

	// 執行Visitor
	public override void RunVisitor(ICharacterVisitor Visitor)
	{
		Visitor.VisitSoldierRookie(this);
	}

}