using UnityEngine;
using System.Collections;

// Soldier數值
public class SoldierAttr : ICharacterAttr
{
	protected int 	m_SoldierLv; // Soldier等級
	protected int	m_AddMaxHP; // 因等級新增的HP值

	public SoldierAttr()
	{}

	// 設定角色數值
	public void SetSoldierAttr(BaseAttr BaseAttr)
	{
		// 共用元件
		base.SetBaseAttr( BaseAttr );

		// 外部參數
		m_SoldierLv = 1;
		m_AddMaxHP = 0;
	}
	
	// 設定等級
	public void SetSoldierLv(int Lv)
	{
		m_SoldierLv = Lv;
	}

	// 取得等級
	public int GetSoldierLv()
	{
		return m_SoldierLv ;
	}

	// 最大HP
	public override int GetMaxHP()
	{
		return base.GetMaxHP() + m_AddMaxHP;
	}

	// 設定新增的最大生命力
	public void AddMaxHP(int AddMaxHP)
	{
		m_AddMaxHP = AddMaxHP;
	}



}
