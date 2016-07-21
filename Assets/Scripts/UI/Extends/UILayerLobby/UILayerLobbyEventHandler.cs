using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Scene;

namespace Assets.Scripts.UI
{
	class UILayerLobbyEventHandler : MonoBehaviour
	{
		public void HandleOnActivateLayer()
		{
			if( null != this._gotoGameButton )
			{
				this._gotoGameButton.onClick.AddListener(_HanldeOnClickGotoGame);
			}
		}
		public void HandleOnDeActivateLayer()
		{
			if (null != this._gotoGameButton)
			{
				this._gotoGameButton.onClick.RemoveListener(_HanldeOnClickGotoGame);
			}
		}

		private void _HanldeOnClickGotoGame()
		{
			SceneManager.Instance.ChangeSceneRequest(SceneType.GAME);
		}
		
		[SerializeField]
		private Button _gotoGameButton = null;
	}
}
