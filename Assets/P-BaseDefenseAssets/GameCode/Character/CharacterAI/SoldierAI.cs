using UnityEngine;
using System.Collections.Generic;

// 玩家角色AI
public class SoldierAI : ICharacterAI 
{	
	public SoldierAI(ICharacter Character):base(Character)
	{
		// 一開始起始的狀態
		ChangeAIState(new IdleAIState());
	}

	// 是否可以攻擊Heart
	public override bool CanAttackHeart()
	{
		return false;
	}
}

