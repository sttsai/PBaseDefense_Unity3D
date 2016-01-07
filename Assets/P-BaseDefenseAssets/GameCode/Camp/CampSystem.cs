using UnityEngine;
using System.Collections.Generic;

// 兵營系統
public class CampSystem : IGameSystem
{
	private Dictionary<ENUM_Soldier, ICamp> m_SoldierCamps = new Dictionary<ENUM_Soldier,ICamp>(); 
	private Dictionary<ENUM_Enemy , ICamp> m_CaptiveCamps = new Dictionary<ENUM_Enemy,ICamp>(); 

	public CampSystem(PBaseDefenseGame PBDGame):base(PBDGame)
	{
		Initialize();
	}

	// 初始兵營系統
	public override void Initialize()
	{
		// 加入三個兵營
		m_SoldierCamps.Add ( ENUM_Soldier.Rookie, SoldierCampFactory( ENUM_Soldier.Rookie ));
		m_SoldierCamps.Add ( ENUM_Soldier.Sergeant, SoldierCampFactory( ENUM_Soldier.Sergeant ));
		m_SoldierCamps.Add ( ENUM_Soldier.Captain, SoldierCampFactory( ENUM_Soldier.Captain ));

		// 加入一個俘兵營
		m_CaptiveCamps.Add ( ENUM_Enemy.Elf, CaptiveCampFactory( ENUM_Enemy.Elf ));
		// 註冊遊戲事件觀測者
		m_PBDGame.RegisterGameEvent( ENUM_GameEvent.EnemyKilled, new EnemyKilledObserverCaptiveCamp(this));
	}

	// 更新
	public override void Update()
	{
		// 兵營執行命令
		foreach( SoldierCamp Camp in m_SoldierCamps.Values )
			Camp.RunCommand();
		foreach( CaptiveCamp Camp in m_CaptiveCamps.Values )
			Camp.RunCommand();
	}
	
	// 取得場景中的兵營
	private SoldierCamp SoldierCampFactory( ENUM_Soldier emSoldier )
	{
		string GameObjectName = "SoldierCamp_";
		float CoolDown = 0;
		string CampName = "";
		string IconSprite = "";
		switch( emSoldier )
		{
		case ENUM_Soldier.Rookie:
			GameObjectName += "Rookie";
			CoolDown = 3;
			CampName = "菜鳥兵營";
			IconSprite = "RookieCamp";
			break;
		case ENUM_Soldier.Sergeant:
			GameObjectName += "Sergeant";
			CoolDown = 4;
			CampName = "中士兵營";
			IconSprite = "SergeantCamp";
			break;
		case ENUM_Soldier.Captain:
			GameObjectName += "Captain";
			CoolDown = 5;
			CampName = "上尉兵營";
			IconSprite = "CaptainCamp";
			break;
		default:
			Debug.Log("沒有指定["+emSoldier+"]要取得的場景物件名稱");
			break;				
		}

		// 取得物件
		GameObject theGameObject = UnityTool.FindGameObject( GameObjectName );

		// 取得集合點
		Vector3 TrainPoint = GetTrainPoint( GameObjectName );

		// 產生兵營
		SoldierCamp NewCamp = new SoldierCamp(theGameObject, emSoldier, CampName, IconSprite, CoolDown, TrainPoint); 
		NewCamp.SetPBaseDefenseGame( m_PBDGame );

		// 設定兵營使用的Script
		AddCampScript( theGameObject, NewCamp);

		return NewCamp;
	}

	// 顯示場景中的俘兵營
	public void ShowCaptiveCamp()
	{
		if( m_CaptiveCamps[ENUM_Enemy.Elf].GetVisible()==false)
		{
			m_CaptiveCamps[ENUM_Enemy.Elf].SetVisible(true);
			m_PBDGame.ShowGameMsg("獲得俘兵營");
		}
	}

	// 取得場景中的俘兵營
	private CaptiveCamp CaptiveCampFactory( ENUM_Enemy emEnemy )
	{
		string GameObjectName = "CaptiveCamp_";
		float CoolDown = 0;
		string CampName = "";
		string IconSprite = "";
		switch( emEnemy )
		{
		case ENUM_Enemy.Elf :
			GameObjectName += "Elf";
			CoolDown = 3;
			CampName = "精靈俘兵營";
			IconSprite = "CaptiveCamp";
			break;		
		default:
			Debug.Log("沒有指定["+emEnemy+"]要取得的場景物件名稱");
			break;				
		}

		// 取得物件
		GameObject theGameObject = UnityTool.FindGameObject( GameObjectName );
				
		// 取得集合點
		Vector3 TrainPoint = GetTrainPoint( GameObjectName );

		// 產生兵營
		CaptiveCamp NewCamp = new CaptiveCamp(theGameObject, emEnemy, CampName, IconSprite, CoolDown, TrainPoint); 
		NewCamp.SetPBaseDefenseGame( m_PBDGame );

		// 設定兵營使用的Script
		AddCampScript( theGameObject, NewCamp);
		// 先隱藏
		NewCamp.SetVisible(false);

		// 回傳
		return NewCamp;
	}

	// 取得集合點
	private Vector3 GetTrainPoint(string GameObjectName )
	{
		// 取得物件
		GameObject theCamp = UnityTool.FindGameObject( GameObjectName );
		// 取得集合點
		GameObject theTrainPoint = UnityTool.FindChildGameObject( theCamp, "TrainPoint" );
		theTrainPoint.SetActive(false);

		return theTrainPoint.transform.position;
	}

	// 設定兵營使用的Script
	private void AddCampScript(GameObject theGameObject,ICamp Camp)
	{
		// 加入Script
		CampOnClick CampScript = theGameObject.AddComponent<CampOnClick>();
		CampScript.theCamp = Camp;
	}
	
	// 通知訓練
	public void UTTrainSoldier( ENUM_Soldier emSoldier ) 
	{
		if( m_SoldierCamps.ContainsKey( emSoldier ))
			m_SoldierCamps[emSoldier].Train();
	}	

	// 通知訓練
	/*public void TrainCaptive( ENUM_Enemy emEnemy ) 
	{
		if( m_CaptiveCamps.ContainsKey( emEnemy ))
			m_CaptiveCamps[emEnemy].Train();
	}*/	
	
}
