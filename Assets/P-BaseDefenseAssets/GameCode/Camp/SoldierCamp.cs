using UnityEngine;
using System.Collections;

// Soldier兵營
public class SoldierCamp : ICamp
{
	const int MAX_LV = 3;	
	ENUM_Weapon	 m_emWeapon = ENUM_Weapon.Gun;	// 武器等級
	int	m_Lv = 1;								// 兵營等級
	Vector3 m_Position;							// 訓練完成後的集合點

	// 設定兵營產出的單位及冷
	public SoldierCamp(GameObject theGameObject, ENUM_Soldier emSoldier,string CampName, string IconSprite ,float TrainCoolDown,Vector3 Position):base(theGameObject, TrainCoolDown,CampName,IconSprite )
	{
		m_emSoldier = emSoldier;			
		m_Position = Position;
	}

	// 等級
	public override int GetLevel()
	{
		return m_Lv;
	}

	// 升級花費
	public override int GetLevelUpCost()
	{ 
		if( m_Lv >= MAX_LV)
			return 0;
		return 100;
	}

	// 升級
	public override void LevelUp()
	{
		m_Lv++;
		m_Lv = Mathf.Min( m_Lv , MAX_LV);
	}
	
	// 武器等級
	public override ENUM_Weapon GetWeaponType()
	{
		return m_emWeapon;
	}

	// 武器升級花費
	public override int GetWeaponLevelUpCost()
	{ 
		if( (m_emWeapon + 1) >= ENUM_Weapon.Max )
			return 0;
		return 100;
	}
	
	// 武器升級
	public override void WeaponLevelUp()
	{
		m_emWeapon++;
		if( m_emWeapon >=ENUM_Weapon.Max)
			m_emWeapon--;
	}

	// 取得訓練金額
	public override int GetTrainCost()
	{
		return m_TrainCost.GetTrainCost( m_emSoldier, m_Lv, m_emWeapon) ;
	}

	// 訓練Soldier
	public override void Train()
	{
		// 產生一個訓練命令
		TrainSoldierCommand NewCommand = new TrainSoldierCommand( m_emSoldier, m_emWeapon, m_Lv, m_Position);  
		AddTrainCommand( NewCommand );
	}
}
