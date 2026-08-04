using BepInEx;
using System;
using UnityEngine;
using GravityDisabler.Applier;
using GravityDisabler.Loader;
using Utilla;
using Utilla.Attributes;

namespace GravityDisabler.Core
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [ModdedGamemode]
    public class Plugin : BaseUnityPlugin
    {
        private PhysicsDecorator _physicsDecorator;
        private AssetLoader _assetLoader;

        private void Awake()
        {
            _assetLoader = new AssetLoader();
            _physicsDecorator = new PhysicsDecorator(_assetLoader);
        }

        private void Start()
        {
            _physicsDecorator.Initialize();
        }

        [ModdedGamemodeJoin]
        private void RoomJoined(string gamemode)
        {
            _physicsDecorator?.SetAllowedRoom(true);
        }

        [ModdedGamemodeLeave]
        private void RoomLeft(string gamemode)
        {
            _physicsDecorator?.SetAllowedRoom(false);
        }
    }
}
