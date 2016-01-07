using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePauseUI : IUserInterface 
{
	private Text m_EnemyKilledCountText = null;
	private Text m_SoldierKilledCountText = null;
	private Text m_StageLvCountText = null;
	

	public GamePauseUI( PBaseDefenseGame PBDGame ):base(PBDGame)
	{
		Initialize();
	}
	
	// 初始
	public override void Initialize()
	{
		m_RootUI = UITool.FindUIGameObject( "GamePauseUI" );

		m_EnemyKilledCountText 	= UITool.GetUIComponent<Text>(m_RootUI,"EnemyKilledCountText");
		m_SoldierKilledCountText = UITool.GetUIComponent<Text>(m_RootUI,"SoldierKilledCountText");
		m_StageLvCountText 		= UITool.GetUIComponent<Text>(m_RootUI,"StageLvCountText");

		// Continue
		Button btn  = UITool.GetUIComponent<Button>(m_RootUI, "ContinueBtn");
		btn.onClick.AddListener( ()=> OnContinueBtnClick() );

		// Continue
		btn  = UITool.GetUIComponent<Button>(m_RootUI, "ExitBtn");
		btn.onClick.AddListener( ()=> OnExitBtnClick() );


		Hide ();
	}

	public override void Hide ()
	{
		Time.timeScale = 1;
		base.Hide ();
	}

	public override void Show ()
	{
		// 顯示相關訊息
		Time.timeScale = 0;
		base.Show ();
	}
	
	// 顯示暫停
	public void ShowGamePause(  AchievementSaveData SaveData )
	{
		m_EnemyKilledCountText.text = string.Format("目前殺敵數總合:{0}",SaveData.EnemyKilledCount);
		m_SoldierKilledCountText.text = string.Format("目前我方單位陣亡總合:{0}",SaveData.SoldierKilledCount);
		m_StageLvCountText.text = string.Format("最高關卡數:{0}",SaveData.StageLv); 		
		Show();
	}

	// Continue
	private void OnContinueBtnClick()
	{
		Hide();
	}

	// Exit
	private void OnExitBtnClick()
	{
		Hide ();
		m_PBDGame.ChangeToMainMenu ();
	}

}
