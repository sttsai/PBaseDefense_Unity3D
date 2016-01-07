using UnityEngine;
using System.Collections.Generic;

namespace DesignPattern_Composite
{
	// 複合體內含物件之介面
	public abstract class IComponent
	{
		protected string m_Value;
		public abstract void Operation();	// 一般操作
		// 加入節點
		public virtual void Add( IComponent theComponent)
		{
			Debug.LogWarning("子類別沒實作");
		}			
		// 移除節點
		public virtual void Remove( IComponent theComponent)
		{
			Debug.LogWarning("子類別沒實作");
		}		
		// 取得子節點
		public virtual IComponent GetChild(int Index)
		{
			Debug.LogWarning("子類別沒實作");
			return null;
		}	
	}

	// 代表複合結構之終端物件
	public class Leaf : IComponent
	{
		public Leaf(string Value)
		{
			m_Value = Value;
		}
		public override void Operation()
		{
			Debug.Log("Leaf["+ m_Value +"]執行Operation()");
		}
	}

	// 代表複合結構的節點之行為
	public class Composite : IComponent
	{
		List<IComponent> m_Childs = new List<IComponent>();

		public Composite(string Value)
		{
			m_Value = Value;
		}

		// 一般操作
		public override void Operation()
		{
			Debug.Log("Composite["+m_Value+"]");
			foreach(IComponent theComponent in m_Childs)
				theComponent.Operation();
		}

		// 加入節點
		public override void Add( IComponent theComponent)
		{
			m_Childs.Add ( theComponent );
		}		

		// 移除節點
		public override void Remove( IComponent theComponent)
		{
			m_Childs.Remove( theComponent );
		}		

		// 取得子節點
		public override IComponent GetChild(int Index)
		{
			return m_Childs[Index];
		}
	}

}
