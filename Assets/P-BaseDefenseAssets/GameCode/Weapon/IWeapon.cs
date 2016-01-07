using UnityEngine;
using System.Collections;

public enum ENUM_Weapon
{
	Null 	= 0,
	Gun 	= 1,
	Rifle	= 2,	
	Rocket	= 3,	
	Max	,
}

// 武器介面
public abstract class IWeapon
{
	protected ENUM_Weapon m_emWeaponType = ENUM_Weapon.Null;

	// 數值
	protected int		   m_AtkPlusValue = 0;		  	// 額外增加的攻擊力
	//protected int 	   m_Atk = 0; 					// 攻擊力
	//protected float 	   m_Range= 0.0f;				// 攻擊距離
	protected WeaponAttr m_WeaponAttr = null;		  	// 武器的能力

	// 
	protected GameObject  m_GameObject = null;			// 顯示的Uniyt模型
	protected ICharacter  m_WeaponOwner = null;			// 武器的擁有者

	// 發射特效
	protected float			 m_EffectDisplayTime = 0;
	protected ParticleSystem m_Particles;                    
	protected LineRenderer   m_Line;                           
	protected AudioSource 	 m_Audio;                           
	protected Light 		 m_Light;                                 
	
	public IWeapon(){}
	
	public ENUM_Weapon GetWeaponType()
	{
		return  m_emWeaponType;
	}

	// 設定顯示的Unity模型
	public void SetGameObject( GameObject theGameObject )
	{
		m_GameObject = theGameObject ;

		// 設定特效元件
		SetupEffect();
	}

	// 取得顯示的Unity模型
	public GameObject GetGameObject()
	{
		return m_GameObject;
	}

	// 設定武器擁有者
	public void SetOwner( ICharacter Owner )
	{
		m_WeaponOwner = Owner;
	}

	// 設定攻擊能力
	public void SetWeaponAttr(WeaponAttr theWeaponAttr)
	{
        m_WeaponAttr = theWeaponAttr;
	}

	// 設定額外功擊力
	public void SetAtkPlusValue(int Value)
	{
		m_AtkPlusValue = Value;
	}

	// 取得攻擊力
	public int GetAtkValue()
	{
		return m_WeaponAttr.Atk + m_AtkPlusValue;
	}

	// 取得攻擊距離
	public float GetAtkRange()
	{
		return m_WeaponAttr.AtkRange;
	}

	// 釋放
	public void Release()
	{
		if( m_GameObject != null)
			GameObject.Destroy( m_GameObject);
	}

	// 更新
	public void Update()
	{
		if( m_EffectDisplayTime > 0 )
		{
			m_EffectDisplayTime -= Time.deltaTime;
			if( m_EffectDisplayTime<=0)
				DisableEffect();
		}
	}

	// 設定特效元件
	protected void SetupEffect()
	{
		GameObject EffectObj = UnityTool.FindChildGameObject( m_GameObject ,"Effect");

		// 取得特效使用的元件
		m_Line = EffectObj.GetComponent <LineRenderer> ();
		m_Particles = EffectObj.GetComponent<ParticleSystem> ();
		m_Audio = EffectObj.GetComponent<AudioSource> ();
		m_Light = EffectObj.GetComponent<Light> ();
	}

	protected void DisableEffect()
	{
		if(m_Line!=null)
			m_Line.enabled = false;
		if(m_Light!=null)
			m_Light.enabled = false;
	}

	// 顯示子彈特效
	protected void ShowBulletEffect(Vector3 TargetPosition, float LineWidth,float DisplayTime)
	{
		if( m_Line ==null)
			return ;
		m_Line.enabled = true;
		m_Line.SetWidth( LineWidth,LineWidth);
		m_Line.SetPosition(0,m_GameObject.transform.position);
		m_Line.SetPosition(1,TargetPosition);
		m_EffectDisplayTime = DisplayTime;
	}

	// 顯示槍口特效 
	protected void ShowShootEffect()
	{
		if( m_Particles != null)
		{
			m_Particles.Stop ();
			m_Particles.Play ();		
		}

		if( m_Light !=null)
			m_Line.enabled = true;
	}

	// 顯示音效
	protected void ShowSoundEffect(string ClipName)
	{
		if(m_Audio==null)
			return ;

		//  取得音效
		IAssetFactory Factory = PBDFactory.GetAssetFactory();
		AudioClip theClip = Factory.LoadAudioClip( ClipName);
		if(theClip == null)
			return ;
		m_Audio.clip = theClip;
		m_Audio.Play();
	}

	// 攻擊目標
	public void Fire( ICharacter theTarget )
	{
		// 顯示武器發射/槍口特效
		ShowShootEffect();

		// 顯示武器子彈特效(子類別實作)
		DoShowBulletEffect( theTarget );

		// 顯示音效(子類別實作)
		DoShowSoundEffect();
		
		// 直接命中攻擊
		theTarget.UnderAttack( m_WeaponOwner );
	}
	
	// 顯示武器子彈特效
	protected abstract void DoShowBulletEffect( ICharacter theTarget );

	// 顯示音效
	protected abstract void DoShowSoundEffect();

}

