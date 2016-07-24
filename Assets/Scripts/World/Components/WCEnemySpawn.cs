using System;
using UnityEngine;
using Assets.Scripts.Game;

namespace Assets.Scripts.World
{
	public class WCEnemySpawn : MonoBehaviour
	{
		public GameObject Spawn()
		{
			if (null != this._enemyObject)
			{
				return GameObject.Instantiate(this._enemyObject, base.transform.position, base.transform.rotation) as GameObject;
			}
			return null;
		}

		[SerializeField]
		private UnityEngine.Object _enemyObject = null;
	}
}
