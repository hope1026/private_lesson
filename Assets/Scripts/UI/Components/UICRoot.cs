using System;
using UnityEngine;


namespace Assets.Scripts.UI
{
	public class UICRoot : MonoBehaviour
	{
		void Awake()
		{
			this._uiRootRectTransform = base.transform as RectTransform;
		}
		public UILayerAbstract InstantiateUILayer(UILayerType uiLayerType_)
		{
			GameObject uiLayerObject = null;

			switch (uiLayerType_)
			{
				case UILayerType.GAME: { uiLayerObject = GameObject.Instantiate(this._gameLayer) as GameObject; } break;
				case UILayerType.GAME_LOADING: { uiLayerObject = GameObject.Instantiate(this._gameLoadingLayer) as GameObject; } break;
				case UILayerType.LOBBY: { uiLayerObject = GameObject.Instantiate(this._lobbyLayer) as GameObject; } break;
				case UILayerType.LOGIN: { uiLayerObject = GameObject.Instantiate(this._loginLayer) as GameObject; } break;
			}
			if (null != uiLayerObject)
			{
				uiLayerObject.transform.localScale = base.transform.localScale;
				uiLayerObject.transform.position = base.transform.position;
				uiLayerObject.transform.SetParent(base.transform);

				RectTransform uiLayerRectTransform = uiLayerObject.transform as RectTransform;
				if (null != this._uiRootRectTransform && null != uiLayerRectTransform)
				{
					uiLayerRectTransform.sizeDelta = Vector2.zero;
				}
				UILayerAbstract uiLayer = null;
				switch (uiLayerType_)
				{
					case UILayerType.GAME: { uiLayer = new UILayerGame(); } break;
					case UILayerType.GAME_LOADING: { uiLayer = new UILayerGameLoading(); } break;
					case UILayerType.LOBBY: { uiLayer = new UILayerLobby(); } break;
					case UILayerType.LOGIN: { uiLayer = new UILayerLogin(); } break;
				}

				if (null != uiLayer)
				{
					uiLayer.Initialize(uiLayerObject);
					return uiLayer;
				}
				return null;
			}
			else
			{
				Debug.LogError("FAILED INSTANTIATE UILAYEROBJECT");
			}
			return null;
		}

		[SerializeField]
		private UnityEngine.Object _loginLayer = null;
		[SerializeField]
		private UnityEngine.Object _lobbyLayer = null;
		[SerializeField]
		private UnityEngine.Object _gameLayer = null;
		[SerializeField]
		private UnityEngine.Object _gameLoadingLayer = null;
		private RectTransform _uiRootRectTransform = null;
	}
}
