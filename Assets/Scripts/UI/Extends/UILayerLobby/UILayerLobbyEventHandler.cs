using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

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
			UIManager.Instance.DeactivateUILayer(UILayerType.LOBBY);
			UIManager.Instance.ActivateUILayer(UILayerType.GAME);
			if( null != this._idInputField )
			{
				PlayerPrefs.SetString("ID", this._idInputField.text);
			}
		}
		
		[SerializeField]
		private Button _gotoGameButton = null;
		[SerializeField]
		private InputField _idInputField = null;
	}
}
