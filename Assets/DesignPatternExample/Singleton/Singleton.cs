using UnityEngine;
using System.Collections;

namespace DesignPattern_Singleton
{
	// 單例模式
	public class Singleton
	{
		public string Name {get; set;}

		private static Singleton _instance;
		public static Singleton Instance
		{
			get
			{
				if (_instance == null)
				{
					Debug.Log("產生Singleton");
					_instance = new Singleton();				
				}
				return _instance;
			}
		}

		private Singleton(){}
	}
}
