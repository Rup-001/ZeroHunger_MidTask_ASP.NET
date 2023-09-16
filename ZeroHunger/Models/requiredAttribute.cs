using System;

namespace ZeroHunger.Models
{
    internal class requiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}