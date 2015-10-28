using UnityEngine;
using System.Collections;

// 302
namespace BuildToolWithPattern
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
	}

	// 圓球
	public class Sphere : IShape
	{
		public override void Draw()
		{
			m_RenderEngine.Render("Sphere");
		}
	}

	// 方塊
	public class Cube : IShape
	{		
		public override void Draw()
		{
			m_RenderEngine.Render("Cube");
		}
	}

	// 圖柱體
	public class Cylinder : IShape
	{		
		public override void Draw()
		{
			m_RenderEngine.Render("Cylinder");
		}
	}

}
