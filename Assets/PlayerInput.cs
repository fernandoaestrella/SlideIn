// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""92a9631d-22da-465c-9c65-5de223606c02"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Value"",
                    ""id"": ""18d31695-9555-433b-bd86-19f19d6efb61"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveNorth"",
                    ""type"": ""Value"",
                    ""id"": ""e72f17a0-3fd7-48d1-9df7-95e5820f284a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
<<<<<<< HEAD
                    ""name"": ""MoveSouth"",
                    ""type"": ""Value"",
                    ""id"": ""9e266991-b2f0-48df-a4f8-494487f40e8c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveEast"",
                    ""type"": ""Value"",
                    ""id"": ""7db91d9b-d779-43e1-a68e-334700c120e4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveWest"",
                    ""type"": ""Value"",
                    ""id"": ""3a4b3f0b-157a-40ee-bae9-f51e273326b6"",
                    ""expectedControlType"": ""Axis"",
=======
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""abc279d5-2736-4d90-a3ba-8f61e3699666"",
                    ""expectedControlType"": ""Button"",
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e8f1082-42fd-43bf-aa66-4569d720b053"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ff0171a-8946-48be-acee-976e24467aed"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveNorth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
<<<<<<< HEAD
                    ""id"": ""aa253004-be52-4c83-9223-de14e9850649"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fbb3c4c-41e5-4f9f-a0cc-bbd454a77c2a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveEast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b28ca71-2b74-419c-8a80-21d43445ef28"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveWest"",
=======
                    ""id"": ""24ce3f09-172f-4f1b-a2a7-bfaefdbedb6b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Select = m_Player.FindAction("Select", throwIfNotFound: true);
        m_Player_MoveNorth = m_Player.FindAction("MoveNorth", throwIfNotFound: true);
<<<<<<< HEAD
        m_Player_MoveSouth = m_Player.FindAction("MoveSouth", throwIfNotFound: true);
        m_Player_MoveEast = m_Player.FindAction("MoveEast", throwIfNotFound: true);
        m_Player_MoveWest = m_Player.FindAction("MoveWest", throwIfNotFound: true);
=======
        m_Player_Newaction = m_Player.FindAction("New action", throwIfNotFound: true);
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
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
    private readonly InputAction m_Player_Select;
    private readonly InputAction m_Player_MoveNorth;
<<<<<<< HEAD
    private readonly InputAction m_Player_MoveSouth;
    private readonly InputAction m_Player_MoveEast;
    private readonly InputAction m_Player_MoveWest;
=======
    private readonly InputAction m_Player_Newaction;
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Player_Select;
        public InputAction @MoveNorth => m_Wrapper.m_Player_MoveNorth;
<<<<<<< HEAD
        public InputAction @MoveSouth => m_Wrapper.m_Player_MoveSouth;
        public InputAction @MoveEast => m_Wrapper.m_Player_MoveEast;
        public InputAction @MoveWest => m_Wrapper.m_Player_MoveWest;
=======
        public InputAction @Newaction => m_Wrapper.m_Player_Newaction;
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelect;
                @MoveNorth.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNorth;
                @MoveNorth.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNorth;
                @MoveNorth.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveNorth;
<<<<<<< HEAD
                @MoveSouth.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveSouth;
                @MoveSouth.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveSouth;
                @MoveSouth.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveSouth;
                @MoveEast.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveEast;
                @MoveEast.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveEast;
                @MoveEast.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveEast;
                @MoveWest.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveWest;
                @MoveWest.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveWest;
                @MoveWest.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveWest;
=======
                @Newaction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewaction;
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @MoveNorth.started += instance.OnMoveNorth;
                @MoveNorth.performed += instance.OnMoveNorth;
                @MoveNorth.canceled += instance.OnMoveNorth;
<<<<<<< HEAD
                @MoveSouth.started += instance.OnMoveSouth;
                @MoveSouth.performed += instance.OnMoveSouth;
                @MoveSouth.canceled += instance.OnMoveSouth;
                @MoveEast.started += instance.OnMoveEast;
                @MoveEast.performed += instance.OnMoveEast;
                @MoveEast.canceled += instance.OnMoveEast;
                @MoveWest.started += instance.OnMoveWest;
                @MoveWest.performed += instance.OnMoveWest;
                @MoveWest.canceled += instance.OnMoveWest;
=======
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnMoveNorth(InputAction.CallbackContext context);
<<<<<<< HEAD
        void OnMoveSouth(InputAction.CallbackContext context);
        void OnMoveEast(InputAction.CallbackContext context);
        void OnMoveWest(InputAction.CallbackContext context);
=======
        void OnNewaction(InputAction.CallbackContext context);
>>>>>>> 4484e39fbc2d62ea628fb270dbf2729c8de6881e
    }
}
