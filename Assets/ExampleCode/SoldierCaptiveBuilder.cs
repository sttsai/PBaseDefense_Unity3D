using UnityEngine;
using System.Collections;

// 建立俘兵時所需的參數
public class SoldierCaptiveBuildParam : ICharacterBuildParam
{
	public SoldierCaptiveBuildParam()
	{
	}
}

// 俘兵各部位的建立
public class SoldierCaptiveBuilder : ICharacterBuilder
{
	private SoldierCaptiveBuildParam m_BuildParam = null;
	
	public override void SetBuildParam( ICharacterBuildParam theParam )
	{
		m_BuildParam = theParam as SoldierCaptiveBuildParam;	
	}
	
	// 載入Asset中的角色模型(Enemy)
	public override void LoadAsset( int GameObjectID )
	{
		IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
		GameObject EnemyGameObject = AssetFactory.LoadEnemy( m_BuildParam.NewCharacter.GetAssetName() );
		EnemyGameObject.transform.position = m_BuildParam.SpawnPosition;
		EnemyGameObject.gameObject.name = string.Format("Enemy[{0}]",GameObjectID);
		m_BuildParam.NewCharacter.SetGameObject( EnemyGameObject );
	}
	
	// 加入OnClickScript(Soldier)
	public override void AddOnClickScript()
	{
		SoldierOnClick Script = m_BuildParam.NewCharacter.GetGameObject().AddComponent<SoldierOnClick>();
		Script.Solder = m_BuildParam.NewCharacter as ISoldier;
	}
	
	// 加入武器
	public override void AddWeapon()
	{
		IWeaponFactory  WeaponFactory = PBDFactory.GetWeaponFactory();
		IWeapon Weapon = WeaponFactory.CreateWeapon( m_BuildParam.emWeapon ); 
		
		// 設定給角色
		m_BuildParam.NewCharacter.SetWeapon( Weapon );
	}
	
	// 設定角色能力(Enemy)
	public override void SetCharacterAttr()
	{
		// 取得Enemy的數值
		IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
		int AttrID = m_BuildParam.NewCharacter.GetAttrID();
		EnemyAttr theEnemyAttr = theAttrFactory.GetEnemyAttr( AttrID ); 
		
		// 設定數值的計算策略
		theEnemyAttr.SetAttStrategy( new EnemyAttrStrategy() );
		
		// 設定給角色
		m_BuildParam.NewCharacter.SetCharacterAttr( theEnemyAttr );
	}
	
	// 加入AI(Soldier)
	public override void AddAI()
	{
		SoldierAI theAI = new SoldierAI( m_BuildParam.NewCharacter );
		m_BuildParam.NewCharacter.SetAI( theAI );
	}
	
	// 加入管理器(Soldier)
	public override void AddCharacterSystem( PBaseDefenseGame PBDGame )
	{
		PBDGame.AddSoldier( m_BuildParam.NewCharacter as ISoldier );
	}
}