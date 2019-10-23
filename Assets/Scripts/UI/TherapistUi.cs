﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Main class of the therapist Ui. Controls the overall behavior of the UI and is used as an interface betweel the UI and the rest of the game.
*/

public class TherapistUi : MonoBehaviour
{
    [SerializeField]
    private ModifiersManager modifiersManager;

    [SerializeField]
    private GameDirector gameDirector;

    [SerializeField]
    private TherapistPanelController therapistPanelController;

    [SerializeField]
    private MinimizedPanelController minimizedPanelController;

    private GameDirector.GameState currentGameState = GameDirector.GameState.Stopped;

    // When start game event is raised, nofifies the gameDirector.
    public void StartGame()
    {
        gameDirector.StartGame();
    }

    // When stop game event is raised, nofifies the gameDirector.
    public void StopGame()
    {
        gameDirector.StopGame();
    }

    // When pause game event is raised, nofifies the gameDirector.
    public void PauseGame()
    {
        gameDirector.PauseUnpauseGame();
    }

    // If game state updated event is raised (by the gameDirector), updates the UI accordingly.
    public void OnGameDirectorStateUpdate(GameDirector.GameState newState)
    {
        switch(newState)
        {
            case GameDirector.GameState.Stopped:
                GameStopped();
                break;
            case GameDirector.GameState.Playing:
                if(currentGameState == GameDirector.GameState.Paused)
                {
                    GamePaused(false);
                }
                else
                {
                    GameStarted();
                }
                break;
            case GameDirector.GameState.Paused:
                GamePaused();
                break;
        }
        currentGameState = newState;
    }

    // When game data updated event is raised, notifies the gameDirector and updates the UI.
    public void UpdateGameDatas(Dictionary<string, object> data)
    {
        foreach(KeyValuePair<string, object> entry in data)
        {
            switch(entry.Key)
            {
                case "runTime":
                    gameDirector.SetGameDuration(float.Parse((string)entry.Value) * 60f);
                    break;
            }
        }
        minimizedPanelController.UpdateDisplayedInfos(data);
    }

    // When the game modifier updated event is raised, notifies the modifiersManager.
    public void SetGameModifier(Dictionary<string, object> data)
    {
        foreach(KeyValuePair<string, object> entry in data)
        {
            switch(entry.Key)
            {
                case "mirror":
                    modifiersManager.SetMirrorEffect(bool.Parse((string)entry.Value));
                    break;
                case "hand":
                    break;
                case "dual":
                    modifiersManager.SetDualTask(bool.Parse((string)entry.Value));
                    break;
                case "eye":
                    ModifiersManager.EyePatch value = ModifiersManager.EyePatch.None;
                    switch(entry.Value)
                    {
                        case "left":
                            value = ModifiersManager.EyePatch.Left;
                            break;
                        case "none":
                            value = ModifiersManager.EyePatch.None;
                            break;
                        case "right":
                            value = ModifiersManager.EyePatch.Right;
                            break;
                    }
                    modifiersManager.SetEyePatch(value);
                    break;
                case "prism":
                    modifiersManager.SetPrismEffect(float.Parse((string)entry.Value));
                    break;
                case "speed":
                    gameDirector.SetDifficulty((string)entry.Value);
                    break;
            }
        }
    }

    // When the game time updated event is raised (by the game director), updates the UI.
    public void GameTimeUpdate(float time)
    {
        therapistPanelController.GameTimeUpdate(time);
        minimizedPanelController.GameTimeUpdate(time);
    }

    // When the game started event is raised (by the game director), updates the UI.
    private void GameStarted()
    {
        therapistPanelController.GameStart();
        minimizedPanelController.GameStart();
    }

    // When the game stopped event is raised (by the game director), updates the UI.
    private void GameStopped()
    {
        therapistPanelController.GameStop();
        minimizedPanelController.GameStop();
    }

    // When the game paused event is raised (by the game director), updates the UI.
    private void GamePaused(bool pause = true)
    {
        therapistPanelController.GamePause(pause);
        minimizedPanelController.GamePause(pause);
    }
}