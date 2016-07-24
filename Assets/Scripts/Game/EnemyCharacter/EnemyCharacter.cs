using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;

namespace Assets.Scripts.Game
{
	public class EnemyCharacter : MonoBehaviour
	{
		private readonly string ANIMATOR_PARAM_IDLE = "Idle";
		private readonly string ANIMATOR_PARAM_DIE = "Die";
		void Awake()
		{
			this._animator = base.GetComponentInChildren<Animator>();
			if( null != this._animator )
			{
				this._animator.SetTrigger(ANIMATOR_PARAM_IDLE);
			}
		}
		public void Die()
		{
			if (null != this._animator)
			{
				this._animator.SetTrigger(ANIMATOR_PARAM_DIE);
			}
			if( null != this._destoryParticleObject )
			{
				ParticleSystem particle = GameObject.Instantiate<ParticleSystem>(this._destoryParticleObject);
				if( null != particle )
				{
					particle.transform.position = base.transform.position;
					particle.transform.rotation = base.transform.rotation;
					particle.Play();
					AutoDestory particleAutoDestory = base.gameObject.AddComponent<AutoDestory>();
					if (null != particleAutoDestory)
					{
						particleAutoDestory.StartAutoDestory(3f);
					}
				}
			}
			AutoDestory enemyAutoDestory = base.gameObject.AddComponent<AutoDestory>();
			if( null != enemyAutoDestory )
			{
				enemyAutoDestory.StartAutoDestory(3f);
			}
		}

		[SerializeField]
		private ParticleSystem _destoryParticleObject = null;
		private Animator _animator = null;
	}
}
