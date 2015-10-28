using UnityEngine;
using System.Collections;

// 302
namespace BuildToolWithoutPattern
{
	// DirectX引擎 
	public class DirectX
	{
		public void DXRender(string ObjName)
		{
			Debug.Log ("DXRender:"+ObjName);
		}
	}

	// OpenGL引擎 
	public class OpenGL
	{
		public void GLRender(string ObjName)
		{
			Debug.Log ("OpenGL:"+ObjName);
		}
	}


	// 圓球
	public abstract class ISphere
	{
		public abstract void Draw();
	}

	// 圓球使用Direct繪出
	public class SphereDX : ISphere
	{
		DirectX m_DirectX;

		public override void Draw()
		{
			m_DirectX.DXRender("Sphere");
		}
	}

	// 圓球使用Direct繪出
	public class SphereGL : ISphere
	{
		OpenGL m_OpenGL;
		
		public override void Draw()
		{
			m_OpenGL.GLRender("Sphere");
		}
	}

}
