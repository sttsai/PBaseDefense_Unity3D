using UnityEngine;
using System.Collections;
using DesignPattern_ChainofResponsibility;

public class ChainofResponsibilityTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();
	}
	
	// 
	void UnitTest () {

		// 建立Cost驗証的連接方式
		ConcreteHandler3 theHandle3 = new ConcreteHandler3(null);
		ConcreteHandler2 theHandle2 = new ConcreteHandler2(theHandle3);
		ConcreteHandler1 theHandle1 = new ConcreteHandler1(theHandle2);

		// 確認
		theHandle1.HandleRequest(10);
		theHandle1.HandleRequest(15);
		theHandle1.HandleRequest(20);
		theHandle1.HandleRequest(30);
		theHandle1.HandleRequest(100);

	
	}
}
