using UnityEngine;
using System.Collections;

public class WeaponGun : IWeapon 
{
	public WeaponGun()
	{
		m_emWeaponType = ENUM_Weapon.Gun;
	}

	// 顯示武器子彈特效
	protected override void DoShowBulletEffect( ICharacter theTarget )
	{
		ShowBulletEffect(theTarget.GetPosition(),0.03f,0.2f);
	}
	
	// 顯示音效
	protected override void DoShowSoundEffect()
	{
		ShowSoundEffect("GunShot");
	}


}
