using UnityEngine;
using System.Collections;

// 關卡資訊介面
public abstract class IStageData
{
	public abstract void Update();
	public abstract	bool IsFinished();
	public abstract	void Reset();
}
