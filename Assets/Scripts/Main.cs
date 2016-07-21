using UnityEngine;
using System.Collections;
using Assets.Scripts.UI;
using Assets.Scripts.Scene;
public class Main : MonoBehaviour
{
	//스크립트 생성시 최초 1번 호출
	void Awake()
	{
		SceneManager.Instance.Initialize();
		UIManager.Instance.Initialize();
	}
	//스크립트 소멸 직전 호출
	void OnDestroy()
	{
		UIManager.Instance.Terminate();
		SceneManager.Instance.Terminate();
	}
	void Start()
	{
		SceneManager.Instance.ChangeSceneRequest(SceneType.LOGIN);
	}
	void Update()
	{
		SceneManager.Instance.UpdateCustomPre();

		SceneManager.Instance.UpdateCustom();
		UIManager.Instance.UpdateCustom();

		SceneManager.Instance.UpdateCustomPost();
	}
}
