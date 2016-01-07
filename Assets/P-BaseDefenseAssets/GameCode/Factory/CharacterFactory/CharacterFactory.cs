using UnityEngine;
using System.Collections;

// 產生遊戲角色工廠
public class CharacterFactory : ICharacterFactory
{
	// 角色建立指導者
	private CharacterBuilderSystem m_BuilderDirector = new CharacterBuilderSystem( PBaseDefenseGame.Instance );

	// 建立Soldier
	public override ISoldier CreateSoldier( ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition)
	{
		// 產生Soldier的參數
		SoldierBuildParam SoldierParam = new SoldierBuildParam();

		// 產生對應的Character
		switch( emSoldier)
		{
		case ENUM_Soldier.Rookie:
			SoldierParam.NewCharacter = new SoldierRookie();
			break;
		case ENUM_Soldier.Sergeant:
			SoldierParam.NewCharacter = new SoldierSergeant();
			break;
		case ENUM_Soldier.Captain:
			SoldierParam.NewCharacter = new SoldierCaptain();
			break;
		default:
            Debug.LogWarning("CreateSoldier:無法建立[" + emSoldier + "]");
			return null;
		}

		if( SoldierParam.NewCharacter == null)
			return null;

		// 設定共用參數
		SoldierParam.emWeapon = emWeapon;
		SoldierParam.SpawnPosition = SpawnPosition;
		SoldierParam.Lv		  = Lv;

		//  產生對應的Builder及設定參數
		SoldierBuilder theSoldierBuilder = new SoldierBuilder();
		theSoldierBuilder.SetBuildParam( SoldierParam ); 
		
		// 產生
		m_BuilderDirector.Construct( theSoldierBuilder );
		return SoldierParam.NewCharacter  as ISoldier;
	}
	
	// 建立Enemy
	public override IEnemy CreateEnemy( ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition)
	{
		// 產生Enemy的參數
		EnemyBuildParam EnemyParam = new EnemyBuildParam();

		// 產生對應的Character
		switch( emEnemy)
		{
		case ENUM_Enemy.Elf:
			EnemyParam.NewCharacter = new EnemyElf();
			break;
		case ENUM_Enemy.Troll:
			EnemyParam.NewCharacter = new EnemyTroll();
			break;
		case ENUM_Enemy.Ogre:
			EnemyParam.NewCharacter = new EnemyOgre();
			break;
		default:
			Debug.LogWarning("無法建立["+emEnemy+"]");
			return null;
		}

		if( EnemyParam.NewCharacter == null)
			return null;

		// 設定共用參數
		EnemyParam.emWeapon = emWeapon;
		EnemyParam.SpawnPosition = SpawnPosition;
		EnemyParam.AttackPosition = AttackPosition;
				
		//  產生對應的Builder及設定參數
		EnemyBuilder theEnemyBuilder = new EnemyBuilder();
		theEnemyBuilder.SetBuildParam( EnemyParam ); 
		
		// 產生
		m_BuilderDirector.Construct( theEnemyBuilder );
		return EnemyParam.NewCharacter  as IEnemy;
	}

}


