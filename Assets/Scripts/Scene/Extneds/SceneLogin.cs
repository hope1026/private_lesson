using UnityEngine;
using System.Collections;
using Assets.Scripts.UI;


namespace Assets.Scripts.Scene
{
	public class SceneLogin : SceneAbstract
	{
		protected override void _OnEnter()
		{
			UIManager.Instance.ActivateUILayer(UILayerType.LOGIN);
		}

		protected override void _OnExit()
		{
			UIManager.Instance.DeactivateUILayer(UILayerType.LOGIN);
		}

		public override SceneType sceneType { get { return SceneType.LOGIN; } }
	}
}
