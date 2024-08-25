using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Item", menuName = "UpgradeStore")]
    public class UpgradeStoreData : ScriptableObject
    {
        [field: SerializeField] public List<UpgradeItemData> UpgradeItems { get; private set; }
    }
}