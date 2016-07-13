﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatClient1
{
    class PacketHandler
    {
        static MainForm MainFormRef;


        public static void Init(MainForm form)
        {
            MainFormRef = form;
        }

        public static void Process(PacketData packet)
        {
            var packetType = (PACKET_ID)packet.PacketID;
            
            switch (packetType)
            {
                case PACKET_ID.SYSTEM_CLIENT_DISCONNECTD:
                    MainFormRef.SetDisconnectd();
                    break;

                case PACKET_ID.LOGIN_IN_RES:
                    {
                        var errorCode = BitConverter.ToInt16(packet.BodyData, 0);

                        if (errorCode == (Int16)ERROR_CODE.NONE)
                        {
                            MainFormRef.SetClientStatus(CLIENT_STATUS.LOGIN);
                            DevLog.Write(string.Format("로그인 성공"), LOG_LEVEL.INFO);
                        }
                        else
                        {
                            DevLog.Write(string.Format("로그인 실패:{0}", errorCode.ToString()), LOG_LEVEL.ERROR);
                        }
                    }
                    break;
                //case PACKET_ID.RESPONSE_LOGIN:
                //    {
                //        var resData = JsonEnDecode.Decode<JsonPacketResponseLogin>(packet.JsonFormatData);
                //        var errorCode = (ERROR_CODE)resData.Result;

                //        if (errorCode == ERROR_CODE.NONE)
                //        {
                //            MainFormRef.SetClientStatus(CLIENT_STATUS.LOGIN);
                //            DevLog.Write(string.Format("로그인 성공"), LOG_LEVEL.INFO);
                //        }
                //        else
                //        {
                //            DevLog.Write(string.Format("로그인 실패:{0}", errorCode.ToString()), LOG_LEVEL.ERROR);
                //        }
                //    }
                //    break;

                //case PACKET_ID.RESPONSE_ENTER_LOBBY:
                //    {
                //        var resData = JsonEnDecode.Decode<JsonPacketResponseEnterLobby>(packet.JsonFormatData);

                //        var errorCode = (ERROR_CODE)resData.Result;

                //        if (errorCode == ERROR_CODE.NONE)
                //        {
                //            MainFormRef.SetClientStatus(CLIENT_STATUS.LOBBY);
                //            DevLog.Write(string.Format("로비 입장 성공"), LOG_LEVEL.INFO);
                //        }
                //        else
                //        {
                //            DevLog.Write(string.Format("로비 입장 실패:{0}", errorCode.ToString()), LOG_LEVEL.ERROR);
                //        }
                //    }
                //    break;

                //case PACKET_ID.RESPONSE_LEAVE_LOBBY:
                //    {
                //        var resData = JsonEnDecode.Decode<JsonPacketResponseLeaveLobby>(packet.JsonFormatData);

                //        var errorCode = (ERROR_CODE)resData.Result;

                //        if (errorCode == ERROR_CODE.NONE)
                //        {
                //            MainFormRef.SetClientStatus(CLIENT_STATUS.LOGIN);
                //            DevLog.Write(string.Format("로비 나가기 성공"), LOG_LEVEL.INFO);
                //        }
                //        else
                //        {
                //            DevLog.Write(string.Format("로비 나가기 실패:{0}", errorCode.ToString()), LOG_LEVEL.ERROR);
                //        }
                //    }
                //    break;

                //case PACKET_ID.NOTICE_CHAT:
                //    {
                //        var resData = JsonEnDecode.Decode<JsonPacketNoticeChat>(packet.JsonFormatData);

                //        MainFormRef.ChatToUI(resData.UserID, resData.Chat);
                //    }
                //    break;
                default:
                    break;
            }
        }
    }

    
}
