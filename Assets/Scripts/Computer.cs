using Enums;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private GameObject powerUnit;
    [SerializeField] private GameObject cooler;
    [SerializeField] private GameObject gpu;
    [SerializeField] private GameObject cpu;
    [SerializeField] private GameObject thermal;
    [SerializeField] private GameObject hardDrive_1;
    [SerializeField] private GameObject hardDrive_2;
    [SerializeField] private GameObject hardDrive_3;

    public enum SlotType
    {
        None,
        PowerUnit,
        Cooler,
        GPU,
        CPU,
        Thermal,
        HardDrive,
    }

    public bool TryInsert(SlotType slot, CollectibleType itemType)
    {
        switch (slot)
        {
            case SlotType.None:
                return false;
            case SlotType.PowerUnit:
                powerUnit.SetActive(powerUnit.activeSelf || itemType == CollectibleType.PowerSource);
                return itemType == CollectibleType.PowerSource;
            case SlotType.Cooler:
                cooler.SetActive(cooler.activeSelf || itemType == CollectibleType.Cooler);
                return itemType == CollectibleType.Cooler;
            case SlotType.GPU:
                gpu.SetActive(gpu.activeSelf || itemType == CollectibleType.GPU);
                return itemType == CollectibleType.GPU;
            case SlotType.CPU:
                cpu.SetActive(cpu.activeSelf || (thermal.activeSelf && itemType == CollectibleType.CPU));
                thermal.SetActive(thermal.activeSelf && itemType != CollectibleType.CPU);
                return cpu.activeSelf || (thermal.activeSelf && itemType == CollectibleType.CPU);
            case SlotType.Thermal:
                thermal.SetActive(thermal.activeSelf || itemType == CollectibleType.ThermalPaste);
                return itemType == CollectibleType.ThermalPaste;
            case SlotType.HardDrive:
                switch (itemType)
                {
                    case CollectibleType.HardDrive_1:
                        hardDrive_1.SetActive(true);
                        return true;
                    case CollectibleType.HardDrive_2:
                        hardDrive_2.SetActive(true);
                        return true;
                    case CollectibleType.HardDrive_3:
                        hardDrive_3.SetActive(true);
                        return true;
                    default:
                        return false;
                }
            default:
                return false;
        }
    }

    public bool CheckCompletion()
    {
        return 
            powerUnit.activeSelf &&
            cooler.activeSelf &&
            gpu.activeSelf &&
            cpu.activeSelf &&
            hardDrive_1.activeSelf &&
            hardDrive_2.activeSelf &&
            hardDrive_3.activeSelf;
    }
}