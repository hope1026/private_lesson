﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.World;
using Assets.Scripts.User;
using Assets.Scripts.UI;

namespace Assets.Scripts.Game
{
	public sealed class GameManager
	{
		private GameManager() { }

		public void HandleOnEnterGame()
		{
			_SpawnPlayer();
			_SpawnEnemies();
		}
		public void HandleOnExitGame()
		{
		}
		public void UpdatePre()
		{
			if (true == Input.GetKeyUp(KeyCode.Escape))
			{
				if( UIManager.Instance.currentActiveLayerType == UILayerType.GAME )
				{
					UIManager.Instance.DeactivateUILayer(UILayerType.GAME);
					UIManager.Instance.ActivateUILayer(UILayerType.GAME_PAUSE);
				}
				else if (UIManager.Instance.currentActiveLayerType == UILayerType.GAME_PAUSE)
				{
					UIManager.Instance.DeactivateUILayer(UILayerType.GAME_PAUSE);
					UIManager.Instance.ActivateUILayer(UILayerType.GAME);
				}
			}
			UserManager.Instance.UpdateCustomPre();
		}
		public void Update()
		{
			UserManager.Instance.UpdateCustom();
		}
		public void UpdatePost()
		{
		}

		private void _SpawnPlayer()
		{
			if (null != WorldManager.Instance.rootComponent && null != WorldManager.Instance.rootComponent.playerSpawn)
			{
				GameObject playerGO = WorldManager.Instance.rootComponent.playerSpawn.Spawn();
				UserManager.Instance.SetUserGameObject(playerGO);
				UserManager.Instance.SetPlayerCamera(WorldManager.Instance.rootComponent.playerCamera);
			}
		}
		private void _SpawnEnemies()
		{
			if (null != WorldManager.Instance.rootComponent && null != WorldManager.Instance.rootComponent.enemySpawnList)
			{
				foreach(WCEnemySpawn enemySpawn in WorldManager.Instance.rootComponent.enemySpawnList )
				{
					if( null != enemySpawn )
					{
						enemySpawn.Spawn();
					}
				}
			}
		}
		
		#region SINGLETON
		private static GameManager _instance = null;
		public static GameManager Instance { get { if (null != _instance) { return _instance; } else { return (_instance = new GameManager()); } } }
		#endregion
	}
}
