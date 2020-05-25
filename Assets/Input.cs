// GENERATED AUTOMATICALLY FROM 'Assets/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b718c68d-513e-4ee5-b965-a4e95b5fab5f"",
            ""actions"": [
                {
                    ""name"": ""MoveNorth"",
                    ""type"": ""Button"",
                    ""id"": ""a5a680f0-f8af-44c5-8148-1a9af2998dc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveSouth"",
                    ""type"": ""Button"",
                    ""id"": ""88c828a3-c8e1-47e1-8532-30dbcae23548"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveEast"",
                    ""type"": ""Button"",
                    ""id"": ""2d971c96-9987-4c8f-b9c4-8af6731dd09a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveWest"",
                    ""type"": ""Button"",
                    ""id"": ""99ca4f69-7f9f-4b20-84d7-43bc7d937ab9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b0b08881-9e44-4e55-a477-5212efb0b59f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveNorth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93ea52fa-6928-4f2e-8f8a-9fb7ad806491"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1074c46-4023-4755-9d1d-a52295a4349c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveEast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""507a2f3e-cfa3-4c8c-8f73-efff217f37c2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoveWest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
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
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveNorth = m_Player.FindAction("MoveNorth", throwIfNotFound: true);
        m_Player_MoveSouth = m_Player.FindAction("MoveSouth", throwIfNotFound: true);
        m_Player_MoveEast = m_Player.FindAction("MoveEast", throwIfNotFound: true);
        m_Player_MoveWest = m_Player.FindAction("MoveWest", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MoveNorth;
    private readonly InputAction m_Player_MoveSouth;
    private readonly InputAction m_Player_MoveEast;
    private readonly InputAction m_Player_MoveWest;
    public struct PlayerActions
    {
        private @Input m_Wrapper;
        public PlayerActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveNorth => m_Wrapper.m_Player_MoveNorth;
        public InputAction @MoveSouth => m_Wrapper.m_Player_MoveSouth;
        public InputAction @MoveEast => m_Wrapper.m_Player_MoveEast;
        public InputAction @MoveWest => m_Wrapper.m_Player_MoveWest;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveNorth.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNorth;
                @MoveNorth.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNorth;
                @MoveNorth.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNorth;
                @MoveSouth.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveSouth;
                @MoveSouth.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveSouth;
                @MoveSouth.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveSouth;
                @MoveEast.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveEast;
                @MoveEast.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveEast;
                @MoveEast.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveEast;
                @MoveWest.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveWest;
                @MoveWest.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveWest;
                @MoveWest.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveWest;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveNorth.started += instance.OnMoveNorth;
                @MoveNorth.performed += instance.OnMoveNorth;
                @MoveNorth.canceled += instance.OnMoveNorth;
                @MoveSouth.started += instance.OnMoveSouth;
                @MoveSouth.performed += instance.OnMoveSouth;
                @MoveSouth.canceled += instance.OnMoveSouth;
                @MoveEast.started += instance.OnMoveEast;
                @MoveEast.performed += instance.OnMoveEast;
                @MoveEast.canceled += instance.OnMoveEast;
                @MoveWest.started += instance.OnMoveWest;
                @MoveWest.performed += instance.OnMoveWest;
                @MoveWest.canceled += instance.OnMoveWest;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMoveNorth(InputAction.CallbackContext context);
        void OnMoveSouth(InputAction.CallbackContext context);
        void OnMoveEast(InputAction.CallbackContext context);
        void OnMoveWest(InputAction.CallbackContext context);
    }
}
