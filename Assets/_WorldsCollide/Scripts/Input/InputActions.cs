// GENERATED AUTOMATICALLY FROM 'Assets/_WorldsCollide/Scripts/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""c4bc16c1-032f-46aa-b452-65fb4cfa1028"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""8e9a9eea-966c-4720-b6bb-58c36122cab7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8b98a8e8-8a48-48a5-b9d6-289d804a6ae0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""300efba0-0c71-4b87-bf6f-81b3e56a9c8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack_1"",
                    ""type"": ""Button"",
                    ""id"": ""9aff0620-55c9-40f5-b895-c2542171a752"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Button"",
                    ""id"": ""0bd63262-8b3a-4406-8633-0c6d55a96763"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""50371863-b673-48da-9138-914ee4278cb5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0159cc05-322c-447a-95ba-c0c740b31048"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7ddacd3e-6c90-4f5a-84d7-1918b857c7e4"",
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
                    ""id"": ""3f566817-34d6-4eb1-acef-22287e9798df"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0883ff42-37a7-4d5c-95f9-f8c14b4d2a7f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24f85f23-c3a0-43a0-9564-3185c7de9963"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7868be75-3801-4557-830b-7a9ddf3bc8cc"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""e8d13009-271d-47d3-8885-6cdaad84c307"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""32014775-6db7-409a-83ee-f593ae1c95bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityMenu"",
                    ""type"": ""Button"",
                    ""id"": ""22626560-1062-44e3-8c15-498233919fdb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DragAndDrop"",
                    ""type"": ""Button"",
                    ""id"": ""6ef9113c-d32e-4ee8-8a8e-ee2bca8f7e48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""ActionsBar_1"",
                    ""type"": ""Button"",
                    ""id"": ""91e9e818-49e4-4436-9c2a-5851d682fa7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""262aefc7-0735-4ea3-b58f-01384ef2d959"",
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
                    ""id"": ""e9f919b9-451e-44c2-b3bb-065a1b624beb"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e66ac8c-88c9-4f2d-a116-f97901ece632"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DragAndDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64b708b3-553f-4d27-ad5a-a1af7e521bbc"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionsBar_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Movement = m_Game.FindAction("Movement", throwIfNotFound: true);
        m_Game_Jump = m_Game.FindAction("Jump", throwIfNotFound: true);
        m_Game_Roll = m_Game.FindAction("Roll", throwIfNotFound: true);
        m_Game_Attack_1 = m_Game.FindAction("Attack_1", throwIfNotFound: true);
        m_Game_Pickup = m_Game.FindAction("Pickup", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Inventory = m_UI.FindAction("Inventory", throwIfNotFound: true);
        m_UI_AbilityMenu = m_UI.FindAction("AbilityMenu", throwIfNotFound: true);
        m_UI_DragAndDrop = m_UI.FindAction("DragAndDrop", throwIfNotFound: true);
        m_UI_ActionsBar_1 = m_UI.FindAction("ActionsBar_1", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Movement;
    private readonly InputAction m_Game_Jump;
    private readonly InputAction m_Game_Roll;
    private readonly InputAction m_Game_Attack_1;
    private readonly InputAction m_Game_Pickup;
    public struct GameActions
    {
        private @InputActions m_Wrapper;
        public GameActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Game_Movement;
        public InputAction @Jump => m_Wrapper.m_Game_Jump;
        public InputAction @Roll => m_Wrapper.m_Game_Roll;
        public InputAction @Attack_1 => m_Wrapper.m_Game_Attack_1;
        public InputAction @Pickup => m_Wrapper.m_Game_Pickup;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Roll.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRoll;
                @Attack_1.started -= m_Wrapper.m_GameActionsCallbackInterface.OnAttack_1;
                @Attack_1.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnAttack_1;
                @Attack_1.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnAttack_1;
                @Pickup.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPickup;
                @Pickup.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPickup;
                @Pickup.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPickup;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Attack_1.started += instance.OnAttack_1;
                @Attack_1.performed += instance.OnAttack_1;
                @Attack_1.canceled += instance.OnAttack_1;
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
            }
        }
    }
    public GameActions @Game => new GameActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Inventory;
    private readonly InputAction m_UI_AbilityMenu;
    private readonly InputAction m_UI_DragAndDrop;
    private readonly InputAction m_UI_ActionsBar_1;
    public struct UIActions
    {
        private @InputActions m_Wrapper;
        public UIActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Inventory => m_Wrapper.m_UI_Inventory;
        public InputAction @AbilityMenu => m_Wrapper.m_UI_AbilityMenu;
        public InputAction @DragAndDrop => m_Wrapper.m_UI_DragAndDrop;
        public InputAction @ActionsBar_1 => m_Wrapper.m_UI_ActionsBar_1;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Inventory.started -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @AbilityMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnAbilityMenu;
                @AbilityMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnAbilityMenu;
                @AbilityMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnAbilityMenu;
                @DragAndDrop.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDragAndDrop;
                @DragAndDrop.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDragAndDrop;
                @DragAndDrop.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDragAndDrop;
                @ActionsBar_1.started -= m_Wrapper.m_UIActionsCallbackInterface.OnActionsBar_1;
                @ActionsBar_1.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnActionsBar_1;
                @ActionsBar_1.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnActionsBar_1;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @AbilityMenu.started += instance.OnAbilityMenu;
                @AbilityMenu.performed += instance.OnAbilityMenu;
                @AbilityMenu.canceled += instance.OnAbilityMenu;
                @DragAndDrop.started += instance.OnDragAndDrop;
                @DragAndDrop.performed += instance.OnDragAndDrop;
                @DragAndDrop.canceled += instance.OnDragAndDrop;
                @ActionsBar_1.started += instance.OnActionsBar_1;
                @ActionsBar_1.performed += instance.OnActionsBar_1;
                @ActionsBar_1.canceled += instance.OnActionsBar_1;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGameActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnAttack_1(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnInventory(InputAction.CallbackContext context);
        void OnAbilityMenu(InputAction.CallbackContext context);
        void OnDragAndDrop(InputAction.CallbackContext context);
        void OnActionsBar_1(InputAction.CallbackContext context);
    }
}
