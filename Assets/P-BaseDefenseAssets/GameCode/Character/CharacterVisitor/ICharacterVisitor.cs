using UnityEngine;
using System.Collections;

// 角色Visitor介面
public abstract class ICharacterVisitor
{
	public virtual void VisitCharacter(ICharacter Character)
	{}

	public virtual void VisitSoldier(ISoldier Soldier)
	{
		VisitCharacter( Soldier );
	}

	public virtual void VisitSoldierRookie(SoldierRookie Rookie)
	{
		VisitSoldier( Rookie );
	}

	public virtual void VisitSoldierSergeant(SoldierSergeant Sergeant)
	{
		VisitSoldier( Sergeant );
	}

	public virtual void VisitSoldierCaptain(SoldierCaptain Captain)
	{
		VisitSoldier( Captain );
	}

	public virtual void VisitSoldierCaptive(SoldierCaptive Captive)
	{
		VisitSoldier( Captive );
	}
	
	public virtual void VisitEnemy(IEnemy Enemy)
	{
		VisitCharacter( Enemy );
	}

	public virtual void VisitEnemyElf(EnemyElf Elf)
	{
		VisitEnemy( Elf );
	}

	public virtual void VisitEnemyTroll(EnemyTroll Troll)
	{
		VisitEnemy( Troll );
	}

	public virtual void VisitEnemyOgre(EnemyOgre Ogre)
	{
		VisitEnemy( Ogre );
	}
}
