using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Item", menuName = "UpgradeStore")]
    public class UpgradeStore : ScriptableObject
    {
        [field: SerializeField] public List<UpgradeItem> UpgradeItems { get; private set; }
    }
}