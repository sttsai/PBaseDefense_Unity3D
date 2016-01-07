using UnityEngine;
using System.Collections;

// 場景狀態
public class ISceneState
{
	// 狀態名稱
	private string m_StateName = "ISceneState";
	public string StateName
	{
		get{ return m_StateName; }
		set{ m_StateName = value; }
	}

	// 控制者
	protected SceneStateController m_Controller = null;
		
	// 建構者
	public ISceneState(SceneStateController Controller)
	{ 
		m_Controller = Controller; 
	}

	// 開始
	public virtual void StateBegin()
	{}

	// 結束
	public virtual void StateEnd()
	{}

	// 更新
	public virtual void StateUpdate()
	{}

	public override string ToString ()
	{
		return string.Format ("[I_SceneState: StateName={0}]", StateName);
	}


}
