using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIBuildButtonForTower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float AdjustSpeed = 10;
    [SerializeField] private float ShowY;
    [SerializeField] private float DefaultY;

    private float TargetY;
    private bool CanMove;

    private void Update()
    {
        if(Mathf.Abs(transform.position.y - TargetY) > .01f && CanMove)
        {
            float NewPositionY = Mathf.Lerp(transform.position.y, TargetY, AdjustSpeed * Time.deltaTime);

            transform.position = new Vector3(transform.position.x, NewPositionY, transform.position.z);
        }
    }

    public void ToggleMovement(bool TowerButtonsActive)
    {
        CanMove = TowerButtonsActive;
    }

    private void SetTargetY(float newY) => TargetY = newY;
    public void OnPointerEnter(PointerEventData eventData)
    {
        SetTargetY(ShowY);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetTargetY(DefaultY);
    }
}
