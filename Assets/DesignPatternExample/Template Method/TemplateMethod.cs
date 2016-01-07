using UnityEngine;
using System.Collections;

namespace DesignPattern_TemplateMethod
{
	// 定義完整演算法各步驟及執行順序
	public abstract class AbstractClass
	{
		public void TemplateMethod()
		{
			PrimitiveOperation1();
			PrimitiveOperation2();
		}
		protected abstract void PrimitiveOperation1();
		protected abstract void PrimitiveOperation2();
	}

	// 實作演算法各步驟
	public class ConcreteClassA : AbstractClass
	{
		protected override void PrimitiveOperation1()
		{
			Debug.Log("ConcreteClassA.PrimitiveOperation1");
		}
		protected override void PrimitiveOperation2()
		{
			Debug.Log("ConcreteClassA.PrimitiveOperation2");
		}
	}
	
	// 實作演算法各步驟
	public class ConcreteClassB : AbstractClass
	{
		protected override void PrimitiveOperation1()
		{
			Debug.Log("ConcreteClassB.PrimitiveOperation1");
		}
		protected override void PrimitiveOperation2()
		{
			Debug.Log("ConcreteClassB.PrimitiveOperation2");
		}
	}
		
}
