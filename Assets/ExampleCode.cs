using UnityEngine;
using System.Collections;

namespace TheTest1
{
	public class ISoldier
	{
	}

	// 兵營界面
	public class CampInfoUI
	{
		CampSystem m_CampSystem; // 兵營系統

		public void TrainSoldier(int SoldierID)
		{
			m_CampSystem.TrainSoldier(SoldierID);
		}
	}

	// 兵營系統
	public class CampSystem
	{
		APSystem m_ApSystem; // 行動力系統
		CharacterSystem m_CharacterSystem;// 角色管理系統

		// 訓練戰士
		public void TrainSoldier(int SoldierID)
		{
			//向行動力系統(APSystem)詢問是否有足夠的行動力可以生產，
			if( m_ApSystem.CheckTrainSoldier( SoldierID )==false)
				return ;

			// 行動力系統(APSystem)回覆有足夠的行動力之後，兵營系統(CampSystem)便執行產生戰士功能
			ISoldier NewSoldier = CreateSoldier(SoldierID);
			if( NewSoldier == null)
				return ;

			// 再通知行動力系統(APSystem)扣除行動力，
			m_ApSystem.DescAP( 10 );
						 
			// 最後將產生的戰士交由角色管理系統(CharacterSystem)管理：
			m_CharacterSystem.AddSoldier( NewSoldier );
		}

		// 執行
		private ISoldier CreateSoldier(int SoldierID)
		{
			return null;
		}

	}

	// 行動力系統
	public class APSystem
	{
		GameStateInfoUI m_StateInfoUI; // 遊戲狀態界面
		int m_AP;

		// 是否可以訓練戰士
		public bool CheckTrainSoldier(int SoldierID)
		{
			return true;
		}

		// 扣除AP
		public void DescAP(int Value)
		{
			m_AP -= Value;
			m_StateInfoUI.UpdateUI();
		}

		// 取得AP
		public int GetAP()
		{
			return m_AP;
		}

	}

	// 遊戲狀態界面
	public class GameStateInfoUI
	{
		APSystem m_ApSystem;	// 行動力系統

		// 更新界面
		public void UpdateUI()
		{
			int NowAP = m_ApSystem.GetAP();
		}
	}

	// 角色管理系統
	public class CharacterSystem
	{
		// 加入戰士
		public void AddSoldier(ISoldier NewSoldier)
		{

		}
	}

public class TestClass
{
	/*CampInfoUI m_CampInfoUI;
	CampSystem m_CampSystem;
	APSystem m_ApSystem;
	GameStateInfoUI m_StateInfoUI;
	CharacterSystem m_CharacterSystem;

	// 設定缺
	public void SetCampInfo( CampSystem m_CampSystem ) 
	{
		m_CampSystem = pCampSystem;
	}*/

	public void CreateSoldier()
	{
		/*兵營界面(CampInfoUI)在接收到玩家指令之後，
		向兵營系統(CampSystem)通知要練訓一員戰士出場，
		兵營系統(CampSystem)接收到通知之後，
		向行動力系統(APSystem)詢問是否有足夠的行動力可以生產，行動力系統(APSystem)回覆有足夠的行動力之後，兵營系統(CampSystem)便執行產生戰士功能，再通知行動力系統(APSystem)扣除行動力，並通知遊戲狀態界面(GameStateInfoUI)顯示目前的行動力，最後將產生的戰士交由角色管理系統(CharacterSystem)管理：
*/


	}


}


}

