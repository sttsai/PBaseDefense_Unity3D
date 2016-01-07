using UnityEngine;
using System.Collections;

namespace DesignPattern_Strategy
{
	// 擁有Strategy物件的客戶端
	public class Context
	{
		Strategy m_Strategy = null;

		// 設定演算法
		public void SetStrategy( Strategy theStrategy  )
		{
			m_Strategy = theStrategy;
		}

		// 執行目前的演算法
		public void ContextInterface()
		{
			m_Strategy.AlgorithmInterface();
		}
	}

	// 演算法的共用介面, Context透過此介面呼叫 ConcreteStrategy所實作的演算法
	public abstract class Strategy
	{
		public abstract void AlgorithmInterface();
	}

	// 演算法A
	public class ConcreteStrategyA : Strategy
	{
		public override void AlgorithmInterface()
		{
			Debug.Log ("ConcreteStrategyA.AlgorithmInterface");
		}
	}

	// 演算法B
	public class ConcreteStrategyB : Strategy
	{
		public override void AlgorithmInterface()
		{
			Debug.Log ("ConcreteStrategyB.AlgorithmInterface");
		}
	}

	// 演算法C
	public class ConcreteStrategyC : Strategy
	{
		public override void AlgorithmInterface()
		{
			Debug.Log ("ConcreteStrategyC.AlgorithmInterface");
		}
	}




}
