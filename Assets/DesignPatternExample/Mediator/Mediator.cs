using UnityEngine;
using System.Collections;

namespace DesignPattern_Mediator
{
	// 用來管理Colleague物件的介面
	public abstract class Mediator
	{
		public abstract void SendMessage(Colleague theColleague,string Message);
	}

	// Mediator所控管的Colleague
	public abstract class Colleague
	{
		protected Mediator m_Mediator = null;
		public Colleague( Mediator theMediator)
		{
			m_Mediator = theMediator;
		}

		// Mediator通知請求
		public abstract void Request(string Message);

	}

	// 實作Colleague的類別1
	public class ConcreateColleague1 : Colleague
	{
		public ConcreateColleague1( Mediator theMediator) : base(theMediator)
		{}

		// 執行動作
		public void Action()
		{
			// 執行後需要通知其它Colleageu
			m_Mediator.SendMessage(this,"Colleage1發出通知");
		}

		// Mediator通知請求
		public override void Request(string Message)
		{
			Debug.Log("ConcreateColleague1.Request:"+Message);
		}
	}	

	// 實作Colleague的類別2
	public class ConcreateColleague2 : Colleague
	{
		public ConcreateColleague2( Mediator theMediator) : base(theMediator)
		{}
		
		// 執行動作
		public void Action()
		{
			// 執行後需要通知其它Colleageu
			m_Mediator.SendMessage(this,"Colleage2發出通知");
		}

		// Mediator通知請求
		public override void Request(string Message)
		{
			Debug.Log("ConcreateColleague2.Request:"+Message);
		}
	}	

	// 實作Mediator界面，並集合管理Colleague物件
	public class ConcreteMediator : Mediator
	{
		ConcreateColleague1 m_Colleague1 = null;
		ConcreateColleague2 m_Colleague2 = null;

		public void SetColleageu1( ConcreateColleague1 theColleague )
		{
			m_Colleague1 = theColleague;
		}

		public void SetColleageu2( ConcreateColleague2 theColleague )
		{
			m_Colleague2 = theColleague;
		}

		// 收到由Colleague通知請求
		public override void SendMessage(Colleague theColleague,string Message)
		{
			// 收到Colleague1通知Colleague2
			if( m_Colleague1 == theColleague)
				m_Colleague2.Request( Message);

			// 收到Colleague2通知Colleague1
			if( m_Colleague2 == theColleague)
				m_Colleague1.Request( Message);
		}
	}


}