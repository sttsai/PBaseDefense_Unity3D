using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// 兵營界面
public class CampInfoUI : IUserInterface
{
	private ICamp m_Camp = null; // 顯示的兵營

	// 界面元件
	private Button m_LevelUpBtn = null;
	private Button m_WeaponLvUpBtn = null;
	private Button m_TrainBtn = null;
	private Button m_CancelBtn = null;
	private Text m_AliveCountTxt = null;
	private Text m_CampLvTxt = null;
	private Text m_WeaponLvTxt = null;
	private Text m_TrainCostText = null;
	private Text m_TrainTimerText= null;
	private Text m_OnTrainCountTxt = null;
	private Text m_CampNameTxt = null;
	private Image m_CampImage = null; 

	private UnitCountVisitor m_UnitCountVisitor = new UnitCountVisitor(); // 存活單位計數

	
	public CampInfoUI( PBaseDefenseGame PBDGame ):base(PBDGame)
	{
		Initialize();
	}

	// 初始
	public override void Initialize()
	{
		m_RootUI = UITool.FindUIGameObject( "CampInfoUI" );

		// 顯示的訊息
		// 兵營名稱
		m_CampNameTxt = UITool.GetUIComponent<Text>(m_RootUI, "CampNameText");
		// 兵營圖
		m_CampImage = UITool.GetUIComponent<Image>(m_RootUI, "CampIcon");
		// 存活單位數
		m_AliveCountTxt = UITool.GetUIComponent<Text>(m_RootUI, "AliveCountText");				
		// 等級
		m_CampLvTxt = UITool.GetUIComponent<Text>(m_RootUI, "CampLevelText");
		// 武器等級
		m_WeaponLvTxt = UITool.GetUIComponent<Text>(m_RootUI, "WeaponLevelText");
		// 訓練中的數量
		m_OnTrainCountTxt = UITool.GetUIComponent<Text>(m_RootUI, "OnTrainCountText");
		// 訓練花費
		m_TrainCostText = UITool.GetUIComponent<Text>(m_RootUI, "TrainCostText");
		// 訓練時間
		m_TrainTimerText = UITool.GetUIComponent<Text>(m_RootUI, "TrainTimerText");

		// 玩家的互動
		// 升級
		m_LevelUpBtn = UITool.GetUIComponent<Button>(m_RootUI, "CampLevelUpBtn");
		m_LevelUpBtn.onClick.AddListener( ()=> OnLevelUpBtnClick() );
		// 武器升級
		m_WeaponLvUpBtn = UITool.GetUIComponent<Button>(m_RootUI, "WeaponLevelUpBtn");
		m_WeaponLvUpBtn.onClick.AddListener( ()=> OnWeaponLevelUpBtnClick() );
		// 訓練
		m_TrainBtn = UITool.GetUIComponent<Button>(m_RootUI, "TrainSoldierBtn");
		m_TrainBtn.onClick.AddListener( ()=> OnTrainBtnClick() );
		// 取消訓練
		m_CancelBtn = UITool.GetUIComponent<Button>(m_RootUI, "CancelTrainBtn");
		m_CancelBtn.onClick.AddListener( ()=> OnCancelBtnClick() );

		Hide();
	}

	// 顯示資訊
	public void ShowInfo(ICamp Camp)
	{
		//Debug.Log("顯示兵營資訊");
		Show ();
		m_Camp = Camp;

		// 名稱
		m_CampNameTxt.text = m_Camp.GetName();
		// 訓練花費
		m_TrainCostText.text = string.Format("AP:{0}",m_Camp.GetTrainCost());
		// 訓練中資訊
		ShowOnTrainInfo();
		// Icon
		IAssetFactory Factory = PBDFactory.GetAssetFactory();
		m_CampImage.sprite = Factory.LoadSprite( m_Camp.GetIconSpriteName());

		// 升級功能
		if( m_Camp.GetLevel() <= 0 )
			EnableLevelInfo(false);
		else
		{
			EnableLevelInfo(true);
			m_CampLvTxt.text = string.Format("等級:" + m_Camp.GetLevel());
			ShowWeaponLv();// 顯示武器等級
		}			
	}

