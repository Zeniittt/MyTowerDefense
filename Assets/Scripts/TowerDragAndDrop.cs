using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject towerArena;

    public GameObject towerPrefab;
    private GameObject towerInstance;
    private RectTransform canvasTransform;

    private float cellSize = .5f;

    void Start()
    {
        canvasTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        towerInstance = Instantiate(towerPrefab);
        towerInstance.transform.SetParent(canvasTransform, false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = eventData.position;
        towerInstance.GetComponent<RectTransform>().position = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsValidDropPosition(eventData.position))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(eventData.position);
            GetCellPutTower(worldPos);
        }
        else
        {
            Destroy(towerInstance);
        }
    }

    bool IsValidDropPosition(Vector3 position)
    {
        return true;
    }

    void GetCellPutTower(Vector3 position)
    {
        if (!CheckPositionOutRangeTowerArena(position))
            return;

        Vector3 positionTower = Vector3.zero;
        float maxDistance = float.MaxValue;
        TowerArenaController cellTower = null;

        foreach (Transform cell in towerArena.transform)
        {
            float distance = Vector3.Distance(position, cell.position);
            if (distance < maxDistance)
            {
                cellTower = cell.GetComponent<TowerArenaController>();
                if (cellTower != null)
                {
                    if (cellTower.hasTower == true)
                    {
                        Destroy(towerInstance);
                        return;
                    }
                }

                maxDistance = distance;
                positionTower = cell.position;
            }
        }

        towerInstance.transform.position = positionTower;
        cellTower.hasTower = true;
    }

    bool CheckPositionOutRangeTowerArena(Vector3 position)
    {
        Transform firstCell = towerArena.transform.GetChild(0);
        Transform lastCell = towerArena.transform.GetChild(towerArena.transform.childCount - 1);

        if (position.x > lastCell.position.x + cellSize)
        {
            return false;
        }

        if (position.x < firstCell.position.x - cellSize)
        {
            return false;
        }

        if (position.y > firstCell.position.y + cellSize)
        {
            return false;
        }

        if (position.y < lastCell.position.y - cellSize)
        {
            return false;
        }

        return true;
    }
}
