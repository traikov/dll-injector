// Dll Injector
// Copyright (C) 2013 Filip Traikov
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

namespace DllInjector.Win32
{
    /// <summary>
    /// Values that determine how a block of memory is protected.
    /// </summary>
    [Flags]
    public enum MemoryProtectionType : uint
    {
        /// <summary>
        /// Enables execute access to the committed region of pages. An attempt to read or write to the committed region results in an access violation. 
        /// </summary>
        PAGE_EXECUTE = 0x10,
        /// <summary>
        /// Enables execute and read access to the committed region of pages. An attempt to write to the committed region results in an access violation. 
        /// </summary>
        PAGE_EXECUTE_READ = 0x20,
        /// <summary>
        /// Enables execute, read, and write access to the committed region of pages. 
        /// </summary>
        PAGE_EXECUTE_READWRITE = 0x40,
        /// <summary>
        /// Enables execute, read, and write access to the committed region of image file code pages. The pages are shared read-on-write and copy-on-write. 
        /// </summary>
        PAGE_EXECUTE_WRITECOPY = 0x80,

        /// <summary>
        /// Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation exception, called a general protection (GP) fault. 
        /// </summary>
        PAGE_NOACCESS = 0x01,
        /// <summary>
        /// Enables read access to the committed region of pages. An attempt to write to the committed region results in an access violation. If the system differentiates between read-only access and execute access, an attempt to execute code in the committed region results in an access violation.
        /// </summary>
        PAGE_READONLY = 0x02,
        /// <summary>
        /// Enables both read and write access to the committed region of pages.
        /// </summary>
        PAGE_READWRITE = 0x04,
        /// <summary>
        /// Gives copy-on-write protection to the committed region of pages. 
        /// </summary>
        PAGE_WRITECOPY = 0x08,

        /// <summary>
        ///Pages in the region become guard pages. Any attempt to access a guard page causes the system to raise a STATUS_GUARD_PAGE_VIOLATION exception and turn off the guard page status. Guard pages thus act as a one-time access alarm. For more information, see Creating Guard Pages.
        ///
        ///When an access attempt leads the system to turn off guard page status, the underlying page protection takes over.
        ///
        ///If a guard page exception occurs during a system service, the service typically returns a failure status indicator.
        ///
        ///This value cannot be used with PAGE_NOACCESS.
        /// </summary>
        PAGE_GUARD = 0x100,
        /// <summary>
        /// Does not allow caching of the committed regions of pages in the CPU cache. The hardware attributes for the physical memory should be specified as "no cache." This is not recommended for general usage. It is useful for device drivers, for example, mapping a video frame buffer with no caching.
        ///
        ///This value cannot be used with PAGE_NOACCESS.
        /// </summary>
        PAGE_NOCACHE = 0x200,
        /// <summary>
        /// Enables write-combined memory accesses. When enabled, the processor caches memory write requests to optimize performance. Thus, if two requests are made to write to the same memory address, only the more recent write may occur.
        ///
        ///Note that the PAGE_GUARD and PAGE_NOCACHE flags cannot be specified with PAGE_WRITECOMBINE. If an attempt is made to do so, the SYSTEM_INVALID_PAGE_PROTECTION NT error code is returned by the function.
        /// </summary>
        PAGE_WRITECOMBINE = 0x400,
    }
}
