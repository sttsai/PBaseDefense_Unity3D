using UnityEngine;
using System.Collections;

// 訓練費用計算
public abstract class ITrainCost 
{
	public abstract int GetTrainCost( ENUM_Soldier emSoldier,int CampLv, ENUM_Weapon emWeapon);
}
