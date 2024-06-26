using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;

using int8_t = System.SByte;
using int16_t = System.Int16;
using int32_t = System.Int32;
using int64_t = System.Int64;

using float32 = System.Single;

using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace DroneCAN
{
    public partial class DroneCAN 
    {
//using uavcan.tunnel.Protocol.cs
        public partial class uavcan_tunnel_Targetted: IDroneCANSerialize 
        {
            public const int UAVCAN_TUNNEL_TARGETTED_MAX_PACK_SIZE = 127;
            public const ulong UAVCAN_TUNNEL_TARGETTED_DT_SIG = 0xB138E7EA72A2A2E9;
            public const int UAVCAN_TUNNEL_TARGETTED_DT_ID = 3001;

            public const double UAVCAN_TUNNEL_TARGETTED_OPTION_LOCK_PORT = 1; // saturated uint4

            public uavcan_tunnel_Protocol protocol = new uavcan_tunnel_Protocol();
            public uint8_t target_node = new uint8_t();
            public int8_t serial_id = new int8_t();
            public uint8_t options = new uint8_t();
            public uint32_t baudrate = new uint32_t();
            public uint8_t buffer_len; [MarshalAs(UnmanagedType.ByValArray,SizeConst=120)] public uint8_t[] buffer = Enumerable.Range(1, 120).Select(i => new uint8_t()).ToArray();

            public void encode(dronecan_serializer_chunk_cb_ptr_t chunk_cb, object ctx, bool fdcan = false)
            {
                encode_uavcan_tunnel_Targetted(this, chunk_cb, ctx, fdcan);
            }

            public void decode(CanardRxTransfer transfer, bool fdcan = false)
            {
                decode_uavcan_tunnel_Targetted(transfer, this, fdcan);
            }

            public static uavcan_tunnel_Targetted ByteArrayToDroneCANMsg(byte[] transfer, int startoffset, bool fdcan = false)
            {
                var ans = new uavcan_tunnel_Targetted();
                ans.decode(new DroneCAN.CanardRxTransfer(transfer.Skip(startoffset).ToArray()), fdcan);
                return ans;
            }
        }
    }
}