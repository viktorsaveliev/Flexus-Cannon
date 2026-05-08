using FlexusCannon.Additional;
using FlexusCannon.CameraSystem;
using FlexusCannon.FPSController;
using FlexusCannon.GameInputSystem;
using FlexusCannon.PoolSystem;
using FlexusCannon.UiSystem;
using FlexusCannon.WeaponSystem;
using UnityEngine;

namespace FlexusCannon.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private FirstPersonLook _firstPersonLook;
        [SerializeField] private Weapon _defaultWeapon;
        [SerializeField] private ProjectileSpawner _projectileSpawner;

        [SerializeField] private PowerPanelController _powerPanel;

        [SerializeField] private TickMaster _tickMaster;
        [SerializeField] private VfxPool _vfxPool;
        [SerializeField] private CameraShakePresenter _shakePresentor;

        private PlayerCombatController _playerCombatController;
        private WeaponController _weaponController;

        private readonly InputRouter _inputRouter = new();
        private readonly WeaponFactory _weaponFactory = new();

        private void Awake()
        {
            _inputRouter.Init(_tickMaster);
            _firstPersonLook.Construct(_inputRouter, _tickMaster);

            _projectileSpawner.Init(_tickMaster, _vfxPool);
            _vfxPool.Init();

            _defaultWeapon.Init();

            _weaponController = new WeaponController(_weaponFactory);
            _powerPanel.Init(_weaponController);

            _weaponController.Equip(_defaultWeapon);
            _shakePresentor.Init(_weaponController, _projectileSpawner);

            PlayerInputMap playerInputMap = _inputRouter.GetInputMap<PlayerInputMap>();
            _playerCombatController = new(playerInputMap, _weaponController, _projectileSpawner, _tickMaster);
            _playerCombatController.Init();

            Cursor.lockState = CursorLockMode.Locked;

            _inputRouter.SetPlayerMap();
        }

        private void OnDestroy()
        {
            _inputRouter.Dispose();
            _playerCombatController.Dispose();
        }
    }
}
