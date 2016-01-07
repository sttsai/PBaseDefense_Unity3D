using UnityEngine;
using System.Collections.Generic;

// 一般關卡資訊
public class NormalStageData : IStageData 
{
	private float m_CoolDown = 0;		// 產生角色的間隔時間
	private float m_MaxCoolDown = 0;	// 
	private Vector3 m_SpawnPosition = Vector3.zero;	// 出生點
	private Vector3 m_AttackPosition = Vector3.zero;// 攻擊目標
	private bool 	m_AllEnemyBorn = false;
	
	//一般關卡要產生的敵人單位
	class StageData
	{
		public ENUM_Enemy emEnemy = ENUM_Enemy.Null;
		public ENUM_Weapon emWeapon = ENUM_Weapon.Null;
		public bool bBorn = false;
		public StageData( ENUM_Enemy emEnemy, ENUM_Weapon emWeapon )
		{
			this.emEnemy = emEnemy;
			this.emWeapon= emWeapon;
		}
	}
	// 關卡內要產生的敵人單位
	private List<StageData> m_StageData = new List<StageData>(); 
	
	// 設定多久產生一個敵方單位
	public NormalStageData(float CoolDown ,Vector3 SpawnPosition, Vector3 AttackPosition)
	{
		m_MaxCoolDown = CoolDown;
		m_CoolDown = m_MaxCoolDown;
		m_SpawnPosition = SpawnPosition;
		m_AttackPosition = AttackPosition;
	}

	// 增加關卡的敵方單位
	public void AddStageData( ENUM_Enemy emEnemy, ENUM_Weapon emWeapon,int Count)
	{
		for(int i=0;i<Count;++i)
			m_StageData.Add ( new StageData(emEnemy, emWeapon));
	}

	// 重置
	public override	void Reset()
	{
		foreach( StageData pData in m_StageData)
			pData.bBorn = false;		
		m_AllEnemyBorn = false;
	}

	// 更新
	public override void Update()
	{
		if( m_StageData.Count == 0)
			return ;

		// 是否可以產生
		m_CoolDown -= Time.deltaTime;
		if( m_CoolDown > 0)
			return ;
		m_CoolDown = m_MaxCoolDown;

		// 取得上場的角色
		StageData theNewEnemy = GetEnemy();
		if(theNewEnemy == null)
			return;

		// 一次產生一個單位
		ICharacterFactory Factory = PBDFactory.GetCharacterFactory();
		Factory.CreateEnemy( theNewEnemy.emEnemy, theNewEnemy.emWeapon, m_SpawnPosition, m_AttackPosition);
	}

	// 取得還沒產出
	private StageData GetEnemy()
	{
		foreach( StageData pData in m_StageData)
		{
			if(pData.bBorn == false)
			{
				pData.bBorn = true;
				return pData;
			}
		}
		m_AllEnemyBorn = true;
		return null;
	}


	// 是否完成
	public override	bool IsFinished()
	{
		return m_AllEnemyBorn;
	}
}
