using UnityEngine;
using System.Collections;
using DesignPattern_Decorator;
using DesignPattern_ShapeDecorator;

public class DecoratorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//UnitTest();	
		UnitTest_Shape();
	}
	
	// 
	void UnitTest () {

		// 物件
		ConcreteComponent theComponent = new ConcreteComponent();

		// 增加Decorator
		ConcreteDecoratorA theDecoratorA = new ConcreteDecoratorA( theComponent );
		theDecoratorA.Operator();

		ConcreteDecoratorB theDecoratorB = new ConcreteDecoratorB( theComponent );
		theDecoratorB.Operator();

		// 再增加一層
		ConcreteDecoratorB theDecoratorB2 = new ConcreteDecoratorB( theDecoratorA );
		theDecoratorB2.Operator();
	}

	// 
	void UnitTest_Shape() 
	{
		OpenGL theOpenGL = new OpenGL();

		// 圓型
		Sphere theSphere = new Sphere();
		theSphere.SetRenderEngine( theOpenGL );

		//在圖型加外框
		BorderDecorator theSphereWithBorder = new BorderDecorator( theSphere );
		theSphereWithBorder.SetRenderEngine( theOpenGL );
		theSphereWithBorder.Draw();

	}
}
