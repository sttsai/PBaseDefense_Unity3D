using UnityEngine;
using System.Collections;

// 產生遊戲角色工廠界面(Generic Method)
public interface TCharacterFactory_Generic
{
	ISoldier CreateSoldier<T>(ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition) where T: ISoldier,new();
	IEnemy 	 CreateEnemy<T>  (ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition) where T: IEnemy,new();
}

