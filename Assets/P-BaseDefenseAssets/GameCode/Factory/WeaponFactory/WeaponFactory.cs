using UnityEngine;
using System.Collections;

// 武器工廠
public class WeaponFactory : IWeaponFactory 
{
	public WeaponFactory()
	{
	}

	// 建立武器
	public override IWeapon CreateWeapon( ENUM_Weapon emWeapon)
	{
		IWeapon pWeapon = null;
		string	AssetName = "";	// Unity模型名稱
		int		AttrID = 0; 	// 武器的能力值

		// 依武器
		switch( emWeapon )
		{
		case ENUM_Weapon.Gun:
			pWeapon = new WeaponGun();
			AssetName = "WeaponGun";
			AttrID	= 1;
			break;
		case ENUM_Weapon.Rifle:
			pWeapon = new WeaponRifle();
			AssetName = "WeaponRifle";
			AttrID	= 2;
			break;
		case ENUM_Weapon.Rocket:
			pWeapon = new WeaponRocket();
			AssetName = "WeaponRocket";
			AttrID	= 3;
			break;		
		default:
			Debug.LogWarning("CreateWeapon:無法建立["+emWeapon+"]");
			return null;
		}

		// 產生Asset
		IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
		GameObject WeaponGameObjet = AssetFactory.LoadWeapon( AssetName );
		pWeapon.SetGameObject( WeaponGameObjet );

		// 取得武器的威力
		IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
		WeaponAttr theWeaponAttr = theAttrFactory.GetWeaponAttr( AttrID ); 

		// 設定武器的威力
		pWeapon.SetWeaponAttr( theWeaponAttr );

		return pWeapon;
	}
	
}
