using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.World
{
	public sealed class WorldManager
	{
		private WorldManager() { }

		public void InstantiateWorld()
		{
			if( null == this.rootComponent )
			{
				this.rootComponent = GameObject.FindObjectOfType<WCRoot>();
			}
			if( null != this.rootComponent )
			{
				this.rootComponent.InstantiateWorldGameObject();
			}
		}
		public void TerminateWorld()
		{
			if (null != this.rootComponent)
			{
				this.rootComponent.TerminateWorldGameObject();
				this.rootComponent = null;
			}
		}

		public WCRoot rootComponent { get; private set; }
		#region SINGLETON
		private static WorldManager _instance = null;
		public static WorldManager Instance { get { if (null != _instance) { return _instance; } else { return (_instance = new WorldManager()); } } }
		#endregion
	}
}
