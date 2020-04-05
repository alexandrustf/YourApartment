using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using CSharpFunctionalExtensions;
using EnsureThat;

namespace YourApartment.Domain
{
    public class Location : Entity
    {
        private Location()
        {

        }
        public Location(string name, PreciseLocation adressLocation)
        {
            Name = name;
            AdressLocation = adressLocation;
        }
        public static Result<Location> Create(string name, PreciseLocation preciseLocation)
        {
            EnsureArg.IsNotEmpty(name);
            EnsureArg.IsNotNull(preciseLocation);

            return Result.Success<Location>(new Location(name, preciseLocation)); //TODO MAY BE REFACTORED TO RETURN ERROR RESULT
        }

        public string Name { get; private set; }
        public PreciseLocation AdressLocation { get; private set; }
    }
}