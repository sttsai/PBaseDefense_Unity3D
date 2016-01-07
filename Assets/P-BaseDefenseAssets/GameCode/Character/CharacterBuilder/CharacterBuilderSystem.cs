using UnityEngine;
using System.Collections.Generic;

// 利用Builder介面來建構物件
public class CharacterBuilderSystem : IGameSystem
{
	private int m_GameObjectID = 0;

	public CharacterBuilderSystem(PBaseDefenseGame PBDGame):base(PBDGame)
	{}

	public override void Initialize()
	{}

	public override void Update()
	{}


	// 建立 
	public void Construct(ICharacterBuilder theBuilder)
	{
		// 利用Builder產生各部份加入Product中
		theBuilder.LoadAsset( ++m_GameObjectID );
		theBuilder.AddOnClickScript();
		theBuilder.AddWeapon();
		theBuilder.SetCharacterAttr();
		theBuilder.AddAI();

		// 加入管理器內
		theBuilder.AddCharacterSystem( m_PBDGame );
	}
}
