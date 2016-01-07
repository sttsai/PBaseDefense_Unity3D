using UnityEngine;
using System.Collections.Generic;
namespace DesignPattern_Flyweight
{
	// 可以被共用的Flyweight介面	
	public abstract class Flyweight
	{
		protected string m_Content; //顯示的內容
		public Flyweight(){}
		public Flyweight(string Content)
		{
			m_Content= Content;
		}
		public string GetContent()
		{
			return m_Content;
		}
		public abstract void Operator();

	}

	// 共用的元件
	public class ConcreteFlyweight : Flyweight
	{
		public ConcreteFlyweight(string Content):base( Content )
		{
		}

		public override void Operator()
		{
			Debug.Log("ConcreteFlyweight.Content["+m_Content+"]");
		}
	}

	// 不共用的元件(可以不必繼承)
	public class UnsharedCoincreteFlyweight  //: Flyweight
	{
		Flyweight m_Flyweight = null; // 共享的元件
		string m_UnsharedContent;	  // 不共享的元件

		public UnsharedCoincreteFlyweight(string Content)
		{
			m_UnsharedContent = Content;
		}

		// 設定共享的元件
		public void SetFlyweight(Flyweight theFlyweight)
		{
			m_Flyweight = theFlyweight;
		}
		
		public void Operator()
		{
			string Msg = string.Format("UnsharedCoincreteFlyweight.Content[{0}]",m_UnsharedContent);
			if( m_Flyweight != null)
				Msg += "包含了：" + m_Flyweight.GetContent();
			Debug.Log(Msg);
		}
	}

	// 負責產生Flyweight的工廠介面
	public class FlyweightFactor
	{
		Dictionary<string,Flyweight> m_Flyweights = new Dictionary<string,Flyweight>();

		// 取得共用的元件 
		public Flyweight GetFlyweight(string Key,string Content)
		{
			if( m_Flyweights.ContainsKey( Key) )
				return m_Flyweights[Key];

			// 產生並設定內容
			ConcreteFlyweight theFlyweight = new ConcreteFlyweight( Content );
			m_Flyweights[Key] = theFlyweight;
			Debug.Log ("New ConcreteFlyweigh Key["+Key+"] Content["+Content+"]");
			return theFlyweight;
		}

		// 取得元件(只取得不共用的Flyweight)
		public UnsharedCoincreteFlyweight GetUnsharedFlyweight(string Content)
		{
			return new UnsharedCoincreteFlyweight( Content);
		}

		// 取得元件(包含共用部份的Flyweight)
		public UnsharedCoincreteFlyweight GetUnsharedFlyweight(string Key,string SharedContent,string UnsharedContent)
		{
			// 先取得共用的部份
			Flyweight SharedFlyweight = GetFlyweight(Key, SharedContent);

			// 產出元件
			UnsharedCoincreteFlyweight  theFlyweight =  new UnsharedCoincreteFlyweight( UnsharedContent);
			theFlyweight.SetFlyweight( SharedFlyweight ); // 設定共享的部份
			return theFlyweight;
		}
	}


}