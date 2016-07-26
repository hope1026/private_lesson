using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;
using Assets.Scripts.User;

namespace Assets.Scripts.Game
{
	public class EnemyCharacter : MonoBehaviour
	{
		private readonly string ANIMATOR_PARAM_IDLE = "Idle";
		private readonly string ANIMATOR_PARAM_DIE = "Die";
		private readonly string ANIMATOR_PARAM_ATTACK = "Attack";
		void Awake()
		{
			this._animator = base.GetComponentInChildren<Animator>();
			if( null != this._animator )
			{
				this._animator.SetTrigger(ANIMATOR_PARAM_IDLE);
			}
			this._navMeshAgent = base.GetComponentInChildren<NavMeshAgent>();
		}
		void Update()
		{
			_RandomMove();
			_CheckAttack();
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
		private void _RandomMove()
		{
			if( this._nextMoveStartTime <= Time.realtimeSinceStartup )
			{
				Vector3 destPosition = base.transform.position;
				destPosition.x = destPosition.x + UnityEngine.Random.Range(-3f, 3f);
				destPosition.z = destPosition.z + UnityEngine.Random.Range(-3f, 3f);
				if( null != this._navMeshAgent )
				{
					this._navMeshAgent.SetDestination(destPosition);
				}
				this._nextMoveStartTime = Time.realtimeSinceStartup + UnityEngine.Random.Range(3f, 5f);
			}
		}
		private void _CheckAttack()
		{
			if( this._lastAttackTime + 10f <= Time.realtimeSinceStartup )
			{
				if( Vector3.Distance(UserManager.Instance.userGO.transform.position, base.transform.position ) <= 2.5f )
				{
					if (null != this._animator)
					{
						this._animator.SetTrigger(ANIMATOR_PARAM_ATTACK);
						Vector3 lookForward = UserManager.Instance.userGO.transform.position - base.transform.position;
						base.transform.rotation = Quaternion.LookRotation(lookForward.normalized);
					}
					this._lastAttackTime = Time.realtimeSinceStartup;
				}
			}
		}
		public void HandlePlayAttack()
		{
			Debug.Log("Atttack Event");
		}

		[SerializeField]
		private ParticleSystem _destoryParticleObject = null;
		private Animator _animator = null;
		private NavMeshAgent _navMeshAgent = null;
		private float _nextMoveStartTime = 0f;
		private float _lastAttackTime = 0f;
	}
}
