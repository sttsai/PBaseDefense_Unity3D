using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// 主選單狀態
public class MainMenuState : ISceneState
{
	public MainMenuState(SceneStateController Controller):base(Controller)
	{
		this.StateName = "MainMenuState";
	}

	// 開始
	public override void StateBegin()
	{
		// 取得開始按鈕
		Button tmpBtn = UITool.GetUIComponent<Button>("StartGameBtn");
		if(tmpBtn!=null)
			tmpBtn.onClick.AddListener( ()=> OnStartGameBtnClick(tmpBtn) );
	}
			
	// 開始戰鬥
	private void OnStartGameBtnClick(Button theButton)
	{
		//Debug.Log ("OnStartBtnClick:"+theButton.gameObject.name);
		m_Controller.SetState(new BattleState(m_Controller), "BattleScene" );
	}

}
