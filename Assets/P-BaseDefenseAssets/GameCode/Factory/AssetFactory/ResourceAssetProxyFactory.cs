using UnityEngine;
using System.Collections.Generic;

// 做為ResourceAssetFactory的Proxy代理者,會記錄已經載入過的資源
public class ResourceAssetProxyFactory : IAssetFactory
{
	private ResourceAssetFactory m_RealFactory = null; // 實際負責載入的AssetFactory
	private Dictionary<string,UnityEngine.Object> m_Soldiers = null;
	private Dictionary<string,UnityEngine.Object> m_Enemys = null;
	private Dictionary<string,UnityEngine.Object> m_Weapons = null;
	private Dictionary<string,UnityEngine.Object> m_Effects = null;
	private Dictionary<string,AudioClip>		  m_Audios = null;
	private Dictionary<string,Sprite> 			  m_Sprites = null;
	
	public ResourceAssetProxyFactory()
	{
		m_RealFactory =  new ResourceAssetFactory();
		m_Soldiers = new Dictionary<string,UnityEngine.Object>();
		m_Enemys = new Dictionary<string,UnityEngine.Object>();
		m_Weapons = new Dictionary<string,UnityEngine.Object>();
		m_Effects = new Dictionary<string,UnityEngine.Object>();
		m_Audios = new Dictionary<string,AudioClip>();
		m_Sprites = new Dictionary<string,Sprite>();
	}
	
	// 產生Soldier
	public override GameObject LoadSoldier( string AssetName )
	{
		// 還沒載入時
		if( m_Soldiers.ContainsKey( AssetName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath( ResourceAssetFactory.SoldierPath + AssetName );
			m_Soldiers.Add ( AssetName, res);
		}
		return  UnityEngine.Object.Instantiate( m_Soldiers[AssetName] ) as GameObject;
	}
	
	// 產生Enemy
	public override GameObject LoadEnemy( string AssetName )
	{
		if( m_Enemys.ContainsKey( AssetName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath( ResourceAssetFactory.EnemyPath + AssetName );
			m_Enemys.Add ( AssetName, res);
		}
		return  UnityEngine.Object.Instantiate( m_Enemys[AssetName] ) as GameObject;
	}

	// 產生Weapon
	public override GameObject LoadWeapon( string AssetName )
	{
		if( m_Weapons.ContainsKey( AssetName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath( ResourceAssetFactory.WeaponPath + AssetName );
			m_Weapons.Add ( AssetName, res);
		}
		return  UnityEngine.Object.Instantiate( m_Weapons[AssetName] ) as GameObject;
	}

	// 產生特效
	public override GameObject LoadEffect( string AssetName )
	{
		if( m_Effects.ContainsKey( AssetName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath( ResourceAssetFactory.EffectPath + AssetName );
			m_Effects.Add ( AssetName, res);
		}
		return  UnityEngine.Object.Instantiate( m_Effects[AssetName] ) as GameObject;
	}

	// 產生AudioClip
	public override AudioClip  LoadAudioClip(string ClipName )
	{
		if( m_Audios.ContainsKey( ClipName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath( ResourceAssetFactory.AudioPath + ClipName );
			m_Audios.Add ( ClipName, res as AudioClip);
		}
		return m_Audios[ClipName];
	}

	// 產生Sprite
	public override Sprite LoadSprite(string SpriteName)
	{
		if( m_Sprites.ContainsKey( SpriteName )==false)
		{
			Sprite res = m_RealFactory.LoadSprite( SpriteName );
			m_Sprites.Add ( SpriteName, res );
		}
		return m_Sprites[SpriteName];
	}
}