	// 顯示武器等級
	private void ShowWeaponLv()
	{
		string WeaponName = "";
		switch(m_Camp.GetWeaponType())
		{
		case ENUM_Weapon.Gun:
			WeaponName = "槍";
			break;
		case ENUM_Weapon.Rifle:
			WeaponName = "長槍";
			break;
		case ENUM_Weapon.Rocket:
			WeaponName = "火箭筒";
			break;
		default:
			WeaponName = "未命名";
			break;
		}
		m_WeaponLvTxt.text = string.Format("武器等級:{0}",WeaponName);

	}

	// 訓練中的資訊
	private void ShowOnTrainInfo()
	{
		if( m_Camp == null)
			return ;
		int Count = m_Camp.GetOnTrainCount();
		m_OnTrainCountTxt.text = string.Format("訓練數量:" + Count);
		if(Count>0)
			m_TrainTimerText.text = string.Format("完成時間:{0:0.00}",m_Camp.GetTrainTimer());
		else
			m_TrainTimerText.text = "";

		// 存活單位
		m_UnitCountVisitor.Reset();
		m_PBDGame.RunCharacterVisitor( m_UnitCountVisitor );
		int UnitCount = m_UnitCountVisitor.GetUnitCount( m_Camp.GetSoldierType());
		m_AliveCountTxt.text = string.Format( "存活單位:{0}",UnitCount );
	}

	// 更新
	public override void Update ()
	{
		ShowOnTrainInfo();
	}

	// 顯示詳細資訊
	private void EnableLevelInfo(bool Value)
	{
		m_CampLvTxt.enabled = Value;
		m_WeaponLvTxt.enabled = Value;
		m_LevelUpBtn.gameObject.SetActive(Value);
		m_WeaponLvUpBtn.gameObject.SetActive( Value);
	}
	
	// 升級
	private void OnLevelUpBtnClick()
	{
		int Cost = m_Camp.GetLevelUpCost();
		if( CheckRule( Cost > 0 , "已達最高等級")==false )
			return ;

		// 是否足夠
		string Msg = string.Format("AP不足無法升級,需要{0}點AP",Cost);
		if( CheckRule(  m_PBDGame.CostAP(Cost), Msg ) ==false)
			return ;

		// 升級
		m_Camp.LevelUp();
		ShowInfo( m_Camp );
	}

	// 武器升級
	private void OnWeaponLevelUpBtnClick()
	{
		int Cost = m_Camp.GetWeaponLevelUpCost();
		if( CheckRule( Cost > 0 ,"已達最高等級" )==false )		
			return ;

		// 是否足夠
		string Msg = string.Format("AP不足無法升級,需要{0}點AP",Cost);
		if( CheckRule( m_PBDGame.CostAP(Cost), Msg ) ==false)
			return ;
		
		// 升級
		m_Camp.WeaponLevelUp();
		ShowInfo( m_Camp );
	}

	// 訓練
	private void OnTrainBtnClick()
	{
		int Cost = m_Camp.GetTrainCost();
		if( CheckRule( Cost > 0 ,"無法訓練" )==false )		
			return ;

		// 是否足夠
		string Msg = string.Format("AP不足無法訓練,需要{0}點AP",Cost);
		if( CheckRule( m_PBDGame.CostAP(Cost), Msg ) ==false)
			return ;

		// 產生訓練命令
		m_Camp.Train();
		ShowInfo( m_Camp );
	}

	// 取消訓練
	private void OnCancelBtnClick()
	{
		// 取消訓練命令
		m_Camp.RemoveLastTrainCommand();
		ShowInfo( m_Camp );
	}

	// 判斷條件並顯示訊息
	private bool CheckRule( bool bValue, string NotifyMsg )
	{
		if( bValue == false)
			m_PBDGame.ShowGameMsg( NotifyMsg );			
		return bValue;
	}

}
