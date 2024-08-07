public class PopupLose : PopupBase
{
    #region UI Events
    public void OnClickRestart()
    {
        LoadSceneManager.Instance.LoadScene(SceneId.Game);
    }
    #endregion
}
