using UnityEngine;
using System.Collections;
using Assets.Scripts.UI;
public class Main : MonoBehaviour
{
	//스크립트 생성시 최초 1번 호출
	void Awake()
	{
		UIManager.Instance.Initialize();
	}
	//스크립트 소멸 직전 호출
	void OnDestroy()
	{
		UIManager.Instance.Terminate();
	}
	void Start()
	{
		UIManager.Instance.ActivateUILayer(UILayerType.LOBBY);
	}
	void Update()
	{
		UIManager.Instance.UpdateCustom();
	}
}
