// GENERATED AUTOMATICALLY FROM 'Assets/PlayerAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerAction"",
    ""maps"": [
        {
            ""name"": ""KeyBoard"",
            ""id"": ""6c699710-e453-4660-b22c-5cad0bbfde9f"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8a9e898a-5262-43d9-9078-9ada8913b4bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""92b7330f-31c5-4aa5-bb1f-72e0c8561a14"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3f02e29e-665a-4b0b-9f61-94e73e767c93"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c618715-593a-42b1-af5d-1604fd0c4146"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4fb0d869-cda5-4cbd-a37b-be0423b2c096"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3db1625a-a49f-49d8-8fd4-823f3cb8b19a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4f5adf35-84a3-4b4f-9122-f6e31fcad40d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b69a7f40-ea66-4b9b-8de0-8bd446508c9d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6446032f-6271-41ba-b56c-0a26e3f11bc0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""id"": ""55366a3e-c532-4dda-ad86-08edb4c00308"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""49a64b44-6567-430e-bc97-082787fbffee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""69dfe505-304f-4e54-850f-463e183ca351"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5fd90d30-d8d0-439c-b9ba-69ac338c454b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4b675e36-dac8-46f3-84ed-b14997320959"",
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
                    ""id"": ""a41cbf54-5da3-4f8a-b634-d9e7043736a3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""90ef5b7b-0a91-4346-828d-f45c0381d454"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9c947fb8-c678-4e5a-93e0-13be3a17e014"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""108e911a-958c-4877-ba4d-c0ca8e44ee7f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // KeyBoard
        m_KeyBoard = asset.FindActionMap("KeyBoard", throwIfNotFound: true);
        m_KeyBoard_Jump = m_KeyBoard.FindAction("Jump", throwIfNotFound: true);
        m_KeyBoard_Movement = m_KeyBoard.FindAction("Movement", throwIfNotFound: true);
        // GamePad
        m_GamePad = asset.FindActionMap("GamePad", throwIfNotFound: true);
        m_GamePad_Jump = m_GamePad.FindAction("Jump", throwIfNotFound: true);
        m_GamePad_Movement = m_GamePad.FindAction("Movement", throwIfNotFound: true);
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

    // KeyBoard
    private readonly InputActionMap m_KeyBoard;
    private IKeyBoardActions m_KeyBoardActionsCallbackInterface;
    private readonly InputAction m_KeyBoard_Jump;
    private readonly InputAction m_KeyBoard_Movement;
    public struct KeyBoardActions
    {
        private @PlayerAction m_Wrapper;
        public KeyBoardActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_KeyBoard_Jump;
        public InputAction @Movement => m_Wrapper.m_KeyBoard_Movement;
        public InputActionMap Get() { return m_Wrapper.m_KeyBoard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyBoardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyBoardActions instance)
        {
            if (m_Wrapper.m_KeyBoardActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_KeyBoardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public KeyBoardActions @KeyBoard => new KeyBoardActions(this);

    // GamePad
    private readonly InputActionMap m_GamePad;
    private IGamePadActions m_GamePadActionsCallbackInterface;
    private readonly InputAction m_GamePad_Jump;
    private readonly InputAction m_GamePad_Movement;
    public struct GamePadActions
    {
        private @PlayerAction m_Wrapper;
        public GamePadActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_GamePad_Jump;
        public InputAction @Movement => m_Wrapper.m_GamePad_Movement;
        public InputActionMap Get() { return m_Wrapper.m_GamePad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePadActions set) { return set.Get(); }
        public void SetCallbacks(IGamePadActions instance)
        {
            if (m_Wrapper.m_GamePadActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_GamePadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public GamePadActions @GamePad => new GamePadActions(this);
    private int m_PlayerSchemeIndex = -1;
    public InputControlScheme PlayerScheme
    {
        get
        {
            if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
            return asset.controlSchemes[m_PlayerSchemeIndex];
        }
    }
    public interface IKeyBoardActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IGamePadActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
