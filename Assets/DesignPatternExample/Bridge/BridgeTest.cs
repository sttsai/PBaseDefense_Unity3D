using UnityEngine;
using System.Collections;
using DesignPattern_Bridge;

public class BridgeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
		UnitTest_Window();
	}
	
	// 
	void UnitTest () {

		// 產生
		Abstraction theAbstraction = new RefinedAbstraction1();

		// 設定
		theAbstraction.SetImplementor( new ConcreteImplementor1());
		theAbstraction.Operation();

		// 設定
		theAbstraction.SetImplementor( new ConcreteImplementor2());
		theAbstraction.Operation();

		// 產生
		theAbstraction = new RefinedAbstraction2();
		
		// 設定
		theAbstraction.SetImplementor( new ConcreteImplementor1());
		theAbstraction.Operation();
		
		// 設定
		theAbstraction.SetImplementor( new ConcreteImplementor2());
		theAbstraction.Operation();

	
	}

	void UnitTest_Window () 
	{
		Window pWindow= null;

		// 產生在XWindow環境下的IconWindow
		pWindow = new IconWindow();
		pWindow.SetImplementor( new XWindowImp());
		pWindow.Show();

		// 產生在PMWindow環境下的IconWindow
		pWindow = new IconWindow();
		pWindow.SetImplementor( new PMWindowImp());
		pWindow.Show();

		// 產生在XWindow環境下的TransientWindow
		pWindow = new TransientWindow();
		pWindow.SetImplementor( new XWindowImp());
		pWindow.Show();
		
		// 產生在PMWindow環境下的TransientWindow
		pWindow = new TransientWindow();
		pWindow.SetImplementor( new PMWindowImp());
		pWindow.Show();


	}
}
