using UnityEngine;
using System.Collections;
using DesignPattern_Singleton;

public class SingletonTest : MonoBehaviour {

	// Use this for initialization
	void Start () {	
		UnitTest();
		UnitTest_ClassWithCounter();
	}

	// 單例模式測試方法
	void UnitTest ()
	{		
		Singleton.Instance.Name = "Hello";
		Singleton.Instance.Name = "World";
		Debug.Log (Singleton.Instance.Name);

		//Singleton TempSingleton = new Singleton();// 錯誤  error CS0122: `DesignPattern_Singleton.Singleton.Singleton()' is inaccessible due to its protection level

	}

	// 有計數功能類別的測試方法
	void UnitTest_ClassWithCounter ()
	{
		// 有計數功能的類別
		ClassWithCounter pObj1 = new ClassWithCounter();
		pObj1.Operator();

		ClassWithCounter pObj2 = new ClassWithCounter();
		pObj2.Operator();

		pObj1.Operator();
	}
}
