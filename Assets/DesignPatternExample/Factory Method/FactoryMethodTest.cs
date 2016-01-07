using UnityEngine;
using System.Collections;
using DesignPattern_FactoryMethod;

public class FactoryMethodTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();
	}

	void UnitTest () {

		// 產品
		Product theProduct = null;

		// 工廠界面
		Creator theCreator = null;

		// 設定為負責ProduceA的工廠
		theCreator = new ConcreteCreatorProductA();
		theProduct = theCreator.FactoryMethod();

		// 設定為負責ProduceB的工廠
		theCreator = new ConcreteCreatorProductB();
		theProduct = theCreator.FactoryMethod();

		// 工廠界面
		Creator_MethodType theCreatorMethodType = new ConcreteCreator_MethodType();

		// 取得兩個產品
		theProduct = theCreatorMethodType.FactoryMethod(1);
		theProduct = theCreatorMethodType.FactoryMethod(2);

		// 使用Generic Method
		ConcreteCreator_GenericMethod theCreatorGM = new ConcreteCreator_GenericMethod();
		theProduct = theCreatorGM.FactoryMethod<ConcreteProductA>();
		theProduct = theCreatorGM.FactoryMethod<ConcreteProductB>();

		// 使用Generic Class
		// 負責ProduceA的工廠
		Creator_GenericClass<ConcreteProductA> Creator_ProductA = new Creator_GenericClass<ConcreteProductA>();
		theProduct = Creator_ProductA.FactoryMethod();

		// 負責ProduceA的工廠
		Creator_GenericClass<ConcreteProductB> Creator_ProductB = new Creator_GenericClass<ConcreteProductB>();
		theProduct = Creator_ProductB.FactoryMethod();
	}
}
