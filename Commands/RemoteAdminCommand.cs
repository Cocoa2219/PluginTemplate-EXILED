using System;
using CommandSystem;
using Exiled.API.Features;

namespace PluginTemplate.Commands
{
    // RemoteAdminCommandHandler - RA 명령어
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class RemoteAdminCommand : ICommand
    {
        /// <summary>
        /// 명령어가 실행되었을 때 실행됩니다.
        /// </summary>
        /// <param name="arguments">명령어의 인자를 띄어쓰기로 구분해 나타냅니다.</param>
        /// <param name="sender">보낸 플레이어를 의미합니다.</param>
        /// <param name="response">명령어의 응답을 설정합니다.</param>
        /// <returns>명령이 제대로 실행되었으면 true를 반환하시고, 중간에 오류가 있다면 false를 반환하십시오.</returns>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender as CommandSender);

            if (player is null)
            {
                response = "플레이어가 아닙니다.";
                return false;
            }

            if (arguments.Count == 0)
            {
                response = "인자가 부족합니다.";
                return false;
            }

            player.Broadcast(5, arguments.At(0), Broadcast.BroadcastFlags.Normal, true);

            response = "RemoteAdminCommand 실행됨";
            return true;
        }

        /// <summary>
        /// 명령어의 이름입니다.
        /// </summary>
        public string Command => "remoteadmincommand";

        /// <summary>
        /// 명령어의 별칭입니다.
        /// </summary>
        public string[] Aliases { get; } = { "rac" };

        /// <summary>
        /// 명령어의 설명입니다.
        /// </summary>
        public string Description => "RemoteAdminCommand의 설명";
    }
}