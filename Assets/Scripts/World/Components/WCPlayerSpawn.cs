using System;
using UnityEngine;


namespace Assets.Scripts.World
{
	public class WCPlayerSpawn : MonoBehaviour
	{
		public GameObject Spawn()
		{
			if( null != this._playerObject )
			{
				return GameObject.Instantiate(this._playerObject, base.transform.position, base.transform.rotation) as GameObject;
			}
			return null;
		}

		[SerializeField]
		private UnityEngine.Object _playerObject = null;
	}
}
