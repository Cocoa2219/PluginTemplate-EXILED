using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace PluginTemplate.Events
{
    public class PlayerHandler
    {
        /// <summary>
        /// 플러그인의 인스턴스를 가져옵니다.
        /// </summary>
        private readonly PluginTemplate _plugin;

        public PlayerHandler(PluginTemplate plugin) => _plugin = plugin;

        /// <summary>
        /// 문과 상호작용 시 실행됩니다.
        /// </summary>
        /// <param name="ev">상호작용에 대한 정보 (플레이어, 문 등...)를 담고 있습니다.</param>
        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            // 문과 상호작용한 플레이어의 이름을 모두에게 브로드캐스트합니다.
            Map.Broadcast(5, $"{ev.Player.Nickname}님이 문과 상호작용했습니다.");
        }
    }
}