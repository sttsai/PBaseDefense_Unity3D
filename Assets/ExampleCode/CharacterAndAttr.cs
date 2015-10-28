using UnityEngine;
using System.Collections;

// 303
namespace CharacterAndValue
{
	// 武器類別
	public enum ENUM_Weapon
	{
		Null 	= 0,
		Gun 	= 1,
		Rifle	= 2,	
		Rocket	= 3,	
		Max	,
	}

	// 武器介面
	public class Weapon
	{
		// 數值
		protected ENUM_Weapon  m_emWeapon = ENUM_Weapon.Null; 	// 類型
		protected int		   m_AtkValue =0;		// 攻擊力
		protected int		   m_AtkRange =0;		// 攻擊距離
		protected int 		   m_AtkPlusValue = 0;	// 額外加乘值


		public Weapon(ENUM_Weapon Type,int AtkValue, int AtkRange)
		{
			m_emWeapon = Type;
			m_AtkValue = AtkValue;
			m_AtkRange = AtkRange;
		}

		public ENUM_Weapon GetWeaponType()
		{
			return m_emWeapon;
		}

		// 攻擊目標
		public void Fire( ICharacter theTarget )
		{
		}

		// 設定額外攻擊力
		public void SetAtkPlusValue(int AtkPlusValue)
		{
			m_AtkPlusValue = AtkPlusValue;
		}

		// 取得攻擊力
		public int GetAtkValue()
		{
			return m_AtkValue + m_AtkPlusValue;
		}
	}
	
	// 角色類型
	public enum ENUM_Character
	{
		Soldier = 0,
		Enemy,
	}
			
	// 角色介面
	public class Character
	{
		// 擁有一筆武器
		protected Weapon m_Weapon = null;

		// 角色數值
		ENUM_Character m_CharacterType; // 角色類型
		int    m_MaxHP = 0;			// 最高生命力值
		int    m_NowHP = 0;			// 目前生命力值
		float  m_MoveSpeed = 1.0f;	// 目前移動速度
		int    m_SoldierLv = 0; 	// Soldier等級
		int    m_CritRate = 0; 		// 爆擊機率

		// 初始角色
		public void InitCharacter()
		{
			// 依角色類型判斷是最高生命力的計算方式
			switch(m_CharacterType) 
			{
			case ENUM_Character.Soldier:
				// 最大生命力有等級加乘
				if(m_SoldierLv > 0 )
					m_MaxHP += (m_SoldierLv-1)*2;
				break;
			case ENUM_Character.Enemy:
				// 不需要
				break;
			}

			// 重設目前的生命力
			m_NowHP = m_MaxHP;
		}

		// 攻擊目標
		public void Attack( ICharacter theTarget)
		{
			// 設定武器額外攻擊加乘
			int AtkPlusValue = 0;

			// 依角色類型判斷是否加乘額外攻擊力
			switch(m_CharacterType) 
			{
			case ENUM_Character.Soldier:
				// 不需要
				break;
			case ENUM_Character.Enemy:
				// 依爆擊機率回傳攻擊加乘值
				int RandValue =  UnityEngine.Random.Range(0,100);
				if( m_CritRate >= RandValue )
					AtkPlusValue = m_MaxHP*5; // 血量的5倍值
				break;
			}

			// 設定額外攻擊力
			m_Weapon.SetAtkPlusValue( AtkPlusValue );

			// 使用武器攻擊目標
			m_Weapon.Fire( theTarget );
		}

		// 被攻擊
		public void UnderAttack( ICharacter Attacker)
		{
			// 取得攻擊力(會包含加乘值)
			int AtkValue = Attacker.GetWeapon().GetAtkValue();

			// 依角色類型計算減傷害值
			switch(m_CharacterType) 
			{
			case ENUM_Character.Soldier:
				// 會依照Soldier等級減少傷害
				AtkValue -= (m_SoldierLv-1)*2;
				break;
			case ENUM_Character.Enemy:
				// 不需要
				break;
			}

			// 目前生命力減去攻擊值
			m_NowHP -= AtkValue;
						
			// 是否陣亡
			if( m_NowHP <= 0 )
				Debug.Log ("角色陣亡");
		}

		// 取得武器
		public Weapon GetWeapon()
		{
			return m_Weapon;
		}
	}
}
