using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Domain
{
    public static class ApartmentEnums
    {
        enum Type : ushort
        {
            Decomandat = 0,
            Semidecomandat = 1,
            Nedecomandat = 2,
            Garsoniera = 3,
            CameraCamin = 4
        }

        enum PostedBy : ushort
        {
            Agentii = 0,
            Particulari = 1,
            Dezvoltatori = 2
        }
    }
}
