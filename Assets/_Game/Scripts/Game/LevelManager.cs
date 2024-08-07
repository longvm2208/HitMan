using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Level level;
    [SerializeField] Transform levelTransform;

    private void Start()
    {
        float baseRatio = 9f / 16f;
        float currentRatio = (float)Screen.width / Screen.height;

        levelTransform.localScale = (currentRatio / baseRatio) * Vector3.one;
    }

    public void Select(int i)
    {
        level.Select(i);
    }
}
