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

        public static string NullOrValid(this string x) => x.ToMaybe().Where(s => !string.IsNullOrEmpty(s)).Unwrap();

        public static Result ToInverseResult<T>(this Maybe<T> maybe, string error) => Result.Create(maybe.HasNoValue, error);
        public static bool EqualsIgnoreCase(this string text, Maybe<string> value)
            => value.Select(v => v.Equals(text, StringComparison.CurrentCultureIgnoreCase)).Unwrap();
    }
}
