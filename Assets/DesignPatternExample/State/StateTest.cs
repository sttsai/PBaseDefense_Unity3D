using UnityEngine;
using System.Collections;
using DesignPattern_State;

public class StateTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
	}
	
	// 
	void UnitTest () 
	{
		Context theContext = new Context();
		theContext.SetState( new ConcreteStateA( theContext ));
		theContext.Request( 5 );
		theContext.Request( 15 );
		theContext.Request( 25 );
		theContext.Request( 35 );

	}
}
