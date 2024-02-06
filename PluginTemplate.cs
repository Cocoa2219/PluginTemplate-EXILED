using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using PluginTemplate.Events;

namespace PluginTemplate
{
    /// <summary>
    /// 플러그인의 메인 클래스입니다. - Plugin 클래스를 Config 클래스로 상속받아야 합니다.
    /// </summary>
    public class PluginTemplate : Plugin<Config>
    {
        /// <summary>
        /// 플러그인을 인스턴스화합니다.
        /// </summary>
        public static PluginTemplate Instance { get; private set; }

        /// <summary>
        /// 플러그인의 이름을 설정합니다.
        /// </summary>
        public override string Name { get; } = "PluginTemplate";

        /// <summary>
        /// 플러그인의 저자를 설정합니다.
        /// </summary>
        public override string Author { get; } = "Cocoa";

        /// <summary>
        /// 플러그인의 로드 순위를 설정합니다.
        /// </summary>
        public override PluginPriority Priority { get; } = PluginPriority.Default;

        /// <summary>
        /// 플러그인의 버전을 설정합니다.
        /// </summary>
        public override Version Version { get; } = new Version(1, 0, 0);

        /// <summary>
        /// 플레이어 이벤트를 핸들링할 핸들러입니다.
        /// </summary>
        public PlayerHandler PlayerHandler { get; private set; }

        /// <summary>
        /// 플러그인이 활성화 될 때 실행됩니다.
        /// </summary>
        public override void OnEnabled()
        {
            // 플러그인이 활성화 되었다면 콘솔에 로그를 출력합니다.
            Log.Info($"{Name}이 활성화 되었습니다.");

            // 플러그인의 인스턴스를 설정합니다.
            Instance = this;

            // 플레이어 이벤트 핸들러를 인스턴스화합니다.
            PlayerHandler = new PlayerHandler(this);

            // 이벤트를 등록합니다.
            RegisterEvents();

            base.OnEnabled();
        }

        /// <summary>
        /// 플러그인이 비활성화 될 때 실행됩니다.
        /// </summary>
        public override void OnDisabled()
        {
            Log.Info($"{Name}이 비활성화 되었습니다.");

            // 이벤트를 등록 해제합니다.
            UnregisterEvents();

            // 플레이어 이벤트 핸들러를 해제합니다.
            PlayerHandler = null;

            base.OnDisabled();
        }

        /// <summary>
        /// 이벤트를 등록합니다.
        /// </summary>
        private void RegisterEvents()
        {
            // 예시 :
            // Exiled.Events.Handlers.Player.Died += PlayerHandler.OnDied;
            // Exiled.Events.Handlers.Player.Hurting += PlayerHandler.OnHurting;
            // ...

            Exiled.Events.Handlers.Player.InteractingDoor += PlayerHandler.OnInteractingDoor;
        }

        /// <summary>
        /// 이벤트를 등록 해제합니다.
        /// </summary>
        private void UnregisterEvents()
        {
            // 예시 :
            // Exiled.Events.Handlers.Player.Died -= PlayerHandler.OnDied;
            // Exiled.Events.Handlers.Player.Hurting -= PlayerHandler.OnHurting;
            // ...

            Exiled.Events.Handlers.Player.InteractingDoor -= PlayerHandler.OnInteractingDoor;
        }
    }
}