using UnityEngine;
using System.Collections;
using DesignPattern_Memento;

public class MementoTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
		UnitTest2();
	}
	
	// 
	void UnitTest () {
			
		Originator theOriginator = new Originator();

		// 設定資訊
		theOriginator.SetInfo( "Step1" );
		theOriginator.ShowInfo();

		// 儲存狀態
		Memento theMemnto = theOriginator.CreateMemento();

		// 設定新的資訊
		theOriginator.SetInfo( "Step2" );
		theOriginator.ShowInfo();

		// 復原
		theOriginator.SetMemento( theMemnto );
		theOriginator.ShowInfo();
	
	}

	// 
	void UnitTest2 () {
		
		Originator theOriginator = new Originator();
		Caretaker theCaretaker = new Caretaker();
		
		// 設定資訊
		theOriginator.SetInfo( "Version1" );
		theOriginator.ShowInfo();
		// 保存
		theCaretaker.AddMemento("1",theOriginator.CreateMemento());

		// 設定資訊
		theOriginator.SetInfo( "Version2" );
		theOriginator.ShowInfo();
		// 保存
		theCaretaker.AddMemento("2",theOriginator.CreateMemento());

		// 設定資訊
		theOriginator.SetInfo( "Version3" );
		theOriginator.ShowInfo();
		// 保存
		theCaretaker.AddMemento("3",theOriginator.CreateMemento());
		                        		
		// 退回到第2版,
		theOriginator.SetMemento( theCaretaker.GetMemento("2"));
		theOriginator.ShowInfo();

		// 退回到第1版,
		theOriginator.SetMemento( theCaretaker.GetMemento("1"));
		theOriginator.ShowInfo();


		
	}
}
