﻿using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.World
{
	public class WCRoot : MonoBehaviour
	{
		public void InstantiateWorldGameObject()
		{
			if( null != this._worldObject && null == this.worldGO )
			{
				this.worldGO = GameObject.Instantiate(this._worldObject) as GameObject;
			}

			if( null != this.worldGO )
			{
				this.playerCamera = this.worldGO.GetComponentInChildren<Camera>();
				this.playerSpawn = this.worldGO.GetComponentInChildren<WCPlayerSpawn>();

				this.enemySpawnList = new List<WCEnemySpawn>();
				this.enemySpawnList.AddRange(this.worldGO.GetComponentsInChildren<WCEnemySpawn>());
			}
		}
		public void TerminateWorldGameObject()
		{
			if (null != this.enemySpawnList)
			{
				this.enemySpawnList.Clear();
				this.enemySpawnList = null;
			}

			if( null != this.worldGO )
			{
				GameObject.Destroy(this.worldGO);
				this.worldGO = null;
			}
		}

		[SerializeField]
		private UnityEngine.Object _worldObject = null;

		public GameObject worldGO { get; private set; }
		public WCPlayerSpawn playerSpawn { get; private set; }
		public List<WCEnemySpawn> enemySpawnList { get; private set; }
		public Camera playerCamera { get; private set; }
	}
}
