using UnityEngine;
using System.Collections;

namespace DesignPattern_Adapter
{
	// 應用域領(Client)所需的介面
	public abstract class Target
	{
		public abstract void Request();		
	}

	// 不同於應用域領(Client)的實作,需要被轉換
	public class Adaptee
	{
		public Adaptee(){}

		public void SpecificRequest()
		{
			Debug.Log("呼叫Adaptee.SpecificRequest");
		}
	}

	// 將Adaptee轉換成Target介面
	public class Adapter : Target
	{
		private Adaptee m_Adaptee = new Adaptee();

		public Adapter(){}

		public override void Request()
		{
			m_Adaptee.SpecificRequest();
		}
	}
}
