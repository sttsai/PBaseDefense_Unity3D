using UnityEngine;
using System.Collections;

// 訂閱新關卡-增加Solder勳章
public class NewStageObserverSoldierAddMedal : IGameEventObserver 
{
	private NewStageSubject m_Subject = null;
	private PBaseDefenseGame m_PBDGame = null;
	
	public NewStageObserverSoldierAddMedal(PBaseDefenseGame  PBDGame)
	{
		m_PBDGame = PBDGame;
	}
	
	// 設定觀察的主題
	public override	void SetSubject( IGameEventSubject Subject )
	{
		m_Subject = Subject as NewStageSubject;
	}
	
	// 通知Subject被更新
	public override void Update()
	{
		// 增加勳章
		SoldierAddMedalVisitor theAddMedalVisitor = new SoldierAddMedalVisitor(m_PBDGame); 
		m_PBDGame.RunCharacterVisitor( theAddMedalVisitor );
	}
	
}