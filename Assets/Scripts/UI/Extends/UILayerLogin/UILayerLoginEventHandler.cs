using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Scene;
using Assets.Scripts.User;

namespace Assets.Scripts.UI
{
	class UILayerLoginEventHandler : MonoBehaviour
	{
		public void HandleOnActivateLayer()
		{
			if( null != this._gotoLobbyButton )
			{
				this._gotoLobbyButton.onClick.AddListener(_HanldeOnClickGotoLobby);
			}
		}
		public void HandleOnDeActivateLayer()
		{
			if (null != this._gotoLobbyButton)
			{
				this._gotoLobbyButton.onClick.RemoveListener(_HanldeOnClickGotoLobby);
			}
		}

		private void _HanldeOnClickGotoLobby()
		{
			SceneManager.Instance.ChangeSceneRequest(SceneType.LOBBY);
			if( null != this._idInputField )
			{
				UserManager.Instance.userID = this._idInputField.text;
			}
		}
		
		[SerializeField]
		private Button _gotoLobbyButton = null;
		[SerializeField]
		private InputField _idInputField = null;
	}
}
