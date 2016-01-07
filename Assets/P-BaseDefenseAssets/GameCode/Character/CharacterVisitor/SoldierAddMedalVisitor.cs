using UnityEngine;
using System.Collections;

// 增加Solder勳章
public class SoldierAddMedalVisitor : ICharacterVisitor 
{
	PBaseDefenseGame m_PBDGame = null;

	public SoldierAddMedalVisitor( PBaseDefenseGame PBDGame)
	{
		m_PBDGame = PBDGame;
	}

	public override void VisitSoldier(ISoldier Soldier)
	{
		base.VisitSoldier( Soldier);
		Soldier.AddMedal();

		// 遊戲事件
		m_PBDGame.NotifyGameEvent( ENUM_GameEvent.SoldierUpgate, Soldier); 
	}
}
