using UnityEngine;
using System.Collections.Generic;

namespace DesignPattern_Observer
{
	// 觀察者介面
	public abstract class Observer
	{
		public abstract void Update();
	}

	// 主題介面
	public abstract class Subject
	{
		List<Observer> m_Observers = new List<Observer>();

		// 加入觀察者
		public void Attach(Observer theObserver)
		{
			m_Observers.Add( theObserver );
		}

		// 移除觀察者
		public void Detach(Observer theObserver)
		{
			m_Observers.Remove( theObserver );
		}

		// 通知所有觀察者
		public void Notify()
		{
			foreach( Observer theObserver  in m_Observers)
				theObserver.Update();
		}
	}

	// 主題實作 
	public class ConcreteSubject : Subject
	{
		string m_SubjectState;
		public void SetState(string State)
		{
			m_SubjectState = State;
			Notify();
		}

		public string GetState()
		{
			return m_SubjectState;
		}
	}

	// 實作的Observer1
	public class ConcreteObserver1 : Observer
	{
		string m_ObjectState;

		ConcreteSubject m_Subject = null;

		public ConcreteObserver1( ConcreteSubject theSubject)
		{
			m_Subject = theSubject;
		}

		// 通知Subject更新
		public override void Update ()
		{
			Debug.Log ("ConcreteObserver1.Update");
			// 取得Subject狀態
			m_ObjectState = m_Subject.GetState();
		}

		public void ShowState()
		{
			Debug.Log ("ConcreteObserver1:Subject目前的主題:"+m_ObjectState);
		}
	}

	// 實作的Observer2
	public class ConcreteObserver2 : Observer
	{			
		ConcreteSubject m_Subject = null;
	
		public ConcreteObserver2( ConcreteSubject theSubject)
		{
			m_Subject = theSubject;
		}
		
		// 通知Subject更新
		public override void Update ()
		{
			Debug.Log ("ConcreteObserver2.Update");
			// 取得Subject狀態
			Debug.Log ("ConcreteObserver2:Subject目前的主題:"+m_Subject.GetState());
		}		
	}
	
}
