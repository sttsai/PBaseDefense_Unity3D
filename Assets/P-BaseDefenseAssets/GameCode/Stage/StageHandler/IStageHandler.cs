using UnityEngine;
using System.Collections;

// 關卡界面
public abstract class IStageHandler
{
	protected IStageHandler m_NextHandler = null;// 下一個關卡
	protected IStageData	m_StatgeData  = null;
	protected IStageScore   m_StageScore  = null;// 關卡的分數

	// 設定下一個關卡
	public IStageHandler SetNextHandler(IStageHandler NextHandler)
	{
		m_NextHandler = NextHandler;
		return m_NextHandler;
	}

	public abstract IStageHandler CheckStage();
	public abstract void Update();
	public abstract void Reset();
	public abstract bool IsFinished();
	public abstract int  LoseHeart();
}
