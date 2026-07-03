using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Gaiden.SFML.System;

public static partial class CSFMLSystem
{
    #region Clock
    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfClock_create();

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfClock_destroy(IntPtr cPointer);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfClock_getElapsedTime(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool sfClock_isRunning(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfClock_start(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfClock_stop(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfClock_restart(IntPtr clock);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfClock_reset(IntPtr clock);
    #endregion
    
    #region Buffer
    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfBuffer_create();

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfBuffer_destroy(IntPtr buffer);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial UIntPtr sfBuffer_getSize(IntPtr buffer);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr sfBuffer_getData(IntPtr buffer);
    #endregion
    
    #region Allocation
    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void sfFree(IntPtr ptr);
    #endregion
    
    #region Time
    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfSeconds(float amount);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfMilliseconds(int amount);

    [LibraryImport(CSFML.System), SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Time sfMicroseconds(long amount);
    #endregion
}