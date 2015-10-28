using UnityEngine;
using System.Collections.Generic;

namespace ResourceAssetFactoryWithCache
{
	// 將Unity Asset實體化成GameObject的工廠類別
	public abstract class IAssetFactory
	{
		// 產生Soldier
		public abstract GameObject LoadSoldier( string AssetName );		
	}

	// 從專案的Resource中,將Unity Asset實體化成GameObject的工廠類別
	public class ResourceAssetFactory : IAssetFactory 
	{
		public const string SoldierPath = "Characters/Soldier/";
		Dictionary<string,UnityEngine.Object> m_Cache = new Dictionary<string,UnityEngine.Object>();
		
		

		// 產生Soldier
		public override GameObject LoadSoldier( string AssetName )
		{	
			return InstantiateGameObject( SoldierPath + AssetName );
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
			// 是否在快取中
			if(m_Cache.ContainsKey(AssetPath))
				return m_Cache[AssetPath];

			UnityEngine.Object res = Resources.Load(AssetPath);
			if( res == null)
			{
				Debug.LogWarning("無法載入路徑["+AssetPath+"]上的Asset");
				return null;
			}		

			// 加入快取
			m_Cache.Add( AssetPath,res);
			return res;
		}
	}

}
