using UnityEngine;
using System.Collections.Generic;

namespace DesignPattern_Memento
{
	// 存放Originator物件的內部狀態
	public class Memento
	{
		string m_State; 
		public string GetState()
		{
			return m_State;
		}

		public void SetState(string State)
		{
			m_State = State;
		}
	}

	// 需要儲存內容資訊
	public class Originator
	{
		string m_State; // 狀態,需要被保存

		public void SetInfo(string State)
		{
			m_State = State;
		}

		public void ShowInfo()
		{
			Debug.Log("Originator State:"+m_State);
		}

		// 產生要儲存的記錄
		public Memento CreateMemento()
		{
			Memento newMemento = new Memento();
			newMemento.SetState( m_State );
			return newMemento;
		}

		// 設定要回復的記錄
		public void SetMemento( Memento m)
		{
			m_State = m.GetState();
		}
	}

	// 保管所有的Memento
	public class Caretaker
	{
		Dictionary<string, Memento> m_Memntos = new Dictionary<string, Memento>();

		// 增加
		public void AddMemento(string Version , Memento theMemento)
		{
			if(m_Memntos.ContainsKey(Version)==false)
				m_Memntos.Add(Version, theMemento);
			else
				m_Memntos[Version]=theMemento;
		}

		// 取回
		public Memento GetMemento(string Version)
		{
			if(m_Memntos.ContainsKey(Version)==false)
				return null;
			return m_Memntos[Version];
		}

	}


}