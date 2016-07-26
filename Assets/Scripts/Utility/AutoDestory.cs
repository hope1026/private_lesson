using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility
{
	class AutoDestory : MonoBehaviour
	{
		public void StartAutoDestory(float time_)
		{
			base.StartCoroutine(_CoroutineAutoDestory(time_));
		}
		private IEnumerator _CoroutineAutoDestory(float time_)
		{
			yield return new WaitForSeconds(time_);
			GameObject.Destroy(base.gameObject);
		}
	}
}
