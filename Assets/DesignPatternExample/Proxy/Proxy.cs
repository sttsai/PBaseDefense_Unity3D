using UnityEngine;
using System.Collections;

namespace DesignPattern_Proxy
{
	// 制訂RealSubject和Proxy所共用遵偱的介面
	public abstract class Subject
	{
		public abstract void Request();
	}

	// 定義Proxy所代表的真正物件
	public class RealSubject : Subject
	{
		public RealSubject(){}

		public override void Request()
		{
			Debug.Log("RealSubject.Request");
		}
	}

	// 持有指向RealSubject物件的reference以便存取真正的物件
	public class Proxy : Subject
	{
		RealSubject m_RealSubject = new RealSubject();

		// 權限控制
		public bool ConnectRemote{get; set;}

		public Proxy()
		{
			ConnectRemote = false;
		}

		public override void Request()
		{
			// 依目前狀態決定是否存取RealSubject
			if( ConnectRemote )
				m_RealSubject.Request();
			else
				Debug.Log ("Proxy.Request");
		}
	}
}
