using UnityEngine;
using System.Collections.Generic;

namespace DesignPattern_Builder
{
	// 欲產生的複雜物件 
	public class Product
	{
		private List<string> m_Part = new List<string>();
		public Product(){}
		public void AddPart(string Part)
		{
			m_Part.Add(Part);
		}
		public void ShowProduct()
		{
			Debug.Log("ShowProduct Functions:");
			foreach(string Part in m_Part)
				Debug.Log(Part);
		}
	}

	// 介面用來生成Product的各零件
	public abstract class Builder
	{
		public abstract void BuildPart1(Product theProduct);
		public abstract void BuildPart2(Product theProduct);
	}

	// Builder介面的具體實作A
	public class ConcreteBuilderA : Builder
	{
		public override void BuildPart1(Product theProduct)
		{
			theProduct.AddPart( "ConcreteBuilderA_Part1");
		}
		public override void BuildPart2(Product theProduct)
		{
			theProduct.AddPart( "ConcreteBuilderA_Part2");
		}
	}

	// Builder介面的具體實作B
	public class ConcreteBuilderB : Builder
	{
		public override void BuildPart1(Product theProduct)
		{
			theProduct.AddPart( "ConcreteBuilderB_Part1");
		}
		public override void BuildPart2(Product theProduct)
		{
			theProduct.AddPart( "ConcreteBuilderB_Part2");
		}
	}

	// 利用Builder介面來建構物件
	public class Director
	{
		private Product m_Product;

		public Director(){}

		// 建立 
		public void Construct(Builder theBuilder)
		{
			// 利用Builder產生各部份加入Product中
			m_Product = new Product();
			theBuilder.BuildPart1( m_Product );
			theBuilder.BuildPart2( m_Product );
		}

		// 取得成品
		public Product GetResult()
		{
			return m_Product;
		}
	}
}

