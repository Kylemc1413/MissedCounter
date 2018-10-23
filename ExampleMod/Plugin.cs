﻿using IllusionPlugin;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using System;

namespace ExampleMod
{
    public class Plugin : IPlugin
    {
        public string Name => "MissCounter";
        public string Version => "1.0.0";

        /*
         * MissCounter | By Caeden117
         * This plugin was made for the Example Mod tutorial in the Beat Saber Wiki:
         * https://wiki.assistant.moe/modding/example-mod
         */


        private readonly string[] env = { "DefaultEnvironment", "BigMirrorEnvironment", "TriangleEnvironment", "NiceEnvironment" };
        bool enabled = true;
        public static Vector3 counterPosition = new Vector3(-3.25f, 0.5f, 7f);

        public void OnApplicationStart()
        {
            Console.WriteLine("Hello World!");
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {

        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (!enabled) return;
            if (!env.Contains(arg0.name)) return; //using System.Linq;
            new GameObject("MissedCounter").AddComponent<MissedCounter>();
        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level)
        {

        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }
    }
}
