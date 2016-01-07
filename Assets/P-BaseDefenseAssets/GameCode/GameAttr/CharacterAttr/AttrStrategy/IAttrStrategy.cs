using UnityEngine;
using System.Collections;

// 角色數值計算界面
public abstract class IAttrStrategy
{
	// 初始的數值
	public abstract void InitAttr( ICharacterAttr CharacterAttr );
	
	// 攻擊加乘
	public abstract int GetAtkPlusValue( ICharacterAttr CharacterAttr );
	
	// 取得減傷害值
	public abstract int GetDmgDescValue( ICharacterAttr CharacterAttr );
}
