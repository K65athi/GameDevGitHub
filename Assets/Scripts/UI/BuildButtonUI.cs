using UnityEngine;

public class BuildButtonUI : MonoBehaviour
{
    [SerializeField] private float yPositionOffset;
    private bool isActive;
    private UIAnimation UiAnimator;

    private void Awake()
    {
        UiAnimator = GetComponentInParent<UIAnimation>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
            ShowBuildButtons();
    }

    public void ShowBuildButtons()
    {
        isActive = !isActive;
        
        float yOffset = isActive ? yPositionOffset : -yPositionOffset;
        Vector3 offset = new Vector3(0, yOffset);

        UiAnimator.ChangePosition(transform.parent, offset);
    }
}
