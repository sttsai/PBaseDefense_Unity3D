using UnityEngine;
using System.Collections;
using DesignPattern_Adapter;

public class AdapterTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
	}
	
	// 
	void UnitTest () 
	{
		Target theTarget = new Adapter();
		theTarget.Request();
	}
}
