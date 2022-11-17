using System;
using BaseCode.Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaseCode.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string StartSceneName = "Initial";
        private const string LoadSceneName = "Dev";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(StartSceneName, EnterLoadScene);
        }

        private void EnterLoadScene()
        {
            _stateMachine.Enter<LoadLevelState, string>(LoadSceneName);
        }

        private void RegisterServices()
        {
            //TODO:
            Debug.Log("RegistrationImitation");
        }

        public void Exit()
        {
            //TODO:
        }

        private static IInputService RegistrationInputService()
        {
            throw new SystemException("We dont have an Input service for registration!");
        }
    }
}