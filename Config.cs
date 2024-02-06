using Exiled.API.Interfaces;

namespace PluginTemplate
{
    /// <summary>
    /// 플러그인의 설정을 저장합니다. - Exiled/Config 폴더에 [포트 번호]-config.yml로 저장됩니다.
    /// </summary>
    public class Config : IConfig
    {
        /// <summary>
        /// 플러그인이 켜질지, 꺼질지를 결정합니다.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// 디버그 모드를 켤지 결정합니다. - 디버그 모드를 켜면 콘솔에 더욱 자세한 로그가 출력됩니다.
        /// </summary>
        public bool Debug { get; set; } = false;
    }
}