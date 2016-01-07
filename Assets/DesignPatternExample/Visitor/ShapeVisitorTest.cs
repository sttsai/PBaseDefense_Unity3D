using UnityEngine;
using System.Collections;
using ShapeVisitor;

public class ShapeVisitorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnitTest();	
	}
	
	// 
	void UnitTest () 
	{
		DirectX theDirectX = new DirectX();
		
		// 加入形狀
		ShapeContainer theShapeContainer = new ShapeContainer();
		theShapeContainer.AddShape( new Cube(theDirectX) );
		theShapeContainer.AddShape( new Cylinder(theDirectX) );
		theShapeContainer.AddShape( new Sphere(theDirectX) );
		
		// 繪圖
		theShapeContainer.RunVisitor(new DrawVisitor());
		
		// 頂點數
		VectorCountVisitor theVectorCount = new VectorCountVisitor();
		theShapeContainer.RunVisitor( theVectorCount );
		Debug.Log("頂點數:"+ theVectorCount.Count );
		
		// 圓體積
		SphereVolumeVisitor theSphereVolume = new SphereVolumeVisitor();
		theShapeContainer.RunVisitor( theSphereVolume );
		Debug.Log("圓體積:"+ theSphereVolume.Volume );
	}
}
