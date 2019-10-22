using UnityEngine;

public class PortalController : Singleton<PortalController>
{

    [SerializeField]
    private PortalItem _enemyPortal;
    [SerializeField]
    private PortalItem _playerPortal;

    public void EntryPortal(PortalItem.Type entryPortal, PortalItem.Type outPortal)
    {
        if (outPortal == PortalItem.Type.EnemyBase)
        {
            _enemyPortal.ActivatePortal();
            Player.Instance.transform.position = _enemyPortal.transform.position + new Vector3(0, 1);
        }
        
        if (outPortal == PortalItem.Type.PlayerBase)
        {
            _playerPortal.ActivatePortal();
            Player.Instance.transform.position = _playerPortal.transform.position + new Vector3(0, 1);
        }
    }
    
}
