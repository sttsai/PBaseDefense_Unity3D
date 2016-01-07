using UnityEngine;
using System.Collections;
using DesignPattern_Flyweight;

public class FlyweightTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
	}

	void UnitTest () {

		// 元件工廠
		FlyweightFactor theFactory = new FlyweightFactor();

		// 產生共用元件
		theFactory.GetFlyweight("1","共用元件1");
		theFactory.GetFlyweight("2","共用元件1");
		theFactory.GetFlyweight("3","共用元件1");

		// 取得一個共用元件
		Flyweight theFlyweight = theFactory.GetFlyweight("1","");
		theFlyweight.Operator();

		// 產生不共用的元件
		UnsharedCoincreteFlyweight theUnshared1 = theFactory.GetUnsharedFlyweight("不共用的資訊1");
		theUnshared1.Operator();

		// 設定共用元件
		theUnshared1.SetFlyweight( theFlyweight );

		// 產生不共用的元件2,並指定使用共用元件１
		UnsharedCoincreteFlyweight theUnshared2 = theFactory.GetUnsharedFlyweight("1","","不共用的資訊2");

		// 同時顯示
		theUnshared1.Operator();
		theUnshared2.Operator();

	}
}
