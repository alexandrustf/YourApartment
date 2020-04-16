using System;

namespace YourApartment.Domain
{
    public class UserApartment
    {
        private UserApartment()
        {
            
        }
        public UserApartment(User user, Apartment apartment)
        {
            User = user;
            UserId = user.Id;
            Apartment = apartment;
            ApartmentId = apartment.Id;
        }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Apartment Apartment { get; set; }
        public Guid ApartmentId { get; set; }
    }
}