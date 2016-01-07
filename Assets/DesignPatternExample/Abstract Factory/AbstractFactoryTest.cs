using UnityEngine;
using System.Collections;
using DesignPattern_AbstractFactory;

public class AbstractFactoryTest : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		UnitTest();		
	}

	// 測試抽象工廠
	void UnitTest()
	{
		AbstractFactory Factory= null;

		// 工廠1
		Factory = new ConcreateFactory1();
		// 產生兩個產品
		Factory.CreateProductA();
		Factory.CreateProductB();

		// 工廠2
		Factory = new ConcreateFactory2();
		// 產生兩個產品
		Factory.CreateProductA();
		Factory.CreateProductB();
	}

}
