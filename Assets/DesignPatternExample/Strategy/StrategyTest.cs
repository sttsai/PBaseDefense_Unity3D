using UnityEngine;
using System.Collections;
using DesignPattern_Strategy;

public class StrategyTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
	}
	
	// Update is called once per frame
	void UnitTest () 
	{
		Context theContext = new Context();

		// 設定演算法
		theContext.SetStrategy( new ConcreteStrategyA());
		theContext.ContextInterface();

		theContext.SetStrategy( new ConcreteStrategyB());
		theContext.ContextInterface();

		theContext.SetStrategy( new ConcreteStrategyC());
		theContext.ContextInterface();
	}
}
