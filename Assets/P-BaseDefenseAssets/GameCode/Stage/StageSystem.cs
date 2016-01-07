using UnityEngine;
using System.Collections.Generic;

// 關卡控制系統
public class StageSystem : IGameSystem
{
	public const int MAX_HEART = 3;
	private int m_NowHeart = MAX_HEART;			// 目前玩家陣地存情況
	private int	m_EnemyKilledCount = 0;			// 目前敵方單位陣亡數

	private int			  m_NowStageLv	 = 1;	// 目前的關卡
	private IStageHandler m_NowStageHandler = null;
	private IStageHandler m_RootStageHandler = null;	
	private List<Vector3> m_SpawnPosition = null;		// 出生點
	private Vector3 	  m_AttackPos = Vector3.zero;	// 攻擊點
	private bool 		  m_bCreateStage = false;		// 是否需要建立關卡

	public StageSystem(PBaseDefenseGame PBDGame):base(PBDGame)
	{
		Initialize();
	}

	// 
	public override void Initialize()
	{
		// 設定關卡
		InitializeStageData();
		// 指定第一個關卡
		m_NowStageHandler = m_RootStageHandler;	
		m_NowStageLv = 1;
		// 註冊遊戲事件
		m_PBDGame.RegisterGameEvent( ENUM_GameEvent.EnemyKilled, new EnemyKilledObserverStageScore(this)); 
	}

	// 
	public override void Release ()
	{
		base.Release ();
		m_SpawnPosition.Clear();
		m_SpawnPosition = null;
		m_NowHeart = MAX_HEART;
		m_EnemyKilledCount = 0;
		m_AttackPos = Vector3.zero;
	}
	
	// 更新
	public override void Update()
	{
		// 更新目前的關卡
		m_NowStageHandler.Update();

		// 是否要切換下一個關卡
		if(m_PBDGame.GetEnemyCount() ==  0 )
		{
			// 是否結束
			if( m_NowStageHandler.IsFinished()==false)
				return ;

			// 取得下一關
			IStageHandler NewStageData = m_NowStageHandler.CheckStage();

			// 是否為舊的關卡
			if( m_NowStageHandler == NewStageData)
				m_NowStageHandler.Reset();
			else			
				m_NowStageHandler = NewStageData;

			// 通知進入下一關
			NotiyfNewStage();
		}
	}
	
	// 通知損失
	public void LoseHeart()
	{
		m_NowHeart -= m_NowStageHandler.LoseHeart();
		m_PBDGame.ShowHeart( m_NowHeart );
	}

	// 增加目前擊殺數(不透過GameEventSystem呼叫)
	public void AddEnemyKilledCount()
	{
		m_EnemyKilledCount++;
	}

	// 設定目前擊殺數(透過GameEventSystem呼叫)
	public void SetEnemyKilledCount( int KilledCount)
	{
		//Debug.Log("StageSysem.SetEnemyKilledCount:"+KilledCount);
		m_EnemyKilledCount = KilledCount;
	}

	// 取得目前擊殺數
	public int GetEnemyKilledCount()
	{
		return m_EnemyKilledCount;
	}

	// 通知新的關卡
	private void NotiyfNewStage()
	{
		m_PBDGame.ShowGameMsg("新的關卡");
		m_NowStageLv++;

		//  顯示
		m_PBDGame.ShowNowStageLv(m_NowStageLv);

		// 事件
		m_PBDGame.NotifyGameEvent( ENUM_GameEvent.NewStage , m_NowStageLv );

	}
	
