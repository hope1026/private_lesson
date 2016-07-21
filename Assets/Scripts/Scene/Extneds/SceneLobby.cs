using UnityEngine;
using System.Collections;
using Assets.Scripts.UI;


namespace Assets.Scripts.Scene
{
	public class SceneLobby : SceneAbstract
	{
		protected override void _OnEnter()
		{
			UIManager.Instance.ActivateUILayer(UILayerType.LOBBY);
		}

		protected override void _OnExit()
		{
			UIManager.Instance.DeactivateUILayer(UILayerType.LOBBY);
		}

		public override void Update()
		{
			if (true == Input.GetKeyUp(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
		public override SceneType sceneType { get { return SceneType.LOBBY; } }
	}
}
