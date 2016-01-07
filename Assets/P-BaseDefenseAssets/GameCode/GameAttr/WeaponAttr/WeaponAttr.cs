using UnityEngine;
using System.Collections;

// 武器數值類別
public class WeaponAttr
{
	public int 		Atk 	{get; private set;}	// 攻擊力
	public float 	AtkRange{get; private set;}	// 攻擊距離
	public string 	AttrName{get; private set;} // 屬性名稱

	public 	WeaponAttr(int AtkValue,float Range,string AttrName)
	{
		this.Atk = AtkValue;
		this.AtkRange = Range;
		this.AttrName = AttrName;
	}
}
