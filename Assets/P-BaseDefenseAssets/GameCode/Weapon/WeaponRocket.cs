using UnityEngine;
using System.Collections;

public class WeaponRocket : IWeapon 
{
	public WeaponRocket()
	{
		m_emWeaponType = ENUM_Weapon.Rocket;
	}

	// 顯示武器子彈特效
	protected override void DoShowBulletEffect( ICharacter theTarget)
	{
		ShowBulletEffect(theTarget.GetPosition(),0.8f,0.5f);
	}
	
	// 顯示音效
	protected override void DoShowSoundEffect()
	{
		ShowSoundEffect("RocketShot");
	}

}
