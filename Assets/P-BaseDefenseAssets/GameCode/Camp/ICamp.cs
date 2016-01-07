using UnityEngine;
using System.Collections.Generic;

// 兵營界面
public abstract class ICamp 
{
	protected GameObject m_GameObject = null;
	protected string m_Name = "Null"; //名稱
	protected string m_IconSpriteName = ""; 
	protected ENUM_Soldier m_emSoldier = ENUM_Soldier.Null;

	// 訓練命令
	protected List<ITrainCommand> m_TrainCommands = new List<ITrainCommand>();
	protected float	m_CommandTimer = 0;	 // 目前冷卻剩餘時間
	protected float m_TrainCoolDown = 0; // 冷卻時間 

	// 訓練花費
	protected ITrainCost m_TrainCost = null;

	// 主遊戲界面（必要時設定）
	protected PBaseDefenseGame m_PBDGame = null;

	public ICamp(GameObject GameObj, float TrainCoolDown,string Name,string IconSprite)
	{
		m_GameObject = GameObj;
		m_TrainCoolDown = TrainCoolDown;
		m_CommandTimer = m_TrainCoolDown;
		m_Name = Name;
		m_IconSpriteName = IconSprite;
		m_TrainCost = new TrainCost();
	}

	// 設定主遊戲界面
	public void SetPBaseDefenseGame(PBaseDefenseGame PBDGame) 
	{
		m_PBDGame = PBDGame;
	}

	// 目前
	public ENUM_Soldier GetSoldierType()
	{
		return m_emSoldier;
	}
	
	// 新增訓練命令
	protected void AddTrainCommand( ITrainCommand Command )
	{
		m_TrainCommands.Add( Command );
	}

	// 刪除訓練命令
	public void RemoveLastTrainCommand()
	{
		if( m_TrainCommands.Count == 0 )
			return ;
		// 移除最後一個
		m_TrainCommands.RemoveAt( m_TrainCommands.Count -1 );
	}

	// 目前訓練命令數量
	public int GetTrainCommandCount()
	{
		return m_TrainCommands.Count;
	}

	// 執行命令
	public void RunCommand()
	{
		// 沒有命令不執行
		if( m_TrainCommands.Count == 0 )
			return ;

		// 冷卻時間是否到了
		m_CommandTimer -= Time.deltaTime;
		if( m_CommandTimer > 0)
			return ;
		m_CommandTimer = m_TrainCoolDown;

		// 執行第一個命令 
		m_TrainCommands[0].Execute();

		// 移除
		m_TrainCommands.RemoveAt( 0 );

		//if( m_TrainCommands.Count == 0)
		//	Debug.Log ("全部訓練完成");
	}
	
	// 等級
	public virtual int GetLevel()
	{
		return 0;
	}

	// 升級花費
	public virtual int GetLevelUpCost(){ return 0;}

	// 升級
	public virtual void LevelUp(){}
	
	// 武器等級
	public virtual ENUM_Weapon GetWeaponType()
	{
		return ENUM_Weapon.Null;
	}

	// 武器升級花費
	public virtual int GetWeaponLevelUpCost(){ return 0;}

	// 武器升級
	public virtual void WeaponLevelUp(){}

	// 訓練數
	public int GetOnTrainCount()
	{
		return m_TrainCommands.Count;
	}

	// 訓練Timer
	public float GetTrainTimer()
	{
		return m_CommandTimer;
	}

	// 名稱
	public string GetName()
	{
		return m_Name;
	}

	// Icon檔名
	public string GetIconSpriteName()
	{
		return m_IconSpriteName;
	}

	// 是否顯示
	public void SetVisible(bool bValue)
	{
		m_GameObject.SetActive(bValue);
	}

	// 是否顯示
	public bool GetVisible()
	{
		return m_GameObject.activeSelf;
	}

	// 取得訓練金額
	public abstract int GetTrainCost();

	// 訓練
	public abstract void Train();

}
