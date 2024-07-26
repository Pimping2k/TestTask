using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class GunSlotController : MonoBehaviour
{
    [SerializeField] public List<GameObject> slots = new List<GameObject>();
    [SerializeField] List<Image> slotImage = new List<Image>();
    private void Start()
    {
        foreach (var slot in slots)
        {
            slot.gameObject.SetActive(false);
        }

        foreach(var slotImage in slotImage)
        {
            slotImage.GetComponent<Image>().color = Color.grey;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotImage[0].color = Color.white;
            slotImage[1].color = Color.grey;
            slotImage[2].color = Color.grey;
            slots[0].SetActive(true);
            slots[1].SetActive(false);
            slots[2].SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotImage[0].color = Color.grey;
            slotImage[1].color = Color.white;
            slotImage[2].color = Color.grey;
            slots[0].SetActive(false);
            slots[1].SetActive(true);
            slots[2].SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotImage[0].color = Color.grey;
            slotImage[1].color = Color.grey;
            slotImage[2].color = Color.white;
            slots[0].SetActive(false);
            slots[1].SetActive(false);
            slots[2].SetActive(true);
        }
    }

    public bool IsAnyActive()
    {
        foreach (var slot in slots)
        {
            if (slot.activeSelf)
                return true;
        }
        return false;
    }
}
