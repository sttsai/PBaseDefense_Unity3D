using UnityEngine;
using System.Collections;
using DesignPattern_Prototype;

public class PrototypeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();
	}

	void UnitTest () {

		// 原始物件
		ConcretePrototype Obj =new ConcretePrototype();
		Obj.Name = "ConcreteObj1";

		// 複製物件
		ConcretePrototype CloneObj = Obj.Clone() as ConcretePrototype;

		// 顯示
		Debug.Log("原始物件:"+Obj.Name);
		Debug.Log("複製物件:"+CloneObj.Name);

	
	}
}
