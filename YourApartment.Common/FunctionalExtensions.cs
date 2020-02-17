using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YourApartment.Common
{
    public static class FunctionalExtensions
    {
        public static async Task<Maybe<T>> ToMaybe<T>(this Task<T> task) => await task;

        public static Maybe<T> ToMaybe<T>(this T subject) => subject;

    }
}
