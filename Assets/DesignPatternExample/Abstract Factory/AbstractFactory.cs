using UnityEngine;
using System.Collections;

namespace DesignPattern_AbstractFactory
{
	// 可生成各抽象成品物件的操作
	public abstract class AbstractFactory
	{
		public abstract AbstractProductA CreateProductA();
		public abstract AbstractProductB CreateProductB();
	}

	// 實作出可建構具象成品物件的操作1
	public class ConcreateFactory1 : AbstractFactory
	{
		public ConcreateFactory1(){}

		public override AbstractProductA CreateProductA()
		{
			return new ProductA1();
		}
		public override AbstractProductB CreateProductB()
		{
			return new ProductB1();
		}	
	}

	// 實作出可建構具象成品物件的操作2
	public class ConcreateFactory2 : AbstractFactory
	{
		public ConcreateFactory2(){}
		
		public override AbstractProductA CreateProductA()
		{
			return new ProductA2();
		}
		public override AbstractProductB CreateProductB()
		{
			return new ProductB2();
		}	
	}

	// 成品物件類型A界面
	public abstract class AbstractProductA
	{
	}

	// 成品物件類型A1
	public class ProductA1 : AbstractProductA
	{
		public ProductA1()
		{
			Debug.Log("生成物件類型A1");
		}
	}

	// 成品物件類型A2
	public class ProductA2 : AbstractProductA
	{
		public ProductA2()
		{
			Debug.Log("生成物件類型A2");
		}
	}

	// 成品物件類型B界面
	public abstract class AbstractProductB
	{
	}

	// 成品物件類型B1
	public class ProductB1 : AbstractProductB
	{
		public ProductB1()
		{
			Debug.Log("生成物件類型B1");
		}
	}

	// 成品物件類型B2
	public class ProductB2 : AbstractProductB
	{
		public ProductB2()
		{
			Debug.Log("生成物件類型B2");
		}
	}
}

