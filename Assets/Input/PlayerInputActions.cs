// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""db2329ae-160e-4789-8427-0b511d217502"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e07de738-9927-4b9e-91be-9a46deb334ab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""97e5d0f4-7f58-4fec-85ea-c5bcd04cde34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""2d78ea39-25b0-47c9-86c7-60bc0905a61a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""cfadee25-6753-42c3-b920-770ab4bee355"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""8096fd21-038c-4098-ae9b-bfc827287c27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""5a24d1c6-be6b-4c54-8816-b2185cbd1575"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""f51c9096-5fef-4668-b25d-e4d66f47f397"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""592279ea-135f-4268-b560-2612a14f5104"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""8b3787c9-dacb-4d56-ada5-f983e617e24f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Load"",
                    ""type"": ""Button"",
                    ""id"": ""b3fcae25-e37d-4eb9-ab85-f640075ddd94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Direction"",
                    ""id"": ""1266b63d-ae51-4672-b0e7-05ad7bd8e260"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7b4896a4-f962-4ee1-9e26-461a3b181222"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9c071835-fb37-477d-82cb-cf00556cd364"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b7f4dd38-39a0-49f7-a49b-308fc67ced5b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""786712ca-171a-4e19-b38c-1590ae3dc0ce"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""352c633b-1464-41c9-8078-ff1e2a49f41a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d30d6068-2ccd-4c9c-9d0f-dbd1351d9429"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c27d272-ebef-4f44-b79f-985737844f2a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b31406ad-298f-4c5a-9845-937a1a18b631"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1a1db6e-d33d-4a02-85e9-13ee4b088a72"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b7c23d3-52c5-4099-84dd-ec4476e45ebf"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d61c72e-f75f-43b5-8258-5f9b8cd6a7a8"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b05ff0b-1807-4e56-9608-fe255ed8861e"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1458133d-baee-4bcc-951e-00ec0965de78"",
                    ""path"": ""<Keyboard>/f6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Load"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseActionMap"",
            ""id"": ""3a2fad8b-f767-4599-80ca-42843acc611a"",
            ""actions"": [
                {
                    ""name"": ""UnPauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""cded9f0b-ff7d-4b2c-9cc1-cb17954f182c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""6ca1e1c0-f525-430a-8eaa-6a8c24bb511b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1ebb1412-750f-492b-acfc-acfcf0ae8433"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnPauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25d3fd1e-169f-4778-a47e-eb0010b35d55"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard/Mouse"",
            ""bindingGroup"": ""Keyboard/Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerActionMap
        m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
        m_PlayerActionMap_Movement = m_PlayerActionMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerActionMap_Jump = m_PlayerActionMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActionMap_Run = m_PlayerActionMap.FindAction("Run", throwIfNotFound: true);
        m_PlayerActionMap_Look = m_PlayerActionMap.FindAction("Look", throwIfNotFound: true);
        m_PlayerActionMap_Fire = m_PlayerActionMap.FindAction("Fire", throwIfNotFound: true);
        m_PlayerActionMap_Reload = m_PlayerActionMap.FindAction("Reload", throwIfNotFound: true);
        m_PlayerActionMap_PauseGame = m_PlayerActionMap.FindAction("PauseGame", throwIfNotFound: true);
        m_PlayerActionMap_Inventory = m_PlayerActionMap.FindAction("Inventory", throwIfNotFound: true);
        m_PlayerActionMap_Save = m_PlayerActionMap.FindAction("Save", throwIfNotFound: true);
        m_PlayerActionMap_Load = m_PlayerActionMap.FindAction("Load", throwIfNotFound: true);
        // PauseActionMap
        m_PauseActionMap = asset.FindActionMap("PauseActionMap", throwIfNotFound: true);
        m_PauseActionMap_UnPauseGame = m_PauseActionMap.FindAction("UnPauseGame", throwIfNotFound: true);
        m_PauseActionMap_Inventory = m_PauseActionMap.FindAction("Inventory", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerActionMap
    private readonly InputActionMap m_PlayerActionMap;
    private IPlayerActionMapActions m_PlayerActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerActionMap_Movement;
    private readonly InputAction m_PlayerActionMap_Jump;
    private readonly InputAction m_PlayerActionMap_Run;
    private readonly InputAction m_PlayerActionMap_Look;
    private readonly InputAction m_PlayerActionMap_Fire;
    private readonly InputAction m_PlayerActionMap_Reload;
    private readonly InputAction m_PlayerActionMap_PauseGame;
    private readonly InputAction m_PlayerActionMap_Inventory;
    private readonly InputAction m_PlayerActionMap_Save;
    private readonly InputAction m_PlayerActionMap_Load;
    public struct PlayerActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerActionMap_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerActionMap_Jump;
        public InputAction @Run => m_Wrapper.m_PlayerActionMap_Run;
        public InputAction @Look => m_Wrapper.m_PlayerActionMap_Look;
        public InputAction @Fire => m_Wrapper.m_PlayerActionMap_Fire;
        public InputAction @Reload => m_Wrapper.m_PlayerActionMap_Reload;
        public InputAction @PauseGame => m_Wrapper.m_PlayerActionMap_PauseGame;
        public InputAction @Inventory => m_Wrapper.m_PlayerActionMap_Inventory;
        public InputAction @Save => m_Wrapper.m_PlayerActionMap_Save;
        public InputAction @Load => m_Wrapper.m_PlayerActionMap_Load;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Look.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Fire.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnFire;
                @Reload.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnReload;
                @PauseGame.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPauseGame;
                @Inventory.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Save.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnSave;
                @Load.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLoad;
                @Load.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLoad;
                @Load.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLoad;
            }
            m_Wrapper.m_PlayerActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @Load.started += instance.OnLoad;
                @Load.performed += instance.OnLoad;
                @Load.canceled += instance.OnLoad;
            }
        }
    }
    public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);

    // PauseActionMap
    private readonly InputActionMap m_PauseActionMap;
    private IPauseActionMapActions m_PauseActionMapActionsCallbackInterface;
    private readonly InputAction m_PauseActionMap_UnPauseGame;
    private readonly InputAction m_PauseActionMap_Inventory;
    public struct PauseActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PauseActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @UnPauseGame => m_Wrapper.m_PauseActionMap_UnPauseGame;
        public InputAction @Inventory => m_Wrapper.m_PauseActionMap_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_PauseActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActionMapActions instance)
        {
            if (m_Wrapper.m_PauseActionMapActionsCallbackInterface != null)
            {
                @UnPauseGame.started -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnUnPauseGame;
                @UnPauseGame.performed -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnUnPauseGame;
                @UnPauseGame.canceled -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnUnPauseGame;
                @Inventory.started -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_PauseActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UnPauseGame.started += instance.OnUnPauseGame;
                @UnPauseGame.performed += instance.OnUnPauseGame;
                @UnPauseGame.canceled += instance.OnUnPauseGame;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public PauseActionMapActions @PauseActionMap => new PauseActionMapActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard/Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnLoad(InputAction.CallbackContext context);
    }
    public interface IPauseActionMapActions
    {
        void OnUnPauseGame(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
}
