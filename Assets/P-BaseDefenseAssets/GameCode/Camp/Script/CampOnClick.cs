using UnityEngine;
using System.Collections;

// 兵營點擊成功後通知顯示
public class CampOnClick : MonoBehaviour 
{
	public ICamp theCamp = null;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	public void OnClick()
	{
		// 顯示兵營資訊
		PBaseDefenseGame.Instance.ShowCampInfo( theCamp );
	}
}
