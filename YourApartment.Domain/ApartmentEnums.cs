using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Domain
{
    public static class ApartmentEnums
    {
        public enum PartitioningType : ushort
        {
            Decomandat = 0,
            Semidecomandat = 1,
            Nedecomandat = 2,
            Garsoniera = 3,
            CameraCamin = 4
        }

        public enum PostedBy : ushort
        {
            Agentii = 0,
            Particulari = 1,
            Dezvoltatori = 2
        }

        public enum Building : ushort
        {
            BlocApartament = 0,
            House = 1,
            Comercial= 2,
            Teren = 3
        }

        public enum PostedFor : ushort
        {
            Rent = 0,
            Buy = 1
        }
    }
}
