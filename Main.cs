using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI; 
using System.Threading;
using System.Collections;
using Terraria.Localization; 

namespace BossReward
{
    [ApiVersion(2, 1)]
    public class BossReward : TerrariaPlugin
    {
        Config configFile;
        public override string Author => "Rua";
        public override string Description => "多人联机boss击败奖励插件";
        public override string Name => "BossReward";
        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version; public BossReward(Main game) : base(game) { }
        public ArrayList OnlinePlayers = new ArrayList();
  
        public override void Initialize()
        {   
            ServerApi.Hooks.NpcKilled.Register(this, OnNpcKilled); 
            ServerApi.Hooks.ServerJoin.Register(this, OnServerjoin);
            ServerApi.Hooks.ServerLeave.Register(this, OnServerLeave);
            Commands.ChatCommands.Add(new Command(permissions: "ResetLifeValue", cmd: this.Cmd,"rlv"));
            Config.EnsureFile();//读取配置文件
            configFile = Config.ReadConfig(); 

        }

        void OnNpcKilled(NpcKilledEventArgs args)
        {
            int BossID = args.npc.netID;
            for (int i=0; i < OnlinePlayers.Count; i++)
            {
                var player = TSPlayer.FindByNameOrID((string)OnlinePlayers[i])[0];
                if (player != null)
                {
                    FoundPlayer found = Util.GetPlayer(player, player.Name);
                    if (found.valid)
                    {
                        int nowMaxHP = found.plr.TPlayer.statLifeMax;
                        int maxHP = GetPlayerMaxHP(BossID);
                        if (maxHP>nowMaxHP&&maxHP!=0)
                        { 
                            found.plr.TPlayer.statLifeMax = maxHP;
                            NetMessage.SendData((int)PacketTypes.PlayerHp, -1, -1, NetworkText.Empty, found.plr.Index, 0f, 0f, 0f, 0);
                            player.SendInfoMessage($"{found.Name} 的生命上限已修改为 {maxHP}");
                        } 
                    }
                   
                }
            }
        }
        void OnServerjoin(JoinEventArgs args)
        {
            TSPlayer tSPlayer = TShock.Players[args.Who];
            Group group = tSPlayer.Group;
            string playergroup = group.Name;
            string name = tSPlayer.Name; 
            OnlinePlayers.Add(name);
        } 
        void OnServerLeave(LeaveEventArgs args)
        {
            TSPlayer tSPlayer = TShock.Players[args.Who];
            Group group = tSPlayer.Group;
            string playergroup = group.Name;
            string name = tSPlayer.Name;
            OnlinePlayers.Remove(name);
            
        } 
       void Cmd(CommandArgs args)
        {
            var player = args.Player;
            if (player == null) return;  
            FoundPlayer found = Util.GetPlayer(args.Player,player.Name);
            if (!found.valid)
            { 
                return;
            }
            int maxHP = 100;
            found.plr.TPlayer.statLifeMax = maxHP;
            NetMessage.SendData((int)PacketTypes.PlayerHp, -1, -1, NetworkText.Empty, found.plr.Index, 0f, 0f, 0f, 0);
             args.Player.SendSuccessMessage($"{found.Name} 的生命上限已修改为 {maxHP}");
             
         }
        int GetPlayerMaxHP(int BossID)
        {
            switch (BossID)
            {
                case 4:
                    return configFile.克苏鲁之眼;
                case 50:
                    return configFile.史莱姆王;
                case 668:
                    return configFile.鹿角怪;
                case 13:
                    return configFile.世界吞噬者;
                case 266:
                    return configFile.克苏鲁之脑;
                case 35:
                    return configFile.骷髅王;   
                case 134:
                    return configFile.机械虫子;
                case 657:
                    return configFile.史莱姆女王;
                case 398:
                    return configFile.月球领主;
                case 262:
                    return configFile.世纪之花;
                case 222:
                    return configFile.蜂后;
                case 127:
                    return configFile.机械骷髅王;
                case 370:
                    return configFile.猪鲨;
                case 636:
                    return configFile.光之女皇;
                case 245:
                    return configFile.石巨人;
                case 507:
                    return configFile.星云柱;
                case 113:
                    return configFile.肉山;
                case 517:
                    return configFile.日曜柱;
                case 493:
                    return configFile.星尘柱;
                case 422:
                    return configFile.旋涡柱;
                case 440:
                    return configFile.邪恶教徒;
                default:
                    return 0;
            }
        }
     }
         
}
 
