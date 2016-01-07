using UnityEngine;
using System.Collections.Generic;

namespace DesignPattern_Visitor
{	
	// 固定的元素, 定義給Visitor存取的介面
	public abstract class Visitor
	{	
		// 可以寫一個通用的函式名稱但以用不同的參數來產生多樣化方法
		public abstract void VisitConcreteElement( ConcreteElementA theElement);
		public abstract void VisitConcreteElement( ConcreteElementB theElement);


		// 或可以針對Element的子元件做不同的執行動作
		public abstract void VisitConcreteElementA( ConcreteElementA theElement);
		public abstract void VisitConcreteElementB( ConcreteElementB theElement);


	}

	// 制訂以Visitor物件當參數的Accept()介面
	public abstract class Element
	{	
		public abstract void Accept( Visitor theVisitor);		
	}

	// 元素A 
	public class ConcreteElementA : Element
	{
		public override void Accept( Visitor theVisitor)
		{
			theVisitor.VisitConcreteElement( this );
			theVisitor.VisitConcreteElementA( this );
		}

		public void OperationA()
		{
			Debug.Log("ConcreteElementA.OperationA");
		}
	}
	
	// 元素B
	public class ConcreteElementB : Element
	{
		public override void Accept( Visitor theVisitor)
		{
			theVisitor.VisitConcreteElement( this );
			theVisitor.VisitConcreteElementB( this );
		}

		public void OperationB()
		{
			Debug.Log("ConcreteElementB.OperationB");
		}
	}
	
	// 實作功能操作Visitor1
	public class ConcreteVicitor1 : Visitor
	{
		// 可以寫一個通用的函式名稱但以用不同的參數來產生多樣化方法
		public override void VisitConcreteElement( ConcreteElementA theElement)
		{
			Debug.Log ("ConcreteVicitor1:VisitConcreteElement(A)");
		}
		public override void VisitConcreteElement( ConcreteElementB theElement)
		{
			Debug.Log ("ConcreteVicitor1:VisitConcreteElement(B)");
		}

		public override void VisitConcreteElementA( ConcreteElementA theElement)
		{
			Debug.Log ("ConcreteVicitor1.VisitConcreteElementA()");
			theElement.OperationA();
		}

		public override void VisitConcreteElementB( ConcreteElementB theElement)
		{
			Debug.Log ("ConcreteVicitor1.VisitConcreteElementB()");
			theElement.OperationB();
		}
	}

	// 實作功能操作Visitor2
	public class ConcreteVicitor2 : Visitor
	{
		// 可以寫一個通用的函式名稱但以用不同的參數來產生多樣化方法
		public override void VisitConcreteElement( ConcreteElementA theElement)
		{
			Debug.Log ("ConcreteVicitor2:VisitConcreteElement(A)");
		}
		public override void VisitConcreteElement( ConcreteElementB theElement)
		{
			Debug.Log ("ConcreteVicitor2.VisitConcreteElement(B)");
		}

		public override void VisitConcreteElementA( ConcreteElementA theElement)
		{
			Debug.Log ("ConcreteVicitor2.VisitConcreteElementA()");
			theElement.OperationA();
		}
		
		public override void VisitConcreteElementB( ConcreteElementB theElement)
		{
			Debug.Log ("ConcreteVicitor2.VisitConcreteElementB()");
			theElement.OperationB();
		}	
	}
		
	// 用來存儲所有的Element	
	public class ObjectStructure
	{
		List<Element> m_Context = new List<Element>();
	
		public  ObjectStructure()
		{
			m_Context.Add( new ConcreteElementA());
			m_Context.Add( new ConcreteElementB());
		}
		
		// 載入不同的Action(Visitor)來判斷
		public void RunVisitor(Visitor theVisitor)
		{
			foreach(Element theElement in m_Context )
				theElement.Accept( theVisitor);
		}
	}
	
}
