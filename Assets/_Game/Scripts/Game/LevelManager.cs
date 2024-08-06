using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform levelTransform;

    private void Start()
    {
        float baseRatio = 9f / 16f;
        float currentRatio = (float)Screen.width / Screen.height;

        levelTransform.localScale = (currentRatio / baseRatio) * Vector3.one;
    }
}
