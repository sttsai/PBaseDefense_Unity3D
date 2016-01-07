using UnityEngine;
using System.Collections.Generic;

// 
namespace ShapeVisitor
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

	// 訪問者界面
	public abstract class IShapeVisitor
	{
		// Sphere類別呼叫用
		public virtual void VisitSphere(Sphere theSphere)
		{}
		// Cube類別呼叫用
		public virtual void VisitCube(Cube theCube)
		{}
		// Cylinder類別呼叫用
		public virtual void VisitCylinder(Cylinder theCylinder)
		{}
	}

	// 繪圖
	public class DrawVisitor : IShapeVisitor
	{
		// Sphere類別呼叫用
		public override void VisitSphere(Sphere theSphere)
		{
			theSphere.Draw();
		}
		// Cube類別呼叫用
		public override void VisitCube(Cube theCube)
		{
			theCube.Draw();
		}
		// Cylinder類別呼叫用
		public override void VisitCylinder(Cylinder theCylinder)
		{
			theCylinder.Draw();
		}
	}

	// 計數
	public class VectorCountVisitor : IShapeVisitor
	{
		public int Count = 0;
		// Sphere類別呼叫用
		public override void VisitSphere(Sphere theSphere)
		{
			Count += theSphere.GetVectorCount();
		}
		// Cube類別呼叫用
		public override void VisitCube(Cube theCube)
		{
			Count += theCube.GetVectorCount();
		}
		// Cylinder類別呼叫用
		public override void VisitCylinder(Cylinder theCylinder)
		{
			Count += theCylinder.GetVectorCount();
		}
	}

	// 只計算圓型體積
	public class SphereVolumeVisitor : IShapeVisitor
	{
		public float Volume;
		// Sphere類別呼叫用
		public override void VisitSphere(Sphere theSphere)
		{
			Volume += theSphere.GetVolume();
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
		public abstract void 	RunVisitor(IShapeVisitor theVisitor);
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

		public override void RunVisitor(IShapeVisitor theVisitor)
		{
			theVisitor.VisitSphere(this);
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

		public override void RunVisitor(IShapeVisitor theVisitor)
		{
			theVisitor.VisitCube(this);
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

		public override void RunVisitor(IShapeVisitor theVisitor)
		{
			theVisitor.VisitCylinder(this);
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

		// 共用的訪問者界面
		public void RunVisitor(IShapeVisitor theVisitor)
		{
			foreach(IShape theShape in m_Shapes)
				theShape.RunVisitor( theVisitor );
		}
	}
}
