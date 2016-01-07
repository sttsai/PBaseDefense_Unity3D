using UnityEngine;
using System.Collections.Generic;

namespace DesignPattern_Command
{
	// 執行命令的介面
	public abstract class Command
	{
		public abstract void Execute();
	}

	// 將命令和Receiver1物件繫結起來
	public class ConcreteCommand1 : Command
	{
		Receiver1 m_Receiver = null;
		string	  m_Command = "";

		public ConcreteCommand1( Receiver1 Receiver, string Command )
		{
			m_Receiver = Receiver;
			m_Command = Command;
		}

		public override void Execute()
		{
			m_Receiver.Action(m_Command);
		}
	}

	// 將命令和Receiver2物件繫結起來
	public class ConcreteCommand2 : Command
	{
		Receiver2 m_Receiver = null;
		int		  m_Param = 0;
		
		public ConcreteCommand2( Receiver2 Receiver,int Param )
		{
			m_Receiver = Receiver;
			m_Param = Param;
		}
		
		public override void Execute()
		{
			m_Receiver.Action( m_Param );
		}		
	}

	// 負責執行命令1
	public class Receiver1
	{
		public Receiver1(){}
		public void Action(string Command)
		{
			Debug.Log ("Receiver1.Action:Command["+Command+"]");
		}
	}

	// 負責執行命令2
	public class Receiver2
	{
		public Receiver2(){}
		public void Action(int Param)
		{
			Debug.Log ("Receiver2.Action:Param["+Param.ToString()+"]");
		}
	}


	// 命令管理者
	public class Invoker
	{
		List<Command> m_Commands = new List<Command>();

		// 加入命令
		public void AddCommand( Command theCommand )
		{
			m_Commands.Add( theCommand );
		}

		// 執行命令
		public void ExecuteCommand()
		{
			// 執行
			foreach(Command theCommand in m_Commands)
				theCommand.Execute();
			// 清空 
			m_Commands.Clear();
		}
	}




}
