using UnityEngine;
using System.Collections;
using DesignPattern_Composite;

public class CompositeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//UnitTest();	
		UnitTest2();
	}
	
	// 
	void UnitTest () {

		// 根節點
		IComponent theRoot = new Composite("Root");
		// 加入兩個最終節點
		theRoot.Add ( new Leaf("Leaf1"));
		theRoot.Add ( new Leaf("Leaf2"));

		// 子節點1
		IComponent theChild1 = new Composite("Child1");
		// 加入兩個最終節點
		theChild1.Add ( new Leaf("Child1.Leaf1"));
		theChild1.Add ( new Leaf("Child1.Leaf2"));
		theRoot.Add (theChild1);

		// 子節點2
		// 加入3個最終節點
		IComponent theChild2 = new Composite("Child2");
		theChild2.Add ( new Leaf("Child2.Leaf1"));
		theChild2.Add ( new Leaf("Child2.Leaf2"));
		theChild2.Add ( new Leaf("Child2.Leaf3"));
		theRoot.Add (theChild2);

		// 顯示
		theRoot.Operation();	


	}

	void UnitTest2 () {
		
		// 根節點
		IComponent theRoot = new Composite("Root");

		// 產生一最終節點
		IComponent theLeaf1 = new Leaf("Leaf1");

		// 加入節點
		theLeaf1.Add ( new Leaf("Leaf2") );  // 錯誤

			
	}
}
