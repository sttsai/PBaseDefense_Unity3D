using UnityEngine;
using System.Collections;

namespace DesignPattern_Prototype
{

	public interface Prototype 
	{
		object Clone();
	}

	public class ConcretePrototype : Prototype
	{
		public string Name { get; set; }

		public ConcretePrototype(){}

		public object Clone()
		{
			ConcretePrototype pNewObj = new ConcretePrototype();
			pNewObj.Name = this.Name;
			return pNewObj;
		}

	}
}