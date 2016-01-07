using UnityEngine;
using System.Collections;

namespace DesignPattern_Bridge
{
	// 定義作類別之共用介面
	public abstract class Implementor
	{
		public abstract void OperationImp();
	}

	// 實作Implementor所訂之介面
	public class ConcreteImplementor1 : Implementor
	{
		public ConcreteImplementor1(){}

		public override void OperationImp()
		{
			Debug.Log("執行Concrete1Implementor.OperationImp");
		}
	}

	// 實作Implementor所訂之介面
	public class ConcreteImplementor2 : Implementor
	{
		public ConcreteImplementor2(){}
		
		public override void OperationImp()
		{
			Debug.Log("執行Concrete2Implementor.OperationImp");
		}
	}
	
	// 抽象體的介面,維護指向Implementor的物件 reference
	public abstract class Abstraction
	{
		private Implementor m_Imp = null;

		public void SetImplementor( Implementor Imp )
		{
			m_Imp = Imp;
		}

		public virtual void Operation()
		{
			if( m_Imp!=null)
				m_Imp.OperationImp();
		}
	}

	// 擴充Abstraction所訂之介面
	public class RefinedAbstraction1 : Abstraction
	{
		public RefinedAbstraction1(){}

		public override void Operation()
		{
			Debug.Log("物件RefinedAbstraction1");
			base.Operation();
		}
	}

	// 擴充Abstraction所訂之介面
	public class RefinedAbstraction2 : Abstraction
	{
		public RefinedAbstraction2(){}

		public override void Operation()
		{
			Debug.Log("物件RefinedAbstraction2");
			base.Operation();
		}
	}

}
