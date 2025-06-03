using System;

namespace Microsoft.AspNetCore.Identity.UI
{
    /// <summary>
    /// Stub para evitar error de compilación cuando se genera
    /// [assembly: Microsoft.AspNetCore.Identity.UI.UIFrameworkAttribute("Bootstrap5")]
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class UIFrameworkAttribute : Attribute
    {
        public UIFrameworkAttribute(string value) { }
    }
}