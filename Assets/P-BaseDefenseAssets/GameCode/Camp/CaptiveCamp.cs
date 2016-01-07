using UnityEngine;
using System.Collections;

// 俘兵兵營
public class CaptiveCamp : ICamp
{
	private GameObject m_GameObject = null;
	private ENUM_Enemy m_emEnemy = ENUM_Enemy.Null;
	private Vector3 m_Position;

	// 設定兵營產出的單位及冷
	public CaptiveCamp(GameObject theGameObject, ENUM_Enemy emEnemy, string CampName,string IconSprite ,float TrainCoolDown,Vector3 Position):base(theGameObject, TrainCoolDown,CampName, IconSprite )
	{
		m_emSoldier = ENUM_Soldier.Captive;
		m_emEnemy = emEnemy;			
		m_Position = Position;
	}

	// 取得訓練金額
	public override int GetTrainCost()
	{
		return 10;
	}

	// 訓練Soldier
	public override void Train()
	{
		// 產生一個訓練命令
		TrainCaptiveCommand NewCommand = new TrainCaptiveCommand( m_emEnemy, m_Position,m_PBDGame);  
		AddTrainCommand( NewCommand );
	}


}
