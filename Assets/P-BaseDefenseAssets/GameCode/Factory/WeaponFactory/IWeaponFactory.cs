using UnityEngine;
using System.Collections;

// 產生武器工廠界面
public abstract class IWeaponFactory
{
	// 建立武器
	public abstract IWeapon CreateWeapon( ENUM_Weapon emWeapon);
}

