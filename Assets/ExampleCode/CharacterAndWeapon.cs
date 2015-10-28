using UnityEngine;
using System.Collections;

// 302
namespace CharacterAndWeapon
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

		// 顯示子彈特效
		public void ShowBulletEffect(Vector3 TargetPosition, float LineWidth,float DisplayTime)
		{
		}
		
		// 顯示槍口特效 
		public void ShowShootEffect()
		{
		}
		
		// 顯示音效
		public void ShowSoundEffect(string ClipName)
		{
		}
	}
	

	// 角色介面
	public abstract class ICharacter
	{
		// 擁有一筆武器
		protected Weapon m_Weapon = null;

		// 攻擊目標
		public abstract void Attack( ICharacter theTarget); 

		// 被攻擊
		public abstract void UnderAttack( ICharacter theTarget); 

		// 取得位置
		public Vector3 GetPosition()
		{
			return Vector3.zero;
		}
	}

	// Enemy角色界面
	public class IEnemy : ICharacter
	{
		public IEnemy()
		{}

		// 攻擊目標
		public override void Attack( ICharacter theTarget)
		{
			// 發射特效
			m_Weapon.ShowShootEffect();
			int AtkPlusValue = 0;

			// 依目前武器決定攻擊方式
			switch(m_Weapon.GetWeaponType())
			{
			case ENUM_Weapon.Gun:

				// 顯示武器特效及音效
				m_Weapon.ShowBulletEffect(theTarget.GetPosition(),0.03f,0.2f);
				m_Weapon.ShowSoundEffect("GunShot");

				// 有機率增加額外加乘
				AtkPlusValue = GetAtkPlusValue(5,20);

				break;
			case ENUM_Weapon.Rifle:
				// 顯示武器特效及音效
				m_Weapon.ShowBulletEffect(theTarget.GetPosition(),0.5f,0.2f);
				m_Weapon.ShowSoundEffect("RifleShot");

				// 有機率增加額外加乘
				AtkPlusValue = GetAtkPlusValue(10,25);

				break;
			case ENUM_Weapon.Rocket:
				// 顯示武器特效及音效
				m_Weapon.ShowBulletEffect(theTarget.GetPosition(),0.8f,0.5f);
				m_Weapon.ShowSoundEffect("RocketShot");

				// 有機率增加額外加乘
				AtkPlusValue = GetAtkPlusValue(15,30);

				break;
			}

			// 設定額外加乘值
			m_Weapon.SetAtkPlusValue( AtkPlusValue );

			// 攻擊
			m_Weapon.Fire( theTarget );
		}

		// 取得額外的加乘值
		private int GetAtkPlusValue(int Rate, int AtkValue)
		{
			int RandValue = UnityEngine.Random.Range(0,100);
			if( Rate > RandValue ) 
				return AtkValue;
			return 0;
		}
		
		// 被攻擊
		public override void UnderAttack( ICharacter Target)
		{
		}
	}


	// Soldier角色界面
	public class ISoldier : ICharacter
	{
		public ISoldier()
		{}
		
		// 攻擊目標
		public override void Attack( ICharacter theTarget)
		{
			// 發射特效
			m_Weapon.ShowShootEffect();
						
			// 依目前武器決定攻擊方式
			switch(m_Weapon.GetWeaponType())
			{
			case ENUM_Weapon.Gun:				
				// 顯示武器特效及音效
				m_Weapon.ShowBulletEffect(theTarget.GetPosition(),0.03f,0.2f);
				m_Weapon.ShowSoundEffect("GunShot");										
				break;
			case ENUM_Weapon.Rifle:
				// 顯示武器特效及音效
				m_Weapon.ShowBulletEffect(theTarget.GetPosition(),0.5f,0.2f);
				m_Weapon.ShowSoundEffect("RifleShot");
				break;
			case ENUM_Weapon.Rocket:
				// 顯示武器特效及音效
				m_Weapon.ShowBulletEffect(theTarget.GetPosition(),0.8f,0.5f);
				m_Weapon.ShowSoundEffect("RocketShot");							
				break;
			}
			
			// 攻擊
			m_Weapon.Fire( theTarget );
		}
		
		// 被攻擊
		public override void UnderAttack( ICharacter Target)
		{
		}
	}





}
