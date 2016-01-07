using UnityEngine;
using System.Collections;

// 敵方單位的數值計算策略
public class EnemyAttrStrategy : IAttrStrategy 
{
	// 初始的數值
	public override void InitAttr( ICharacterAttr CharacterAttr )
	{
		// 不用計算
	}
	
	// 攻擊加乘
	public override int GetAtkPlusValue( ICharacterAttr CharacterAttr )
	{
		// 是否為敵方數值
		EnemyAttr theEnemyAttr = CharacterAttr as EnemyAttr;
		if(theEnemyAttr==null)
			return 0;

		// 依爆擊機率回傳攻擊加乘值
		int RandValue =  UnityEngine.Random.Range(0,100);
		if( theEnemyAttr.GetCritRate()  >= RandValue )
		{
			theEnemyAttr.CutdownCritRate();		// 減少爆擊機率
			return theEnemyAttr.GetMaxHP()*5; 	// 血量的5倍值
		}
		return 0;
	}
	
	// 取得減傷害值
	public override int GetDmgDescValue( ICharacterAttr CharacterAttr )
	{
		// 沒有減傷
		return 0;
	}

}
