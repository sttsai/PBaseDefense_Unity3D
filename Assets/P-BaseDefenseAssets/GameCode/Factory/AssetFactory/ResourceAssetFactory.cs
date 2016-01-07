using UnityEngine;
using System.Collections;

// 從專案的Resource中,將Unity Asset實體化成GameObject的工廠類別
public class ResourceAssetFactory : IAssetFactory 
{
	public const string SoldierPath = "Characters/Soldier/";
	public const string EnemyPath = "Characters/Enemy/";
	public const string WeaponPath = "Weapons/";
	public const string EffectPath = "Effects/";
	public const string AudioPath  = "Audios/";
	public const string SpritePath = "Sprites/";

	// 產生Soldier
	public override GameObject LoadSoldier( string AssetName )
	{	
		return InstantiateGameObject( SoldierPath + AssetName );
	}
	
	// 產生Enemy
	public override GameObject LoadEnemy( string AssetName )
	{
		return InstantiateGameObject( EnemyPath + AssetName  );
	}

	// 產生Weapon
	public override GameObject LoadWeapon( string AssetName )
	{
		return InstantiateGameObject( WeaponPath +  AssetName );
	}

	// 產生特效
	public override GameObject LoadEffect( string AssetName )
	{
		return InstantiateGameObject( EffectPath + AssetName);
	}

	// 產生AudioClip
	public override AudioClip  LoadAudioClip(string ClipName)
	{
		UnityEngine.Object res = LoadGameObjectFromResourcePath(AudioPath + ClipName );
		if(res==null)
			return null;
		return res as AudioClip;
	}

	// 產生Sprite
	public override Sprite LoadSprite(string SpriteName)
	{
		return Resources.Load(SpritePath + SpriteName,typeof(Sprite)) as Sprite;
	}

	// 產生GameObject
	private GameObject InstantiateGameObject( string AssetName )
	{
		// 從Resrouce中載入
		UnityEngine.Object res = LoadGameObjectFromResourcePath( AssetName );
		if(res==null)
			return null;
		return  UnityEngine.Object.Instantiate(res) as GameObject;
	}

	// 從Resrouce中載入
	public UnityEngine.Object LoadGameObjectFromResourcePath( string AssetPath)
	{
		UnityEngine.Object res = Resources.Load(AssetPath);
		if( res == null)
		{
			Debug.LogWarning("無法載入路徑["+AssetPath+"]上的Asset");
			return null;
		}		
		return res;
	}
}
