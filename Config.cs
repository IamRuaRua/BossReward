using Newtonsoft.Json;
using System.IO;
using TShockAPI;

namespace BossReward
{
    public class Config
    {
        //路径
        public static string ConfigPath = $"{TShock.SavePath}/BossReward.json";
        public int 史莱姆王;
        public int 克苏鲁之眼;
        public int 克苏鲁之脑;
        public int 世界吞噬者;
        public int 骷髅王;
        public int 鹿角怪;

        public int 肉山;
        public int 史莱姆女王;
        public int 双子魔眼;
        public int 机械骷髅王;
        public int 机械虫子;
        public int 猪鲨;
        public int 光之女皇;

        public int 世纪之花;
        public int 石巨人;

        public int 邪恶教徒;
        public int 星尘柱;
        public int 日曜柱;
        public int 星云柱;
        public int 旋涡柱;
        public int 月球领主;
        public int 蜂后;
        /// <summary>
        /// 确认配置文件存在，不存在则创建并填入默认值
        /// </summary>
        public static void EnsureFile()
        {
            if (!File.Exists(ConfigPath))
            {
                File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(new Config(160,200, 220, 240, 260, 220, 320, 360, 380, 420, 440, 420, 500, 500, 500, 500, 500, 500, 500,500,500,280)));
         
            }
        }
        public static Config ReadConfig()
        {
            //读取ConfigFile
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigPath));
        }
        public Config(int num1,int num2, int num3, int num4, int num5, int num6, int num7, int num8, int num9, int num10, int num11, int num12, int num13, int num14, int num15, int num16, int num17, int num18, int num19, int num20, int num21, int num22)
        {
            史莱姆王 = num1;   //50
            克苏鲁之眼 = num2; //4
            克苏鲁之脑 = num3; //266
            世界吞噬者 = num4; //13
            骷髅王 = num5;     //35
            鹿角怪 = num6;     //668
            肉山 = num7;       //113
            史莱姆女王 = num8; //657
            双子魔眼 = num9;   //125//126
            机械骷髅王 = num10;//127
            机械虫子 = num11;  //134
            猪鲨 = num12;      //370
            光之女皇 = num13;  //636
            世纪之花 = num14;  //262
            石巨人 = num15;   //245
            邪恶教徒 = num16;//440
            星尘柱 = num17;//493
            日曜柱 = num18;//517
            星云柱 = num19;//507
            旋涡柱 = num20;//422
            月球领主 = num21;//398
            蜂后 = num22; //222
        }
    }
}
