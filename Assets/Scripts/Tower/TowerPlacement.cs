using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    [Header("Tower Prefabs")]
    [SerializeField] private GameObject CrossbowTowerPrefab;

    private GameObject selectedTower;

    private Camera mainCamera;

    [SerializeField] private int CrossBowCost = 5;
    private int selectedTowerCost;
    private GameManager gameManager;
    private InGameUI inGameUI;


    private void Awake()
    {
        mainCamera = Camera.main;
        gameManager = FindFirstObjectByType<GameManager>();
        inGameUI = FindFirstObjectByType<InGameUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTower();
        }
    }

    public void SelectCrossbowTower()
    {
        if (gameManager.CurrentScraps < CrossBowCost)
        {
            inGameUI.ShowWarningText();

            return;
        }
        selectedTower = CrossbowTowerPrefab;
        selectedTowerCost = CrossBowCost;

        Debug.Log("Crossbow Selected");
    }

    private void PlaceTower()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (selectedTower == null)
            return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.transform.CompareTag("Tile"))
            {
                Instantiate(selectedTower, hit.transform.position + Vector3.up * 0.5f, Quaternion.identity);

                gameManager.UpdateScraps(-selectedTowerCost);
                Debug.Log("Tower Placed");

                selectedTower = null;
            }
        }
    }
}
