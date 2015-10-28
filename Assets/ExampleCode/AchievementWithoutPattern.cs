using UnityEngine;
using System.Collections;
namespace AchievementWithoutPattern
{

	// 成就事件
	public enum ENUM_GameEvent
	{
		Null  			= 0,
		EnemyKilled 	= 1,// 敵方單位陣亡
		SoldierKilled	= 2,// 玩家單位陣亡
		SoldierUpgate	= 3,// 玩家單位升級
		NewStage		= 4,// 新關卡
	}

	// 成就系統
	public class AchievementSystem
	{
		// 記錄的成就項目
		private int m_EnemyKilledCount = 0;
		private int m_SoldierKilledCount = 0;
		private int m_StageLv =  0;
		private bool m_KillOgreEquipRocket=false;

		// 通知遊戲事件發生
		public void NotifyGameEvent(ENUM_GameEvent emGameEvent, System.Object Param1, System.Object Param2)
		{
			// 依遊戲事件
			switch( emGameEvent )
			{
			case ENUM_GameEvent.EnemyKilled:	// 敵方單位陣亡
				Notify_EnemyKilled(Param1 as IEnemy );
				break;
			case ENUM_GameEvent.SoldierKilled:	// 玩家單位陣亡
				Notify_SoldierKilled( Param1 as ISoldier );
				break;
			case ENUM_GameEvent.SoldierUpgate:	// 玩家單位升級
				Notify_SoldierUpgate( Param1 as ISoldier );
				break;
			case ENUM_GameEvent.NewStage:		// 新關卡
				Notify_NewStage((int)Param1);
				break;
			}
		}

		// 敵方單位陣亡
		private void Notify_EnemyKilled(IEnemy theEnemy )
		{
			// 陣亡數增加
			m_EnemyKilledCount++;

			// 擊倒裝備Rocket 的Ogre
			if( theEnemy.GetEnemyType() == ENUM_Enemy.Ogre && theEnemy.GetWeapon().GetWeaponType() == ENUM_Weapon.Rocket)
				m_KillOgreEquipRocket = true;
		}

		// 玩家單位陣亡
		private void Notify_SoldierKilled( ISoldier theSoldier)
		{
			
		}

		// 玩家單位升級
		private void Notify_SoldierUpgate( ISoldier theSoldier)
		{
			
		}

		// 新關卡
		private void Notify_NewStage( int StageLv)
		{
			
		}

	}

	

}

