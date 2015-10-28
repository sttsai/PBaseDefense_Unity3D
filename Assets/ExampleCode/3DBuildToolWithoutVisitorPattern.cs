using UnityEngine;
using System.Collections.Generic;

// 603
namespace BuildToolWithoutVisitorPattern
{
	// 繪圖引擎
	public abstract class RenderEngine
	{
		public abstract void Render(string ObjName);
		public abstract void Text(string Text);
	}
	
	// DirectX引擎 
	public class DirectX : RenderEngine
	{
		public override void Render(string ObjName)
		{
			DXRender(ObjName);
		}
		public override void Text(string Text)
		{
			DXRender(Text);			
		}

		public void DXRender(string ObjName)
		{
			Debug.Log ("DXRender:"+ObjName);
		}

	}

	// OpenGL引擎 
	public class OpenGL : RenderEngine
	{
		public override void Render(string ObjName)
		{
			GLRender(ObjName);
		}
		public override void Text(string Text)
		{
			GLRender(Text);			
		}

		public void GLRender(string ObjName)
		{
			Debug.Log ("OpenGL:"+ObjName);
		}
	}


	// 形狀
	public abstract class IShape
	{
		protected RenderEngine m_RenderEngine = null; 	// 使用的繪圖引擎
		protected Vector3 m_Position = Vector3.zero;	// 顯示位置
		protected Vector3 m_Scale = Vector3.zero;		// 大小(縮放)

		public void SetRenderEngine( RenderEngine theRenderEngine )
		{
			m_RenderEngine = theRenderEngine;
		}

		public Vector3 GetPosition()
		{
			return m_Position;
		}

		public Vector3 GetScale()
		{
			return m_Scale;
		}

		public abstract void 	Draw();		 // 繪出
		public abstract float 	GetVolume(); // 取得體積
		public abstract int		GetVectorCount(); // 取得頂點數
	}

	// 圓球
	public class Sphere : IShape
	{
		public Sphere(RenderEngine theRenderEngine)
		{
			base.SetRenderEngine( theRenderEngine );
		}

		public override void Draw()
		{
			m_RenderEngine.Render("Sphere");
		}

		public override float GetVolume()
		{
			return 0;
		}

		public override int	GetVectorCount()
		{
			return 0;
		}
	}

	// 方塊
	public class Cube : IShape
	{	
		public Cube(RenderEngine theRenderEngine)
		{
			base.SetRenderEngine( theRenderEngine );
		}

		public override void Draw()
		{
			m_RenderEngine.Render("Cube");
		}

		public override float GetVolume()
		{
			return 0;
		}

		public override int	GetVectorCount()
		{
			return 0;
		}
	}

	// 圖柱體
	public class Cylinder : IShape
	{	
		public Cylinder(RenderEngine theRenderEngine)
		{
			base.SetRenderEngine( theRenderEngine );
		}

		public override void Draw()
		{
			m_RenderEngine.Render("Cylinder");
		}

		public override float GetVolume()
		{
			return 0;
		}

		public override int	GetVectorCount()
		{
			return 0;
		}
	}

	// 形狀容器
	public class ShapeContainer
	{
		List<IShape> m_Shapes = new List<IShape>();

		public ShapeContainer(){}

		// 新增
		public void AddShape(IShape theShape)
		{
			m_Shapes.Add ( theShape );
		}

		// 繪出
		public void DrawAllShape()
		{
			foreach(IShape theShape in m_Shapes)
				theShape.Draw();
		}

		// 取得所有頂點數
		public int GetAllVectorCount()
		{
			int Count = 0;
			foreach(IShape theShape in m_Shapes)
				Count += theShape.GetVectorCount();
			return Count;
		}
	}


	// 測試
	public class TestClass
	{
		public void CreateShape()
		{
			DirectX theDirectX = new DirectX();

			// 加入形狀
			ShapeContainer theShapeContainer = new ShapeContainer();
			theShapeContainer.AddShape( new Cube(theDirectX) );
			theShapeContainer.AddShape( new Cylinder(theDirectX) );
			theShapeContainer.AddShape( new Sphere(theDirectX) );


		}

	}


}
