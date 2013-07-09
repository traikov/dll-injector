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
    /// Values that determine how memory is allocated.
    /// </summary>
    [Flags]
    public enum MemoryAllocationType
    {
        /// <summary>
        /// Allocates physical storage in memory or in the paging file on disk for the specified reserved memory pages. The function initializes the memory to zero. 
        ///
        ///To reserve and commit pages in one step, call VirtualAllocEx with MEM_COMMIT | MEM_RESERVE.
        ///
        ///The function fails if you attempt to commit a page that has not been reserved. The resulting error code is ERROR_INVALID_ADDRESS.
        ///
        ///An attempt to commit a page that is already committed does not cause the function to fail. This means that you can commit pages without first determining the current commitment state of each page.
        /// </summary>
        MEM_COMMIT = 0x00001000,

        /// <summary>
        /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk.
        ///
        ///You commit reserved pages by calling VirtualAllocEx again with MEM_COMMIT.
        /// </summary>
        MEM_RESERVE = 0x00002000,

        /// <summary>
        /// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest. The pages should not be read from or written to the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other value.
        ///
        ///Using this value does not guarantee that the range operated on with MEM_RESET will contain zeroes. If you want the range to contain zeroes, decommit the memory and then recommit it.
        /// </summary>
        MEM_RESET = 0x00080000,

        /// <summary>
        /// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.
        ///
        ///This value must be used with MEM_RESERVE and no other values.
        /// </summary>
        MEM_PHYSICAL = 0x00400000,

        /// <summary>
        /// Allocates memory at the highest possible address. 
        /// </summary>
        MEM_TOP_DOWN = 0x00100000,
    }
}
