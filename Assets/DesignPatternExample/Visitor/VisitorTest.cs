using UnityEngine;
using System.Collections;
using DesignPattern_Visitor;

public class VisitorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
	}
	
	// 
	void UnitTest () 
	{
		ObjectStructure theStructure = new ObjectStructure();

		// 將Vicitor走訪ObjectStructure裡的各元表
		theStructure.RunVisitor(new ConcreteVicitor1());
		theStructure.RunVisitor(new ConcreteVicitor2());			
	}
}
