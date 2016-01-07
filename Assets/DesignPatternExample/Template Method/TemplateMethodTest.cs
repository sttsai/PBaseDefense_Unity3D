using UnityEngine;
using System.Collections;
using DesignPattern_TemplateMethod;

public class TemplateMethodTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
	}
	
	// Update is called once per frame
	void UnitTest () 
	{
		AbstractClass theClass = new ConcreteClassA();
		theClass.TemplateMethod();

		theClass = new ConcreteClassB();
		theClass.TemplateMethod();
	
	}
}