	// 初始所有關卡
	private void InitializeStageData()
	{
		if( m_RootStageHandler!=null)
			return ;

		// 參考點
		Vector3 AttackPosition = GetAttackPosition();

		NormalStageData StageData = null; // 關卡要產生的Enemy
		IStageScore StageScore = null; // 關卡過關資訊
		IStageHandler NewStage = null;

		// 第1關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition );
		StageData.AddStageData( ENUM_Enemy.Elf, ENUM_Weapon.Gun, 3); 
		StageScore 	= new StageScoreEnemyKilledCount(3, this);
		NewStage = new NormalStageHandler(StageScore, StageData );

		// 設定為起始關卡
		m_RootStageHandler = NewStage;

		// 第2關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Elf, ENUM_Weapon.Rifle,3); 
		StageScore 	= new StageScoreEnemyKilledCount(6, this);
		NewStage = NewStage.SetNextHandler( new NormalStageHandler( StageScore, StageData) );

		// 第3關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Elf, ENUM_Weapon.Rocket,3); 
		StageScore 	= new StageScoreEnemyKilledCount(9, this);
		NewStage = NewStage.SetNextHandler( new NormalStageHandler( StageScore, StageData) );

		// 第4關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Troll, ENUM_Weapon.Gun,3); 
		StageScore 	= new StageScoreEnemyKilledCount(12, this);
		NewStage = NewStage.SetNextHandler( new NormalStageHandler( StageScore, StageData) );

		// 第5關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Troll, ENUM_Weapon.Rifle,3); 
		StageScore 	= new StageScoreEnemyKilledCount(15, this);
		NewStage = NewStage.SetNextHandler( new NormalStageHandler( StageScore, StageData) );

		// 第5關:Boss關卡
		/*StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Ogre, ENUM_Weapon.Rocket,3); 
		StageScore 	= new StageScoreEnemyKilledCount(13, this);
		NewStage = NewStage.SetNextHandler( new BossStageHandler( StageScore, StageData) );*/

		// 第6關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Troll, ENUM_Weapon.Rocket,3); 
		StageScore 	= new StageScoreEnemyKilledCount(18, this);
		NewStage = NewStage.SetNextHandler( new NormalStageHandler( StageScore, StageData) );

		// 第7關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Ogre, ENUM_Weapon.Gun,3); 
		StageScore 	= new StageScoreEnemyKilledCount(21, this);
		NewStage = NewStage.SetNextHandler( new NormalStageHandler( StageScore, StageData) );
		
		// 第8關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Ogre, ENUM_Weapon.Rifle,3); 
		StageScore 	= new StageScoreEnemyKilledCount(24, this);
		NewStage = NewStage.SetNextHandler( new NormalStageHandler( StageScore, StageData) );
		
		// 第9關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Ogre, ENUM_Weapon.Rocket,3); 
		StageScore 	= new StageScoreEnemyKilledCount(27, this);
		NewStage = NewStage.SetNextHandler( new NormalStageHandler( StageScore, StageData) );

		// 第10關
		StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Elf, ENUM_Weapon.Rocket,3); 
		StageData.AddStageData( ENUM_Enemy.Troll, ENUM_Weapon.Rocket,3); 
		StageData.AddStageData( ENUM_Enemy.Ogre, ENUM_Weapon.Rocket,3); 
		StageScore 	= new StageScoreEnemyKilledCount(30, this);
		NewStage = NewStage.SetNextHandler( new NormalStageHandler( StageScore, StageData) );
	}

	// 取得出生點
	private Vector3 GetSpawnPosition()
	{
		if( m_SpawnPosition == null)
		{
			m_SpawnPosition = new List<Vector3>();

			for(int i=1;i<=3;++i)
			{
				string name = string.Format("EnemySpawnPosition{0}",i);
				GameObject tempObj = UnityTool.FindGameObject( name );
				if( tempObj==null)
					continue;
				tempObj.SetActive(false);
				m_SpawnPosition.Add( tempObj.transform.position );
			}
		}

		// 隨機傳回
		int index  = UnityEngine.Random.Range(0, m_SpawnPosition.Count -1 );
		return m_SpawnPosition[index];
	}

	// 取得攻擊點
	private Vector3 GetAttackPosition()
	{
		if( m_AttackPos == Vector3.zero)
		{
			GameObject tempObj = UnityTool.FindGameObject("EnemyAttackPosition");
			if( tempObj==null)
				return Vector3.zero;
			tempObj.SetActive(false);
			m_AttackPos = tempObj.transform.position;
		}
		return m_AttackPos;
	}

	//===============================================================================
	// 定期更新(沒有套用 Chain of Responsibility 模式前)
	/*public override void Update()
	{
		// 是否要開啟新關卡
		if(m_bCreateStage)
		{
			CreateStage();
			m_bCreateStage =false;
		}
		
		// 是否要切換下一個關卡
		if(m_PBDGame.GetEnemyCount() ==  0 )
		{
			if( CheckNextStage() )
				m_NowStageLv++ ;
			m_bCreateStage = true;
		}
	}
	
	// 建立關卡
	private void CreateStage()
	{
		// 一次產生一個單位
		ICharacterFactory Factory = PBDFactory.GetCharacterFactory();			
		Vector3 AttackPosition = GetAttackPosition();
		switch( m_NowStageLv)
		{
		case 1:
			Debug.Log("建立第1關");
			Factory.CreateEnemy( ENUM_Enemy.Elf ,ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
			Factory.CreateEnemy( ENUM_Enemy.Elf ,ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
			Factory.CreateEnemy( ENUM_Enemy.Elf ,ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
			break;
		case 2:
			Debug.Log("建立第2關");
			Factory.CreateEnemy( ENUM_Enemy.Elf ,ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
			Factory.CreateEnemy( ENUM_Enemy.Elf ,ENUM_Weapon.Rifle, GetSpawnPosition(), AttackPosition);
			Factory.CreateEnemy( ENUM_Enemy.Troll ,ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
			break;
		case 3:
			Debug.Log("建立第3關");
			Factory.CreateEnemy( ENUM_Enemy.Elf ,ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
			Factory.CreateEnemy( ENUM_Enemy.Troll ,ENUM_Weapon.Gun, GetSpawnPosition(), AttackPosition);
			Factory.CreateEnemy( ENUM_Enemy.Troll ,ENUM_Weapon.Rifle, GetSpawnPosition(), AttackPosition);
			break;
		}	
	}
	
	// 確認是否要切掉到下一個關卡
	private bool CheckNextStage()
	{
		switch( m_NowStageLv)
		{
		case 1:
			if( GetEnemyKilledCount() >=3)
				return true;
			break;
		case 2:
			if( GetEnemyKilledCount() >=6)
				return true;
			break;
		case 3:
			if( GetEnemyKilledCount() >=9)
				return true;
			break;
		}	
		return false;
	}*/
	
}
