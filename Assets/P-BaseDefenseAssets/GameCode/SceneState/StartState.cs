using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// 開始狀態
public class StartState : ISceneState
{
	public StartState(SceneStateController Controller):base(Controller)
	{
		this.StateName = "StartState";
	}

	// 開始
	public override void StateBegin()
	{
		// 可在此進行遊戲資料載入及初始...等
	}

	// 更新
	public override void StateUpdate()
	{
		// 更換為
		m_Controller.SetState(new MainMenuState(m_Controller), "MainMenuScene");
	}
			
}
