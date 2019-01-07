using System;
using Seldino.CrossCutting.Utilities;

namespace Seldino.CrossCutting.Enums
{
    [Flags]
    public enum NotificationMessageType : byte
    {
        [LocalizedDescription("Complain", typeof(NotificationEnumMessage))]
        Complain = 0,

        Question = 1,

        Help = 3
    }
}
