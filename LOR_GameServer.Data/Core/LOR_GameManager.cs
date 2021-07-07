using LOR_GameServer.Client;
using LOR_GameServer.debug;
using LOR_GameServer.SharedData;
using MyJsonTool;
using System;
using System.Collections.Generic;

namespace LOR_GameServer.Core
{
    /// <summary>
    /// 客户端主逻辑
    /// </summary>
    public class LOR_GameManager
    {
        // Token: 0x06000058 RID: 88 RVA: 0x00002348 File Offset: 0x00000548
        public void Start()
        {
            zhujue.client = new RoomClientSimulator(new DemoTcpClient(), MyId);
            zhujue.client.Connect();
        }

        // Token: 0x06000059 RID: 89 RVA: 0x00002FA0 File Offset: 0x000011A0
        public void AddPlayer(GamePlayer user)
        {
            if (_gamers.ContainsKey(user.id))
            {
                return;
            }
            if (user.id == MyId)
            {
                zhujue.id = user.id;
                _gamers.Add(user.id, zhujue);
                return;
            }
            Gamer value = new Gamer
            {
                id = user.id,
                Dmg = user.Dmg,
                Play_Over_time = user.Play_Over_time
            };
            _gamers.Add(user.id, value);
        }

        // Token: 0x0600005A RID: 90 RVA: 0x00002375 File Offset: 0x00000575
        public void Quit()
        {
            zhujue.client.Quit();
        }

        /// <summary>
        /// 处理服务器发过来的指令信息
        /// </summary>
        /// <param name="basemsg">消息</param>
        public void OnRecieveMsg(string basemsg)
        {
            try
            {
                lock (basemsg)
                {
                    if (basemsg != null)
                    {
                        //解析为GameMessage并判断stateCode
                        switch (basemsg.ToObject<GameMessage>().stateCode)
                        {
                            case 1:
                                {
                                    //解析为相应Message并处理逻辑
                                    GamePlayer player = basemsg.ToObject<GamePlayerMessage>().player;
                                    Debug.LogandWrite("有玩家加入, id=" + player.id);
                                    AddPlayer(player);
                                    break;
                                }
                            case 2:
                                {
                                    //解析为相应Message并处理逻辑
                                    GamePlayer player2 = basemsg.ToObject<GamePlayerMessage>().player;
                                    if (player2 != null)
                                    {
                                        string id = player2.id;
                                        if (_gamers.ContainsKey(id))
                                        {
                                            Gamer gamer = _gamers[id];
                                        }
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    //解析为相应Message并处理逻辑
                                    GamePlayer player3 = basemsg.ToObject<GamePlayerMessage>().player;
                                    string id2 = player3.id;
                                    Debug.LogandWrite("有玩家退出, id=" + player3.id);
                                    if (_gamers.ContainsKey(id2))
                                    {
                                        Gamer gamer2 = _gamers[id2];
                                        _gamers.Remove(id2);
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    //解析为相应Message并处理逻辑
                                    DmgMessage dmgMessage = basemsg.ToObject<DmgMessage>();
                                    _gamers[dmgMessage.ID].Dmg += dmgMessage.dmg;
                                    Debug.LogandWrite(string.Concat(new object[]
                                    {
                                dmgMessage.ID,
                                "造成了",
                                dmgMessage.dmg,
                                "点伤害，总伤害为",
                                _gamers[dmgMessage.ID].Dmg
                                    }));
                                    break;
                                }
                            case 7:
                                {
                                    //解析为相应Message并处理逻辑
                                    Debug.LogandWrite("同步信息...");
                                    SyncMessage syncMessage = basemsg.ToObject<SyncMessage>();
                                    if (syncMessage.players != null)
                                    {
                                        foreach (GamePlayer user in syncMessage.players)
                                        {
                                            AddPlayer(user);
                                        }
                                    }
                                    Total_time = syncMessage.time;
                                    break;
                                }
                            case 8:
                                {
                                    //解析为相应Message并处理逻辑
                                    TimeMessage timeMessage = basemsg.ToObject<TimeMessage>();
                                    Total_time = timeMessage.Total_time;
                                    foreach (Gamer gamer3 in _gamers.Values)
                                    {
                                        gamer3.Play_Over_time += timeMessage.Over_time;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Error(ex.Message + "\n" + ex.StackTrace);
            }
        }

        // Token: 0x04000040 RID: 64
        public static string MyId;

        // Token: 0x04000041 RID: 65
        public static string ServerEndpoint;

        // Token: 0x04000042 RID: 66
        public Gamer zhujue = new Gamer();

        // Token: 0x04000043 RID: 67
        public Dictionary<string, Gamer> _gamers = new Dictionary<string, Gamer>();

        // Token: 0x04000044 RID: 68
        public int Total_time;
    }
}
