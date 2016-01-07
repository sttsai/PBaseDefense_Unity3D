using UnityEngine;
using System.Collections;
using DesignPattern_Observer;

public class ObserverTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();
	}
	
	// Update is called once per frame
	void UnitTest () 
	{
		// 主題
		ConcreteSubject theSubject = new ConcreteSubject();

		// 加入觀察者
		ConcreteObserver1 theObserver1 = new ConcreteObserver1(theSubject);
		theSubject.Attach( theObserver1 );
		theSubject.Attach( new ConcreteObserver2(theSubject) );

		// 設定Subject
		theSubject.SetState("Subject狀態1");

		// 顯示狀態
		theObserver1.ShowState();	
	}
}
