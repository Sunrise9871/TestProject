using ScriptableObjects;
using UnityEngine;

namespace Logic
{
    public class UpgradeStoreLogic : MonoBehaviour
    {
        [SerializeField] private UpgradeStore _upgradeStore;
        [SerializeField] private UpgradeItemGraphics _upgradeItemGraphics;
        
        private void OnEnable()
        {
            var upgradeItems = _upgradeStore.UpgradeItems;

            foreach (var upgradeItem in upgradeItems)
            {
                var item = Instantiate(_upgradeItemGraphics, transform);
                item.FillInfo(upgradeItem.Sprite, upgradeItem.name, upgradeItem.Description, upgradeItem.Cost);
            }
        }
    }
}
