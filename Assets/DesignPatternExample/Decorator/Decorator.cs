using UnityEngine;
using System.Collections;

namespace DesignPattern_Decorator
{
	// 制訂可被Decorator動態增加權責的物件介面
	public abstract class Component
	{
		public abstract void Operator();
	}

	// 定義可被Decorator動態增加權責的物件
	public class ConcreteComponent : Component
	{
		public override void Operator()
		{
			Debug.Log("ConcreteComponent.Operator");
		}
	}

	// 持有指向Component的reference，須符合Component的介面
	public class Decorator : Component
	{
		Component m_Component;
		public Decorator(Component theComponent)
		{
			m_Component = theComponent;
		}

		public override void Operator()
		{
			m_Component.Operator();
		}
	}

	// 增加額外的權責/功能
	public class ConcreteDecoratorA : Decorator
	{
		Component m_Component;
		public ConcreteDecoratorA(Component theComponent) : base( theComponent)
		{
		}
		
		public override void Operator()
		{
			base.Operator();
			AddBehaivor();
		}

		private void AddBehaivor()
		{
			Debug.Log("ConcreteDecoratorA.AddBehaivor");
		}
	}

	// 增加額外的權責/功能
	public class ConcreteDecoratorB : Decorator
	{
		Component m_Component;
		public ConcreteDecoratorB(Component theComponent) : base( theComponent)
		{
		}
		
		public override void Operator()
		{
			AddBehaivor();
			base.Operator();
		}
		
		private void AddBehaivor()
		{
			Debug.Log("ConcreteDecoratorB.AddBehaivor");
		}
	}

	

}