using UnityEngine;
using System.Collections;

// Boss關卡
public class BossStageHandler : NormalStageHandler 
{
	public BossStageHandler(IStageScore StateScore, IStageData StageData ):base(StateScore,StageData) 
	{}

	// 損失的生命值
	public override int  LoseHeart()
	{
		return StageSystem.MAX_HEART;
	}
}

