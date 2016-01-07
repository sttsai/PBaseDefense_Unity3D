using UnityEngine;
using System.Collections;
using DesignPattern_Command;

public class CommandTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
	}
	
	// 
	void UnitTest () 
	{
		Invoker theInvoker = new Invoker();

		Command  theCommand = null;
		// 獎命令與執行結合
		theCommand = new ConcreteCommand1( new Receiver1(),"你好");
		theInvoker.AddCommand( theCommand );
		theCommand = new ConcreteCommand2( new Receiver2(),999);
		theInvoker.AddCommand( theCommand );

		// 執行
		theInvoker.ExecuteCommand();

	}
}
