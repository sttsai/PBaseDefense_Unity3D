using UnityEngine;
using System.Collections.Generic;

// 管理創建出來的角色
public class CharacterSystem : IGameSystem
{
	private List<ICharacter> m_Soldiers = new List<ICharacter>();
	private List<ICharacter> m_Enemys = new List<ICharacter>();

	public CharacterSystem(PBaseDefenseGame PBDGame):base(PBDGame)
	{
		Initialize();

		// 註冊事件
		m_PBDGame.RegisterGameEvent( ENUM_GameEvent.NewStage , new NewStageObserverSoldierAddMedal(m_PBDGame));
	}

	#region 角色管理

	// 增加Soldier
	public void AddSoldier( ISoldier theSoldier)
	{
		m_Soldiers.Add( theSoldier );
	}
	
	// 移除Soldier
	public void RemoveSoldier( ISoldier theSoldier)
	{
		m_Soldiers.Remove( theSoldier );
	}
	
	// 增加Enemy
	public void AddEnemy( IEnemy theEnemy)
	{
		m_Enemys.Add( theEnemy );
	}
	
	// 移除Enemy
	public void RemoveEnemy( IEnemy theEnemy)
	{
		m_Enemys.Remove( theEnemy );
	}


	// 移除角色
	public void RemoveCharacter()
	{
		// 移除可以刪除的角色
		RemoveCharacter( m_Soldiers, m_Enemys, ENUM_GameEvent.SoldierKilled );
		RemoveCharacter( m_Enemys, m_Soldiers, ENUM_GameEvent.EnemyKilled);
	}

	// 移除角色
	public void RemoveCharacter(List<ICharacter> Characters, List<ICharacter> Opponents, ENUM_GameEvent emEvent)
	{
		// 分別取得可以移除及存活的角色
		List<ICharacter> CanRemoves = new List<ICharacter>();
		foreach( ICharacter Character in Characters)
		{
			// 是否陣亡
			if( Character.IsKilled() == false)
				continue;

			//  是否確認過陣亡事情
			if( Character.CheckKilledEvent()==false)			
				m_PBDGame.NotifyGameEvent( emEvent,Character );

			// 是否可以移除
			if( Character.CanRemove())
				CanRemoves.Add (Character);
		}

		// 移除
		foreach( ICharacter CanRemove in CanRemoves)
		{
			// 通知對手移除
			foreach(ICharacter Opponent in Opponents)
				Opponent.RemoveAITarget( CanRemove );

			// 釋放資源並移除
			CanRemove.Release();
			Characters.Remove( CanRemove );
		}
	}

	// Enemy數量
	UnitCountVisitor m_UnitCountVisitor =  new UnitCountVisitor();
	public int GetEnemyCount()
	{
		// 使用Vistiro
		m_UnitCountVisitor.Reset();
		RunVisitor( m_UnitCountVisitor );
		return m_UnitCountVisitor.EnemyCount;

		// 直接取得
		//return m_Enemys.Count;
	}

	// 執行Visitor
	public void RunVisitor(ICharacterVisitor Visitor)
	{
		foreach( ICharacter Character in m_Soldiers)
			Character.RunVisitor( Visitor);
		foreach( ICharacter Character in m_Enemys)
			Character.RunVisitor( Visitor);
	}
	#endregion

	#region 更新
	// 更新
	public override void Update()	
	{
		UpdateCharacter();
		UpdateAI(); // 更新AI
	}
	
	// 更新角色
	private void UpdateCharacter()
	{
		foreach( ICharacter Character in m_Soldiers)
			Character.Update();
		foreach( ICharacter Character in m_Enemys)
			Character.Update();
	}
	
	// 更新AI
	private void UpdateAI()
	{
		// 分別更新兩個群組的AI
		UpdateAI(m_Soldiers, m_Enemys );
		UpdateAI(m_Enemys, m_Soldiers );
		
		// 移除角色
		RemoveCharacter();
	}
	
	// 更新AI
	private void UpdateAI( List<ICharacter> Characters, List<ICharacter> Targets )
	{
		foreach( ICharacter Character in Characters)
			Character.UpdateAI( Targets );
	}
	
	#endregion



	/*#region 直接取得角色數量的實作方式
	// 取得Soldier數量
	public int GetSoldierCount()
	{
		return m_Soldiers.Count;
	}

	// 取得各Soldier單位數量
	public int GetSoldierCount(ENUM_Soldier emSolider)
	{
		int Count =0;
		foreach(ISoldier pSoldier in m_Soldiers)
		{
			if(pSoldier == null)
				continue;

			if( pSoldier.GetSoldierType() == emSolider)
				Count++;
		}
		return Count;
	}		
	#endregion*/


}
