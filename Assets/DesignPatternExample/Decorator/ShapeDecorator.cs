using UnityEngine;
using System.Collections;

namespace DesignPattern_ShapeDecorator
{
	// 繪圖引擎
	public abstract class RenderEngine
	{
		public abstract void Render(string ObjName);
	}
		
	// OpenGL引擎 
	public class OpenGL : RenderEngine
	{
		public override void Render(string ObjName)
		{
			GLRender(ObjName);
		}
		
		public void GLRender(string ObjName)
		{
			Debug.Log ("OpenGL:"+ObjName);
		}
	}
	
	
	// 形狀
	public abstract class IShape
	{
		protected RenderEngine m_RenderEngine = null;
		
		public virtual void SetRenderEngine( RenderEngine theRenderEngine )
		{
			m_RenderEngine = theRenderEngine;
		}
		
		public abstract void Draw();
		public abstract string GetPolygon();
	}
	
	// 圓球
	public class Sphere : IShape
	{
		public override void Draw()
		{
			m_RenderEngine.Render("Sphere");
		}
		public override string GetPolygon()
		{
			return "Sphere多邊型";
		}
	}

	// 型狀裝飾者界面
	public abstract class IShapeDecorator : IShape
	{
		IShape m_Component;
		public IShapeDecorator(IShape theComponent)
		{
			m_Component = theComponent;
		}
		
		public override void Draw()
		{
			m_Component.Draw();
		}
		public override string GetPolygon()
		{
			return m_Component.GetPolygon();
		}
	}


	// 額外功能
	public abstract class IAdditional
	{
		protected RenderEngine m_RenderEngine = null;
		
		public void SetRenderEngine( RenderEngine theRenderEngine )
		{
			m_RenderEngine = theRenderEngine;
		}
		
		public abstract void DrawOnShape(IShape theShpe);
		
	}
	
	// 外框
	public class Border : IAdditional
	{
		public override void DrawOnShape(IShape theShpe)
		{
			m_RenderEngine.Render("Draw Border On "+ theShpe.GetPolygon());
		}
		
	}

	// 外框裝飾者
	public class BorderDecorator : IShapeDecorator
	{
		// 外框功能
		Border m_Border = new Border();

		public BorderDecorator(IShape theComponent):base(theComponent)
		{}

		public virtual void SetRenderEngine( RenderEngine theRenderEngine )
		{
			base.SetRenderEngine(theRenderEngine);
			m_Border.SetRenderEngine(theRenderEngine);
		}

		public override void Draw()
		{
			// 被裝飾者的功能
			base.Draw();
			// 外框功能
			m_Border.DrawOnShape( this);
		}	
	}
	



	

}