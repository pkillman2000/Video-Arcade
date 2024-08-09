//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/2.5 Platformer/Input Actions/Input Actions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Platformer
{
    public partial class @InputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input Actions"",
    ""maps"": [
        {
            ""name"": ""Land"",
            ""id"": ""f4c63f88-c675-49cb-8f93-d7d49b2962d0"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""60d5e6fb-0626-4bef-a3fd-91f4fe24d976"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""7455389d-d05f-4181-a7e1-181a68d7e02b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Climb"",
                    ""type"": ""Button"",
                    ""id"": ""8834b03f-8e22-4114-9151-193b618dd3a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""1150074b-7741-40c1-925b-a5f5e15fc9b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""9628a8a9-62e2-403e-80f4-4d0a68653395"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0f7e0b7c-87b1-4bdc-842c-5b82c2168115"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbff9eb7-8859-4c8c-a6ca-fd0137b14e43"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""A/D"",
                    ""id"": ""3f9e641c-f5b8-4ba4-aef9-aa3edc2451f1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""de9f06ef-af50-4dd8-ac51-a5c05a059930"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ab3df0ad-45ba-458d-b3ec-0245de7a7ae0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""L/R Cursor"",
                    ""id"": ""5c6a986f-086d-48a9-96f4-78db5dbeaaf9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f1817328-459d-4958-a3b4-a83eb888fbc8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""024f9561-01b4-4706-a1ff-5095915affec"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Stick [Gamepad]"",
                    ""id"": ""f35e113e-589d-4624-ad8a-7e062f63b297"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c2ef13ca-4d79-4666-8dcb-258dfcfdbfe2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""806d7f5e-5511-441b-b45c-e0eed53a810d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""W/S"",
                    ""id"": ""b74db9e0-ebdb-4854-b86c-4b64745aadff"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3d5d67a0-dd80-42b4-9eff-a6b9dadfc0dd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""db82390d-1ffd-4ce4-b3a6-09c5051db44b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""U/D Cursor"",
                    ""id"": ""403d3209-fdd3-4e29-a083-e5be0e5168bd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f9cfea8e-602e-4833-8054-7c79f9093477"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9ff057cd-6951-46b8-b96e-d50be3258ef5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""ec49ed72-aca5-4d01-aade-6ee51df49d44"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2bf9b61e-b060-4e93-9004-aad219d956a3"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6414031f-347a-4516-a966-1880779cf96d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d617c855-f032-4e01-a6c7-dacb9e928ceb"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83051b25-18d6-4397-92a3-5ee6f95af129"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52271131-a345-43ae-b464-f33d54d2326c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10f5b0b2-32a5-4ea2-846f-42af50f60354"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Air"",
            ""id"": ""64702de6-332f-4c59-b7af-c4d63499ed02"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""78df6bff-6f68-42ed-96f9-e01657dbc6d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7a7c6463-4d98-4482-92c0-dde15152ff0f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Water"",
            ""id"": ""ab739f2b-1c1e-4cbd-bbd6-53904be91338"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""e5713920-1527-4a34-8603-9aaedda3720d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a110bc9d-df97-4491-92ac-e42c2dc140d8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Land
            m_Land = asset.FindActionMap("Land", throwIfNotFound: true);
            m_Land_Jump = m_Land.FindAction("Jump", throwIfNotFound: true);
            m_Land_Walk = m_Land.FindAction("Walk", throwIfNotFound: true);
            m_Land_Climb = m_Land.FindAction("Climb", throwIfNotFound: true);
            m_Land_Run = m_Land.FindAction("Run", throwIfNotFound: true);
            m_Land_Fire = m_Land.FindAction("Fire", throwIfNotFound: true);
            // Air
            m_Air = asset.FindActionMap("Air", throwIfNotFound: true);
            m_Air_Newaction = m_Air.FindAction("New action", throwIfNotFound: true);
            // Water
            m_Water = asset.FindActionMap("Water", throwIfNotFound: true);
            m_Water_Newaction = m_Water.FindAction("New action", throwIfNotFound: true);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Land
        private readonly InputActionMap m_Land;
        private List<ILandActions> m_LandActionsCallbackInterfaces = new List<ILandActions>();
        private readonly InputAction m_Land_Jump;
        private readonly InputAction m_Land_Walk;
        private readonly InputAction m_Land_Climb;
        private readonly InputAction m_Land_Run;
        private readonly InputAction m_Land_Fire;
        public struct LandActions
        {
            private @InputActions m_Wrapper;
            public LandActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_Land_Jump;
            public InputAction @Walk => m_Wrapper.m_Land_Walk;
            public InputAction @Climb => m_Wrapper.m_Land_Climb;
            public InputAction @Run => m_Wrapper.m_Land_Run;
            public InputAction @Fire => m_Wrapper.m_Land_Fire;
            public InputActionMap Get() { return m_Wrapper.m_Land; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LandActions set) { return set.Get(); }
            public void AddCallbacks(ILandActions instance)
            {
                if (instance == null || m_Wrapper.m_LandActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_LandActionsCallbackInterfaces.Add(instance);
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Climb.started += instance.OnClimb;
                @Climb.performed += instance.OnClimb;
                @Climb.canceled += instance.OnClimb;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }

            private void UnregisterCallbacks(ILandActions instance)
            {
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Walk.started -= instance.OnWalk;
                @Walk.performed -= instance.OnWalk;
                @Walk.canceled -= instance.OnWalk;
                @Climb.started -= instance.OnClimb;
                @Climb.performed -= instance.OnClimb;
                @Climb.canceled -= instance.OnClimb;
                @Run.started -= instance.OnRun;
                @Run.performed -= instance.OnRun;
                @Run.canceled -= instance.OnRun;
                @Fire.started -= instance.OnFire;
                @Fire.performed -= instance.OnFire;
                @Fire.canceled -= instance.OnFire;
            }

            public void RemoveCallbacks(ILandActions instance)
            {
                if (m_Wrapper.m_LandActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ILandActions instance)
            {
                foreach (var item in m_Wrapper.m_LandActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_LandActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public LandActions @Land => new LandActions(this);

        // Air
        private readonly InputActionMap m_Air;
        private List<IAirActions> m_AirActionsCallbackInterfaces = new List<IAirActions>();
        private readonly InputAction m_Air_Newaction;
        public struct AirActions
        {
            private @InputActions m_Wrapper;
            public AirActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_Air_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_Air; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(AirActions set) { return set.Get(); }
            public void AddCallbacks(IAirActions instance)
            {
                if (instance == null || m_Wrapper.m_AirActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_AirActionsCallbackInterfaces.Add(instance);
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }

            private void UnregisterCallbacks(IAirActions instance)
            {
                @Newaction.started -= instance.OnNewaction;
                @Newaction.performed -= instance.OnNewaction;
                @Newaction.canceled -= instance.OnNewaction;
            }

            public void RemoveCallbacks(IAirActions instance)
            {
                if (m_Wrapper.m_AirActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IAirActions instance)
            {
                foreach (var item in m_Wrapper.m_AirActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_AirActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public AirActions @Air => new AirActions(this);

        // Water
        private readonly InputActionMap m_Water;
        private List<IWaterActions> m_WaterActionsCallbackInterfaces = new List<IWaterActions>();
        private readonly InputAction m_Water_Newaction;
        public struct WaterActions
        {
            private @InputActions m_Wrapper;
            public WaterActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_Water_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_Water; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WaterActions set) { return set.Get(); }
            public void AddCallbacks(IWaterActions instance)
            {
                if (instance == null || m_Wrapper.m_WaterActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_WaterActionsCallbackInterfaces.Add(instance);
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }

            private void UnregisterCallbacks(IWaterActions instance)
            {
                @Newaction.started -= instance.OnNewaction;
                @Newaction.performed -= instance.OnNewaction;
                @Newaction.canceled -= instance.OnNewaction;
            }

            public void RemoveCallbacks(IWaterActions instance)
            {
                if (m_Wrapper.m_WaterActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IWaterActions instance)
            {
                foreach (var item in m_Wrapper.m_WaterActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_WaterActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public WaterActions @Water => new WaterActions(this);
        public interface ILandActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnWalk(InputAction.CallbackContext context);
            void OnClimb(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
        }
        public interface IAirActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
        public interface IWaterActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
    }
}
