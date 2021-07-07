using System;
using MyJsonTool;
using LOR_GameServer.Server;
using LOR_GameServer.SharedData;

namespace LOR_GameServer.Core
{
    // Token: 0x02000014 RID: 20
    internal class PlayerMessage
    {
        /// <summary>
        /// 处理玩家发过来的指令信息
        /// </summary>
        /// <param name="msg">指令</param>
        /// <param name="server">处理的服务器</param>
        public static void Execute(ClientMessageCarrior msg, GameServer server)
        {
            try
            {
                string id = msg.id;
                //解析为GameMessage
                int stateCode = msg.Msg.ToObject<GameMessage>().stateCode;
                if (stateCode == 102)
                {
                    server.Quit(id);
                }
                //判断stateCode
                if (stateCode == 5)
                {
                    //解析为DmgMessage
                    DmgMessage dmgMessage = msg.Msg.ToObject<DmgMessage>();
                    server._players[dmgMessage.ID].user.Dmg += dmgMessage.dmg;
                    server.DispatchMsg(msg.Msg, "", dmgMessage.ID);
                }
            }
            catch
            {
            }
        }
    }
}
