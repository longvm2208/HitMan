using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWin : PopupBase
{
	#region UI Events
	public void OnClickRestart()
	{
		LoadSceneManager.Instance.LoadScene(SceneId.Game);
	}
	#endregion
}
