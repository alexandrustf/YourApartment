using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Domain
{
    public static class ApartmentEnums
    {
        public enum PartitioningType : ushort
        {
            UnSpecified = 0,
            Decomandat = 1,
            Semidecomandat = 2,
            Nedecomandat = 3,
            Garsoniera = 4,
            CameraCamin = 5,
        }

        public enum PostedBy : ushort
        {
            UnSpecified = 0,
            Agentii = 1,
            Particulari = 2,
            Dezvoltatori = 3
        }

        public enum Building : ushort
        {
            UnSpecified = 0,
            BlocApartament = 1,
            House = 2,
            Comercial= 3,
            Teren = 4
        }

        public enum PostedFor : ushort
        {
            Rent = 0,
            Buy = 1
        }
    }
}
