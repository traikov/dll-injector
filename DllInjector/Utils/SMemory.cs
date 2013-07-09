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
using DllInjector.Win32;

namespace DllInjector.Memory
{
    public static class SMemory
    {
        /// <summary>
        /// Writes raw bytes to another process' memory.
        /// </summary>
        /// <param name="hProcess">Handle to the external process.</param>
        /// <param name="dwAddress">Address to which bytes will be written.</param>
        /// <param name="lpBuffer">Unmanaged buffer that will be written to process in question.</param>
        /// <param name="nSize">Number of bytes to be written.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool WriteProcessMemory(IntPtr hProcess, IntPtr dwAddress, byte[] lpBuffer, int nSize)
        {
            IntPtr iBytesWritten = IntPtr.Zero;

            if (!Imports.WriteProcessMemory(hProcess, dwAddress, lpBuffer, nSize, out iBytesWritten))
                return false;

            return true;
        }

        /// <summary>
        /// Allocates a block of memory in the target process.
        /// </summary>
        /// <param name="hProcess">Handle to the process in which memory will be allocated.</param>
        /// <param name="nSize">Number of bytes to be allocated.  Default is 0x1000.</param>
        /// <param name="dwAllocationType">The type of memory allocation.  See <see cref="MemoryAllocType"/></param>
        /// <param name="dwProtect">The memory protection for the region of pages to be allocated. If the pages are being committed, you can specify any one of the <see cref="MemoryProtectType"/> constants.</param>
        /// <returns>Returns zero on failure, or the base address of the allocated block of memory on success.</returns>
        public static IntPtr AllocateMemory(IntPtr hProcess, int nSize, MemoryAllocationType dwAllocationType, MemoryProtectionType dwProtect)
        {
            IntPtr allocatedMemory = Imports.VirtualAllocEx(hProcess, 0, nSize, dwAllocationType, dwProtect);
            if (allocatedMemory == IntPtr.Zero)
            {
                throw new NullReferenceException();
            }
            return allocatedMemory;
        }

        /// <summary>
        /// Releases, decommits, or releases and decommits a region of memory within the virtual address space of a specified process.
        /// </summary>
        /// <param name="hProcess">Handle to the process in which memory will be freed.</param>
        /// <param name="dwAddress">A pointer to the starting address of the region of memory to be freed. </param>
        /// <param name="nSize">
        /// The size of the region of memory to free, in bytes. 
        ///
        /// If the dwFreeType parameter is MEM_RELEASE, dwSize must be 0 (zero). The function frees the entire region that is reserved in the initial allocation call to VirtualAllocEx.</param>
        /// <param name="dwFreeType">The type of free operation.  See <see cref="MemoryFreeType"/>.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool FreeMemory(IntPtr hProcess, uint dwAddress, int nSize, MemoryFreeType dwFreeType)
        {
            if (dwFreeType == MemoryFreeType.MEM_RELEASE)
                nSize = 0;

            return Imports.VirtualFreeEx(hProcess, dwAddress, nSize, dwFreeType);
        }

        /// <summary>
        /// Releases, decommits, or releases and decommits a region of memory within the virtual address space of a specified process.
        /// </summary>
        /// <param name="hProcess">Handle to the process in which memory will be freed.</param>
        /// <param name="dwAddress">A pointer to the starting address of the region of memory to be freed. </param>
        /// <returns>Returns true on success, false on failure.</returns>
        /// <remarks>
        /// Uses <see cref="MemoryFreeType.MEM_RELEASE"/> to free the page(s) specified.
        /// </remarks>
        public static bool FreeMemory(IntPtr hProcess, uint dwAddress)
        {
            return FreeMemory(hProcess, dwAddress, 0, MemoryFreeType.MEM_RELEASE);
        }
    }
}