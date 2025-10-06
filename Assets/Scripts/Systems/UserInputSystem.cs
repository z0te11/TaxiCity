using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputSystem : MonoBehaviour
{
    private InputAction _usePauseAction;
    private InputAction _moveAction;
    private InputAction _stageNextAction;
    private InputAction _stagePrevAction;
    private InputAction _mainAbilityAction;
    public static Vector2 moveInput;
    public static float stageNextInput;
    public static float stagePrevInput;
    public static float mainAbilityInput;
    public static float mainAssistAbilityInput;
    public static bool usePauseInput;

    private void OnEnable()
    {
        SetJostickAction();
        SetMainAbilityAction();
        SetPauseButton();
        SetStageNextAction();
        SetStagePrevAction();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _mainAbilityAction.Disable();
        _usePauseAction.Disable();
        _stageNextAction.Disable();
        _stagePrevAction.Disable();
    }

    private void SetJostickAction()
    {
        _moveAction = new InputAction("move", binding: "<Gamepad>/rightStick");
        _moveAction.AddCompositeBinding("Dpad")
        .With("Up", "<Keyboard>/w")
        .With("Down", "<Keyboard>/s")
        .With("Left", "<Keyboard>/a")
        .With("Right", "<Keyboard>/d");

        _moveAction.performed += context => { moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => { moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => { moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();
    }

    private void SetStageNextAction()
    {
        _stageNextAction = new InputAction("NextStage");
        _stageNextAction.AddBinding("<Keyboard>/e");
        _stageNextAction.performed += context => { stageNextInput = context.ReadValue<float>(); };
        _stageNextAction.Enable();
    }

    private void SetStagePrevAction()
    {
        _stagePrevAction = new InputAction("PrevStage");
        _stagePrevAction.AddBinding("<Keyboard>/q");
        _stagePrevAction.performed += context => { stagePrevInput = context.ReadValue<float>(); };
        _stagePrevAction.Enable();
    }

    private void SetMainAbilityAction()
    {
        _mainAbilityAction = new InputAction("mainAbility", binding: "<Mouse>/leftButton");

        _mainAbilityAction.performed += context => { mainAbilityInput = context.ReadValue<float>(); };
        _mainAbilityAction.started += context => { mainAbilityInput = context.ReadValue<float>(); };
        _mainAbilityAction.canceled += context => { mainAbilityInput = context.ReadValue<float>(); };
        _mainAbilityAction.Enable();
    }

    private void SetPauseButton()
    {
        _usePauseAction = new InputAction("pauseButton", binding: "<Keyboard>/Escape");
        _usePauseAction.Enable();
    }

}
