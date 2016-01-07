using UnityEngine;
using System.Collections;

public class WeaponRifle : IWeapon 
{
	public WeaponRifle()
	{
		m_emWeaponType = ENUM_Weapon.Rifle;
	}
	
	// 顯示武器子彈特效
	protected override void DoShowBulletEffect( ICharacter theTarget )
	{
		ShowBulletEffect(theTarget.GetPosition(),0.5f,0.2f);
	}
	
	// 顯示音效
	protected override void DoShowSoundEffect()
	{
		ShowSoundEffect("RifleShot");
	}

}
