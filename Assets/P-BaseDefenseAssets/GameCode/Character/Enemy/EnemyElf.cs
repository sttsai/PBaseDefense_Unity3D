using UnityEngine;
using System.Collections;

// 精靈
public class EnemyElf  : IEnemy
{
	public EnemyElf()
	{
		m_emEnemyType = ENUM_Enemy.Elf;
		m_AssetName = "Enemy1";
		m_AttrID   = 1;
		m_IconSpriteName = "ElfIcon";
	}
	
	// 播放音效
	public override void DoPlayHitSound()
	{
		//Debug.Log ("EnemyElf.PlayHitSound");
	}
	
	// 播放特效
	public override void DoShowHitEffect()
	{
		PlayEffect( "ElfHitEffect" );
	}

	// 執行Visitor
	public override void RunVisitor(ICharacterVisitor Visitor)
	{
		Visitor.VisitEnemyElf(this);
	}
}
