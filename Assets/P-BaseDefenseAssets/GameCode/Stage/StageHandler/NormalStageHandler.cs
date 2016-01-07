using UnityEngine;
using System.Collections;

// 一般關卡
public class NormalStageHandler : IStageHandler 
{
	// 設定分數及關卡資料
	public NormalStageHandler(IStageScore StateScore, IStageData StageData )
	{
		m_StageScore  = StateScore;
		m_StatgeData  = StageData;
	}
		
	// 確認關卡
	public override IStageHandler CheckStage()
	{
		// 分數是否足夠
		if( m_StageScore.CheckScore()==false)
			return this;

		// 已經是最後一關了
		if(m_NextHandler==null)
			return this;		

		// 確認下一個關卡
		return m_NextHandler.CheckStage();
	}
	
	public override void Update()
	{
		m_StatgeData.Update();
	}

	public override void Reset()
	{
		m_StatgeData.Reset();
	}

	public override bool IsFinished()
	{
		return m_StatgeData.IsFinished();
	}

	// 損失的生命值
	public override int  LoseHeart()
	{
		return 1;
	}
}
