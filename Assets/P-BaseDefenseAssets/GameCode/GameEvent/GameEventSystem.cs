using UnityEngine;
using System.Collections.Generic;

// 遊戲事件
public enum ENUM_GameEvent
{
	Null  			= 0,
	EnemyKilled 	= 1,// 敵方單位陣亡
	SoldierKilled	= 2,// 玩家單位陣亡
	SoldierUpgate	= 3,// 玩家單位升級
	NewStage		= 4,// 新關卡
}


// 遊戲事件系統
public class GameEventSystem : IGameSystem
{
	private Dictionary< ENUM_GameEvent, IGameEventSubject> m_GameEvents = new Dictionary< ENUM_GameEvent, IGameEventSubject>(); 

	public GameEventSystem(PBaseDefenseGame PBDGame):base(PBDGame)
	{
		Initialize();
	}
		
	// 釋放
	public override void Release()
	{
		m_GameEvents.Clear();
	}
		
	// 替某一主題註冊一個觀測者
	public void RegisterObserver(ENUM_GameEvent emGameEvnet, IGameEventObserver Observer)
	{
		// 取得事件
		IGameEventSubject Subject = GetGameEventSubject( emGameEvnet );
		if( Subject!=null)
		{
			Subject.Attach( Observer );
			Observer.SetSubject( Subject );
		}
	}

	// 註冊一個事件
	private IGameEventSubject GetGameEventSubject( ENUM_GameEvent emGameEvnet )
	{
		// 是否已經存在
		if( m_GameEvents.ContainsKey( emGameEvnet ))
			return m_GameEvents[emGameEvnet];

		// 產生對映的GameEvent
		IGameEventSubject pSujbect= null;
		switch( emGameEvnet )
		{
		case ENUM_GameEvent.EnemyKilled:
			pSujbect = new EnemyKilledSubject();
			break;
		case ENUM_GameEvent.SoldierKilled:
			pSujbect = new SoldierKilledSubject();
			break;
		case ENUM_GameEvent.SoldierUpgate:
			pSujbect = new SoldierUpgateSubject();
			break;
		case ENUM_GameEvent.NewStage:
			pSujbect = new NewStageSubject();
			break;
		default:
			Debug.LogWarning("還沒有針對["+emGameEvnet+"]指定要產生的Subject類別");
			return null;
		}

		// 加入後並回傳
		m_GameEvents.Add (emGameEvnet, pSujbect );
		return pSujbect;
	}

	// 通知一個GameEvent更新
	public void NotifySubject( ENUM_GameEvent emGameEvnet, System.Object Param)
	{
		// 是否存在
		if( m_GameEvents.ContainsKey( emGameEvnet )==false)
			return ;
		//Debug.Log("SubjectAddCount["+emGameEvnet+"]");
		m_GameEvents[emGameEvnet].SetParam( Param );
	}
	
}
