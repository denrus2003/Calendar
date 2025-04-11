using System;

namespace CalendarLibrary
{
    public class EncryptionSettings
    {
        public bool EncryptionEnabled { get; set; } = false;
        public string EncryptionPassword { get; set; } = string.Empty;
    }
}
