using UnityEngine;
using System.Collections;
using Assets.Scripts.UI;
using Assets.Scripts.World;
using Assets.Scripts.Game;

namespace Assets.Scripts.Scene
{
	public class SceneGame : SceneAbstract
	{
		protected override void _OnEnter()
		{
			UIManager.Instance.ActivateUILayer(UILayerType.GAME);
			WorldManager.Instance.InstantiateWorld();
			GameManager.Instance.HandleOnEnterGame();
		}
		protected override void _OnExit()
		{
			WorldManager.Instance.TerminateWorld();
			UIManager.Instance.DeactivateUILayer(UILayerType.GAME);
			GameManager.Instance.HandleOnExitGame();
		}


		public override void UpdatePre()
		{
			GameManager.Instance.UpdatePre();
		}
		public override void Update()
		{
			GameManager.Instance.Update();
		}
		public override void UpdatePost()
		{
			GameManager.Instance.UpdatePost();
		}

		public string requestWorldListRIDC { get; set; }
		public override SceneType sceneType { get { return SceneType.GAME; } }

	}
}
