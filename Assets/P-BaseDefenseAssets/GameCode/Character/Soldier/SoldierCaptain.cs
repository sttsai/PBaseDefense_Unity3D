using UnityEngine;
using System.Collections;

// 上尉
public class SoldierCaptain : ISoldier
{	
	public SoldierCaptain()
	{
		m_emSoldier = ENUM_Soldier.Captain;
		m_AssetName = "Soldier3";
		m_IconSpriteName = "CaptainIcon";
		m_AttrID   = 3;
	}

	// 播放音效
	public override void DoPlayKilledSound()
	{
		PlaySound( "CaptainDeath" );
	}
	
	// 播放特效
	public override void DoShowKilledEffect()
	{
		PlayEffect( "CaptainDeadEffect" );
	}

	// 執行Visitor
	public override void RunVisitor(ICharacterVisitor Visitor)
	{
		Visitor.VisitSoldierCaptain(this);
	}

}