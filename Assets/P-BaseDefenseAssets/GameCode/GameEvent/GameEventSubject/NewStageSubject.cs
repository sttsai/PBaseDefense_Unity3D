using UnityEngine;
using System.Collections;

// 新的關卡
public class NewStageSubject : IGameEventSubject
{
	private int m_StageCount = 1;

	public NewStageSubject()
	{}

	// 目前關卡數
	public int GetStageCount()
	{
		return m_StageCount;
	}
	
	// 通知
	public override void SetParam( System.Object Param )
	{
		base.SetParam( Param);
		m_StageCount = (int)Param;
		
		// 通知
		Notify();
	}
}
