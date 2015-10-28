using UnityEngine;
using System.Collections;

// 302
namespace BuildToolWithoutDecoratorPattern
{
	// 繪圖引擎
	public abstract class RenderEngine
	{
		public abstract void Render(string ObjName);
	}


	// DirectX引擎 
	public class DirectX : RenderEngine
	{
		public override void Render(string ObjName)
		{
			DXRender(ObjName);
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

		public void GLRender(string ObjName)
		{
			Debug.Log ("OpenGL:"+ObjName);
		}
	}


	// 形狀
	public abstract class IShape
	{
		protected RenderEngine m_RenderEngine = null;

		public void SetRenderEngine( RenderEngine theRenderEngine )
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

}
