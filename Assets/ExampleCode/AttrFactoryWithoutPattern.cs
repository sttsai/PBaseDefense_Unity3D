using UnityEngine;
using System.Collections;

namespace AttrFactoryWithoutPattern 
{
	public class SoldierAttr
	{
		public SoldierAttr()
		{}
		public SoldierAttr(int MaxHP,float MoveSpeed,string AttrName)
		{}
	}

	// Enemy數值
	public class EnemyAttr 
	{			
		public EnemyAttr()
		{}		
		public EnemyAttr(int MaxHP, float MoveSpeed,int CritRate ,string AttrName)
		{}		
	}
	

	// 產生遊戲用數值界面
	public abstract class IAttrFactory
	{
		// 取得Soldier的數值
		public abstract SoldierAttr GetSoldierAttr( int AttrID );
		//public abstract PrefixSoldierAttr GetPrefixSoldierAttr(int AttrID, SoldierAttr theSoldierAttr);
		//public abstract SuffixSoldierAttr GetSuffixSoldierAttr(int AttrID, SoldierAttr theSoldierAttr);
		
		// 取得Enemy的數值
		public abstract EnemyAttr GetEnemyAttr(int AttrID);
		
		// 取得武器的數值
		public abstract WeaponAttr GetWeaponAttr(int AttrID);
		
	}

	// 實作產生遊戲用數值
	public class AttrFactory : IAttrFactory
	{			
		public AttrFactory()
		{}
				
		// 取得Soldier的數值
		public override SoldierAttr GetSoldierAttr( int AttrID )
		{
			switch( AttrID)
			{
			case 1: 
				return new SoldierAttr(10, 3.0f, "新兵"); // 生命力,移動速度,數值名稱
			case 2:
				return new SoldierAttr(20, 3.2f, "中士");
			case 3:
				return new SoldierAttr(30, 3.4f, "上尉");
			default:
				Debug.LogWarning("沒有針對角色數值["+AttrID+"]產生新的數值");
				break;
			}							
			return null;
		}		

		// 取得Enemy的數值
		public override EnemyAttr GetEnemyAttr( int AttrID )
		{
			switch( AttrID)
			{
			case 1: 
				return new EnemyAttr(5, 3.0f,5, "精靈"); // 生命力,移動速度,爆擊率,數值名稱
			case 2:
				return new EnemyAttr(15,3.1f,10,"山妖");
			case 3:
				return new EnemyAttr(20,3.3f,15,"怪物");
			default:
				Debug.LogWarning("沒有針對角色數值["+AttrID+"]產生新的數值");
				break;
			}							
			return null;
		}	

		// 取得武器的數值
		public override WeaponAttr GetWeaponAttr( int AttrID )
		{		
			switch( AttrID)
			{
			case 1: 
				return new WeaponAttr( 2, 4 ,"短槍"); // 攻擊力,攻擊距離,數值名稱
			case 2:
				return new WeaponAttr( 4, 7, "長槍");
			case 3:
				return new WeaponAttr( 8, 10,"火箭筒");
			default:
				Debug.LogWarning("沒有針對角色數值["+AttrID+"]產生新的數值");
				break;
			}							
			return null;
		}

	}


}
