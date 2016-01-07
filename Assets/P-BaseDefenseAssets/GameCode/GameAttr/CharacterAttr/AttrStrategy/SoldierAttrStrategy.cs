using UnityEngine;
using System.Collections;

// 玩家單位(士兵)的數值計算策略
public class SoldierAttrStrategy : IAttrStrategy 
{
	// 初始的數值
	public override void InitAttr( ICharacterAttr CharacterAttr )
	{
		// 是否為士兵類別
		SoldierAttr theSoldierAttr = CharacterAttr as SoldierAttr;
		if(theSoldierAttr==null)
			return ;

		// 最大生命力有等級加乘
		int AddMaxHP = 0;
		int Lv = theSoldierAttr.GetSoldierLv();
		if(Lv > 0 )
			AddMaxHP = (Lv-1)*2;
	
		// 設定最高HP
		theSoldierAttr.AddMaxHP( AddMaxHP );
	}
	
	// 攻擊加乘
	public override int GetAtkPlusValue( ICharacterAttr CharacterAttr )
	{
		// 沒有攻擊加乘
		return 0;
	}
	
	// 取得減傷害值
	public override int GetDmgDescValue( ICharacterAttr CharacterAttr )
	{
		// 是否為士兵類別
		SoldierAttr theSoldierAttr = CharacterAttr as SoldierAttr;
		if(theSoldierAttr==null)
			return 0;

		// 回傳減傷值
		return (theSoldierAttr.GetSoldierLv()-1)*2;;
	}

}
