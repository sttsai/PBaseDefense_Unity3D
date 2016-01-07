using UnityEngine;
using System.Collections;

// 建立角色時所需的參數
public abstract class ICharacterBuildParam
{
	public ENUM_Weapon  emWeapon = ENUM_Weapon.Null;
	public ICharacter   NewCharacter = null;		
	public Vector3      SpawnPosition;
	public int          AttrID; 
	public string       AssetName;
	public string       IconSpriteName;
}

// 介面用來生成ICharacter的各零件
public abstract class ICharacterBuilder
{
	// 設定建立參數
	public abstract void SetBuildParam( ICharacterBuildParam theParam );
	// 載入Asset中的角色模型
	public abstract void LoadAsset	( int GameObjectID );
	// 加入OnClickScript
	public abstract void AddOnClickScript();
	// 加入武器
	public abstract void AddWeapon	();
	// 加入AI
	public abstract void AddAI		();
	// 設定角色能力
	public abstract void SetCharacterAttr();
	// 加入管理器
	public abstract void AddCharacterSystem( PBaseDefenseGame PBDGame ); 
}

