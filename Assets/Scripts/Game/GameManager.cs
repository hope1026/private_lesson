using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.World;
using Assets.Scripts.User;

namespace Assets.Scripts.Game
{
	public sealed class GameManager
	{
		private GameManager() { }

		public void HandleOnEnterGame()
		{
			if( null != WorldManager.Instance.rootComponent && null != WorldManager.Instance.rootComponent.playerSpawn )
			{
				GameObject playerGO = WorldManager.Instance.rootComponent.playerSpawn.Spawn();
				UserManager.Instance.SetUserGameObject(playerGO);
				UserManager.Instance.SetPlayerCamera(WorldManager.Instance.rootComponent.playerCamera);
			}
		}
		public void HandleOnExitGame()
		{

		}
		public void UpdatePre()
		{
			UserManager.Instance.UpdateCustomPre();
		}
		public void Update()
		{
			UserManager.Instance.UpdateCustom();
		}
		public void UpdatePost()
		{
		}
		
		#region SINGLETON
		private static GameManager _instance = null;
		public static GameManager Instance { get { if (null != _instance) { return _instance; } else { return (_instance = new GameManager()); } } }
		#endregion
	}
}
