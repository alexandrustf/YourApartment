using System;
using EnsureThat;

namespace YourApartment.Business
{
    public class AddToFavoriteCommand
    {
        public Guid ApartmentId { get; set; }

        public string Email { get; set; }

        public AddToFavoriteCommand(Guid apartmentId, string email)
        {
            EnsureArg.IsNotNullOrEmpty(email);
            EnsureArg.IsNotNullOrEmpty(apartmentId.ToString());

            ApartmentId = apartmentId;
            Email = email;
        }
    }
}